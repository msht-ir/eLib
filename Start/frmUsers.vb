Imports DocumentFormat.OpenXml.Office2010.ExcelAc

Public Class frmUsers
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshGridUsers()
    End Sub
    Private Sub RefreshGridUsers()
        ReadSettingsAndUsers()
        GridUsers.DataSource = DS.Tables("tblUsrs")
        GridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridUsers.Columns(0).Visible = False    'ID
        GridUsers.Columns(0).Width = 0          'ID
        GridUsers.Columns(1).Width = 150        'UserName
        GridUsers.Columns(2).Width = 120        'UserPass
        GridUsers.Columns(3).Width = 45         'Active
        GridUsers.Columns(4).Width = 220        'UserNote
        For i As Integer = 0 To 15
            GridUsers.Columns(i + 5).Width = 45 'Acc00-15
        Next
        For i As Integer = 0 To GridUsers.Columns.Count - 1 'Disable sort for column_haeders
            GridUsers.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i
        Me.Text = "eLib     |     USR: " & strUser & "     |     DB: " & strCaption & "     |     BE: " & strDbBackEnd
        GridUsers.Refresh()
        If GridUsers.Rows.Count > 1 Then GridUsers.Rows(0).Cells(1).Selected = True
        GridUsers.Focus()
    End Sub
    Private Sub GridUsers_KeyDown(sender As Object, e As KeyEventArgs) Handles GridUsers.KeyDown
        Select Case e.KeyCode
            Case 27 : Menu_LoginAsAdmin_Click(sender, e)
            Case Else  'nothing
        End Select
    End Sub
    Private Sub frmUsers_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case 27 : Menu_LoginAsAdmin_Click(sender, e)
            Case Else  'nothing
        End Select
    End Sub
    Private Sub GridUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridUsers.CellDoubleClick
        Dim boolON As Integer = -1
        Dim boolOFF As Integer = 0
        If DatabaseType = "SqlServer" Then boolON = 1
        '00 ID                 '01 UsrName            '02 UsrPass            '03 UsrActive      '04 UsrNote           
        '05 acc00              '06 acc01              '07 acc02              '08 acc03          '09 acc04              
        '10 acc05              '11 acc06              '09 acc07              '12 acc08          '13 acc09             
        '14 acc10              '15 acc11              '16 acc12              '17 acc13          '18 acc14        '19 acc15
        '-----------------------------------------------------------------------------------------------------------------
        If GridUsers.RowCount < 1 Then Exit Sub
        Dim r As Integer = e.RowIndex 'count from 0
        Dim c As Integer = e.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Dim valx As String = DS.Tables("tblUsrs").Rows(r).Item(c)
        'MsgBox(r.ToString & " " & c.ToString & " " & valx)
        Select Case c
            Case 1, 2, 4 'using INPUTBOX
                valx = InputBox("Enter new Value for   " & valx, "User Settings", valx)
                DS.Tables("tblUsrs").Rows(r).Item(c) = valx
            Case Else 'Toggle on/off
                If DS.Tables("tblUsrs").Rows(r).Item(c) = 0 Then
                    DS.Tables("tblUsrs").Rows(r).Item(c) = boolON
                Else
                    DS.Tables("tblUsrs").Rows(r).Item(c) = boolOFF
                End If
        End Select
        SaveUserSettings(c, r)
    End Sub
    Private Sub SaveUserSettings(c As Integer, r As Integer)
        Select Case c
            Case 0 : strSQL = "UPDATE Usrs SET ID = @sttvalue WHERE ID = @ID"
            Case 1 : strSQL = "UPDATE Usrs SET UsrName = @sttvalue WHERE ID = @ID"
            Case 2 : strSQL = "UPDATE Usrs SET UsrPass = @sttvalue WHERE ID = @ID"
            Case 3 : strSQL = "UPDATE Usrs SET UsrActive = @sttvalue WHERE ID = @ID"
            Case 4 : strSQL = "UPDATE Usrs SET UsrNote = @sttvalue WHERE ID = @ID"
            Case 5 : strSQL = "UPDATE Usrs SET acc00 = @sttvalue WHERE ID = @ID"
            Case 6 : strSQL = "UPDATE Usrs SET acc01 = @sttvalue WHERE ID = @ID"
            Case 7 : strSQL = "UPDATE Usrs SET acc02 = @sttvalue WHERE ID = @ID"
            Case 8 : strSQL = "UPDATE Usrs SET acc03 = @sttvalue WHERE ID = @ID"
            Case 9 : strSQL = "UPDATE Usrs SET acc04 = @sttvalue WHERE ID = @ID"
            Case 10 : strSQL = "UPDATE Usrs SET acc05 = @sttvalue WHERE ID = @ID"
            Case 11 : strSQL = "UPDATE Usrs SET acc06 = @sttvalue WHERE ID = @ID"
            Case 12 : strSQL = "UPDATE Usrs SET acc07 = @sttvalue WHERE ID = @ID"
            Case 13 : strSQL = "UPDATE Usrs SET acc08 = @sttvalue WHERE ID = @ID"
            Case 14 : strSQL = "UPDATE Usrs SET acc09 = @sttvalue WHERE ID = @ID"
            Case 15 : strSQL = "UPDATE Usrs SET acc10 = @sttvalue WHERE ID = @ID"
            Case 16 : strSQL = "UPDATE Usrs SET acc11 = @sttvalue WHERE ID = @ID"
            Case 17 : strSQL = "UPDATE Usrs SET acc12 = @sttvalue WHERE ID = @ID"
            Case 18 : strSQL = "UPDATE Usrs SET acc13 = @sttvalue WHERE ID = @ID"
            Case 19 : strSQL = "UPDATE Usrs SET acc14 = @sttvalue WHERE ID = @ID"
            Case 20 : strSQL = "UPDATE Usrs SET acc15 = @sttvalue WHERE ID = @ID"
        End Select
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", DS.Tables("tblUsrs").Rows(r).Item(c))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblUsrs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    CnnSS.Dispose()
                End Using
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", DS.Tables("tblUsrs").Rows(r).Item(c))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblUsrs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    CnnSC.Close()
                End Using
            Case "Access"
                Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                    CnnAC.Open()
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", DS.Tables("tblUsrs").Rows(r).Item(c))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblUsrs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    CnnAC.Close()
                End Using
        End Select
    End Sub

    '//MENU
    Private Sub Menu_AddNewUser_Click(sender As Object, e As EventArgs) Handles Menu_AddNewUser.Click
        AddNewUser()
        frmUsers_Load(sender, e)
    End Sub
    Private Sub Menu_DeleteUser_Click(sender As Object, e As EventArgs) Handles Menu_DeleteUser.Click
        If GridUsers.Rows.Count = 0 Then Exit Sub
        Dim iRow As Integer = GridUsers.SelectedCells.Item(0).RowIndex
        If iRow < 0 Then Exit Sub
        Dim intUser2bDel As Integer = Val(GridUsers.Rows(iRow).Cells(0).Value)
        If intUser2bDel < 1 Then Exit Sub
        '//Does this User have some Projects? If yes, dont delete it!
        Try
            DS.Tables("tblProject").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "SELECT * FROM Project WHERE user_ID=" & intUser2bDel.ToString & ";"
                        DASS = New SqlClient.SqlDataAdapter(strSQL, CnnSS)
                        DASS.Fill(DS, "tblProject")
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "SELECT * FROM Project WHERE user_ID=" & intUser2bDel.ToString & ";"
                        DASC = New SqlServerCe.SqlCeDataAdapter(strSQL, CnnSC)
                        DASC.Fill(DS, "tblProject")
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "SELECT * FROM Project WHERE user_ID=" & intUser2bDel.ToString & ";"
                        DAAC = New OleDb.OleDbDataAdapter(strSQL, CnnAC)
                        DAAC.Fill(DS, "tblProject")
                        CnnAC.Close()
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '//Check user's activity (Number of existing projects for this User)
        If DS.Tables("tblProject").Rows.Count > 0 Then
            MsgBox("Selected User has " & DS.Tables("tblProject").Rows.Count.ToString & " Projects. You can not delete this User!", vbOKOnly, "eLib")
            '//reload users table at buttom of this sub
        Else
            Dim myansw As DialogResult = MsgBox("Delete selected 'USER' ?   Are you Sure ?", vbYesNo + vbDefaultButton2, "eLib")
            If myansw = vbNo Then Exit Sub
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM usrs WHERE ID=@id"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@id", intUser2bDel.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM usrs WHERE ID=@id"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@id", intUser2bDel.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM usrs WHERE ID=@id"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@id", intUser2bDel.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        '//Reload Page
        DS.Tables("tblProject").Clear()
        frmUsers_Load(sender, e)
    End Sub
    Private Sub Menu_Settings_Click(sender As Object, e As EventArgs) Handles Menu_Settings.Click
        frmSettings.ShowDialog()
    End Sub
    Private Sub Menu_Scan_Click(sender As Object, e As EventArgs) Handles Menu_Scan.Click
        If DatabaseType = "Access" Then '!BulkInsert works with sqlserver, (not accdb)
            Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strDbBackEnd, vbNormalFocus)
            Exit Sub
        End If
        Dim myansw As DialogResult = MsgBox("eLib Settings :" & vbCrLf & "-" & vbCrLf & "Papers ->   " & strFolderPapers & vbCrLf & "Books ->   " & strFolderBooks & vbCrLf & "Manuals ->   " & strFolderManuals & vbCrLf & "Lectures ->   " & strFolderLectures & vbCrLf & "-" & vbCrLf & vbCrLf & "(YES) Scan Current Folders" & vbCrLf & vbCrLf & "(NO) 'Change' Folders", vbYesNoCancel + vbDefaultButton2, "eLib")
        Select Case myansw
            Case vbNo
                Menu_Settings_Click(sender, e)
                ReadSettingsAndUsers()
                ValidateFolders()
            Case vbYes
                lblInfo.Text = "Step 1/3 : Clear current file Paths . . ."
                Clear_eLibPapersInfo("Paths")
                lblInfo.Text = "Step 2/3 : Scan eLib Folders . . ."
                eLibScanNames() 'equals eLibTitles in old eLib versions
                lblInfo.Text = "Step 3/3 : Constructing new file Paths  . . ."
                eLibScanPaths() 'equals eLibPaths in old eLib versions
                lblInfo.Text = "SCAN finished successfully!"
                MsgBox("SCAN finished successfully!", vbOKOnly + vbInformation, "eLib")
                lblInfo.Text = "eLib     |     USR: " & strUser & "     |     DB: " & strCaption & "     |     BE: " & strDbBackEnd
            Case vbCancel
                'do nothing
        End Select
    End Sub
    Private Sub Menu_Backup_Click(sender As Object, e As EventArgs) Handles Menu_Backup.Click
        lblInfo.Text = "Backup in progress ... Please wait!"
        eLib_Backup()
        lblInfo.Text = "eLib     |     USR: " & strUser & "     |     DB: " & strCaption & "     |     BE: " & strDbBackEnd
        If Retval1 = 1 Then
            lblInfo.Text = "Backup finished successfully!"
        Else
            lblInfo.Text = "Backup Error!"
        End If
    End Sub
    Private Sub Menu_Restore_Click(sender As Object, e As EventArgs) Handles Menu_Restore.Click
        If DatabaseType = "Access" Then 'BulkInser works with sqlserver, (not accdb)
            Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strDbBackEnd, vbNormalFocus)
            Exit Sub
        End If
        Dim myansw As DialogResult = MsgBox("Notice: 'Restore' will ERASE current data in library", vbOKCancel + vbDefaultButton2 + vbExclamation, "eLib")
        If myansw = vbCancel Then Exit Sub
        lblInfo.Text = "Restoring ... Please wait!"
        eLib_Restore()
        lblInfo.Text = "eLib     |     USR: " & strUser & "     |     DB: " & strCaption & "     |     BE: " & strDbBackEnd
        RefreshGridUsers()
        If Retval1 = 1 Then
            lblInfo.Text = "Restore Finished Successfully !"
        Else
            lblInfo.Text = "Restore Error!"
        End If
    End Sub
    Private Sub Menu_ClearDB_Click(sender As Object, e As EventArgs) Handles Menu_ClearDB.Click
        Dim myansw As DialogResult
        If UserType <> "Admin" Then
            myansw = MsgBox("Login as 'Admin' and Try Again", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbOK Then
                Menu_LogOut_Click(sender, e)
                Exit Sub
            Else 'Cancel
                Exit Sub
            End If
        Else 'OK, Admin! continue...
            myansw = MsgBox("This will 'CLEAR' all Data from Current Database" & vbCrLf & "Continue ?", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbCancel Then
                Exit Sub
            Else
                myansw = MsgBox("Are you Sure ?" & vbCrLf & "Continue ?", vbYesNo + vbDefaultButton2 + vbExclamation, "eLib")
                If myansw = vbYes Then '-----------------------------------------------------------------///
                    Randomize()
                    Dim strRndNumber As Integer = Trim(Str(CInt(Int((10000 * Rnd()) + 1001))))
                    Dim strAnsw As String = InputBox("Enter this Code: " & strRndNumber, "Enter Code below to Proceed with Delete", "")
                    If strAnsw <> strRndNumber Then Exit Sub
                    '//OPEN A CONNECTION for this SUB
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                        Case "SqlServerCE"
                            CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                        Case "Access"
                            CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                    End Select
                    '//WIPE-OUT!
                    Clear_eLibPapersInfo("Papers")
                    Clear_eLibPapersInfo("Paths")
                    Clear_eLibProjectsInfo()
                    '//CLOSE ALL Connections
                    Select Case DatabaseType
                        Case "SqlServer"
                            CnnSS.Dispose()
                            CnnSS.Dispose()
                        Case "SqlServerCE"
                            CnnSC.Close()
                            CnnSC.Dispose()
                        Case "Access"
                            CnnAC.Close()
                            CnnAC.Dispose()
                    End Select
                End If '----------------------------------------------------------------------------------///
                RefreshGridUsers()
                lblInfo.Text = "Database Cleared !"
            End If
        End If
    End Sub
    Private Sub Menu_LoginAsAdmin_Click(sender As Object, e As EventArgs) Handles Menu_LoginAsAdmin.Click
        ReadSettingsAndUsers()
        Me.Dispose()
        frmAssign.ShowDialog()
    End Sub
    Private Sub Menu_LoginAsUser_Click(sender As Object, e As EventArgs) Handles Menu_LoginAsUser.Click
        If GridUsers.Rows.Count = 0 Then Exit Sub
        Dim r As Integer = GridUsers.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = GridUsers.SelectedCells(0).ColumnIndex 'count from 0
        If (r < 0) Or (c < 0) Then Exit Sub
        intUser = DS.Tables("tblusrs").Rows(r).Item(0)
        UserType = "User"
        strUser = DS.Tables("tblusrs").Rows(r).Item(1)
        strUserPass = DS.Tables("tblusrs").Rows(r).Item(2)
        '//SetUserAccessControls()
        Dim UACregister As Integer
        For i As Integer = 0 To 15
            If DS.Tables("tblusrs").Rows(r).Item(5 + i) = True Then UACregister = UACregister Or (2 ^ i)
        Next
        UserAccessControls = UACregister
        Me.Dispose()
        frmAssign.ShowDialog()
    End Sub
    Private Sub Menu_LogOut_Click(sender As Object, e As EventArgs) Handles Menu_LogOut.Click
        DeleteHtmlFiles() 'Remove possible existing Data related to other users (now, and also when logging-in via frmCNN as new user )
        Me.Dispose()
        frmCNN.ShowDialog()
    End Sub

End Class