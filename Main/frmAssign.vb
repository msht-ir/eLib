﻿Imports System.IO
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Office

Public Class frmAssign
    Private Sub frmAssign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UserTypes: Admin | Guest | User
        Select Case DatabaseType
            Case "SqlServer"
                CnnSS.Close()
                CnnSS.Dispose()
            Case "SqlServerCE"
                CnnSC.Close()
                CnnSC.Dispose()
            Case "Access"
                CnnAC.Close()
                CnnAC.Dispose()
        End Select
        Dim boolEnbl As Boolean = False
        If UserType = "User" Or UserType = "Guest" Then boolEnbl = False Else boolEnbl = True
        Menu_UsersSpecs.Enabled = boolEnbl
        'Menu_AddUser.Enabled = boolEnbl
        Menu_WipeOutData.Enabled = boolEnbl
        Menu_Backup.Enabled = boolEnbl
        Menu_Restore.Enabled = boolEnbl
        Menu_Settings.Enabled = boolEnbl
        'Menu_Scan.Enabled = boolEnbl
        Try
            Me.Text = "eLib     |     USR: " & strUser & "     |     LIB: " & strCaption & "     |     BE: " & strDbBackEnd
            DS.Tables("tblProject").Clear()
            DS.Tables("tblProduct").Clear()
            DS.Tables("tblAssignments").Clear()
            DS.Tables("tblProductNotes").Clear()
            DS.Tables("tblRefs1").Clear()
            DS.Tables("tblRefs2").Clear()
            ClearLabels(255) 'ie clear all 0-7 lables
            Menu3_Active_Click(sender, e)
            '//Preload Tables Ref1, ProdNote
            DS.Tables("tblProductNotes").Clear()
            DS.Tables("tblRefs2").Clear()
            'tblProductNote
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes WHERE ID =1;", CnnSS)
                        DASS.Fill(DS, "tblProductNotes")
                        CnnSS.Dispose()
                    End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes WHERE ID =1;", CnnSC)
                        DASC.Fill(DS, "tblProductNotes")
                        CnnSC.Close()
                    End Using
                '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("SELECT ID, NoteDatum, [Note], Product_ID FROM ProductNotes WHERE ID =1;", CnnAC)
                        DAAC.Fill(DS, "tblProducNotes")
                        CnnAC.Close()
                    End Using
                    Menu_Scan.Enabled = False
                    Menu_Restore.Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ClearLabels(i As Integer)
        If (i And &H1) = &H1 Then lblRefStatus1.Text = ""      '0:1   0000'0001  RefStatus1 
        If (i And &H2) = &H2 Then lblRefNote1.Text = ""        '1:2   0000'0010  RefNote1
        If (i And &H4) = &H4 Then lblAssignInfo.Text = ""      '2:4   0000'0100  AssignInfo
        If (i And &H4) = &H4 Then lblAssignNote1.Text = ""     '3:8   0000'0100  AssignNote1
        If (i And &H8) = &H8 Then lblProdNote.Text = ""        '4:16  0000'1000  ProdNote
        If (i And &H10) = &H10 Then lblRefStatus2.Text = ""    '5:32  0001'0000  RefStatus2
        If (i And &H20) = &H20 Then lblRefNote2.Text = ""      '6:64  0010'0000  RefNote2
        If (i And &H40) = &H40 Then lblAssignNote2.Text = ""   '7:128 0100'0000  AssignNote2
    End Sub
    'Main Menu
    Private Sub Menu_user_Click(sender As Object, e As EventArgs) Handles Menu_user.Click
        Me.Dispose()
        frmCNN.ShowDialog()
    End Sub
    Private Sub Menu_AddUser_Click(sender As Object, e As EventArgs) Handles Menu_AddUser.Click
        'If UserType <> "Admin" Then
        '    Dim myansw As DialogResult = MsgBox("Login as 'Admin' and Try Again", vbOKCancel + vbDefaultButton2, "eLib")
        '    If myansw = vbOK Then
        '        Menu_user_Click(sender, e)
        '        Exit Sub
        '    Else 'Cancel
        '        Exit Sub
        '    End If
        'End If
        '//OK, Admin! Call: +USER
        AddNewUser()
        '//Now, login!
        Menu_user_Click(sender, e)
    End Sub
    Private Sub Menu_UsersSpecs_Click(sender As Object, e As EventArgs) Handles Menu_UsersSpecs.Click
        If UserType <> "Admin" Then
            Dim myansw As DialogResult = MsgBox("Login as 'Admin' and Try Again", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbOK Then
                Menu_user_Click(sender, e)
                Exit Sub
            Else 'Cancel
                Exit Sub
            End If
        Else 'OK, Admin! continue...
            Me.Dispose()
            frmUsers.ShowDialog()
        End If
    End Sub
    Private Sub Menu_ChangePass_Click(sender As Object, e As EventArgs) Handles Menu_ChangePass.Click
        Select Case UserType
            Case "Guest"
                MsgBox("You have logged in as eLibGuest !", vbOKOnly, "eLib")
                Exit Sub
            Case "Admin"
                Menu_Settings_Click(sender, e)
                Exit Sub
            Case "User"
                'Continue with codes below
        End Select
        'MsgBox("intUser: " & intUser.ToString)
        Dim strOldPass As String = ""
        Dim strNewPass As String = ""
        Dim strCheckPass As String = ""
        strOldPass = strUserPass
        Try
            '//Check current password
            strProjectName = strUser
            strProjectNote = ""
            Retval1 = 2 'User
            Retval2 = 1 'Edit/OldPass?
            Retval3 = -1 'Active
            frmProject.ShowDialog()
            strCheckPass = strProjectNote
            If strCheckPass <> strOldPass Then
                'Try again!
                MsgBox("'Incorrect' Password !    PLEASE TRY AGAIN", vbOKOnly, "eLib")
                strProjectName = strUser
                strProjectNote = ""
                Retval1 = 2 'User
                Retval2 = 1 'Edit/OldPass?
                Retval3 = -1 'Active
                frmProject.ShowDialog()
                strCheckPass = strProjectNote
                If strCheckPass <> strOldPass Then
                    MsgBox("Incorrect Password !" & vbCrLf & "To keep your account secure:  re-Login!", vbOKOnly, "eLib")
                    Menu_user_Click(sender, e)
                    Exit Sub
                End If
            End If
            '//Get new password:
            strProjectName = strUser
            strProjectNote = ""
            Retval1 = 2 'User
            Retval2 = 2 'Edit/newPass?
            Retval3 = -1 'lets be Active
            frmProject.ShowDialog()
            strNewPass = strProjectNote
            If (strNewPass = "") Or (strNewPass = strOldPass) Or (Len(strNewPass) < 6) Then
                MsgBox("Password must be ( NEW ) and greater than ( 6 ) characters !", vbOKOnly, "eLib")
                Exit Sub
            Else 'Re-Enter (confirm) New Password
                strOldPass = strNewPass
                strProjectName = strUser
                strProjectNote = ""
                Retval1 = 2 'User
                Retval2 = 3 'Edit/Re-Enter Pass(confirm)
                Retval3 = -1
                frmProject.ShowDialog()
                strNewPass = strProjectNote
                If strNewPass <> strOldPass Then
                    MsgBox("Incorrect repeat of the new Password ", vbOKOnly, "unsuccessful operation")
                    Exit Sub
                End If
            End If
            'Save new password
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "UPDATE usrs SET UsrPass=@usrpass WHERE ID=@id"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@usrpass", strNewPass)
                        cmd.Parameters.AddWithValue("@id", intUser.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Error updating Password", vbOKOnly, "eLib")
                        End Try
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "UPDATE usrs SET UsrPass=@usrpass WHERE ID=@id"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@usrpass", strNewPass)
                        cmd.Parameters.AddWithValue("@id", intUser.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Error updating Password", vbOKOnly, "eLib")
                        End Try
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "UPDATE usrs SET UsrPass=@usrpass WHERE ID=@id"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@usrpass", strNewPass)
                        cmd.Parameters.AddWithValue("@id", intUser.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Error updating Password", vbOKOnly, "eLib")
                        End Try
                        CnnAC.Close()
                    End Using
            End Select
            strUserPass = strNewPass
            MsgBox("Password Changed !", vbInformation, "eLib")
            Menu_user_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    'Tools
    Private Sub Menu_Import_Click(sender As Object, e As EventArgs) Handles Menu_Import.Click
        Retval3 = 0 'flag for NewImport (not Edit Ref)
        frmImportRefs.ShowDialog()
    End Sub
    Private Sub Menu_CreateWord_Click(sender As Object, e As EventArgs) Handles Menu_CreateWord.Click
        '//Create New Document as Ref
        CreateNewRef(".docx")
    End Sub
    Private Sub Menu_CreatePowepoint_Click(sender As Object, e As EventArgs) Handles Menu_CreatePowepoint.Click
        '//Create New Powerpoint as Ref
        CreateNewRef(".pptx")
    End Sub
    Private Sub Menu_CreateTextFile_Click(sender As Object, e As EventArgs) Handles Menu_CreateTextFile.Click
        '//Create New textfile as Ref
        CreateNewRef(".txt")
    End Sub
    Private Sub Menu_CreateExcel_Click(sender As Object, e As EventArgs) Handles Menu_CreateExcel.Click
        '//Create New Excel spreadsheet as Ref
        CreateNewRef(".xlsx")
    End Sub
    Private Sub CreateNewRef(strRefExt As String)
        Dim myansw As DialogResult = MsgBox("Open New Ref", vbYesNoCancel + vbQuestion + vbDefaultButton2, "eLib")
        If myansw = vbCancel Then Exit Sub
        Try
            Select Case strRefExt
                Case ".docx"
                    strRef = "New Word Document Ref " & Now().ToString("yyyy-MM-dd HH-mm")
                    strPath = Application.StartupPath & strRef & ".docx"
                    FileOpen(1, strPath, OpenMode.Output)
                    FileClose(1)
                Case ".pptx"
                    strRef = "New Powerpoint Ref " & Now().ToString("yyyy-MM-dd HH-mm")
                    strPath = Application.StartupPath & strRef & ".pptx"
                    FileOpen(1, strPath, OpenMode.Output)
                    FileClose(1)
                Case ".txt"
                    strRef = "New Text Document Ref " & Now().ToString("yyyy-MM-dd HH-mm")
                    strPath = Application.StartupPath & strRef & ".txt"
                    FileOpen(1, strPath, OpenMode.Output)
                    FileClose(1)
                Case ".xlsx"
                    Using WB As IXLWorkbook = New XLWorkbook
                        Dim WS0 As IXLWorksheet = WB.Worksheets.Add("eLib_NewExcelRef")
                        WS0.Cell(1, 1).Value = "eLib Col1"
                        WS0.Cell(1, 2).Value = "eLib Col2"
                        WS0.Cell(1, 3).Value = "eLib Col3"
                        '//Save Excel
                        strRef = "New Excel Ref " & Now().ToString("yyyy-MM-dd HH-mm")
                        strPath = Application.StartupPath & strRef & ".xlsx"
                        WB.SaveAs(strPath)
                    End Using
            End Select
            Retval3 = 2 'flag for New Ref Document (not EditRef nor NewImport!)
            strExt = strRefExt
            strRefNote = "Newly created Ref by user"
            strRefType = "Manual"
            frmImportRefs.ShowDialog()
            If myansw = vbYes Then Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strPath, vbNormalFocus)
        Catch ex As Exception
            MsgBox("Error Creating New Ref" & vbCrLf & ex.ToString)
        End Try
    End Sub
    Private Sub Menu_Scan_Click_1(sender As Object, e As EventArgs) Handles Menu_Scan.Click
        If DatabaseType = "Access" Then 'BulkInser works with sqlserver, (not accdb)
            'MsgBox("SCAN Folders using Access database", vbOKOnly, "eLib")
            Exit Sub
        End If
        Dim myansw As DialogResult = MsgBox("eLib Settings :" & vbCrLf & "-" & vbCrLf & "Papers ->   " & strFolderPapers & vbCrLf & "Books ->   " & strFolderBooks & vbCrLf & "Manuals ->   " & strFolderManuals & vbCrLf & "Lectures ->   " & strFolderLectures & vbCrLf & "-" & vbCrLf & vbCrLf & "(YES) Scan Current Folders" & vbCrLf & vbCrLf & "(NO) 'Change' Folders", vbYesNoCancel + vbDefaultButton2, "eLib")
        Select Case myansw
            Case vbNo
                Menu_Settings_Click(sender, e)
                ReadSettingsAndUsers()
                ValidateFolders()
            Case vbYes
                List1.DataSource = Nothing
                List2.DataSource = Nothing
                lblRefNote1.Text = "Step 1/2 : Please  Wait . . ."
                eLibScanNames() 'eLibTitles in old eLib versions
                lblRefNote1.Text = "Step 2/2 : Please  Wait . . . . . ."
                eLibScanPaths() 'eLibPaths in old eLib versions
                lblRefNote1.Text = "SCAN finished successfully!"
                txtSearch.Text = ""
                txtSearch.Focus()
            Case vbCancel
                'do nothing
        End Select
    End Sub
    Private Sub Menu_Backup_Click(sender As Object, e As EventArgs) Handles Menu_Backup.Click
        List1.DataSource = Nothing
        List2.DataSource = Nothing
        List3.DataSource = Nothing
        List4.DataSource = Nothing
        List5.DataSource = Nothing
        List6.DataSource = Nothing
        lblRefNote1.Text = "Backup ... Please wait!"
        eLib_Backup()
        If Retval1 = 1 Then lblRefNote1.Text = "Backup finished successfully!" Else lblRefNote1.Text = "Backup Error!"
        txtSearch.Focus()
    End Sub
    Private Sub Menu_Restore_Click(sender As Object, e As EventArgs) Handles Menu_Restore.Click
        If DatabaseType = "Access" Then 'BulkInser works with sqlserver, (not accdb)
            MsgBox("To Restore a Library, Connect using SqlServer database", vbOKOnly, "eLib")
            Exit Sub
        End If
        List1.DataSource = Nothing
        List2.DataSource = Nothing
        List3.DataSource = Nothing
        List4.DataSource = Nothing
        List5.DataSource = Nothing
        List6.DataSource = Nothing
        'Dim myansw As DialogResult = MsgBox("Notice: 'Restore' will ERASE current data in library", vbOKCancel + vbDefaultButton2 + vbExclamation, "eLib")
        'If myansw = vbCancel Then Exit Sub
        lblRefNote1.Text = "Restoring ... Please wait!"
        eLib_Restore()
        If Retval1 = 1 Then
            lblRefNote1.Text = "Restore Finished Successfully !"
            MsgBox("Restore Finished Successfully !", vbOKOnly, "eLib")
        Else
            lblRefNote1.Text = "Error Restoring a Library!"
        End If
        Menu_user_Click(sender, e)
    End Sub
    Private Sub Menu_WipeOutData_Click(sender As Object, e As EventArgs) Handles Menu_WipeOutData.Click
        Dim myansw As DialogResult
        If UserType <> "Admin" Then
            myansw = MsgBox("Login as 'Admin' and Try Again", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbOK Then
                Menu_user_Click(sender, e)
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
                    WipeOutAndResetCurrentDatabase()
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
                lblRefNote1.Text = "Database Cleared !"
            End If
        End If
    End Sub
    Private Sub Menu_Settings_Click(sender As Object, e As EventArgs) Handles Menu_Settings.Click
        If UserType <> "Admin" Then
            Dim myansw As DialogResult = MsgBox("Login as 'Admin' and Try Again", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbOK Then
                Menu_user_Click(sender, e)
                Exit Sub
            Else 'Cancel
                Exit Sub
            End If
        Else 'OK, Admin! continue...
            frmSettings.ShowDialog()
        End If
    End Sub
    'Help
    Private Sub Menu_Guide_Click(sender As Object, e As EventArgs) Handles Menu_Guide.Click
        Try
            Dim pWeb As Process = New Process()
            pWeb.StartInfo.UseShellExecute = True
            pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir"
            pWeb.Start()
        Catch ex As Exception
            MsgBox("Notice: Help opens with Edge browser", vbOKOnly, "EDGE not found!") 'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu_About_Click(sender As Object, e As EventArgs) Handles Menu_About.Click
        frmAbout.ShowDialog()
    End Sub
    'txtSearch
    Private Sub lblSearch_Click(sender As Object, e As EventArgs) Handles lblSearch.Click
        '//CUT-and-PASTE
        Dim strTempText As String = ""
        '//Step 1
        If Trim(txtSearch.Text) <> "" Then
            strTempText = Trim(txtSearch.Text)
        Else
            strTempText = ""
        End If
        '//Step 2
        Try
            If My.Computer.Clipboard.ContainsText() Then txtSearch.Text = My.Computer.Clipboard.GetText()
        Catch ex As Exception
            My.Computer.Clipboard.SetText("")
            txtSearch.Text = ""
        End Try
        '//Step 3
        If Trim(strTempText) <> "" Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(strTempText)
        End If
        txtSearch.SelectionStart = Len(txtSearch.Text)
    End Sub
    Private Sub lblSearch_DoubleClick(sender As Object, e As EventArgs) Handles lblSearch.DoubleClick
        If Trim(txtSearch.Text) <> "" Then
            Try
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(Trim(txtSearch.Text)) '1 Copy to ClipBoard from textBox
                txtSearch.Text = ""
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtSearchP_Click(sender As Object, e As EventArgs) Handles txtSearchP.Click
        If txtSearchP.Checked = True Then txtSearchP.Checked = False Else txtSearchP.Checked = True
        txtSearch.Focus()
    End Sub
    Private Sub txtSearchB_Click(sender As Object, e As EventArgs) Handles txtSearchB.Click
        If txtSearchB.Checked = True Then txtSearchB.Checked = False Else txtSearchB.Checked = True
        txtSearch.Focus()
    End Sub
    Private Sub txtSearchM_Click(sender As Object, e As EventArgs) Handles txtSearchM.Click
        If txtSearchM.Checked = True Then txtSearchM.Checked = False Else txtSearchM.Checked = True
        txtSearch.Focus()
    End Sub
    Private Sub txtSearchL_Click(sender As Object, e As EventArgs) Handles txtSearchL.Click
        If txtSearchL.Checked = True Then txtSearchL.Checked = False Else txtSearchL.Checked = True
        txtSearch.Focus()
    End Sub
    Private Sub txtSearchAll_Click(sender As Object, e As EventArgs) Handles txtSearchAll.Click
        txtSearchP.Checked = True
        txtSearchB.Checked = True
        txtSearchM.Checked = True
        txtSearchL.Checked = True
        txtSearch.Focus()
    End Sub
    Private Sub txtSearchRevrs_Click(sender As Object, e As EventArgs) Handles txtSearchRevrs.Click
        If txtSearchP.Checked = True Then txtSearchP.Checked = False Else txtSearchP.Checked = True
        If txtSearchB.Checked = True Then txtSearchB.Checked = False Else txtSearchB.Checked = True
        If txtSearchM.Checked = True Then txtSearchM.Checked = False Else txtSearchM.Checked = True
        If txtSearchL.Checked = True Then txtSearchL.Checked = False Else txtSearchL.Checked = True
        txtSearch.Focus()
    End Sub
    Private Sub txtSearch_DoubleClick(sender As Object, e As EventArgs) Handles txtSearch.DoubleClick
        If Trim(txtSearch.Text) = "" Then
            'Paste
            If My.Computer.Clipboard.ContainsText() Then txtSearch.Text = My.Computer.Clipboard.GetText()
        Else
            'keep empty
            txtSearch.Text = ""
        End If
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Select Case e.KeyCode
            Case 38 : List1.Focus() 'UP
            Case 40 : List3.Focus() 'DOWN
        End Select
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If Microsoft.VisualBasic.Right(txtSearch.Text, 1) = " " Then
            DS.Tables("tblRefs1").Clear()
            DS.Tables("tblAssignments").Clear()
            If Trim(txtSearch.Text) = "" Then
                txtSearch.Text = ""
            Else 'OK, there are some keys to search
                Dim searchString As String = Trim(txtSearch.Text)
                FindRefs(searchString)
                List1.SelectedValue = -1
                DS.Tables("tblAssignments").Clear()
                '//Clear labels in top of the form
                ClearLabels(15) '15:&B00001111
            End If
        End If
    End Sub
    Private Sub FindRefs(searchString As String)
        txtSearch.Focus()
        intRefType = 0
        If txtSearchP.Checked = True Then intRefType = intRefType Or &H1 '0b0001 for papers
        If txtSearchB.Checked = True Then intRefType = intRefType Or &H2 '0b0010 for books
        If txtSearchM.Checked = True Then intRefType = intRefType Or &H4 '0b0100 for manuals
        If txtSearchL.Checked = True Then intRefType = intRefType Or &H8 '0b1000 for lectures
        If intRefType = 0 Then
            MsgBox("Select some Ref types to search, and try again", vbOKOnly, "eLib")
            Exit Sub
        End If
        Dim KeyxA As String = "", Keyx1 As String = "", Keyx2 As String = "", Keyx3 As String = "", Keyx4 As String = "", Fltr As String = ""
        Dim spcz(3) As Integer
        '//locate spaces in the search string [ save nSPC in scpz(0) ]
        KeyxA = searchString
        Dim k As Integer = 0
        For i = 1 To Len(KeyxA)
            If Mid(KeyxA, i, 1) = " " Then
                k = k + 1
                If k = 4 Then Exit For
                spcz(k) = i
            End If
        Next i
        spcz(0) = k
        '//how many spaces?
        Select Case spcz(0)
            Case 0 'no space; one key
                Fltr = "(Papers.PaperName Like '%" & KeyxA & "%' OR Papers.Note Like '%" & KeyxA & "%')"
            Case 1 '1 space; 2 keys
                'Keyx1 = Mid(KeyxA, 1, spcz(1) - 1)
                Keyx1 = Microsoft.VisualBasic.Left(KeyxA, spcz(1) - 1)
                Keyx2 = Mid(KeyxA, spcz(1) + 1)
                Fltr = "(Papers.PaperName Like '%" & Keyx1 & "%' OR Papers.Note Like '%" & Keyx1 & "%') AND "
                Fltr = Fltr & "(Papers.PaperName Like '%" & Keyx2 & "%' OR Papers.Note Like '%" & Keyx2 & "%')"
            Case 2 '2 spaces; 3 keys
                Keyx1 = Microsoft.VisualBasic.Left(KeyxA, spcz(1) - 1)
                Keyx2 = Mid(KeyxA, spcz(1) + 1, spcz(2) - spcz(1) - 1)
                Keyx3 = Mid(KeyxA, spcz(2) + 1)
                Fltr = "(Papers.PaperName Like '%" & Keyx1 & "%' OR Papers.Note Like '%" & Keyx1 & "%') AND "
                Fltr = Fltr & "(Papers.PaperName Like '%" & Keyx2 & "%' OR Papers.Note Like '%" & Keyx2 & "%') AND "
                Fltr = Fltr & "(Papers.PaperName Like '%" & Keyx3 & "%' OR Papers.Note Like '%" & Keyx3 & "%')"
            Case 3, 4
                Keyx1 = Microsoft.VisualBasic.Left(KeyxA, spcz(1) - 1)
                Keyx2 = Mid(KeyxA, spcz(1) + 1, spcz(2) - spcz(1) - 1)
                Keyx3 = Mid(KeyxA, spcz(2) + 1, spcz(3) - spcz(2) - 1)
                Keyx4 = Mid(KeyxA, spcz(3) + 1)
                Fltr = "(Papers.PaperName Like '%" & Keyx1 & "%' OR Papers.Note Like '%" & Keyx1 & "%') AND "
                Fltr = Fltr & "(Papers.PaperName Like '%" & Keyx2 & "%' OR Papers.Note Like '%" & Keyx2 & "%') AND "
                Fltr = Fltr & "(Papers.PaperName Like '%" & Keyx3 & "%' OR Papers.Note Like '%" & Keyx3 & "%') AND "
                Fltr = Fltr & "(Papers.PaperName Like '%" & Keyx4 & "%' OR Papers.Note Like '%" & Keyx4 & "%')"
        End Select
        'Search in which Ref types?   [0b 1111 bits:LMBP]
        If intRefType <> 15 Then '15: 0b1111 : All types are selected
            Fltr = Fltr & " AND (" '----------start filter on intreftype
            Select Case DatabaseType
                Case "SqlServer" '----------------------------------------------------- sqlserver
                    Select Case intRefType
                        Case 1  ' ---P
                            Fltr = Fltr & "IsPaper=1"
                        Case 2   ' --B-
                            Fltr = Fltr & "IsBook=1"
                        Case 3   ' --BP
                            Fltr = Fltr & "IsPaper=1 AND IsBook=1"
                        Case 4   ' -M--
                            Fltr = Fltr & "IsManual=1"
                        Case 5   ' -M-P
                            Fltr = Fltr & "IsPaper=1 AND IsManual=1"
                        Case 6   ' -MB-
                            Fltr = Fltr & "IsBook=1 AND IsManual=1"
                        Case 7   ' -MBP
                            Fltr = Fltr & "IsLecture=0"
                        Case 8   ' L---
                            Fltr = Fltr & "IsLecture=1"
                        Case 9   ' L--P
                            Fltr = Fltr & "IsLecture=1 AND IsPaper=1"
                        Case 10  ' L-B-
                            Fltr = Fltr & "IsLecture=1 AND IsBook=1"
                        Case 11  ' L-BP
                            Fltr = Fltr & "IsManual=0"
                        Case 12  ' LM--
                            Fltr = Fltr & "IsLecture=1 AND IsManual=1"
                        Case 13  ' LM-P
                            Fltr = Fltr & "IsBook=0"
                        Case 14  ' LMB-
                            Fltr = Fltr & "IsPaper=0"
                    End Select
                Case "Access", "SqlServerCE" '----------------------------------------------------- accdb
                    Select Case intRefType
                        Case 1  ' ---P
                            Fltr = Fltr & "IsPaper=-1"
                        Case 2   ' --B-
                            Fltr = Fltr & "IsBook=-1"
                        Case 3   ' --BP
                            Fltr = Fltr & "IsPaper=-1 AND IsBook=-1"
                        Case 4   ' -M--
                            Fltr = Fltr & "IsManual=-1"
                        Case 5   ' -M-P
                            Fltr = Fltr & "IsPaper=-1 AND IsManual=-1"
                        Case 6   ' -MB-
                            Fltr = Fltr & "IsBook=-1 AND IsManual=-1"
                        Case 7   ' -MBP
                            Fltr = Fltr & "IsLecture=0"
                        Case 8   ' L---
                            Fltr = Fltr & "IsLecture=-1"
                        Case 9   ' L--P
                            Fltr = Fltr & "IsLecture=-1 AND IsPaper=-1"
                        Case 10  ' L-B-
                            Fltr = Fltr & "IsLecture=-1 AND IsBook=-1"
                        Case 11  ' L-BP
                            Fltr = Fltr & "IsManual=0"
                        Case 12  ' LM--
                            Fltr = Fltr & "IsLecture=-1 AND IsManual=-1"
                        Case 13  ' LM-P
                            Fltr = Fltr & "IsBook=0"
                        Case 14  ' LMB-
                            Fltr = Fltr & "IsPaper=0"
                    End Select
            End Select
            Fltr = Fltr & ")" '----------finish filter on intReftype
        End If
        '//Do Query
        Try
            DS.Tables("tblRefs1").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.PaperName DESC;", CnnSS)
                        DASS.Fill(DS, "tblRefs1")
                        CnnSS.Dispose()
                    End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.PaperName DESC;", CnnSC)
                        DASC.Fill(DS, "tblRefs1")
                        CnnSC.Close()
                    End Using
                '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.PaperName DESC;", CnnAC)
                        DAAC.Fill(DS, "tblRefs1")
                        CnnAC.Close()
                    End Using
            End Select
            '--------- end select --------- end select --------- end select --------- end select --------- end select --------- end select --------- end select
            List1.DataSource = DS.Tables("tblRefs1")
            List1.DisplayMember = "PaperName"
            List1.ValueMember = "Papers.ID"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '//nrows?
        If DS.Tables("tblRefs1").Rows.Count = 0 Then
            Select Case spcz(0)
                Case 0 : txtSearch.Text = ""
                Case 1 : txtSearch.Text = Keyx1
                Case 2 : txtSearch.Text = Keyx1 & " " & Keyx2
                Case 3, 4 : txtSearch.Text = Keyx1 & " " & Keyx2 & " " & Keyx3
            End Select
            If Microsoft.VisualBasic.Right(txtSearch.Text, 1) <> " " Then txtSearch.Text = txtSearch.Text + " ."
            txtSearch.SelectionStart = Len(txtSearch.Text)
        End If
    End Sub

    'List 1 (Refs1)
    Private Sub Menu1_Import_Click(sender As Object, e As EventArgs) Handles Menu1_Import.Click
        Menu_Import_Click(sender, e)
    End Sub
    Private Sub Menu1_Read_Click(sender As Object, e As EventArgs) Handles Menu1_Read.Click
        If List1.SelectedIndex >= 0 Then
            strRef = Trim(List1.Text)
            If strRef <> "" Then frmReadRef.ShowDialog()
        End If
    End Sub
    Private Sub List1_Click(sender As Object, e As EventArgs) Handles List1.Click
        If List1.SelectedIndex = -1 Then Exit Sub
        '//Clear labels in top of form 
        ClearLabels(15) '15:&B00001111
        intRef = List1.SelectedValue
        GetAssignments1(intRef)
        List2.DataSource = DS.Tables("tblAssignments")
        List2.DisplayMember = "ProductName"
        List2.ValueMember = "Product_ID"
        List2.SelectedValue = -1
        Try
            strRefType = ""
            If DS.Tables("tblRefs1").Rows(List1.SelectedIndex).Item(2) = True Then strRefType = strRefType & "Paper  "
            If DS.Tables("tblRefs1").Rows(List1.SelectedIndex).Item(3) = True Then strRefType = strRefType & "Book  "
            If DS.Tables("tblRefs1").Rows(List1.SelectedIndex).Item(4) = True Then strRefType = strRefType & "Manual  "
            If DS.Tables("tblRefs1").Rows(List1.SelectedIndex).Item(5) = True Then strRefType = strRefType & "Lecture  "
            lblRefStatus1.Text = strRefType
            strRefNote = DS.Tables("tblRefs1").Rows(List1.SelectedIndex).Item(6)
            lblRefNote1.Text = strRefNote
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetAssignments1(refid As Integer)
        Select Case UserType
            Case "Admin"
                strSQL = "SELECT Paper_Product.ID, Paper_ID, Product_ID, ProductName, Paper_Product.Note, user_ID FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID WHERE Paper_ID=" & refid.ToString & " ORDER BY ProductName;"
            Case "User", "Guest"
                strSQL = "SELECT Paper_Product.ID, Paper_ID, Product_ID, ProductName, Paper_Product.Note, user_ID FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID WHERE Paper_ID=" & refid.ToString & " AND user_ID= " & intUser & " ORDER BY ProductName;"
        End Select
        DS.Tables("tblAssignments").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DASS = New SqlClient.SqlDataAdapter(strSQL, CnnSS)
                    DASS.Fill(DS, "tblAssignments")
                    CnnSS.Dispose()
                End Using
            '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    DASC = New SqlServerCe.SqlCeDataAdapter(strSQL, CnnSC)
                    DASC.Fill(DS, "tblAssignments")
                    CnnSC.Close()
                End Using
            '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
            Case "Access"
                Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                    CnnAC.Open()
                    DAAC = New OleDb.OleDbDataAdapter(strSQL, CnnAC)
                    DAAC.Fill(DS, "tblAssignments")
                    CnnAC.Close()
                End Using
        End Select
    End Sub
    Private Sub List1_DoubleClick(sender As Object, e As EventArgs) Handles List1.DoubleClick
        Menu1_Read_Click(sender, e)
    End Sub
    Private Sub Menu1_Assign_Click(sender As Object, e As EventArgs) Handles Menu1_Assign.Click
        intRef = List1.SelectedValue
        intProd = List4.SelectedValue
        If intRef < 1 Or intProd < 1 Then Exit Sub
        Dim i As Boolean = DoAssignRef2Prod(intRef, intProd)
        If i = True Then
            List1_Click(sender, e) 'refresh list2
            List4_Click(sender, e) 'refresh list5
        Else
            MsgBox("Error Assigning Ref to Product!", vbOKOnly, "eLib")
        End If
    End Sub
    Private Sub Menu_1AssignTo_Click(sender As Object, e As EventArgs) Handles Menu_1AssignTo.Click
        intRef = List1.SelectedValue
        frmChooseProject.ShowDialog()
        If Retval1 = 2 Then '//1: A Product is selected from dialog //intProd=id of the selected Product
            If intRef < 1 Or intProd < 1 Then Exit Sub
            Dim i As Boolean = DoAssignRef2Prod(intRef, intProd)
            If i = True Then
                List1_Click(sender, e) 'refresh list2
                List4_Click(sender, e) 'refresh list5
            Else
                MsgBox("Error Assigning Ref to Product!", vbOKOnly, "eLib")
            End If
        End If
    End Sub
    Private Function DoAssignRef2Prod(iRef As Integer, iProd As Integer) As Boolean
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperid", intRef.ToString)
                        cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperid", intRef.ToString)
                        cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperid", intRef.ToString)
                        cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            DoAssignRef2Prod = True
        Catch ex As Exception
            DoAssignRef2Prod = False
        End Try
    End Function
    Private Sub Menu1_GetList_Click(sender As Object, e As EventArgs) Handles Menu1_ListSubProject.Click
        frmChooseProject.ShowDialog()
        Select Case Retval1
            Case 0 'was Canceled
                Exit Sub
            Case 1 'a project is selected
                Try
                    DS.Tables("tblRefs1").Clear()
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                CnnSS.Open()
                                DASS = New SqlClient.SqlDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Project_ID = " & intProj.ToString & " Order By PaperName DESC;", CnnSS)
                                DASS.Fill(DS, "tblRefs1")
                                CnnSS.Dispose()
                            End Using
                        Case "SqlServerCE"
                            Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                CnnSC.Open()
                                DASC = New SqlServerCe.SqlCeDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Project_ID = " & intProj.ToString & " Order By PaperName DESC;", CnnSC)
                                DASC.Fill(DS, "tblRefs1")
                                CnnSC.Close()
                            End Using
                        Case "Access"
                            Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                                CnnAC.Open()
                                DAAC = New OleDb.OleDbDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Project_ID = " & intProj.ToString & " Order By PaperName DESC;", CnnAC)
                                DAAC.Fill(DS, "tblRefs1")
                                CnnAC.Close()
                            End Using
                    End Select
                Catch ex As Exception
                End Try
            Case 2 'a product is selected
                Try
                    DS.Tables("tblRefs1").Clear()
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                CnnSS.Open()
                                DASS = New SqlClient.SqlDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & intProd.ToString & " Order By PaperName DESC;", CnnSS)
                                DASS.Fill(DS, "tblRefs1")
                                CnnSS.Dispose()
                            End Using
                        Case "SqlServerCE"
                            Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                CnnSC.Open()
                                DASC = New SqlServerCe.SqlCeDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & intProd.ToString & " Order By PaperName DESC;", CnnSC)
                                DASC.Fill(DS, "tblRefs1")
                                CnnSC.Close()
                            End Using
                        Case "Access"
                            Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                                CnnAC.Open()
                                DAAC = New OleDb.OleDbDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & intProd.ToString & " Order By PaperName DESC;", CnnAC)
                                DAAC.Fill(DS, "tblRefs1")
                                CnnAC.Close()
                            End Using
                    End Select
                Catch ex As Exception
                End Try
        End Select
        List1.DataSource = DS.Tables("tblRefs1")
        List1.DisplayMember = "Papername"
        List1.ValueMember = "Papers.ID"
        DS.Tables("tblAssignments").Clear()
        ClearLabels(15) '15: &B00001111
    End Sub
    Private Sub Menu1_RefNote_Click(sender As Object, e As EventArgs) Handles Menu1_RefNote.Click
        '//Note for Ref
        If List1.SelectedIndex = -1 Then Exit Sub
        Dim i As Integer = List1.SelectedIndex
        strRefNote = DS.Tables("tblRefs1").Rows(i).Item(6)
        Dim intID As Integer = DS.Tables("tblRefs1").Rows(i).Item(0)
        strRefNote = InputBox("Edit Ref-Note:", "eLib", strRefNote)
        If Trim(strRefNote) = "" Then
            Dim myansw As DialogResult = MsgBox("clear Note ?", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbCancel Then Exit Sub
        End If
        '//Do change the Note
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "UPDATE Papers SET Papers.Note=@note WHERE ID=@id"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@note", strRefNote)
                        cmdx.Parameters.AddWithValue("@id", intID.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "UPDATE Papers SET Papers.Note=@note WHERE ID=@id"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@note", strRefNote)
                        cmdx.Parameters.AddWithValue("@id", intID.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "UPDATE Papers SET Papers.Note=@note WHERE ID=@id"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@note", strRefNote)
                        cmdx.Parameters.AddWithValue("@id", intID.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            DS.Tables("tblRefs1").Rows(i).Item(6) = strRefNote
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
        List1_Click(sender, e)
    End Sub
    Private Sub lblRefNote1_DoubleClick(sender As Object, e As EventArgs) Handles lblRefNote1.DoubleClick
        Menu1_RefNote_Click(sender, e)
    End Sub
    Private Sub Menu1_Copy_Click(sender As Object, e As EventArgs) Handles Menu1_Copy.Click
        If List1.SelectedIndex >= 0 Then
            My.Computer.Clipboard.SetText(List1.Text)
            lblRefNote1.Text = "'Title' coppied to clipboard"
        End If
    End Sub
    Private Sub Menu1_QRCode_Click(sender As Object, e As EventArgs) Handles Menu1_QRCode.Click
        '//check if tbl.Settings allows QRCODEGen ?
        If List1.SelectedIndex >= 0 Then Call QRCodeGen(List1.Text)
    End Sub
    Private Sub Menu1_GoogleScholar_Click(sender As Object, e As EventArgs) Handles Menu1_GoogleScholar.Click
        If List1.SelectedIndex >= 0 Then
            Dim strSearchScholar As String = List1.Text
            SearchScholar(strSearchScholar)
        End If
    End Sub
    Private Sub Menu1_ImR_Click(sender As Object, e As EventArgs) Handles Menu1_ImR.Click
        GetImportantRefs("ImR")
        List1.DataSource = DS.Tables("tblRefs1")
        List1.DisplayMember = "PaperName"
        List1.ValueMember = "Papers.ID"
    End Sub
    Private Sub GetImportantRefs(Imx As String)
        Try
            DS.Tables("tblRefs1").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE user_ID = " & intUser.ToString & " And " & Imx & "= 1 Order By PaperName DESC;", CnnSS)
                        DASS.Fill(DS, "tblRefs1")
                        CnnSS.Dispose()
                    End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE user_ID = " & intUser.ToString & " And " & Imx & "= 1 Order By PaperName DESC;", CnnSC)
                        DASC.Fill(DS, "tblRefs1")
                        CnnSC.Close()
                    End Using
                '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE user_ID = " & intUser.ToString & " And " & Imx & "= -1 Order By PaperName DESC;", CnnAC)
                        DAAC.Fill(DS, "tblRefs1")
                        CnnAC.Close()
                    End Using
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Menu1_Imp1_Click(sender As Object, e As EventArgs) Handles Menu1_Imp1.Click
        GetImportantRefs("Imp1")
        List1.DataSource = DS.Tables("tblRefs1")
        List1.DisplayMember = "PaperName"
        List1.ValueMember = "Papers.ID"
    End Sub
    Private Sub Menu1_Imp2_Click(sender As Object, e As EventArgs) Handles Menu1_Imp2.Click
        GetImportantRefs("Imp2")
        List1.DataSource = DS.Tables("tblRefs1")
        List1.DisplayMember = "PaperName"
        List1.ValueMember = "Papers.ID"
    End Sub
    Private Sub Menu1_Imp3_Click(sender As Object, e As EventArgs) Handles Menu1_Imp3.Click
        GetImportantRefs("Imp3")
        List1.DataSource = DS.Tables("tblRefs1")
        List1.DisplayMember = "PaperName"
        List1.ValueMember = "Papers.ID"
    End Sub
    Private Sub Menu1_ImpAll_Click(sender As Object, e As EventArgs) Handles Menu1_ImpAll.Click
        GetImportantRefs("Imp1=True OR Imp2=True OR Imp3")
        List1.DataSource = DS.Tables("tblRefs1")
        List1.DisplayMember = "PaperName"
        List1.ValueMember = "Papers.ID"
    End Sub
    Private Sub Menu1_Delete_Click(sender As Object, e As EventArgs) Handles Menu1_Delete.Click
        If List1.SelectedIndex = -1 Then Exit Sub
        intRef = List1.SelectedValue
        If intRef < 1 Then Exit Sub
        '//check if this Ref was assigned, if yes, dont delete it 
        If DS.Tables("tblAssignments").Rows.Count > 0 Then
            MsgBox("This Ref is Assigned to some subProjects !" & vbCrLf & "Could not be Deleted", vbOKOnly, "eLib")
            Exit Sub
        Else
            Dim myansw As DialogResult = MsgBox("Delete this Ref?", vbYesNo, "eLib")
            If myansw = vbYes Then
                Try
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                CnnSS.Open()
                                strSQL = "DELETE FROM Papers WHERE ID=@refid"
                                Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmdx.CommandType = CommandType.Text
                                cmdx.Parameters.AddWithValue("@refid", intRef.ToString)
                                Dim ix As Integer = cmdx.ExecuteNonQuery()
                                CnnSS.Dispose()
                            End Using
                        Case "SqlServerCE"
                            Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                CnnSC.Open()
                                strSQL = "DELETE FROM Papers WHERE ID=@refid"
                                Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmdx.CommandType = CommandType.Text
                                cmdx.Parameters.AddWithValue("@refid", intRef.ToString)
                                Dim ix As Integer = cmdx.ExecuteNonQuery()
                                CnnSC.Close()
                            End Using
                        Case "Access"
                            Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                                CnnAC.Open()
                                strSQL = "DELETE FROM Papers WHERE ID=@refid"
                                Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmdx.CommandType = CommandType.Text
                                cmdx.Parameters.AddWithValue("@refid", intRef.ToString)
                                Dim ix As Integer = cmdx.ExecuteNonQuery()
                                CnnAC.Close()
                            End Using
                    End Select
                    txtSearch_TextChanged(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub

    'List 2 (Assigned)
    Private Sub List2_KeyDown(sender As Object, e As KeyEventArgs) Handles List2.KeyDown
        Select Case e.KeyCode
            Case 37 : List1.Focus()
            Case 39 : List3.Focus()
        End Select
    End Sub
    Private Sub List2_Click(sender As Object, e As EventArgs) Handles List2.Click
        If List2.SelectedIndex = -1 Then Exit Sub
        Try
            lblAssignNote1.Text = DS.Tables("tblAssignments").Rows(List2.SelectedIndex).Item(4)
            Dim intKarbar As Integer = DS.Tables("tblAssignments").Rows(List2.SelectedIndex).Item(5)
            For i = 0 To DS.Tables("tblUsrs").Rows.Count - 1
                'MsgBox("intKarbar: " & intKarbar.ToString & " /  " & i.ToString & ":i  / id: " & DS.Tables("tblUsrs").Rows(i).Item(0) & " / user: " & DS.Tables("tblUsrs").Rows(i).Item(1))
                If DS.Tables("tblUsrs").Rows(i).Item(0) = intKarbar Then
                    lblAssignInfo.Text = "usr: " & DS.Tables("tblUsrs").Rows(i).Item(1)
                    Exit Sub
                End If
            Next i
            lblAssignInfo.Text = "" '//in case no matching user-id was found
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString)
        End Try
    End Sub
    Private Sub List2_DoubleClick(sender As Object, e As EventArgs) Handles List2.DoubleClick
        Menu2_Note_Click(sender, e)
    End Sub
    Private Sub Menu2_Note_Click(sender As Object, e As EventArgs) Handles Menu2_Note.Click
        '//Edit Note
        If List2.SelectedIndex = -1 Then Exit Sub
        Dim i As Integer = List2.SelectedIndex
        Dim strPPNote As String = DS.Tables("tblAssignments").Rows(i).Item(4)
        Dim intID As Integer = DS.Tables("tblAssignments").Rows(i).Item(0)
        strPPNote = InputBox("Edit Note for this Assignment:", "eLib", strPPNote)
        If Trim(strPPNote) = "" Then
            Dim myansw As DialogResult = MsgBox("clear Note ?", vbOKCancel + vbDefaultButton2, "eLib")
            If myansw = vbCancel Then Exit Sub
        End If
        '//Do change the Note
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "UPDATE Paper_Product SET Paper_Product.Note=@note WHERE ID=@id"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@note", strPPNote)
                        cmdx.Parameters.AddWithValue("@id", intID.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "UPDATE Paper_Product SET Paper_Product.Note=@note WHERE ID=@id"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@note", strPPNote)
                        cmdx.Parameters.AddWithValue("@id", intID.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "UPDATE Paper_Product SET Paper_Product.Note=@note WHERE ID=@id"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@note", strPPNote)
                        cmdx.Parameters.AddWithValue("@id", intID.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
        DS.Tables("tblAssignments").Rows(i).Item(4) = strPPNote
        List2_Click(sender, e)
    End Sub
    Private Sub lblAssignNote1_DoubleClick(sender As Object, e As EventArgs) Handles lblAssignNote1.DoubleClick
        Menu2_Note_Click(sender, e)
    End Sub
    Private Sub Menu2_Filter_Click(sender As Object, e As EventArgs) Handles Menu2_Filter.Click
        If List2.SelectedIndex >= 0 Then
            intProd = List2.SelectedValue
            Try
                DS.Tables("tblRefs1").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            DASS = New SqlClient.SqlDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & intProd.ToString & " Order By PaperName DESC;", CnnSS)
                            DASS.Fill(DS, "tblRefs1")
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            DASC = New SqlServerCe.SqlCeDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & intProd.ToString & " Order By PaperName DESC;", CnnSC)
                            DASC.Fill(DS, "tblRefs1")
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            DAAC = New OleDb.OleDbDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & intProd.ToString & " Order By PaperName DESC;", CnnAC)
                            DAAC.Fill(DS, "tblRefs1")
                            CnnAC.Close()
                        End Using
                End Select
            Catch ex As Exception
            End Try
            List1.DataSource = DS.Tables("tblRefs1")
            List1.DisplayMember = "Papername"
            List1.ValueMember = "Papers.ID"
            List1.SelectedIndex = -1
            DS.Tables("tblAssignments").Clear()
            ClearLabels(15) '15: &B00001111 (clra lbls in top of from)
        End If
    End Sub
    Private Sub Menu2_Remove_Click(sender As Object, e As EventArgs) Handles Menu2_Remove.Click
        'notice: only user's own assignments are listed in list 2, so user cannot removeother's assignments! this function is safe. 
        intAssign = DS.Tables("tblAssignments").Rows(List2.SelectedIndex).Item(0) 'see GetAssignments1 above
        If intAssign < 1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("Delete this Assignment?", vbYesNo, "eLib")
        If myansw = vbYes Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM Paper_Product WHERE ID=@assignid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@assignid", intAssign.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM Paper_Product WHERE ID=@assignid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@assignid", intAssign.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM Paper_Product WHERE ID=@assignid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@assignid", intAssign.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                intRef = List1.SelectedValue
                GetAssignments1(intRef) 'refresh list2
                If List4.SelectedIndex >= 0 Then
                    intProd = List4.SelectedValue
                    GetRefs(intProd) 'refresh list5
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    'List 3 (Projects)
    Private Sub List3_KeyDown(sender As Object, e As KeyEventArgs) Handles List3.KeyDown
        Select Case e.KeyCode
            Case 37 : txtSearch.Focus() '<-
            Case 39 : List4.Focus() '->
        End Select
    End Sub
    Private Sub Menu3_Add_Click(sender As Object, e As EventArgs) Handles Menu3_Add.Click
        If (UserType = "Guest") Or (UserType = "Admin") Then Exit Sub
        'strProjectName | strProjectNote
        Retval1 = 0 'project
        Retval2 = 0 'new project
        Retval3 = 1 'active
        '//Dialog to get new Proj info
        frmProject.ShowDialog()
        Try
            If Retval1 = 1 Then 'Save it
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            If Retval3 = -1 Then Retval3 = 1 '//sqlserver:TRUE=1 accdb:TRUE=-1 
                            strSQL = "INSERT INTO Project (ProjectName, Notes, Active, user_ID) VALUES (@projectname, @notes, @active, @userid)"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@active", Retval3)
                            cmdx.Parameters.AddWithValue("@userid", intUser.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            If Retval3 = -1 Then Retval3 = 1 '//sqlserver:TRUE=1 accdb:TRUE=-1 
                            strSQL = "INSERT INTO Project (ProjectName, Notes, Active, user_ID) VALUES (@projectname, @notes, @active, @userid)"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@active", Retval3)
                            cmdx.Parameters.AddWithValue("@userid", intUser.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "INSERT INTO Project (ProjectName, Notes, Active, user_ID) VALUES (@projectname, @notes, @active, @userid)"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@active", Retval3)
                            cmdx.Parameters.AddWithValue("@userid", intUser.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                '//Add a subProject for this new Project
                Menu3_Active_Click(sender, e) 'refresh list3 itself!
                For k As Integer = 0 To DS.Tables("tblProject").Rows.Count - 1
                    If DS.Tables("tblProject").Rows(k).Item(1) = strProjectName Then
                        List3.SelectedIndex = k
                        Exit For
                    End If
                Next
                AddNewProduct(0) '{0: auto add product for new Project | 1: add extra product for a already existing project}
            Else
                'MsgBox("Canceled", vbOKOnly, "eLib")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
    End Sub
    Private Sub Menu3_Edit_Click(sender As Object, e As EventArgs) Handles Menu3_Edit.Click
        intProj = List3.SelectedValue
        If intProj < 1 Then Exit Sub
        Retval1 = 0 'project
        Retval2 = 1 'edit project
        Retval3 = DS.Tables("tblProject").Rows(List3.SelectedIndex).Item(3) 'active/inactive
        strProjectName = DS.Tables("tblProject").Rows(List3.SelectedIndex).Item(1)
        strProjectNote = DS.Tables("tblProject").Rows(List3.SelectedIndex).Item(2)
        frmProject.ShowDialog()
        Try
            If Retval1 = 1 Then 'save it
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            If Retval3 = -1 Then Retval3 = 1 '//sqlserver:TRUE=1 accdb:TRUE=-1 
                            strSQL = "UPDATE Project SET ProjectName=@projectname, Notes=@notes, Active=@active WHERE ID=@id"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@active", Retval3.ToString)
                            cmdx.Parameters.AddWithValue("@id", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "UPDATE Project SET ProjectName=@projectname, Notes=@notes, Active=@active WHERE ID=@id"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@active", Retval3.ToString)
                            cmdx.Parameters.AddWithValue("@id", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "UPDATE Project SET ProjectName=@projectname, Notes=@notes, Active=@active WHERE ID=@id"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@active", Retval3.ToString)
                            cmdx.Parameters.AddWithValue("@id", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                If Retval2 = 0 Then Menu3_InActive_Click(sender, e) Else Menu3_Active_Click(sender, e) 'refresh list4
            Else
                'MsgBox("Canceled", vbOKOnly, "eLib")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
    End Sub
    Private Sub List3_DoubleClick(sender As Object, e As EventArgs) Handles List3.DoubleClick
        Menu3_Edit_Click(sender, e)
    End Sub
    Private Sub Menu3_Delete_Click(sender As Object, e As EventArgs) Handles Menu3_Delete.Click
        intProj = List3.SelectedValue
        If intProj < 1 Then Exit Sub
        '//check if this project was populated, if yes, dont delete it 
        If DS.Tables("tblProduct").Rows.Count > 0 Then
            MsgBox("This Project is Populated !" & vbCrLf & "Replace (or Delete), then try again", vbOKOnly, "eLib")
            Exit Sub
        End If
        Dim myansw As DialogResult = MsgBox("Delete this Project?", vbYesNo, "eLib")
        If myansw = vbYes Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM Project WHERE ID=@projectid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectid", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM Project WHERE ID=@projectid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectid", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM Project WHERE ID=@projectid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@projectid", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                If Menu3_Active.Checked = True Then
                    GetProjects(intUser, 0) 'refresh list3 (active)
                Else
                    GetProjects(intUser, 2) 'refresh list3 (all)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Private Sub Menu3_Active_Click(sender As Object, e As EventArgs) Handles Menu3_Active.Click
        GetProjects(intUser, 0) '0:active 1:inactive 2:all
        List3.DataSource = DS.Tables("tblProject")
        List3.DisplayMember = "ProjectName"
        List3.ValueMember = "ID"
        Menu3_Active.Checked = True
        Menu3_InActive.Checked = False
        Menu3_All.Checked = False
    End Sub
    Private Sub Menu3_InActive_Click(sender As Object, e As EventArgs) Handles Menu3_InActive.Click
        GetProjects(intUser, 1) '0:active 1:inactive 2:all
        List3.DataSource = DS.Tables("tblProject")
        List3.DisplayMember = "ProjectName"
        List3.ValueMember = "ID"
        Menu3_Active.Checked = False
        Menu3_InActive.Checked = True
        Menu3_All.Checked = False
    End Sub
    Private Sub Menu3_All_Click(sender As Object, e As EventArgs) Handles Menu3_All.Click
        GetProjects(intUser, 2) '0:active 1:inactive 2:all
        List3.DataSource = DS.Tables("tblProject")
        List3.DisplayMember = "ProjectName"
        List3.ValueMember = "ID"
        Menu3_Active.Checked = False
        Menu3_InActive.Checked = False
        Menu3_All.Checked = True
    End Sub
    Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProject.TextChanged
        GetProjects(intUser, 3) '0:active 1:inactive 2:all
        List3.DataSource = DS.Tables("tblProject")
        List3.DisplayMember = "ProjectName"
        List3.ValueMember = "ID"
        Menu3_Active.Checked = False
        Menu3_InActive.Checked = False
        Menu3_All.Checked = True 'but filter by strSearchProject
    End Sub
    Private Sub lblSearchProject_Click(sender As Object, e As EventArgs) Handles lblSearchProject.Click
        txtSearchProject.Text = ""
    End Sub
    Private Sub GetProjects(usrid As Integer, activex As Integer)
        'activex {0:active 1:inactive 2:all}
        Dim strSearchProj As String = Trim(txtSearchProject.Text)
        DS.Tables("tblProject").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Select Case activex
                    Case 0 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active= 1 Order By ProjectName"
                    Case 1 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active= 0 Order By ProjectName"
                    Case 2 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                    Case 3
                        If strSearchProj = "" Then
                            strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                        Else
                            strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND ProjectName LIKE '%" & strSearchProj & "%' Order By ProjectName"
                        End If
                End Select
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DASS = New SqlClient.SqlDataAdapter(strSQL, CnnSS)
                    DASS.Fill(DS, "tblProject")
                    CnnSS.Dispose()
                End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
            Case "SqlServerCE"
                Select Case activex
                    Case 0 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active= 1 Order By ProjectName"
                    Case 1 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active = 0 Order By ProjectName"
                    Case 2 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                    Case 3
                        If strSearchProj = "" Then
                            strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                        Else
                            strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND ProjectName LIKE '%" & strSearchProj & "%' Order By ProjectName"
                        End If
                End Select
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    DASC = New SqlServerCe.SqlCeDataAdapter(strSQL, CnnSC)
                    DASC.Fill(DS, "tblProject")
                    CnnSC.Close()
                End Using
            '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
            Case "Access"
                Select Case activex
                    Case 0 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active= -1 Order By ProjectName"
                    Case 1 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active = 0 Order By ProjectName"
                    Case 2 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                    Case 3
                        If strSearchProj = "" Then
                            strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                        Else
                            strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND ProjectName LIKE '%" & strSearchProj & "%' Order By ProjectName"
                        End If
                End Select
                Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                    CnnAC.Open()
                    DAAC = New OleDb.OleDbDataAdapter(strSQL, CnnAC)
                    DAAC.Fill(DS, "tblProject")
                    CnnAC.Close()
                End Using
        End Select
        'MsgBox(strSearchProj & vbCrLf & strSQL)
        DS.Tables("tblProduct").Clear()
    End Sub
    Private Sub List3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles List3.SelectedIndexChanged
        List3_Click(sender, e)
    End Sub
    Private Sub List3_Click(sender As Object, e As EventArgs) Handles List3.Click
        If List3.SelectedIndex = -1 Then Exit Sub
        Try
            intProj = List3.SelectedValue
            GetProducts(intProj)
            List4.DataSource = DS.Tables("tblProduct")
            List4.DisplayMember = "ProductName"
            List4.ValueMember = "ID"
            List4.SelectedValue = -1
            DS.Tables("tblRefs2").Clear()
            DS.Tables("tblProductNotes").Clear()
            ClearLabels(240) '240:&B11110000 clear labels in below of the form
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetProducts(Projectid As Integer)
        DS.Tables("tblProduct").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DASS = New SqlClient.SqlDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product Where Project_ID = " & Projectid.ToString & " Order by ProductName", CnnSS)
                    DASS.Fill(DS, "tblProduct")
                    CnnSS.Dispose()
                End Using
            '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product Where Project_ID = " & Projectid.ToString & " Order by ProductName", CnnSC)
                    DASC.Fill(DS, "tblProduct")
                    CnnSC.Close()
                End Using
            '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
            Case "Access"
                Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                    CnnAC.Open()
                    DAAC = New OleDb.OleDbDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product Where Project_ID = " & Projectid.ToString & " Order by ProductName", CnnAC)
                    DAAC.Fill(DS, "tblProduct")
                    CnnAC.Close()
                End Using
        End Select
    End Sub
    Private Sub Menu3_Report_Click(sender As Object, e As EventArgs) Handles Menu3_Report.Click
        '//Report a Project
        Dim iProj, iProd As Integer
        Dim strLine As String = ""
        Dim strx As String = ""
        Try
            FileOpen(1, Application.StartupPath & "elibReport.html", OpenMode.Output)
            '//header
            If Menu3_Active.Checked = -1 Then
                AddHeader2Report("Report Active Projects for User: ")
            ElseIf Menu3_InActive.Checked = -1 Then
                AddHeader2Report("Report Inactive Projects for User: ")
            Else
                AddHeader2Report("Report All Projects for User: ")
            End If
            '//data
            List4.DataSource = Nothing
            For iProj = 0 To DS.Tables("tblProject").Rows.Count - 1
                PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:16px'>Project: " & DS.Tables("tblProject").Rows(iProj).Item(1) & " ")
                PrintLine(1, "<span style='color:Black; font-family:tahoma; font-size:12px'> (" & DS.Tables("tblProject").Rows(iProj).Item(2) & ")</span>")
                '//Read Data
                GetProducts(DS.Tables("tblProject").Rows(iProj).Item(0))
                For iProd = 0 To DS.Tables("tblProduct").Rows.Count - 1
                    PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:12px'> - " & DS.Tables("tblProduct").Rows(iProd).Item(1) & " ")
                    PrintLine(1, "<span style='color:Green; font-family:tahoma; font-size:10px'> ///" & DS.Tables("tblProduct").Rows(iProd).Item(2) & "</span>")
                Next iProd
                PrintLine(1, "<hr>")
            Next iProj
            ' //footer
            AddFooter2Report()
            FileClose(1)
            Shell("explorer.exe " & Application.StartupPath & "elibreport.html")
        Catch ex As Exception
            MsgBox(iProj.ToString & " / " & iProd.ToString & " / " & ex.ToString)
            FileClose(1)
            Exit Sub
        End Try
    End Sub
    'List 4 (sub-Projects)
    Private Sub List4_KeyDown(sender As Object, e As KeyEventArgs) Handles List4.KeyDown
        Select Case e.KeyCode
            Case 37 : List3.Focus() '<-
            Case 39 : List5.Focus() '->
        End Select
    End Sub
    Private Sub List4_Click(sender As Object, e As EventArgs) Handles List4.Click
        If List4.SelectedIndex = -1 Then Exit Sub
        Dim intProduct As Integer = List4.SelectedValue
        Try
            GetRefs(intProduct)
            List5.DataSource = DS.Tables("tblRefs2")
            List5.DisplayMember = "PaperName"
            List5.ValueMember = "Papers.ID"
            List5.SelectedIndex = -1
        Catch ex As Exception
        End Try
        Try
            GetProductNotes(intProduct)
            List6.DataSource = DS.Tables("tblProductNotes")
            List6.DisplayMember = "NoteDatum"
            List6.ValueMember = "ID"
            List6.SelectedIndex = -1
        Catch ex As Exception
        End Try
        ClearLabels(240) '240:&B11110000 clear labels in below of the form
        lblProdNote.Text = DS.Tables("tblProduct").Rows(List4.SelectedIndex).Item(2)
    End Sub
    Private Sub GetRefs(Productid)
        Try
            DS.Tables("tblRefs2").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note, Product_ID, Paper_Product.Note, Paper_Product.ID, Imp1, Imp2, Imp3, ImR FROM Papers INNER JOIN Paper_Product ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & Productid.ToString & " ORDER BY Papers.PaperName DESC;", CnnSS)
                        DASS.Fill(DS, "tblRefs2")
                        CnnSS.Dispose()
                    End Using
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note, Product_ID, Paper_Product.Note, Paper_Product.ID, Imp1, Imp2, Imp3, ImR FROM Papers INNER JOIN Paper_Product ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & Productid.ToString & " ORDER BY Papers.PaperName DESC;", CnnSC)
                        DASC.Fill(DS, "tblRefs2")
                        CnnSC.Close()
                    End Using
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note, Product_ID, Paper_Product.Note, Paper_Product.ID, Imp1, Imp2, Imp3, ImR FROM Papers INNER JOIN Paper_Product ON Papers.ID = Paper_Product.Paper_ID WHERE Product_ID = " & Productid.ToString & " ORDER BY Papers.PaperName DESC;", CnnAC)
                        DAAC.Fill(DS, "tblRefs2")
                        CnnAC.Close()
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetProductNotes(productid As Integer)
        Try
            DS.Tables("tblProductNotes").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes WHERE Product_ID = " & productid.ToString & " ORDER BY NoteDatum ASC;", CnnSS)
                        DASS.Fill(DS, "tblProductNotes")
                        CnnSS.Dispose()
                    End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes WHERE Product_ID = " & productid.ToString & " ORDER BY NoteDatum ASC;", CnnSC)
                        DASC.Fill(DS, "tblProductNotes")
                        CnnSC.Close()
                    End Using
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("SELECT ID, NoteDatum, [Note], Product_ID FROM ProductNotes WHERE Product_ID = " & productid.ToString & " ORDER BY NoteDatum ASC;", CnnAC)
                        DAAC.Fill(DS, "tblProductNotes")
                        CnnAC.Close()
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu4_Add_Click(sender As Object, e As EventArgs) Handles Menu4_Add.Click
        AddNewProduct(1)
    End Sub
    Private Function AddNewProduct(Func_Mode As Integer)
        'use strProjectName also for subproject (sharing one frm for add/edit)
        'strProjectNote also for subproject (sharing one frm for add/edit)
        Select Case Func_Mode
            Case 0 '//List4 is empty: ie a Project has been newly added to List3 and we want to automatically add a product for it 'Add new product
                intProj = List3.SelectedValue
                strProjectName = List3.Text & "_sub"
                strProjectNote = "new subproject for " & List3.Text
                Retval1 = 1 'Save a subproject
            Case 1 '//List4 is already populated: ie user wants to add more Products for an already existing Project 'Add extra product
                intProj = List3.SelectedValue
                If intProj < 1 Then Exit Function
                Retval1 = 1 'subproject
                Retval2 = 0 'new subproject
                frmProject.ShowDialog()
        End Select
        Try
            If Retval1 = 1 Then 'Save it
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "INSERT INTO Product (ProductName, Notes, Project_ID) VALUES (@productname, @notes, @projectid)"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@projectid", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "INSERT INTO Product (ProductName, Notes, Project_ID) VALUES (@productname, @notes, @projectid)"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@projectid", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "INSERT INTO Product (ProductName, [Notes], Project_ID) VALUES (@productname, @notes, @projectid)"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@projectid", intProj.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                GetProducts(intProj) 'refresh list5
            Else
                'MsgBox("Canceled", vbOKOnly, "eLib")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
    End Function
    Private Sub Menu4_Edit_Click(sender As Object, e As EventArgs) Handles Menu4_Edit.Click
        intProj = List3.SelectedValue 'is required for refreshing List4 (see below at end of current sub)
        If intProj < 1 Then Exit Sub
        intProd = List4.SelectedValue
        If intProd < 1 Then Exit Sub
        Retval1 = 1 'Product
        Retval2 = 1 'Edit mode
        strProjectName = DS.Tables("tblProduct").Rows(List4.SelectedIndex).Item(1) 'using shared variables
        strProjectNote = DS.Tables("tblProduct").Rows(List4.SelectedIndex).Item(2) 'using shared variables
        frmProject.ShowDialog()
        Try
            If Retval1 = 1 Then 'save it
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            If Retval3 = -1 Then Retval3 = 1 '//sqlserver:TRUE=1 accdb:TRUE=-1 
                            strSQL = "UPDATE Product SET ProductName=@productname, Notes=@notes WHERE ID=@id"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@id", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "UPDATE Product SET ProductName=@productname, Notes=@notes WHERE ID=@id"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@id", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "UPDATE Product SET ProductName=@productname, Notes=@notes WHERE ID=@id"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productname", strProjectName)
                            cmdx.Parameters.AddWithValue("@notes", strProjectNote)
                            cmdx.Parameters.AddWithValue("@id", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                GetProducts(intProj) 'refresh list5
            Else
                'MsgBox("Canceled", vbOKOnly, "eLib")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
    End Sub
    Private Sub lblProdNote_DoubleClick(sender As Object, e As EventArgs) Handles lblProdNote.DoubleClick
        Menu4_Edit_Click(sender, e)
    End Sub
    Private Sub List4_DoubleClick(sender As Object, e As EventArgs) Handles List4.DoubleClick
        Menu4_Edit_Click(sender, e)
    End Sub
    Private Sub Menu4_Replace_Click(sender As Object, e As EventArgs) Handles Menu4_Replace.Click
        If List4.SelectedIndex = -1 Then Exit Sub
        frmChooseProject.ShowDialog()
        '//replace current product to selected project
        If Retval1 = 1 Then '1: A Project is selected from dialog
            strSQL = "UPDATE Product SET Project_ID=@projectid WHERE ID=@id"
            Select Case DatabaseType '---- sqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.Parameters.AddWithValue("@projectid", intProj.ToString)
                        cmd.Parameters.AddWithValue("@id", List4.SelectedValue.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.Parameters.AddWithValue("@projectid", intProj.ToString)
                        cmd.Parameters.AddWithValue("@id", List4.SelectedValue.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.Parameters.AddWithValue("@projectid", intProj.ToString)
                        cmd.Parameters.AddWithValue("@id", List4.SelectedValue.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CnnAC.Close()
                    End Using
            End Select
            List3_Click(sender, e) 'to refresh list4
        End If
    End Sub
    Private Sub Menu4_Delete_Click(sender As Object, e As EventArgs) Handles Menu4_Delete.Click
        intProj = List3.SelectedValue
        If intProj < 1 Then Exit Sub
        intProd = List4.SelectedValue
        If intProd < 1 Then Exit Sub
        '//check if this subproject was populated, if yes, dont delete it 
        Try
            If (DS.Tables("tblRefs2").Rows.Count > 0) Or (DS.Tables("tblProductNotes").Rows.Count > 0) Then
                MsgBox("This subProject is not empty" & vbCrLf & "Replace (or Delete), then try again", vbOKOnly, "eLib")
                Exit Sub
            End If
        Catch ex As Exception
            'when list 5 is empty - ok nothing to do
        End Try
        Dim myansw As DialogResult = MsgBox("Delete this subProject?", vbYesNo, "eLib")
        If myansw = vbYes Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM Product WHERE ID=@productid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM Product WHERE ID=@productid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM Product WHERE ID=@productid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                GetProducts(intProj) 'refresh list4
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub Menu4_ReportThis_Click(sender As Object, e As EventArgs) Handles Menu4_ReportThis.Click
        If List3.SelectedIndex = -1 Then Exit Sub
        If List4.SelectedIndex = -1 Then Exit Sub
        '//Report a Product (subProject)
        Dim iProj, iProd, iRef, iNote As Integer
        Dim strLine As String = ""
        Try
            FileOpen(1, Application.StartupPath & "elibReport.html", OpenMode.Output)
            '//header
            AddHeader2Report("Report subProject: '" & List4.Text & "' of Project: '" & List3.Text & "' of User: ")
            '//data
            List5.DataSource = Nothing
            List6.DataSource = Nothing
            iProd = List4.SelectedIndex '/not selectedValue!
            PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:16px'>Project: " & DS.Tables("tblProduct").Rows(iProd).Item(1) & " ")
            PrintLine(1, "<span style='color:Black; font-family:tahoma; font-size:12px'> [ " & DS.Tables("tblProduct").Rows(iProd).Item(2) & " ]</span>")
            '//Read Data
            GetProductNotes(DS.Tables("tblProduct").Rows(iProd).Item(0))
            GetRefs(DS.Tables("tblProduct").Rows(iProd).Item(0))
            PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:14px'>Refs: </p>")
            Try
                '//A: Report Refs
                For iRef = 0 To DS.Tables("tblRefs2").Rows.Count - 1
                    PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:12px'> - " & DS.Tables("tblRefs2").Rows(iRef).Item(1) & " ")
                    PrintLine(1, "<span style='color:DarkCyan; font-family:tahoma; font-size:10px'> ///" & DS.Tables("tblRefs2").Rows(iRef).Item(6) & "</span>")
                Next iRef
            Catch ex As Exception
            End Try
            '//B: Report Notes
            PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:12px'>Notes: </p>")
            Try
                For iNote = 0 To DS.Tables("tblProductNotes").Rows.Count - 1
                    PrintLine(1, "<p style='color:SlateGray; font-family:tahoma; font-size:12px'> - " & DS.Tables("tblProductNotes").Rows(iNote).Item(1) & " ")
                    PrintLine(1, "<span style='color:DarkCyan; font-family:tahoma; font-size:10px'> ///" & DS.Tables("tblProductNotes").Rows(iNote).Item(2) & "</span>")
                Next iNote
                PrintLine(1, "<hr>")
            Catch ex As Exception
            End Try
            ' //footer
            AddFooter2Report()
            FileClose(1)
            Shell("explorer.exe " & Application.StartupPath & "elibreport.html")
        Catch ex As Exception
            MsgBox(iProj.ToString & " / " & iProd.ToString & " / " & ex.ToString)
            FileClose(1)
            Exit Sub
        End Try
    End Sub
    Private Sub Menu4_ReportAll_Click(sender As Object, e As EventArgs) Handles Menu4_ReportAll.Click
        If List3.SelectedIndex = -1 Then Exit Sub
        '//Report a Product (subProject)
        Dim iProj, iProd, iRef, iNote As Integer
        Dim strLine As String = ""
        Try
            FileOpen(1, Application.StartupPath & "elibReport.html", OpenMode.Output)
            '//header
            AddHeader2Report("Report Project: '" & List3.Text & "' of User: ")
            '//data
            List5.DataSource = Nothing
            List6.DataSource = Nothing
            For iProd = 0 To DS.Tables("tblProduct").Rows.Count - 1
                PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:16px'>Project: " & DS.Tables("tblProduct").Rows(iProd).Item(1) & " ")
                PrintLine(1, "<span style='color:Black; font-family:tahoma; font-size:12px'> [ " & DS.Tables("tblProduct").Rows(iProd).Item(2) & " ]</span>")
                '//Read Data
                GetProductNotes(DS.Tables("tblProduct").Rows(iProd).Item(0))
                GetRefs(DS.Tables("tblProduct").Rows(iProd).Item(0))
                '//A: Report Refs
                PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:14px'>Refs: </p>")
                Try
                    For iRef = 0 To DS.Tables("tblRefs2").Rows.Count - 1
                        PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:12px'> - " & DS.Tables("tblRefs2").Rows(iRef).Item(1) & " ")
                        PrintLine(1, "<span style='color:DarkCyan; font-family:tahoma; font-size:10px'> ///" & DS.Tables("tblRefs2").Rows(iRef).Item(6) & "</span>")
                    Next iRef
                Catch ex As Exception
                End Try
                '//B: Report Notes
                PrintLine(1, "<p style='color:Blue; font-family:tahoma; font-size:12px'>Notes: </p>")
                Try
                    For iNote = 0 To DS.Tables("tblProductNotes").Rows.Count - 1
                        PrintLine(1, "<p style='color:SlateGray; font-family:tahoma; font-size:12px'> - " & DS.Tables("tblProductNotes").Rows(iNote).Item(1) & " ")
                        PrintLine(1, "<span style='color:DarkCyan; font-family:tahoma; font-size:10px'> ///" & DS.Tables("tblProductNotes").Rows(iNote).Item(2) & "</span>")
                    Next iNote
                    PrintLine(1, "<hr>")
                Catch ex As Exception
                End Try
            Next iProd
            ' //footer
            AddFooter2Report()
            FileClose(1)
            Shell("explorer.exe " & Application.StartupPath & "elibreport.html")
        Catch ex As Exception
            MsgBox(iProj.ToString & " / " & iProd.ToString & " / " & ex.ToString)
            FileClose(1)
            Exit Sub
        End Try
    End Sub

    'List 5 (Refs2)
    Private Sub List5_KeyDown(sender As Object, e As KeyEventArgs) Handles List5.KeyDown
        Select Case e.KeyCode
            Case 37 : List4.Focus() '<-
            Case 39 : txtSearch.Focus() '->
        End Select
    End Sub
    Private Sub List5_Click(sender As Object, e As EventArgs) Handles List5.Click
        If List5.SelectedIndex = -1 Then Exit Sub
        If List6.SelectedIndex = -1 Then ' if one row of list6 is selected, it is in /subProject_Notes MODE/
            Try
                intRef = List5.SelectedValue
                Dim Refid As Integer = List5.SelectedIndex
                strRefType = ""
                Dim lblCaption As String = ""
                If DS.Tables("tblRefs2").Rows(Refid).Item(2) = True Then lblCaption = lblCaption & "P. " : strRefType = strRefType & "Paper  "
                If DS.Tables("tblRefs2").Rows(Refid).Item(3) = True Then lblCaption = lblCaption & "B. " : strRefType = strRefType & "Book  "
                If DS.Tables("tblRefs2").Rows(Refid).Item(4) = True Then lblCaption = lblCaption & "M. " : strRefType = strRefType & "Manual  "
                If DS.Tables("tblRefs2").Rows(Refid).Item(5) = True Then lblCaption = lblCaption & "L. " : strRefType = strRefType & "Lecture  "
                If DS.Tables("tblRefs2").Rows(Refid).Item(10) = True Then lblCaption = lblCaption & "Imp1. "
                If DS.Tables("tblRefs2").Rows(Refid).Item(11) = True Then lblCaption = lblCaption & "Imp2. "
                If DS.Tables("tblRefs2").Rows(Refid).Item(12) = True Then lblCaption = lblCaption & "Imp3. "
                If DS.Tables("tblRefs2").Rows(Refid).Item(13) = True Then lblCaption = lblCaption & "ImR. "
                lblRefStatus2.Text = lblCaption
                lblAssignNote2.Text = DS.Tables("tblRefs2").Rows(Refid).Item(8) '8:Paper_Product.Note
                strRefNote = DS.Tables("tblRefs2").Rows(Refid).Item(6) '6:Papers.Note
                lblRefNote2.Text = strRefNote                          '6:Papers.Note
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Private Sub List5_DoubleClick(sender As Object, e As EventArgs) Handles List5.DoubleClick
        If List6.SelectedIndex >= 0 Then
            List6_DoubleClick(sender, e)
            Exit Sub
        End If
        Menu5_Read_Click(sender, e)
    End Sub
    Private Sub Menu5_Read_Click(sender As Object, e As EventArgs) Handles Menu5_Read.Click
        strRef = List5.Text
        If strRef <> "" Then frmReadRef.ShowDialog()
    End Sub
    Private Sub Menu5_RefAttributes_Click(sender As Object, e As EventArgs) Handles Menu5_RefAttributes.Click
        If List5.SelectedIndex = -1 Then Exit Sub
        'If List6.SelectedIndex <> -1 Then Exit Sub
        intProd = DS.Tables("tblProduct").Rows(List4.SelectedIndex).Item(0)     '0:Product.ID
        intAssign = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(9)     '9:Paper_Product.ID
        strRef = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(1)        '1:PaperName
        strProdNote = DS.Tables("tblProduct").Rows(List4.SelectedIndex).Item(2) '2:Product.Note
        strAssignNote = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(8) '8:Assignment.Note
        strRefNote = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(6)    '6:Paper.Note
        intRef = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(0)        '0:Paper.ID
        'Retval2: 1111-1111 {ImR.Imp3.Imp2.Imp2.Lect.Man.Book.Paper}
        Retval2 = 0
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(2) = True Then Retval2 = (Retval2 Or 1)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(3) = True Then Retval2 = (Retval2 Or 2)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(4) = True Then Retval2 = (Retval2 Or 4)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(5) = True Then Retval2 = (Retval2 Or 8)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(10) = True Then Retval2 = (Retval2 Or 16)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(11) = True Then Retval2 = (Retval2 Or 32)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(12) = True Then Retval2 = (Retval2 Or 64)
        If DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(13) = True Then Retval2 = (Retval2 Or 128)
        frmRefAttributes.ShowDialog()
        If Retval1 = 1 Then
            SetRefAttributes(Retval2, strProdNote, strAssignNote, strRefNote)
            List5_Click(sender, e) 'refresh labels
        End If
    End Sub
    Private Sub SetRefAttributes(Attr As Integer, strProdNote As String, strAssignNote As String, strRefNote As String)
        'intAssign
        'intProd
        Dim strAttrx As String = ""
        'Retval2: 1111-1111 {ImR.Imp3.Imp2.Imp2.Lect.Man.Book.Paper}
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        If (Retval2 And 16) = 16 Then strAttrx = (strAttrx & "Imp1=1, ") Else strAttrx = (strAttrx & "Imp1=0, ")
                        If (Retval2 And 32) = 32 Then strAttrx = (strAttrx & "Imp2=1, ") Else strAttrx = (strAttrx & "Imp2=0, ")
                        If (Retval2 And 64) = 64 Then strAttrx = (strAttrx & "Imp3=1, ") Else strAttrx = (strAttrx & "Imp3=0, ")
                        If (Retval2 And 128) = 128 Then strAttrx = (strAttrx & "ImR=1, ") Else strAttrx = (strAttrx & "ImR=0, ")
                        strSQL = "UPDATE Paper_Product SET " & strAttrx & "Paper_Product.Note=@paperproductnote WHERE ID=@id"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperproductnote", strAssignNote)
                        cmdx.Parameters.AddWithValue("@id", intAssign.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        If (Retval2 And 16) = 16 Then strAttrx = (strAttrx & "Imp1=-1, ") Else strAttrx = (strAttrx & "Imp1=0, ")
                        If (Retval2 And 32) = 32 Then strAttrx = (strAttrx & "Imp2=-1, ") Else strAttrx = (strAttrx & "Imp2=0, ")
                        If (Retval2 And 64) = 64 Then strAttrx = (strAttrx & "Imp3=-1, ") Else strAttrx = (strAttrx & "Imp3=0, ")
                        If (Retval2 And 128) = 128 Then strAttrx = (strAttrx & "ImR=-1, ") Else strAttrx = (strAttrx & "ImR=0, ")
                        strSQL = "UPDATE Paper_Product SET " & strAttrx & "Paper_Product.Note=@paperproductnote WHERE ID=@id"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperproductnote", strAssignNote)
                        cmdx.Parameters.AddWithValue("@id", intAssign.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        If (Retval2 And 16) = 16 Then strAttrx = (strAttrx & "Imp1=-1, ") Else strAttrx = (strAttrx & "Imp1=0, ")
                        If (Retval2 And 32) = 32 Then strAttrx = (strAttrx & "Imp2=-1, ") Else strAttrx = (strAttrx & "Imp2=0, ")
                        If (Retval2 And 64) = 64 Then strAttrx = (strAttrx & "Imp3=-1, ") Else strAttrx = (strAttrx & "Imp3=0, ")
                        If (Retval2 And 128) = 128 Then strAttrx = (strAttrx & "ImR=-1, ") Else strAttrx = (strAttrx & "ImR=0, ")
                        strSQL = "UPDATE Paper_Product SET " & strAttrx & "Paper_Product.Note=@paperproductnote WHERE ID=@id"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperproductnote", strAssignNote)
                        cmdx.Parameters.AddWithValue("@id", intAssign.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            strAttrx = ""
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    If (Retval2 And 1) = 1 Then strAttrx = strAttrx & "IsPaper=1, " Else strAttrx = strAttrx & "IsPaper=0, "
                    If (Retval2 And 2) = 2 Then strAttrx = strAttrx & "IsBook=1, " Else strAttrx = strAttrx & "IsBook=0, "
                    If (Retval2 And 4) = 4 Then strAttrx = strAttrx & "IsManual=1, " Else strAttrx = strAttrx & "IsManual=0, "
                    If (Retval2 And 8) = 8 Then strAttrx = strAttrx & "IsLecture=1, " Else strAttrx = strAttrx & "IsLecture=0, "
                    strSQL = "UPDATE Papers SET " & strAttrx & "Papers.Note=@papersnote WHERE ID=@id"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@papersnote", strRefNote)
                        cmdx.Parameters.AddWithValue("@id", intRef.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    If (Retval2 And 1) = 1 Then strAttrx = strAttrx & "IsPaper=-1, " Else strAttrx = strAttrx & "IsPaper=0, "
                    If (Retval2 And 2) = 2 Then strAttrx = strAttrx & "IsBook=-1, " Else strAttrx = strAttrx & "IsBook=0, "
                    If (Retval2 And 4) = 4 Then strAttrx = strAttrx & "IsManual=-1, " Else strAttrx = strAttrx & "IsManual=0, "
                    If (Retval2 And 8) = 8 Then strAttrx = strAttrx & "IsLecture=-1, " Else strAttrx = strAttrx & "IsLecture=0, "
                    strSQL = "UPDATE Papers SET " & strAttrx & "Papers.Note=@papersnote WHERE ID=@id"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@papersnote", strRefNote)
                        cmdx.Parameters.AddWithValue("@id", intRef.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    If (Retval2 And 1) = 1 Then strAttrx = strAttrx & "IsPaper=-1, " Else strAttrx = strAttrx & "IsPaper=0, "
                    If (Retval2 And 2) = 2 Then strAttrx = strAttrx & "IsBook=-1, " Else strAttrx = strAttrx & "IsBook=0, "
                    If (Retval2 And 4) = 4 Then strAttrx = strAttrx & "IsManual=-1, " Else strAttrx = strAttrx & "IsManual=0, "
                    If (Retval2 And 8) = 8 Then strAttrx = strAttrx & "IsLecture=-1, " Else strAttrx = strAttrx & "IsLecture=0, "
                    strSQL = "UPDATE Papers SET " & strAttrx & "Papers.Note=@papersnote WHERE ID=@id"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@papersnote", strRefNote)
                        cmdx.Parameters.AddWithValue("@id", intRef.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "UPDATE Product SET Notes=@notes WHERE ID=@id"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@notes", strProdNote)
                        cmdx.Parameters.AddWithValue("@id", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "UPDATE Product SET Notes=@notes WHERE ID=@id"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@notes", strProdNote)
                        cmdx.Parameters.AddWithValue("@id", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "UPDATE Product SET Notes=@notes WHERE ID=@id"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@notes", strProdNote)
                        cmdx.Parameters.AddWithValue("@id", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            List4_Click(sender:=1, e:=Nothing) 'refresh list5
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try

    End Sub
    Private Sub lblAssignNote2_DoubleClick(sender As Object, e As EventArgs) Handles lblAssignNote2.DoubleClick
        Menu5_RefAttributes_Click(sender, e)
    End Sub
    Private Sub lblRefNote2_DoubleClick(sender As Object, e As EventArgs) Handles lblRefNote2.DoubleClick
        Menu5_RefAttributes_Click(sender, e)
    End Sub
    Private Sub Menu5_Replace_Click(sender As Object, e As EventArgs) Handles Menu5_Replace.Click
        If List5.SelectedIndex = -1 Then Exit Sub
        If List6.SelectedIndex >= 0 Then Exit Sub
        frmChooseProject.ShowDialog()
        If Retval1 = 2 Then
            'intProd  : id from Dialog
            'intAssign: id from List5
            intAssign = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(9)
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "UPDATE Paper_Product SET Product_ID=@prodid WHERE ID=@id"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@prodid", intProd)
                        cmdx.Parameters.AddWithValue("@id", intAssign.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "UPDATE Paper_Product SET Product_ID=@prodid WHERE ID=@id"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@prodid", intProd)
                        cmdx.Parameters.AddWithValue("@id", intAssign.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "UPDATE Product SET Notes=@notes WHERE ID=@id"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@prodid", intProd)
                        cmdx.Parameters.AddWithValue("@id", intAssign.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            List4_Click(sender, e) 'refresh List5
        End If
    End Sub
    Private Sub Menu5_AddTo_Click(sender As Object, e As EventArgs) Handles Menu5_AddTo.Click
        If List5.SelectedIndex = -1 Then Exit Sub
        If List6.SelectedIndex >= 0 Then Exit Sub
        frmChooseProject.ShowDialog()
        If Retval1 = 2 Then
            'intRef   : Ref id from List5
            'intProd  : id from Dialog
            intRef = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(0)
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperid", intRef.ToString)
                        cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                        Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperid", intRef.ToString)
                        cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@paperid", intRef.ToString)
                        cmdx.Parameters.AddWithValue("@productid", intProd.ToString)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
            txtSearch.Text = List5.Text & " "
        End If

    End Sub
    Private Sub Menu5_Delete_Click(sender As Object, e As EventArgs) Handles Menu5_Delete.Click
        intAssign = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(9) 'see GetRefs above
        If intAssign < 1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("Delete this Assignment?", vbYesNo, "eLib")
        If myansw = vbYes Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM Paper_Product WHERE ID=@assignid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@assignid", intAssign.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM Paper_Product WHERE ID=@assignid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@assignid", intAssign.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM Paper_Product WHERE ID=@assignid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@assignid", intAssign.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                intProd = List4.SelectedValue
                GetRefs(intProd) 'refresh list5
                If List1.SelectedIndex >= 0 Then
                    intRef = List1.SelectedValue
                    GetAssignments1(intRef) 'refresh list2
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub Menu5_ShowAbove_Click(sender As Object, e As EventArgs) Handles Menu5_ShowAbove.Click
        '//WAITING
        If List5.SelectedIndex = -1 Then Exit Sub
        If List6.SelectedIndex = -1 Then 'Check if list 5 is showing a ref / not a note!
            lblSearch_Click(sender, e)
            txtSearch.Text = DS.Tables("tblRefs2").Rows(List5.SelectedIndex).Item(1) + " "
        End If
    End Sub
    Private Sub Menu5_Copy_Click(sender As Object, e As EventArgs) Handles Menu5_Copy.Click
        'Copy to clipboard
        If List5.SelectedIndex >= 0 Then
            My.Computer.Clipboard.SetText(List5.Text)
            lblRefStatus2.Text = "'Title' coppied to clipboard"
        End If
    End Sub
    Private Sub Menu5_QRCode_Click(sender As Object, e As EventArgs) Handles Menu5_QRCode.Click
        '//check if tbl.Settings allows QRCODEGen ?
        If List5.SelectedIndex >= 0 Then Call QRCodeGen(List5.Text)
    End Sub
    Private Sub Menu5_GoogleScholar_Click(sender As Object, e As EventArgs) Handles Menu5_GoogleScholar.Click
        If List5.SelectedIndex >= 0 Then
            Dim strSearchScholar As String = List5.Text
            SearchScholar(strSearchScholar)
        End If
    End Sub
    Private Sub Menu5_Collect_Click(sender As Object, e As EventArgs) Handles Menu5_Collect.Click
        If List5.SelectedIndex = -1 Then Exit Sub
        FileOpen(1, Application.StartupPath & "elibCollect", OpenMode.Append)
        PrintLine(1, ". " & List3.Text & " . " & List4.Text & " . " & List6.Text)
        PrintLine(1, "  " & List5.Text)
        PrintLine(1, "")
        FileClose(1)
        lblRefStatus2.Text = "Collected <  " & List5.Text
    End Sub
    Private Sub Menu5_Show_Click(sender As Object, e As EventArgs) Handles Menu5_Show.Click
        '//Open Collection to read
        Dim strLine As String = ""
        Try
            FileOpen(1, Application.StartupPath & "elibCollect.html", OpenMode.Output)
            FileOpen(2, Application.StartupPath & "elibCollect", OpenMode.Input)
            PrintLine(1, "<head><title>eLib Collect</title><style>table, th, td {border: 1px solid;}</style></head>")
            PrintLine(1, "<body>")
            '//header
            AddHeader2Report("Collected Notes by User: ")
            While Not EOF(2)
                strLine = LineInput(2)
                Select Case Microsoft.VisualBasic.Left(strLine, 1)
                    Case "."
                        PrintLine(1, "<p style='color:Green; font-family:tahoma; font-size:14px'>" & strLine & "</p>")
                    Case Else
                        PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:14px'>" & strLine & "</p>")
                End Select
            End While
            ' //footer
            AddFooter2Report()
            FileClose(1)
            FileClose(2)
            Shell("explorer.exe " & Application.StartupPath & "elibCollect.html")
            Dim myansw As DialogResult = MsgBox("Keep Data ?", vbYesNo + vbDefaultButton2, "eLib")
            If myansw = vbNo Then
                Try
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "elibCollect", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "elibCollect.html", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                    lblRefStatus2.Text = "Collected Data Erased !"
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            lblRefStatus2.Text = "Collected Data not Found!"
            Exit Sub
        End Try
    End Sub

    'List 6 (Notes of a sub)
    Private Sub List6_KeyDown(sender As Object, e As KeyEventArgs) Handles List6.KeyDown
        Select Case e.KeyCode
            Case 37 : List3.Focus()
            Case 39 : List5.Focus()
        End Select
    End Sub
    Private Sub List6_Click(sender As Object, e As EventArgs) Handles List6.Click
        If List6.SelectedIndex = -1 Then Exit Sub
        Try
            Dim intProductNote As Integer = List6.SelectedValue
            List5.DataSource = DS.Tables("tblProductNotes")
            List5.DisplayMember = "Note"
            List5.ValueMember = "ID"
            List5.SelectedIndex = -1
            ClearLabels(224) '224:&B1110'0000 labels below the form except for lblProdNotes
        Catch ex As Exception
        End Try
    End Sub
    Private Sub List6_DoubleClick(sender As Object, e As EventArgs) Handles List6.DoubleClick
        If List6.SelectedIndex <> -1 Then Menu6_Edit_Click(sender, e)
    End Sub
    Private Sub Menu6_Add_Click(sender As Object, e As EventArgs) Handles Menu6_Add.Click
        intProd = List4.SelectedValue
        If intProd < 1 Then Exit Sub
        strProductName = List4.Text
        strDateTime = System.DateTime.Now.ToString("yyyy.MM.dd HH:mm")
        Retval1 = 0 'new note
        frmProductNotes.ShowDialog()
        Try
            If Retval1 = 1 Then
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "INSERT INTO ProductNotes (NoteDatum, Note, Product_ID) VALUES (@notedatum, @note, @prodid)"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@notedatum", strDateTime)
                            cmdx.Parameters.AddWithValue("@note", strProdNote)
                            cmdx.Parameters.AddWithValue("@prodid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "INSERT INTO ProductNotes (NoteDatum, Note, Product_ID) VALUES (@notedatum, @note, @prodid)"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@notedatum", strDateTime)
                            cmdx.Parameters.AddWithValue("@note", strProdNote)
                            cmdx.Parameters.AddWithValue("@prodid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "INSERT INTO ProductNotes (NoteDatum, [Note], Product_ID) VALUES (@notedatum, @note, @prodid)"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@notedatum", strDateTime)
                            cmdx.Parameters.AddWithValue("@note", strProdNote)
                            cmdx.Parameters.AddWithValue("@prodid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                List4_Click(sender, e) 'refresh list5,6
            Else
                'MsgBox("Canceled", vbOKOnly, "eLib")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString) 'Do Nothing!
        End Try
    End Sub
    Private Sub Menu6_Edit_Click(sender As Object, e As EventArgs) Handles Menu6_Edit.Click
        intProd = List4.SelectedValue
        If intProd < 1 Then Exit Sub
        strProductName = List4.Text
        intProdNote = List6.SelectedValue
        If intProdNote < 1 Then Exit Sub
        Retval1 = 1 'edit mode
        strDateTime = DS.Tables("tblProductNotes").Rows(List6.SelectedIndex).Item(1)
        strProdNote = DS.Tables("tblProductNotes").Rows(List6.SelectedIndex).Item(2)
        frmProductNotes.ShowDialog()
        Try
            If Retval1 = 1 Then
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "UPDATE ProductNotes SET NoteDatum=@notedatum, Note=@note WHERE ID=@noteid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@notedatum", strDateTime)
                            cmdx.Parameters.AddWithValue("@note", strProdNote)
                            cmdx.Parameters.AddWithValue("@noteid", intProdNote.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "UPDATE ProductNotes SET NoteDatum=@notedatum, Note=@note WHERE ID=@noteid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@notedatum", strDateTime)
                            cmdx.Parameters.AddWithValue("@note", strProdNote)
                            cmdx.Parameters.AddWithValue("@noteid", intProdNote.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "UPDATE ProductNotes SET NoteDatum=@notedatum, Note=@note WHERE ID=@noteid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@notedatum", strDateTime)
                            cmdx.Parameters.AddWithValue("@note", strProdNote)
                            cmdx.Parameters.AddWithValue("@noteid", intProdNote.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                List4_Click(sender, e) 'refresh list5,6
                List6.SelectedIndex = 0
                List6_Click(sender, e)
            Else
                'MsgBox("Canceled", vbOKOnly, "eLib")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu6_Replace_Click(sender As Object, e As EventArgs) Handles Menu6_Replace.Click
        '//Replace a Note
        If List6.SelectedIndex = -1 Then Exit Sub
        frmChooseProject.ShowDialog()
        '//replace current ProductNote to selected Product
        If Retval1 = 2 Then '2: A Product is selected from dialog
            strSQL = "UPDATE ProductNotes SET Product_ID=@productid WHERE ID=@id"
            Select Case DatabaseType '---- sqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.Parameters.AddWithValue("@productid", intProd.ToString)
                        cmd.Parameters.AddWithValue("@id", List6.SelectedValue.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CnnSS.Dispose()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.Parameters.AddWithValue("@productid", intProd.ToString)
                        cmd.Parameters.AddWithValue("@id", List6.SelectedValue.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.Parameters.AddWithValue("@productid", intProd.ToString)
                        cmd.Parameters.AddWithValue("@id", List6.SelectedValue.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CnnAC.Close()
                    End Using
            End Select
            List4_Click(sender, e) 'to refresh list6
        End If

    End Sub
    Private Sub Menu6_Delete_Click(sender As Object, e As EventArgs) Handles Menu6_Delete.Click
        intProd = List4.SelectedValue
        If intProd < 1 Then Exit Sub
        intProdNote = List6.SelectedValue
        If intProdNote < 1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("Delete this note?", vbYesNo, "eLib")
        If myansw = vbYes Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM ProductNotes WHERE ID=@noteid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@noteid", intProdNote.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM ProductNotes WHERE ID=@noteid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@noteid", intProdNote.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM ProductNotes WHERE ID=@noteid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@noteid", intProdNote.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                List4_Click(sender, e) 'refresh list5,6
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Private Sub Menu6_DeleteAll_Click(sender As Object, e As EventArgs) Handles Menu6_DeleteAll.Click
        If List6.Items.Count = 0 Then Exit Sub
        intProd = List4.SelectedValue
        If intProd < 1 Then Exit Sub
        'intProdNote = List6.SelectedValue
        'If intProdNote < 1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("Delete  'ALL' notes?", vbYesNo + vbDefaultButton2, "eLib")
        If myansw = vbYes Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM ProductNotes WHERE Product_ID=@Prodid"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@prodid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Dispose()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "DELETE FROM ProductNotes WHERE Product_ID=@Prodid"
                            Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@prodid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            strSQL = "DELETE FROM ProductNotes WHERE Product_ID=@prodid"
                            Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@prodid", intProd.ToString)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                List4_Click(sender, e) 'refresh list5,6
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    '//Private Procedures on this form
    Private Sub AddHeader2Report(strTitle As String)
        PrintLine(1, "<head><title>eLib Report</title><style>table, th, td {border: 1px solid;}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:12px; text-align: center'>[" & Now().ToString("yyyy.MM.dd - HH:mm") & "]</p>")
        PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:12px; text-align: center'>eLib - " & strTitle & " " & strUser & "</p>")
        PrintLine(1, "<p style='color:Black; font-family:tahoma; font-size:12px; text-align: center'>DB Type: " & strCaption & " - BackEnd: " & strDbBackEnd & "</p><hr>")
    End Sub
    Private Sub AddFooter2Report()
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'></p><br>")
        PrintLine(1, "<center><input type=button onclick=location.href='http://www.msht.ir' value='eLib'</button></center>")
        PrintLine(1, "</body></html>")
    End Sub

    'Exit
    Private Sub Menu1_Exit_Click(sender As Object, e As EventArgs) Handles Menu1_Exit.Click
        Menu_Exit_Click(sender, e)
    End Sub
    Private Sub Menu5_Exit_Click(sender As Object, e As EventArgs) Handles Menu5_Exit.Click
        Menu_Exit_Click(sender, e)
    End Sub
    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        DeleteHtmlFiles() 'Remove possible existing Data related to other users (now, and also when logging-in via frmCNN as new user )
        Me.Dispose()
        CnnSS.Close() : CnnSS.Dispose() : CnnSS = Nothing
        CnnSC.Close() : CnnSC.Dispose() : CnnSC = Nothing
        CnnAC.Close() : CnnAC.Dispose() : CnnAC = Nothing
        Application.Exit() : End
    End Sub
    Private Sub frmeLibAssign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            'MsgBox("To exit, use menu!", vbOKOnly, "eLib")
        End If
    End Sub

End Class
