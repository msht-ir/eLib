Public Class frmProject
    Private Sub frmProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Retval1 {0:Project 1:subProject}
        'Retval2 {MODE 0:new 1:edit}
        'Retval3 {0:InActive -1:Active}

        Select Case Retval1
            Case 0 'Request from project
                Select Case Retval2 'MODE {new|edit}
                    Case 0 'new project
                        Me.Text = "NOTE: New Project:"
                        txtProjectName.Text = "Prj " & System.DateTime.Now.ToString("yyyy.MM.dd HH:mm") & "- EDIT me!"
                        txtProjectNote.Text = "new project"
                        CheckBoxActive.Checked = True
                    Case 1 'edit mode
                        Me.Text = "Edit Project:"
                        txtProjectName.Text = strProjectName
                        txtProjectNote.Text = strProjectNote
                        CheckBoxActive.Checked = Retval3
                End Select
                txtProjectName.Focus()
            Case 1 'Request from subProject
                Me.Text = "subProject:"
                CheckBoxActive.Enabled = False
                Select Case Retval2 'MODE {new|edit}
                    Case 0 'new subproject
                        Me.Text = "New subProject:"
                        txtProjectName.Text = "Prd " & System.DateTime.Now.ToString("yyyy.MM.dd HH:mm") & "- EDIT me!"
                        txtProjectNote.Text = "[NOTE: new subproject"
                    Case 1 'edit mode
                        Me.Text = "Edit subProject:"
                        txtProjectName.Text = strProjectName
                        txtProjectNote.Text = strProjectNote
                End Select
                txtProjectName.Focus()
            Case 2 'Request from USER Add/Edit
                '[password: clr and type here]

                CheckBoxActive.Enabled = True
                Select Case Retval2
                    Case 0 'new User
                        Me.Text = "New User:"
                        txtProjectName.Text = "usrName-" & System.DateTime.Now.ToString("MMddHHmm") & "- EDIT!"
                        txtProjectNote.Text = "[password:type here]"
                        'txtProjectNote.PasswordChar = "-"
                        txtProjectName.Focus()
                    Case 1
                        Me.Text = "Current Password:"
                        txtProjectName.Text = strProjectName
                        txtProjectName.Enabled = False
                        txtProjectNote.Text = ""
                        txtProjectNote.PasswordChar = "-"
                        CheckBoxActive.Checked = Retval3
                        txtProjectNote.Focus()
                    Case 2
                        Me.Text = "NEW Password:"
                        txtProjectName.Text = strProjectName
                        txtProjectName.Enabled = False
                        txtProjectNote.Text = ""
                        txtProjectNote.PasswordChar = "-"
                        CheckBoxActive.Checked = Retval3
                        txtProjectNote.Focus()
                    Case 3
                        Me.Text = "NEW Password (Confirm):"
                        txtProjectName.Text = strProjectName
                        txtProjectName.Enabled = False
                        txtProjectNote.Text = ""
                        txtProjectNote.PasswordChar = "-"
                        CheckBoxActive.Checked = Retval3
                        CheckBoxActive.Enabled = False
                        txtProjectNote.Focus()
                End Select
        End Select
    End Sub
    Private Sub txtProjectName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProjectName.KeyDown
        If e.KeyCode = 13 Then Menu_Save_Click(sender, e)
    End Sub
    Private Sub txtProjectNote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProjectNote.KeyDown
        Select Case Retval1
            Case 0, 1 '0:Project 1:Produvt
                If e.KeyCode = 13 Then txtProjectName.Focus()
            Case 2 '2:USER-Password
                If e.KeyCode = 13 Then Menu_Save_Click(sender, e)
        End Select
    End Sub
    Private Sub Menu_Save_Click(sender As Object, e As EventArgs) Handles Menu_Save.Click
        strProjectName = txtProjectName.Text
        strProjectNote = txtProjectNote.Text
        Retval3 = CheckBoxActive.Checked
        If Trim(strProjectName) = "" Then
            txtProjectName.Focus()
            Exit Sub
        Else
            Retval1 = 1 'send signal for a save (0: Cancel)
            Me.Dispose()
        End If

    End Sub
    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Retval1 = 0
        Me.Dispose()

    End Sub

End Class