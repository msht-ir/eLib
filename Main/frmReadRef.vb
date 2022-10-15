Imports System.IO

Public Class frmReadRef
    Private Sub frmReadRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DS.Tables("tblRefPaths").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT ID, FilePath FROM Paths WHERE FilePath Like '%" & strRef & "%' ORDER BY FilePath;", CnnSS)
                        DASS.Fill(DS, "tblRefPaths")
                        CnnSS.Dispose()
                    End Using
            '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, FilePath FROM Paths WHERE FilePath Like '%" & strRef & "%' ORDER BY FilePath;", CnnSC)
                        DASC.Fill(DS, "tblRefPaths")
                        CnnSC.Close()
                    End Using
            '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("SELECT ID, FilePath FROM Paths WHERE FilePath Like '%" & strRef & "%' ORDER BY FilePath;", CnnAC)
                        DAAC.Fill(DS, "tblRefPaths")
                        CnnAC.Close()
                    End Using
            End Select
            ListPaths.DataSource = DS.Tables("tblRefPaths")
            ListPaths.DisplayMember = "FilePath"
            ListPaths.ValueMember = "ID"
            ListPaths.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ListPaths_DoubleClick(sender As Object, e As EventArgs) Handles ListPaths.DoubleClick
        Menu_Read_Click(sender, e)
    End Sub
    Private Sub ListPaths_KeyDown(sender As Object, e As KeyEventArgs) Handles ListPaths.KeyDown
        Select Case e.KeyCode
            Case 13 : Menu_Read_Click(sender, e)
            Case 27 : Menu_Cancel_Click(sender, e)
            Case Else  'nothing
        End Select
        'If e.KeyCode = Keys.Enter Then
        '    Select Case e.KeyCode
        '        Case 13 : Menu_Read_Click(sender, e)
        '        Case 27 : Menu_Cancel_Click(sender, e)
        '    End Select
        '    e.SuppressKeyPress = True
        'End If
    End Sub

    'MENU
    Private Sub Menu_Read_Click(sender As Object, e As EventArgs) Handles Menu_Read.Click
        If ListPaths.SelectedIndex = -1 Then
            ListPaths.Focus()
            Exit Sub
        End If
        strPath = ListPaths.Text
        Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strPath, vbNormalFocus)
        Me.Dispose()
    End Sub
    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        '//Ref Name
        '//Ref Assignments {1,2,3,4,...}
        '//Ref Type
        '//Set Request Type {0:Import new Ref | 1:Edit a Ref}
        '//Get dialog result
        '//SEND them to dialog:
        frmImportRefs.ShowDialog()
    End Sub
    Private Sub Menu_Delete_Click(sender As Object, e As EventArgs) Handles Menu_Delete.Click
        'Waiting
    End Sub

    Private Sub Menu_Locate_Click(sender As Object, e As EventArgs) Handles Menu_Locate.Click
        '//Locate
        If ListPaths.SelectedIndex = -1 Then Exit Sub
        strPath = ListPaths.Text
        Dim strTitle As String = strPath
lblNextBackslash:
        Dim intPosBackslash As Integer = 0
        intPosBackslash = InStr(1, strTitle, "\")
        If intPosBackslash <> 0 Then
            strTitle = Mid(strTitle, intPosBackslash + 1)
            GoTo lblNextBackslash
        End If
        strPath = Microsoft.VisualBasic.Left(strPath, Len(strPath) - Len(strTitle) - 1)
        Shell("explorer " & strPath, AppWinStyle.NormalFocus)
    End Sub

    Private Sub Menu_SaveACopy_Click(sender As Object, e As EventArgs) Handles Menu_SaveACopy.Click
        '//SaveACopy
    End Sub

    Private Sub Menu_OpenSaveFolder_Click(sender As Object, e As EventArgs) Handles Menu_OpenSaveFolder.Click
        '//OpenSaveFolder
        strFolderSaveACopy = DS.Tables("tblSettings").Rows(6).Item(3)
        Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strFolderSaveACopy, vbNormalFocus)
    End Sub

    Private Sub Menu_Email_Click(sender As Object, e As EventArgs) Handles Menu_Email.Click
        '//Email
    End Sub
    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Me.Dispose()
    End Sub
End Class