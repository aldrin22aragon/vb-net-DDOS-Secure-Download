Imports System.Net
Imports WinSCP
Imports System.IO
Imports System.Data.OleDb

Public Class Form1
#Region "Settings"
    Dim mySessionSettings As MySettingsInfo
    Dim settingsPath As String = IO.Path.Combine(Application.StartupPath, "settings_")
    Dim settingsFilePath As String = IO.Path.Combine(settingsPath, "settings.ini")
    Dim colIndexForPath As Integer = 2
    Dim elapser As New Stopwatch
    Dim mode As EnumMode = EnumMode.None
    Dim clientDate As Date
    Dim dateFolder As String = ""
    Dim dlSource As String = ""
    Class StringCollection
        Public Const UploadDestination As String = "UploadDestination"
        Public Const UploadSource As String = "UploadSource"
        Public Const SimultaniusDownload As String = "SimultaniusDownload"
        Public Const SimultaniusUpload As String = "SimultaniusUpload"
        Public Const DownLoadDestination As String = "DownLoadDestination"
        Public Const DownloadSource As String = "DownloadSource"
        Public Const CheckDLperMinute As String = "CheckDLperMinute"
        Public Const AdjustTimeBy As String = "0"
    End Class
    Enum from_ As Integer
        File = 0
        TextFields = 1
    End Enum

    Structure MySettingsInfo
        Dim sessionOpt As SessionOptions
        Dim otherInformation As Dictionary(Of String, Object)
        Sub New(sesOp As SessionOptions, Optional otherInf As Dictionary(Of String, Object) = Nothing)
            Me.sessionOpt = sesOp
            Me.otherInformation = otherInf
        End Sub
    End Structure
    Property getSetFtpSettings(FileOrTextboxes As from_) As MySettingsInfo
        Get
            Dim ses As New SessionOptions
            Dim otherSettings As New Dictionary(Of String, Object)
            If FileOrTextboxes = from_.File Then
                If IO.File.Exists(settingsFilePath) Then
                    Dim lines As String() = IO.File.ReadAllLines(settingsFilePath)
                    Try
                        With ses
                            .HostName = lines(0)
                            .UserName = lines(1)
                            .Password = lines(2)
                            .PortNumber = lines(3)
                            If LCase(lines(4)) = "ftp" Then
                                .Protocol = Protocol.Ftp
                            ElseIf LCase(lines(4)) = "sftp" Then
                                .Protocol = Protocol.Sftp
                                .SshHostKeyFingerprint = lines(5)
                            End If
                        End With
                        otherSettings.Add(StringCollection.UploadDestination, lines(6))
                        otherSettings.Add(StringCollection.UploadSource, lines(7))
                        otherSettings.Add(StringCollection.SimultaniusDownload, lines(8))
                        otherSettings.Add(StringCollection.SimultaniusUpload, lines(9))
                        otherSettings.Add(StringCollection.DownLoadDestination, lines(10))
                        otherSettings.Add(StringCollection.DownloadSource, lines(11))
                        otherSettings.Add(StringCollection.CheckDLperMinute, lines(12))
                        otherSettings.Add(StringCollection.AdjustTimeBy, lines(13))
                    Catch ex As Exception
                    End Try
                End If
            ElseIf FileOrTextboxes = from_.TextFields Then
                With ses
                    .HostName = txtHost.Text
                    .UserName = txtUsername.Text
                    .Password = txtPassword.Text
                    .PortNumber = txtPort.Text
                    If LCase(cmbConnectionType.SelectedItem.ToString) = "ftp" Then
                        .Protocol = Protocol.Ftp
                    ElseIf LCase(cmbConnectionType.SelectedItem.ToString) = "sftp" Then
                        .Protocol = Protocol.Sftp
                        .SshHostKeyFingerprint = txtHostkey.Text
                    End If
                End With

                otherSettings.Add(StringCollection.UploadSource, txtSrcUpload.Text)
                otherSettings.Add(StringCollection.UploadDestination, txtDestUpload.Text)
                otherSettings.Add(StringCollection.SimultaniusDownload, txtLimitDownload.Value)
                otherSettings.Add(StringCollection.SimultaniusUpload, txtLimitUpload.Value)
                otherSettings.Add(StringCollection.DownLoadDestination, txtDLdest.Text)
                otherSettings.Add(StringCollection.DownloadSource, txtDLSrc.Text)
                otherSettings.Add(StringCollection.CheckDLperMinute, txtDLmin.Value)
                otherSettings.Add(StringCollection.AdjustTimeBy, txtAdjustTimeBy.Value)
            End If
            Return New MySettingsInfo(ses, otherSettings)
        End Get
        Set(value As MySettingsInfo)
            Dim ses As SessionOptions = value.sessionOpt
            Dim otherInf As Dictionary(Of String, Object) = value.otherInformation
            If FileOrTextboxes = from_.File Then
                If Not IO.Directory.Exists(settingsPath) Then MkDir(settingsPath)
                Dim wr As New IO.StreamWriter(settingsFilePath, False)
                With ses
                    wr.WriteLine(.HostName)
                    wr.WriteLine(.UserName)
                    wr.WriteLine(.Password)
                    wr.WriteLine(.PortNumber)
                    If .Protocol = Protocol.Ftp Then
                        wr.WriteLine("ftp")
                    ElseIf .Protocol = Protocol.Sftp Then
                        wr.WriteLine("sftp")
                    Else
                        wr.WriteLine()
                    End If
                    wr.WriteLine(.SshHostKeyFingerprint)
                    If otherInf.Count > 0 Then
                        wr.WriteLine(otherInf.Item(StringCollection.UploadDestination))
                        wr.WriteLine(otherInf.Item(StringCollection.UploadSource))
                        wr.WriteLine(otherInf.Item(StringCollection.SimultaniusDownload))
                        wr.WriteLine(otherInf.Item(StringCollection.SimultaniusUpload))
                        wr.WriteLine(otherInf.Item(StringCollection.DownLoadDestination))
                        wr.WriteLine(otherInf.Item(StringCollection.DownloadSource))
                        wr.WriteLine(otherInf.Item(StringCollection.CheckDLperMinute))
                        wr.WriteLine(otherInf.Item(StringCollection.AdjustTimeBy))
                    Else
                        wr.WriteLine("")
                        wr.WriteLine("")
                        wr.WriteLine("")
                        wr.WriteLine("")
                        wr.WriteLine("")
                        wr.WriteLine("")
                        wr.WriteLine("")
                        wr.WriteLine("")
                    End If
                    wr.Close()
                End With
            ElseIf FileOrTextboxes = from_.TextFields Then
                With ses
                    txtHost.Text = .HostName
                    txtUsername.Text = .UserName
                    txtPassword.Text = .Password
                    txtPort.Text = .PortNumber
                    txtHostkey.Text = .SshHostKeyFingerprint
                    If .Protocol = Protocol.Ftp Then
                        cmbConnectionType.SelectedIndex = cmbConnectionType.FindStringExact("ftp")
                    ElseIf .Protocol = Protocol.Sftp Then
                        cmbConnectionType.SelectedIndex = cmbConnectionType.FindStringExact("sftp")
                    Else
                        cmbConnectionType.SelectedIndex = -1
                    End If
                    If otherInf.Count > 0 Then
                        Try
                            txtDestUpload.Text = otherInf.Item(StringCollection.UploadDestination)
                            txtSrcUpload.Text = IIf(otherInf.Item(StringCollection.UploadSource).ToString = "", "/", otherInf.Item(StringCollection.UploadSource))
                            txtLimitDownload.Value = otherInf.Item(StringCollection.SimultaniusDownload)
                            txtLimitUpload.Value = otherInf.Item(StringCollection.SimultaniusUpload)
                            txtDLdest.Text = otherInf.Item(StringCollection.DownLoadDestination)
                            txtDLSrc.Text = IIf(otherInf.Item(StringCollection.DownloadSource).ToString = "", "/", otherInf.Item(StringCollection.DownloadSource))
                            txtDLmin.Value = Val(otherInf.Item(StringCollection.CheckDLperMinute))
                            txtAdjustTimeBy.Value = Val(otherInf.Item(StringCollection.AdjustTimeBy))
                        Catch ex As Exception

                        End Try
                    Else
                        txtDestUpload.Text = ""
                        txtSrcUpload.Text = ""
                        txtLimitDownload.Value = 0
                        txtLimitUpload.Value = 0
                        txtDLdest.Text = ""
                        txtDLSrc.Text = ""
                        txtDLmin.Value = 0
                        txtAdjustTimeBy.Value = 0
                    End If
                End With
            End If
        End Set
    End Property
    Sub showFptBrowser(text As TextBox)
      Dim b As New FtpBrowser(getSetFtpSettings(from_.TextFields).sessionOpt, FtpBrowser.Mode_.folder, IIf(text.Text = "", "/", text.Text))
      If b.ShowDialog = DialogResult.OK Then
         text.Text = b.ReturnString
      End If
   End Sub
   Sub showBrowseFolder(txt As TextBox)
      Dim folderBrowser As New FolderBrowserDialog()
      folderBrowser.SelectedPath = Application.StartupPath
      If folderBrowser.ShowDialog = DialogResult.OK Then
         txt.Text = folderBrowser.SelectedPath
      End If
   End Sub


   Function testConnection() As Boolean
      Try
         Dim session As New Session
         Label6.Text = "Connecting....."
         session.Open(getSetFtpSettings(from_.TextFields).sessionOpt)
         session.Dispose()
         session = Nothing
         showTextForAWhile(Label6, 3000, "Connected :)")
         Return True
      Catch ex As Exception
         MsgBox(ex.Message)
         showTextForAWhile(Label6, 3000, ex.Message)
         Return False
      Finally
      End Try
   End Function
   Private Sub btnTestConnect_Click(sender As Object, e As EventArgs) Handles btnTestConnect.Click
      testConnection()
   End Sub
   Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
      getSetFtpSettings(from_.File) = getSetFtpSettings(from_.TextFields)
      mySessionSettings = getSetFtpSettings(from_.File)
      showTextForAWhile(Label6, 3000, "Settings is saved :)")
   End Sub
   Private Sub cmbConnectionType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConnectionType.SelectedValueChanged
      If cmbConnectionType.SelectedItem.ToString.ToLower = "sftp" Then
         txtHostkey.Visible = True
      Else
         txtHostkey.Visible = False
      End If
   End Sub
   Private Sub tabSettings_Enter(sender As Object, e As EventArgs) Handles tabSettings.Enter
      getSetFtpSettings(from_.TextFields) = getSetFtpSettings(from_.File)
   End Sub
   Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      Application.Exit()
   End Sub
   Sub showTextForAWhile(c As Control, miliseconds As Integer, textvalue As String)
      Dim th As New System.Threading.Thread(Sub()
                                               Dim sw As New Stopwatch
                                               c.Invoke(Sub(c1 As Control)
                                                           c1.Text = textvalue
                                                        End Sub, c)
                                               sw.Start()
                                               While sw.ElapsedMilliseconds < miliseconds
                                                  Application.DoEvents()
                                               End While
                                               sw.Stop()
                                               sw = Nothing
                                               c.Invoke(Sub(c1 As Control)
                                                           c1.Text = ""
                                                        End Sub, c)
                                            End Sub)
      th.Start()
   End Sub
   Private Sub txtDLdest_DoubleClick(sender As Object, e As EventArgs) Handles txtDLdest.DoubleClick
      showBrowseFolder(sender)
   End Sub
   Private Sub txtDLSrc_DoubleClick(sender As Object, e As EventArgs) Handles txtDLSrc.DoubleClick
      If testConnection() Then
         showFptBrowser(DirectCast(sender, TextBox))
      End If
   End Sub
#End Region
#Region "Process"
   Enum EnumMode As Integer
      None = 0
      WaitingForNextXLScheck = 1
      Stoped = 2
      Downloading = 3
   End Enum
   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      mySessionSettings = getSetFtpSettings(from_.File)
      Dim aa As New TextboxPlaceholder(Label1, txtDLdest, txtHostkey, txtDLSrc)
      'currentDateTime = New TimeZoneInfo("Eastern Standard Time").CurrentTime.ToString("dddd, MMMM dd, yyyy hh:mm tt")
      'ServerDate = currentDateTime.ToString("dddd, MMMM dd, yyyy hh:mm tt")
      'lblCLientDateAndTime.Text = ServerDate

      'Dim a As String = "C:\IDCSI\FTP Auto Downloader\DDCOS\Logs\31032021\Files\rrr.txt"
      'My.Computer.FileSystem.WriteAllText(a, "1", True)
      'My.Computer.FileSystem.WriteAllText(a, vbNewLine & "2", True)


      If IO.File.Exists(settingsFilePath) Then
         setMode(EnumMode.Downloading)
      Else
         setMode(EnumMode.Stoped)
         MsgBox("Please setup first settings.")
      End If
   End Sub
   Function checkIfettingConnectionIsValid() As Boolean
      Try
         Dim session As New Session
         session.Open(getSetFtpSettings(from_.File).sessionOpt)
         session.Dispose()
         session = Nothing
         Return True
      Catch ex As Exception
         Return False
      End Try
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
   Sub setMode(mode As EnumMode)
      Select Case mode
         Case EnumMode.WaitingForNextXLScheck
            timerDLexecutorXLSfiles.Enabled = False
            timerDLfinisheDownloadCheckerXLSfiles.Enabled = False
            mode = EnumMode.WaitingForNextXLScheck
            btnStop.Enabled = True
            btnStart.Enabled = False
            Try
               elapser.Stop()
            Catch ex As Exception
            End Try
            elapser = New Stopwatch
            elapser.Start()
            TimerCheckingForDownloadInterval.Enabled = True
            blinkTimer.Enabled = True
         Case EnumMode.Stoped
            RichTextBox1.Text = String.Concat(RichTextBox1.Text, vbNewLine, "Process stoped")
            timerDLexecutorXLSfiles.Enabled = False
            timerDLfinisheDownloadCheckerXLSfiles.Enabled = False
            TimerCheckingForDownloadInterval.Enabled = False
            blinkTimer.Enabled = False
            mode = EnumMode.Stoped
            btnStop.Enabled = False
            btnStart.Enabled = True
            Try
               elapser.Stop()
            Catch ex As Exception
            End Try
            Dim s = Sub(dgv As DataGridView)
                       For Each i As DataGridViewRow In dgv.Rows
                          Dim dl As DownloadFile = i.Tag
                          If Not dl.status.isErr And Not dl.status.isDoneRunning And Not dl.status.isDownloaded Then
                             i.Cells(3).Value = "Stoped"
                          End If
                       Next
                    End Sub
            s(dgvDL)
            s(dgvXls)
            lblMins.Text = "Stoped"
         Case EnumMode.Downloading
            Dim allXlsFiles As RemoteFileInfoCollection
            Dim tmDate As Date = Nothing
            Dim dtFlder As String = ""
            updateClientDateAndDateFoler(tmDate, dtFlder)
            If dateFolder <> "" Then
               If dtFlder <> dateFolder Then
                  clientDate = tmDate
                  dateFolder = dtFlder
                  Label21.Text = "0 done of 0"
                  lblDLcount.Text = "0 done of 0"
                  dgvDL.Rows.Clear()
                  dgvXls.Rows.Clear()
                  RichTextBox1.Text = String.Concat(RichTextBox1.Text, vbNewLine, "Current date changed. Table is cleared.")
               End If
            Else
               clientDate = tmDate
               dateFolder = dtFlder
            End If
            lblMins.Text = "Running..."
            blinkTimer.Enabled = False
            Dim allXLSindgvAllCaps As List(Of String) = getDgvColumvaluesAllCaps(dgvXls, colIndexForPath)
            Dim allZIPindgvAllCaps As List(Of String) = getDgvColumvaluesAllCaps(dgvDL, colIndexForPath)
            While True
               allXlsFiles = getXlsFiles()
               If allXlsFiles IsNot Nothing Then
                  If allXlsFiles.Count > 0 Then
                     Dim forRunCOunt As Integer = 0
                     Dim runDownloadDoneChecker As Boolean = False
                     For Each i As RemoteFileInfo In allXlsFiles
                        If Not i.IsDirectory AndAlso i.Name.ToUpper.EndsWith(".XLS") Then
                           Dim destDir As String = IO.Path.Combine(mySessionSettings.otherInformation.Item(StringCollection.DownLoadDestination), dateFolder)
                           If Not IO.Directory.Exists(destDir) Then MkDir(destDir)
                           Dim filePath As String = IO.Path.Combine(destDir, i.Name)
                           Dim ndx As Integer = -1
                           If Not allXLSindgvAllCaps.Contains(i.FullName.ToUpper) Then
                              allXLSindgvAllCaps.Add(i.FullName)
                              If IO.File.Exists(filePath) Then
                                 ndx = dgvXls.Rows.Add(i.Name, ConvertBitesToStringize(CULng(i.Length)), i.FullName, "Already downloaded")
                                 Dim dl As New DownloadFile(i.FullName, destDir, mySessionSettings.sessionOpt, dgvXls.Rows(ndx))
                                 dl.runIfDownloaded = Sub()
                                                      End Sub
                                 dl.status = New DownloadFile._STAT_INFO(False, "Already downloaded", False, True, True)
                                 dgvXls.Rows(ndx).Tag = dl
                                 Dim tbl As DataTable = getTableFromXls(filePath, GetExcelSheetNames(filePath)(0))

                                 For jj As Integer = 1 To tbl.Rows.Count - 1
                                    Dim j As DataRow = tbl.Rows(jj)
                                    Dim zipName As String = j.Item(0) & ".zip"
                                    Dim imagesCount As Integer = Val(j.Item(4).ToString)
                                    Dim zipDLftpPath As String = RemotePath.Combine(dlSource, zipName)
                                    If Not allZIPindgvAllCaps.Contains(zipDLftpPath.ToUpper) Then
                                       Dim fl = From f As RemoteFileInfo In allXlsFiles Where f.FullName = zipDLftpPath Select f
                                       Dim size As String = "___"
                                       If fl.Count > 0 Then size = ConvertBitesToStringize(fl(0).Length)
                                       Dim destFilePath As String = IO.Path.Combine(destDir, zipName)
                                       Dim ndxDgvDLAdded As Integer = -1
                                       If IO.File.Exists(destFilePath) Then
                                          ndxDgvDLAdded = dgvDL.Rows.Add(zipName, size, zipDLftpPath, "Already downloaded")
                                          Dim dl1 As New DownloadFile(zipDLftpPath, destDir, mySessionSettings.sessionOpt, dgvDL.Rows(ndxDgvDLAdded))
                                          dl1.imageCOunt = imagesCount
                                          dl1.status = New DownloadFile._STAT_INFO(False, "Already downloaded", False, True, True)
                                          dgvDL.Rows(ndxDgvDLAdded).Tag = dl1
                                       Else
                                          ndxDgvDLAdded = dgvDL.Rows.Add(zipName, size, zipDLftpPath, "Waiting")
                                          Dim dl1 As New DownloadFile(zipDLftpPath, destDir, mySessionSettings.sessionOpt, dgvDL.Rows(ndxDgvDLAdded))
                                          dl1.imageCOunt = imagesCount
                                          dgvDL.Rows(ndxDgvDLAdded).Tag = dl1
                                          If Not TimerExecutorForZipFiles.Enabled Then TimerExecutorForZipFiles.Enabled = True
                                          runDownloadDoneChecker = True
                                       End If
                                    End If
                                 Next
                              Else
                                 ndx = dgvXls.Rows.Add(i.Name, ConvertBitesToStringize(CULng(i.Length)), i.FullName, "Waiting")
                                 Dim dl As New DownloadFile(i.FullName, destDir, mySessionSettings.sessionOpt, dgvXls.Rows(ndx))
                                 dl.runIfDownloaded = Sub()
                                                         Dim xlCon As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " &
                                                                                 "Data Source='" & filePath & "'; " & "Extended Properties=""Excel 8.0;HDR=NO;IMEX=1"";")
                                                         Dim xlCmd As OleDbDataAdapter = New OleDbDataAdapter("SELECT * FROM [" & GetExcelSheetNames(filePath)(0) & "];", xlCon)
                                                         xlCmd.TableMappings.Add("Table", "Upload Report")
                                                         Dim dtSet As DataSet = New DataSet
                                                         xlCmd.Fill(dtSet)
                                                         dtSet = dtSet
                                                         Dim rows As DataRowCollection = dtSet.Tables(0).Rows
                                                         For j As Integer = 1 To rows.Count - 1
                                                            Dim dataRow As DataRow = rows(j)
                                                            Dim zipName As String = dataRow.Item(0) & ".zip"
                                                            Dim imagesCount As Integer = Val(dataRow.Item(4).ToString)
                                                            Dim pathZipFile As String = IO.Path.Combine(destDir, zipName)
                                                            If IO.File.Exists(pathZipFile) Then
                                                               Try
                                                                  IO.File.Delete(pathZipFile)
                                                               Catch ex As Exception
                                                               End Try
                                                            End If

                                                            Dim zipDLftpPath As String = RemotePath.Combine(dlSource, zipName)
                                                            dgvDL.Invoke(Sub()
                                                                            Dim fl = From f As RemoteFileInfo In allXlsFiles Where f.FullName = zipDLftpPath Select f
                                                                            Dim size As String = "___"
                                                                            If fl.Count > 0 Then size = ConvertBitesToStringize(fl(0).Length)
                                                                            Dim ndxDgvDLAdded As Integer = dgvDL.Rows.Add(zipName, size, zipDLftpPath, "Waiting")
                                                                            Dim dl1 As New DownloadFile(zipDLftpPath, destDir, mySessionSettings.sessionOpt, dgvDL.Rows(ndxDgvDLAdded))
                                                                            dl1.imageCOunt = imagesCount
                                                                            dgvDL.Rows(ndxDgvDLAdded).Tag = dl1
                                                                            If Not timerDLfinisheDownloadCheckerXLSfiles.Enabled Then timerDLfinisheDownloadCheckerXLSfiles.Enabled = True
                                                                            If Not TimerExecutorForZipFiles.Enabled Then TimerExecutorForZipFiles.Enabled = True
                                                                         End Sub)
                                                         Next
                                                      End Sub
                                 dgvXls.Rows(ndx).Tag = dl
                                 forRunCOunt += 1
                              End If
                           End If
                        End If
                        Application.DoEvents()
                     Next
                     If forRunCOunt > 0 Then
                        timerDLexecutorXLSfiles.Enabled = True
                     Else
                        RichTextBox1.Text &= (String.Concat(vbNewLine, dlSource, vbNewLine, "     No new XLS files found."))
                        setMode(EnumMode.WaitingForNextXLScheck)
                     End If
                     If runDownloadDoneChecker Then
                        If Not timerDLfinisheDownloadCheckerXLSfiles.Enabled Then timerDLfinisheDownloadCheckerXLSfiles.Enabled = True
                     End If
                     Exit While
                  Else
                     RichTextBox1.Text &= (String.Concat(vbNewLine, dlSource, vbNewLine, "     No XLS files found."))
                     setMode(EnumMode.WaitingForNextXLScheck)
                     Exit While
                  End If
               Else
                  RichTextBox1.Text &= (String.Concat(vbNewLine, dlSource, vbNewLine, "     No XLS files found."))
                  setMode(EnumMode.WaitingForNextXLScheck)
                  Exit While
               End If
               Application.DoEvents()
            End While
            For Each i As DataGridViewRow In dgvDL.Rows
               If i.Cells(3).Value = "Stoped" Then
                  If Not timerDLexecutorXLSfiles.Enabled Then timerDLexecutorXLSfiles.Enabled = True
                  If Not timerDLfinisheDownloadCheckerXLSfiles.Enabled Then timerDLfinisheDownloadCheckerXLSfiles.Enabled = True
                  If Not TimerExecutorForZipFiles.Enabled Then TimerExecutorForZipFiles.Enabled = True
                  Exit For
               End If
               Application.DoEvents()
            Next
            For Each i As DataGridViewRow In dgvXls.Rows
               If i.Cells(3).Value = "Stoped" Then
                  If Not timerDLexecutorXLSfiles.Enabled Then timerDLexecutorXLSfiles.Enabled = True
                  If Not timerDLfinisheDownloadCheckerXLSfiles.Enabled Then timerDLfinisheDownloadCheckerXLSfiles.Enabled = True
                  If Not TimerExecutorForZipFiles.Enabled Then TimerExecutorForZipFiles.Enabled = True
                  Exit For
               End If
               Application.DoEvents()
            Next
      End Select
   End Sub
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
   Function getDgvColumvaluesAllCaps(dgv As DataGridView, colNumber As Integer) As List(Of String)
      Dim res As New List(Of String)
      For Each i As DataGridViewRow In dgv.Rows
         res.Add(i.Cells(colNumber).Value.ToString.ToUpper)
      Next
      Return res
   End Function
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
   Function getXlsFiles() As RemoteFileInfoCollection
      Dim ses As New Session
      Dim res As RemoteFileInfoCollection
      Try
         ses.Open(mySessionSettings.sessionOpt)
         Dim fls As RemoteFileInfoCollection = Nothing
         dlSource = RemotePath.Combine(mySessionSettings.otherInformation(StringCollection.DownloadSource), dateFolder)
         RichTextBox1.Text &= vbNewLine & ("Fetching xls files....")
         LinkLabel1.Text = dlSource
         Try
            Dim directory As RemoteDirectoryInfo = ses.ListDirectory(dlSource)
            fls = directory.Files
            res = fls
            'For Each i As WinSCP.RemoteFileInfo In fls
            '    If Not i.IsDirectory And i.Name.ToUpper.EndsWith(".XLS") Then
            '        res.Add(i.FullName)
            '    End If
            'Next
         Catch ex As Exception
            RichTextBox1.Text &= (vbNewLine & "ERROR:Fetching List of files-" & ex.Message)
            res = Nothing
         End Try
         ses.Dispose()
         ses = Nothing
      Catch ex As Exception
         RichTextBox1.Text &= (vbNewLine & "ERROR:Opening connection-" & ex.Message)
         res = Nothing
      End Try
      Return res
   End Function
   Sub updateClientDateAndDateFoler(ByRef clientDate_ As Date, ByRef dateFoler_ As String)
      'clientDate_ = New TimeZoneInfo("Canada Central Standard Time").CurrentTime
      Dim adjust As Integer = 0
      Try
         adjust = Val(mySessionSettings.otherInformation.Item(StringCollection.AdjustTimeBy))
      Catch ex As Exception

      End Try
      If adjust < 0 Then
         adjust = Val(adjust.ToString.Replace("-", ""))
         clientDate_ = Now.Subtract(New TimeSpan(adjust, 0, 0))
      ElseIf adjust > 0 Then
         clientDate_ = Now.Add(New TimeSpan(adjust, 0, 0))
      Else
         clientDate_ = Now
      End If
      dateFoler_ = clientDate_.ToString("ddMMyyyy")

      dlSource = RemotePath.Combine(mySessionSettings.otherInformation(StringCollection.DownloadSource), dateFoler_)
      LinkLabel1.Text = dlSource

      clientDate_ = clientDate_
   End Sub
   Private Sub TimerCheckingForDownloadInterval_Tick(sender As Object, e As EventArgs) Handles TimerCheckingForDownloadInterval.Tick
      Dim stngs As MySettingsInfo = mySessionSettings
      Dim m As Integer = Val(stngs.otherInformation(StringCollection.CheckDLperMinute))
      updateClientDateAndDateFoler(clientDate, dateFolder)
      lblCLientDateAndTime.Text = clientDate.ToString("dddd, MMMM dd, yyyy hh:mm tt")
      If elapser.Elapsed.TotalMinutes >= m Then
         'If elapser.Elapsed.TotalMinutes >= 0.04 Then
         elapser.Stop()
         TimerCheckingForDownloadInterval.Enabled = False
         setMode(EnumMode.Downloading)
      Else
         Dim ela As TimeSpan = (New TimeSpan(0, m, 0) - elapser.Elapsed)
         lblMins.Text = (ela.Minutes & " min : " & ela.Seconds & " sec")
      End If
   End Sub

   Dim ticking As Boolean = False
   Private Sub timerDLexecutor_Tick(sender As Object, e As EventArgs) Handles timerDLexecutorXLSfiles.Tick
      If Not ticking Then
         ticking = True
         Dim runningCount As Integer = 0
         For Each i As DataGridViewRow In dgvXls.Rows
            Dim dl As DownloadFile = i.Tag
            If dl.status.isRunning Then
               runningCount += 1
            End If
            Application.DoEvents()
         Next
         For Each i As DataGridViewRow In dgvXls.Rows
            Dim dl As DownloadFile = i.Tag
            If Not dl.status.isRunning And
                Not dl.status.isDownloaded And
                Not dl.status.isDoneRunning And
                runningCount < mySessionSettings.otherInformation(StringCollection.SimultaniusDownload) Then
               runningCount += 1
               dl.startDownload()
            End If
            Application.DoEvents()
         Next
         Label18.Text = "Running: " & runningCount

         ticking = False
      End If
   End Sub
   Dim timerDLfinisheDownloadChecker___ As Boolean = False
   Private Sub timerDLfinisheDownloadChecker_Tick(sender As Object, e As EventArgs) Handles timerDLfinisheDownloadCheckerXLSfiles.Tick
      If Not timerDLfinisheDownloadChecker___ Then
         timerDLfinisheDownloadChecker___ = True
         Dim errors As String = ""
         Dim dgvDLdoneCount As Integer = 0
         For Each i As DataGridViewRow In dgvDL.Rows
            Dim dl As DownloadFile = i.Tag
            If (Not dl.status.isRunning And dl.status.isDownloaded) Then
               dgvDLdoneCount += 1
            ElseIf (Not dl.status.isRunning And dl.status.isDoneRunning And dl.status.isErr) Then
               errors = String.Concat(errors, vbNewLine, IIf(errors = "", "Errors found:" & vbNewLine, ""), dl.status.errMsg)
               dgvDLdoneCount += 1
            End If
         Next
         lblDLcount.Text = String.Concat(dgvDLdoneCount, " done of ", dgvDL.Rows.Count)

         Dim dgvXLSdoneCount As Integer = 0
         For Each i As DataGridViewRow In dgvXls.Rows
            Dim dl As DownloadFile = i.Tag
            If (Not dl.status.isRunning And dl.status.isDownloaded) Then
               dgvXLSdoneCount += 1
            ElseIf (Not dl.status.isRunning And dl.status.isDoneRunning And dl.status.isErr) Then
               errors = String.Concat(errors, vbNewLine, IIf(errors = "", "Errors found:" & vbNewLine, ""), dl.status.errMsg)
               dgvXLSdoneCount += 1
            End If
         Next
         Label21.Text = String.Concat(dgvXLSdoneCount, " done of ", dgvXls.Rows.Count)

         If dgvXLSdoneCount = dgvXls.Rows.Count And dgvDLdoneCount = dgvDL.Rows.Count Then
            Label22.Text = "Running: 0"
            Label18.Text = "Running: 0"
            If errors <> "" Then
               Dim erForm As New errorForm(errors)
               erForm.ShowDialog()
            End If
            setMode(EnumMode.WaitingForNextXLScheck)
         End If

         timerDLfinisheDownloadChecker___ = False
      End If
   End Sub

   Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
      Dim ftp As New FtpBrowser(mySessionSettings.sessionOpt, FtpBrowser.Mode_.file, LinkLabel1.Text, False)
      ftp.ShowDialog()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        If RichTextBox1.Text.Length > 4000 Then
            RichTextBox1.Text = ""
        Else
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length - 1
            RichTextBox1.ScrollToCaret()
        End If
    End Sub

    Private Sub TimerExecutorForZipFiles_Tick(sender As Object, e As EventArgs) Handles TimerExecutorForZipFiles.Tick
        Dim runningCount As Integer = 0
        For Each i As DataGridViewRow In dgvDL.Rows
            Dim dl As DownloadFile = i.Tag
            If dl.status.isRunning Then
                runningCount += 1
            End If
            Application.DoEvents()
        Next
        For Each i As DataGridViewRow In dgvDL.Rows
            Dim dl As DownloadFile = i.Tag
            If Not dl.status.isRunning And
            Not dl.status.isDownloaded And
            Not dl.status.isDoneRunning And
            runningCount < mySessionSettings.otherInformation(StringCollection.SimultaniusDownload) Then
                runningCount += 1
                dl.startDownload()
            End If
            Application.DoEvents()
        Next
        Label22.Text = "Running: " & runningCount
    End Sub

    Private Sub dgvXls_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvXls.CurrentCellChanged
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim row As DataGridViewRow = dgvXls.Rows(dgvXls.CurrentCell.RowIndex)
        If row.Tag IsNot Nothing Then
            Dim dl As DownloadFile = row.Tag
            Dim stat As DownloadFile._STAT_INFO = dl.status
            If stat.isErr And Not stat.isRunning And Not stat.isDownloaded And stat.isDoneRunning Then
                Button1.Tag = dgvXls.CurrentCell.RowIndex
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub dgvDL_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvDL.CurrentCellChanged
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim row As DataGridViewRow = dgvDL.Rows(dgvDL.CurrentCell.RowIndex)
        If row.Tag IsNot Nothing Then
            Dim dl As DownloadFile = row.Tag
            Dim stat As DownloadFile._STAT_INFO = dl.status
            If stat.isErr And Not stat.isRunning And Not stat.isDownloaded And stat.isDoneRunning Then
                Button2.Tag = dgvDL.CurrentCell.RowIndex
                Button2.Enabled = True
            Else
                Button2.Enabled = False
            End If
        Else
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim btn As Button = CType(sender, Button)
        Dim ndx As Integer = IIf(btn.Tag IsNot Nothing, Val(btn.Tag), -1)
        If ndx <> -1 Then
            Dim rw As DataGridViewRow = dgvXls.Rows(ndx)
            Dim dl As DownloadFile = rw.Tag
            rw.Cells(3).Value = "Trying to re-Download"
            dl.status = New DownloadFile._STAT_INFO(False, "", True, False, False)
            Button1.Enabled = False
            dl.startDownload()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim btn As Button = CType(sender, Button)
        Dim ndx As Integer = IIf(btn.Tag IsNot Nothing, Val(btn.Tag), -1)
        If ndx <> -1 Then
            Dim rw As DataGridViewRow = dgvDL.Rows(ndx)
            Dim dl As DownloadFile = rw.Tag
            rw.Cells(3).Value = "Trying to re-Download"
            dl.status = New DownloadFile._STAT_INFO(False, "", True, False, False)
            Button2.Enabled = False
            dl.startDownload()
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        setMode(EnumMode.Downloading)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        setMode(EnumMode.Stoped)
    End Sub
    Private Sub blinkTimer_Tick(sender As Object, e As EventArgs) Handles blinkTimer.Tick
        'If lblMins.BorderStyle = BorderStyle.FixedSingle Then
        '    lblMins.BorderStyle = BorderStyle.Fixed3D
        'Else
        '    lblMins.BorderStyle = BorderStyle.FixedSingle
        'End If
        If lblMins.BackColor = Color.DarkOrange Then
            lblMins.BackColor = Color.White
            lblMins.ForeColor = Color.Black
        Else
            lblMins.BackColor = Color.DarkOrange
            lblMins.ForeColor = Color.Black
        End If
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'IO.Directory.Delete("C:\Users\soft10\Documents\Visual Studio 2019\Projects\DDCOS Secure Download (New Exe)\DDCOS Secure Download (New Exe)\bin\Debug\06042021", True)
        'IO.Directory.Delete("C:\IDCSI\FTP Auto Downloader\DDCOS\Logs (new exe)", True)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim aa As New frmLog(dateFolder)
        aa.ShowDialog()
    End Sub


#End Region
End Class
