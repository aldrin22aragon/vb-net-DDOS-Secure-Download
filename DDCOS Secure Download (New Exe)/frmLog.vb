Imports System.IO

Public Class frmLog
    Dim folder As String = ""
    Dim logPath As String = "C:\IDCSI\FTP Auto Downloader\DDCOS\Logs (new exe)"
    Sub New(folderDate As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.folder = folderDate
    End Sub

    Private Sub frmLog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If IO.Directory.Exists(logPath) Then
            Dim dirs As String() = IO.Directory.GetDirectories(logPath)
            Dim added As Boolean = False
            For Each i As String In dirs
                Dim folderOnly As String = IO.Path.GetFileName(i)
                cmbDate.Items.Add(folderOnly)
                added = True
            Next
            If added Then
                cmbDate.SelectedItem = Me.folder
            End If
        End If
    End Sub

    Private Sub frmLog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
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
    Sub okay()
        Dim value As String = cmbDate.SelectedItem.ToString
        Dim files As String() = IO.Directory.GetFiles(IO.Path.Combine(logPath, value, "Files"))
        lstLogs.Items.Clear()
        lstLog.Items.Clear()

        For Each i As String In files
            Dim objReader = New StreamReader(i)
            Dim filename As String = ""
            Dim savepath As String = ""
            Dim filesize As String = ""
            Dim starttime As String = ""
            Dim endtime As String = ""
            Dim remarks As String = ""
            Try
                filename = Trim(objReader.ReadLine)
                savepath = Trim(objReader.ReadLine)
                filesize = Trim(objReader.ReadLine)
                starttime = Trim(objReader.ReadLine)
                endtime = Trim(objReader.ReadLine)
                remarks = Trim(objReader.ReadLine)
                With lstLogs.Items.Add(filename)
                    .SubItems.Add(ConvertBitesToStringize(CLng(filesize)))
                    .SubItems.Add(Format(CDate(starttime), "dd-MM-yyyy"))
                    .SubItems.Add(Format(CDate(starttime), "hh:mm:ss tt"))
                    .SubItems.Add(Format(CDate(endtime), "hh:mm:ss tt"))
                    .SubItems.Add(savepath)
                    .SubItems.Add(remarks)
                    .SubItems.Add(filesize)
                End With
            Catch ex As Exception

            End Try
            objReader.Close()
        Next
        Dim objReader1 As StreamReader = Nothing
        Dim logAA As String = IO.Path.Combine(logPath, value, value & ".txt")
        If File.Exists(logAA) Then
            objReader1 = New StreamReader(logAA)
            Do While objReader1.Peek() <> -1
                lstLog.Items.Add(objReader1.ReadLine())
            Loop
            objReader1.Close()
        End If
    End Sub
    Private Sub cmbDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDate.SelectedIndexChanged
        okay()
    End Sub

    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class