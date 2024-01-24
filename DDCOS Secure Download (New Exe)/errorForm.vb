Public Class errorForm
    Dim msg As String
    Sub New(errMsg As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.msg = errMsg
    End Sub

    Private Sub errorForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        RichTextBox1.Text = Me.msg
    End Sub
End Class