Imports WinSCP
Imports System.Text.RegularExpressions
Imports System.Data.OleDb

Public Class DownloadFile
    Dim sesOptions As SessionOptions
    Dim flPath As String
    Dim destination As String
    Dim dgvRow As DataGridViewRow
    Public status As New _STAT_INFO(False, "", False, False, False)
    Public th As System.Threading.Thread
    Public removeAfterDowload As Boolean = False
    Public runIfDownloaded As MethodInvoker = Sub()
                                              End Sub
    Public imageCOunt As Integer = 0

    Dim folderLogs As String() = {"C:\", "IDCSI", "FTP Auto Downloader", "DDCOS", "Logs (new exe)"}

    Sub New(filePath As String, destFolder As String, sesOption As WinSCP.SessionOptions, dgvRow As DataGridViewRow)
        Me.flPath = filePath
        Me.sesOptions = sesOption
        Me.dgvRow = dgvRow
        Me.destination = destFolder
    End Sub

    Sub startDownload()
        status = New _STAT_INFO(False, "", True, False, False)
        th = New System.Threading.Thread(AddressOf runThread)
        th.Start()
    End Sub
    Function getFormatedDate() As String
        Return Format(Now, "MMM dd,yyyy hh:mm:ss tt")
    End Function
    Function getTabs() As String
        Return Strings.StrDup(4, vbTab)
    End Function

    Sub writeNewLine(path As String, value As String)

        While Publicvalues.fileisOpen
            Application.DoEvents()
        End While
        Publicvalues.fileisOpen = True
        While IsFileInUse(path)
            Application.DoEvents()
        End While
        Dim wr As New IO.StreamWriter(path, True)
        wr.WriteLine(value.Replace(vbLf, "==>").Replace(vbNewLine, "==>"))
        wr.Close()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        Publicvalues.fileisOpen = False
    End Sub

    Public Function IsFileInUse(path As String) As Boolean
        If IO.File.Exists(path) Then
            Try
                Using fs = IO.File.OpenWrite(path)
                    'If stream can write to the file, it suggests the file is not in use.
                    Return Not fs.CanWrite
                End Using
            Catch ex As Exception
                'An exception was raised when trying to create a write stream
                'This suggests the file is in use.
                Return True
            End Try
        Else
            'File does not exists, therefore it is not in use:
            'a file could be written anew to the provided path.
            Return False
        End If
    End Function
    Function getTableFromXls(path As String, tableName As String) As DataTable
        Dim xlCon As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " &
                                                                                "Data Source='" & path & "'; " & "Extended Properties=""Excel 8.0;HDR=NO;IMEX=1"";")
        Dim xlCmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [" & tableName & "];", xlCon)
        xlCmd.TableMappings.Add("Table", "Upload Report")
        Dim dtSet As DataSet = New DataSet
        xlCmd.Fill(dtSet)
        Return dtSet.Tables(0)
    End Function
    Public Function GetExcelSheetNames(ByVal excelFile As String) As [String]()
        Dim objConn As OleDb.OleDbConnection = Nothing
        Dim dt As System.Data.DataTable = Nothing
        Try
            Dim connString As [String] = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & excelFile & ";Extended Properties=Excel 8.0;"
            objConn = New OleDb.OleDbConnection(connString)
            objConn.Open()
            dt = objConn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
            If dt Is Nothing Then Return Nothing
            Dim excelSheets As [String]() = New [String](dt.Rows.Count - 1) {}
            Dim i As Integer = 0
            For Each row As DataRow In dt.Rows
                excelSheets(i) = row("TABLE_NAME").ToString()
                i += 1
            Next
            Return excelSheets
        Catch ex As Exception
            Return Nothing
        Finally
            If objConn IsNot Nothing Then
                objConn.Close()
                objConn.Dispose()
            End If
            If dt IsNot Nothing Then
                dt.Dispose()
            End If
        End Try
    End Function
    Private Sub runThread()
        Dim stopWatch As New Stopwatch
        stopWatch.Start()
        Dim started As Date = Now
        Dim pth As String = ""
        For Each j As String In folderLogs
            If pth = "" Then
                pth = j
            Else
                pth = IO.Path.Combine(pth, j)
                createDirectoryIFnotExist(pth)
            End If
        Next
        Dim folderLogDate As String = WinSCP.RemotePath.GetFileName(WinSCP.RemotePath.GetDirectoryName(Me.flPath))
        Dim fileName As String = WinSCP.RemotePath.GetFileName(Me.flPath)
        Dim logsDirDate As String = IO.Path.Combine(pth, folderLogDate)
        createDirectoryIFnotExist(logsDirDate)
        Dim filesDir As String = IO.Path.Combine(logsDirDate, "Files")
        createDirectoryIFnotExist(filesDir)
        Dim reportsDir As String = IO.Path.Combine(logsDirDate, "Reports")
        createDirectoryIFnotExist(reportsDir)
        Dim logFilePath As String = IO.Path.Combine(logsDirDate, folderLogDate & ".txt")
        Dim fileSize As Long = 0
        Try
            Dim ses As New Session
            AddHandler ses.FileTransferProgress, Sub(sender As Object, e As FileTransferProgressEventArgs)
                                                     dgvRow.Cells(3).Value = String.Concat((e.FileProgress * 100).ToString, "%")
                                                 End Sub
            ses.Open(Me.sesOptions)
            Try
                Dim downloadedFile As String = IO.Path.Combine(Me.destination, IO.Path.GetFileName(Me.flPath))
                If IO.File.Exists(downloadedFile) Then
                    Throw New Exception("Already downloaded")
                End If
                Dim transferOpt As New WinSCP.TransferOptions
                transferOpt.TransferMode = TransferMode.Binary
                Dim tmpDest As String = IO.Path.Combine(Me.destination, IO.Path.GetFileName(Me.flPath))
                Dim tmpDownloadingPath As String = tmpDest & ".downloading"
                Dim cnt As Integer = 0
                While IO.File.Exists(tmpDownloadingPath)
                    tmpDownloadingPath = String.Concat(tmpDest, ".downloading", cnt)
                    cnt += 1
                End While
                writeNewLine(logFilePath, String.Concat(getFormatedDate, getTabs, "Downloading file: " & fileName))
                Dim transferResult As WinSCP.TransferOperationResult = ses.GetFiles(Me.flPath, tmpDownloadingPath, removeAfterDowload, transferOpt)
                transferResult.Check()

                Dim i As Integer = 0
                While Not transferResult.IsSuccess
                    Application.DoEvents()
                End While
                cnt = 0
                While IO.File.Exists(downloadedFile)
                    cnt += 1
                    Dim tmpFlNm As String = IO.Path.GetFileNameWithoutExtension(Me.flPath)
                    Dim xt As String = IO.Path.GetExtension(Me.flPath)
                    downloadedFile = IO.Path.Combine(Me.destination, String.Concat(tmpFlNm, cnt, xt))
                End While
                My.Computer.FileSystem.RenameFile(tmpDownloadingPath, IO.Path.GetFileName(downloadedFile))
                fileSize = New IO.FileInfo(downloadedFile).Length
                dgvRow.Cells(3).Value = "Done"
                status = New _STAT_INFO(False, "File successfully downloaded", False, True, True)
                writeNewLine(logFilePath, String.Concat(getFormatedDate, getTabs, "File successfully downloaded: " & fileName))
                runIfDownloaded()
            Catch ex As Exception
                dgvRow.Cells(3).Value = ex.Message
                writeNewLine(logFilePath, String.Concat(getFormatedDate, getTabs, fileName & " : " & ex.Message))
                status = New _STAT_INFO(True, String.Concat("Downloading error => ", ex.Message), False, False, True)
            End Try
        Catch ex As Exception
            dgvRow.Cells(3).Value = ex.Message
            writeNewLine(logFilePath, String.Concat(getFormatedDate, getTabs, fileName & " : " & ex.Message))
            status = New _STAT_INFO(True, String.Concat("Open session error => ", ex.Message), False, False, True)
        End Try
        stopWatch.Stop()
        Dim ended As Date = Now
        If fileName.ToUpper.EndsWith(".ZIP") Then
            Dim wr As New IO.StreamWriter(IO.Path.Combine(filesDir, fileName & ".txt"))
            wr.WriteLine(fileName)
            wr.WriteLine(Me.destination)
            wr.WriteLine((fileSize))
            wr.WriteLine(started)
            wr.WriteLine(ended)
            wr.WriteLine(status.errMsg)
            wr.Close()
            While Publicvalues.pleaseWait
                Application.DoEvents()
            End While
            Publicvalues.pleaseWait = True
            Dim csvPath As String = IO.Path.Combine(Me.destination, folderLogDate & ".csv")
            Dim ww As csvWriter
            If IO.File.Exists(csvPath) Then
                ww = New csvWriter(csvPath, System.Text.Encoding.UTF8, True)
            Else
                ww = New csvWriter(csvPath, System.Text.Encoding.UTF8, False)
                ww.writLine("FileName", "FileSize", "Image Count", "Date", "Start Time", "End Time", "Save Path", "Status")
            End If
            ww.writLine(fileName, fileSize, Me.imageCOunt, Format(started, "dd-MMMM-yyyy"), Format(started, "hh:mm:ss tt"), Format(ended, "hh:mm:ss tt"), Me.destination, status.errMsg.Replace(vbNewLine, "==>").Replace(vbLf, "==>"))
            ww.close()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            Publicvalues.pleaseWait = False
        ElseIf fileName.ToUpper.EndsWith(".XLS") Then
            Dim wr As New IO.StreamWriter(IO.Path.Combine(reportsDir, fileName & ".txt"))
            wr.WriteLine(fileName)
            wr.WriteLine(Me.destination)
            wr.WriteLine(ConvertBitesToStringize(fileSize))
            wr.WriteLine(started)
            wr.WriteLine(ended)
            Dim xlPath As String = IO.Path.Combine(Me.destination, fileName)
            Dim tbl As DataTable = getTableFromXls(xlPath, GetExcelSheetNames(xlPath)(0))
            wr.WriteLine(tbl.Rows.Count - 1)
            wr.WriteLine(status.errMsg)
            wr.Close()
        End If
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
#Region "Utensils"
    Public Function ConvertBitesToStringize(ByVal size As Long) As String
        Dim retStr As String = "0KB"
        Dim KB As Integer = 1024
        If size >= (KB * KB * KB) Then
            retStr = Format(CDbl(size / (KB * KB * KB)), "0.00") & "GB"
        ElseIf size >= (KB * KB) Then
            retStr = Format(CDbl(size / (KB * KB)), "0.00") & "MB"
        ElseIf size >= KB Then
            retStr = Format(CDbl(size / KB), "0.00") & "KB"
        Else
            retStr = size & "B"
        End If
        Return retStr
    End Function
    Sub createDirectoryIFnotExist(dir As String)
e:
        If IO.Directory.Exists(dir) Then
        Else
            Try
                MkDir(dir)
            Catch ex As Exception
                GoTo e
            End Try
        End If
    End Sub
    Structure _STAT_INFO
        Dim isErr As Boolean
        Dim errMsg As String
        Dim isRunning As Boolean
        Dim isDownloaded As Boolean
        Dim isDoneRunning As Boolean
        Sub New(isErr As Boolean, msg As String, isRunning As Boolean, isDownloaded As Boolean, isDoneRunning As Boolean)
            Me.isErr = isErr
            Me.errMsg = msg
            Me.isRunning = isRunning
            Me.isDownloaded = isDownloaded
            Me.isDoneRunning = isDoneRunning
        End Sub
    End Structure
#End Region
End Class
