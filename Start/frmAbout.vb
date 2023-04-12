Public Class frmAbout
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblBackEnd.Text = "FrontEnd: " & strCurrentVersion & "  |  BackEnd: " & strBuildInfo
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Dispose()
    End Sub
    Private Sub frmAbout_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.Dispose()
    End Sub

End Class