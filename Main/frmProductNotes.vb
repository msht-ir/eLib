Public Class frmProductNotes
    Private Sub frmProductNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Retval1
            Case 0 'Add new note
                Me.Text = "Add New Note for:  " & strProductName
                txtDatum.Text = System.DateTime.Now.ToString("yyyy.MM.dd HH:mm")
            Case 1 'Edit existing note
                Me.Text = "Edit Note of:  " & strProductName
                txtDatum.Text = strDateTime
                txtNote.Text = strProdNote
        End Select
    End Sub
    Private Sub txtDatum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDatum.KeyDown
        If (e.KeyCode = 13) Then txtNote.Focus()
    End Sub
    Private Sub txtNote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNote.KeyDown
        If (e.KeyCode = 13) Then Menu_Save_Click(sender, e)
    End Sub
    Private Sub Menu_UpdateDateTime_Click(sender As Object, e As EventArgs) Handles Menu_UpdateDateTime.Click
        txtDatum.Text = System.DateTime.Now.ToString("yyyy.MM.dd HH:mm")
    End Sub
    Private Sub Menu_Save_Click(sender As Object, e As EventArgs) Handles Menu_Save.Click
        strProdNote = txtNote.Text
        If Trim(strProdNote) = "" Then
            txtNote.Focus()
            Exit Sub
        Else
            strDateTime = Trim(txtDatum.Text)
            If strDateTime = "" Then strDateTime = System.DateTime.Now.ToString("yyyy.MM.dd HH:mm")
            Retval1 = 1 'Save|Edit this ProdNote / send signal for a save
            Me.Dispose()
        End If
    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Retval1 = 0
        Me.Dispose()
    End Sub

End Class