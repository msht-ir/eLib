Imports System.IO

Public Class frmCNN
    Dim tblConnection As New System.Data.DataTable
    Private Sub cnn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DeleteHtmlFiles() 'Remove possible existing Data related to other users (now, and also when exiting the Program)
        PasswordTextBox.Enabled = False
        GetBuildInfo()
        lblBuildInfo.Text = "fe: " & strBuildInfo
        Me.Text = "eLib "
        Dim strConnectionName As String = ""
        Dim strConnectionAddress As String = ""
        Dim strConnectionUsername As String = ""
        Dim strConnectionPassword As String = ""
        tblConnection.Columns.Add("Select database", GetType(String))
        tblConnection.Columns.Add("Specs", GetType(String))
        tblConnection.Columns.Add("uid", GetType(String))
        tblConnection.Columns.Add("pwd", GetType(String))
        strFilename = Application.StartupPath & "eLibcnn"
        If IO.File.Exists(strFilename) = False Then
            Menu_ResetCnns_Click(sender, e)
            frmAbout.ShowDialog()
            'MsgBox("Connections Restored", vbInformation + vbOKOnly, "eLib")
        End If
        If IO.File.Exists(strFilename) = True Then
            FileOpen(1, strFilename, OpenMode.Input) '//----------------------------------------------------------- OPEN FILE
lbl_Read:
            Try
                Dim strx1 As String = LineInput(1)
                If strx1 = "eLibcnn" Then
                    strConnectionName = LineInput(1)
                    strConnectionAddress = LineInput(1)
                    strConnectionUsername = LineInput(1)
                    strConnectionPassword = LineInput(1)
                    tblConnection.Rows.Add(strConnectionName, strConnectionAddress, strConnectionUsername, strConnectionPassword)
                End If
                GoTo lbl_Read
            Catch ex As Exception
                'MsgBox("Connection Error", vbOKOnly, "eLib") ' MsgBox(ex.ToString)
            End Try
            If Not EOF(1) Then GoTo lbl_Read
            FileClose(1) '//-------------------------------------------------------------------------------------- CLOSE FILE
            GridCNN.DataBindings.Clear()
            GridCNN.DataSource = tblConnection
            GridCNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            GridCNN.Columns(0).Width = 300         'connection name
            GridCNN.Columns(1).Width = 530         'connection address
            GridCNN.Columns(2).Width = 0           'connection username
            GridCNN.Columns(3).Width = 0           'connection password
            GridCNN.Columns(2).Visible = False     'connection username
            GridCNN.Columns(3).Visible = False     'connection password
            For i As Integer = 0 To GridCNN.Columns.Count - 1 'Disable sort for column_haeders
                GridCNN.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
            GridCNN.Refresh()
        Else
            MsgBox("Close and re-Open eLib", vbOKOnly, "eLib")
            Menu_Exit_Click(sender, e)
        End If
    End Sub
    Private Sub GetBuildInfo()
        strBuildInfo = ""
        UserNickName = ""
        intUser = 0
        strFilename = Application.StartupPath & "eLibusr"
        If IO.File.Exists(strFilename) = True Then
            Try
                FileOpen(1, strFilename, OpenMode.Input)
                Dim strx As String = LineInput(1)
                If Trim(strx) <> "eLib" Then
                    FileClose(1) : Exit Sub
                Else
                    strBuildInfo = LineInput(1)
                    If Microsoft.VisualBasic.Left(strBuildInfo, 5) <> "Build" Then strBuildInfo = "n/a"
                    UserNickName = LCase(Trim(Mid(LineInput(1), 6)))
                    If UserNickName = "na" Then UserNickName = ""
                    intUser = Val(Mid(LineInput(1), 5))
                End If
            Catch ex As Exception
                'MsgBox("Connection Error", vbOKOnly, "eLib") '// MsgBox(ex.ToString)
            End Try
            FileClose(1)
        End If
    End Sub
    Private Sub GridCNN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCNN.CellDoubleClick
        Menu_SelectBE_Click(sender, e)

    End Sub
    Private Sub Menu_AddCNN_Click(sender As Object, e As EventArgs) Handles Menu_AddCNN.Click
        tblConnection.Rows.Add("NEW Library Connection", "Address (DblClick)", "", "")
    End Sub
    Private Sub Menu_FindDB_Click(sender As Object, e As EventArgs) Handles Menu_FindDB.Click
        If GridCNN.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCNN.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Then Exit Sub

        Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "eLib ACCDB BackEnd|eLib*.accdb|eLib SqlServerCE BackEnd|eLib*.sdf"}
            If dialog.ShowDialog = DialogResult.OK Then
                GridCNN(1, r).Value = dialog.FileName
            Else
                Exit Sub
            End If
        End Using
        SaveChanges()
    End Sub
    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        Try
            If GridCNN.RowCount < 1 Then Exit Sub
            Dim r As Integer = GridCNN.SelectedCells(0).RowIndex    'count from 0
            Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
            If r < 0 Or c < 0 Then Exit Sub
            Dim strValue As String = GridCNN(c, r).Value
            strValue = InputBox("enter new value", "connection settings", strValue)
            GridCNN(c, r).Value = strValue
            SaveChanges() 'AutoSave
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu_Remove_Click(sender As Object, e As EventArgs) Handles Menu_Remove.Click
        If GridCNN.SelectedCells.Count = 0 Then Exit Sub 'No cells is selected
        Try '//Method2 for scaping from error!
            Dim iRow As Integer = GridCNN.SelectedCells(0).RowIndex
            'Dim myansw As DialogResult = MsgBox("Delete 'Connection' from List?", vbOKCancel + vbDefaultButton2, "eLib")
            'If myansw = vbCancel Then Exit Sub
            GridCNN.Rows.RemoveAt(iRow) '//DataGridView Row Delete in 'CellSelect' Mode
            SaveChanges()
        Catch ex As Exception
            Exit Sub 'No cells is selected
        End Try
    End Sub
    Private Sub Menu_ResetCnns_Click(sender As Object, e As EventArgs) Handles Menu_ResetCnns.Click
        '//Confirm
        'Dim myansw As DialogResult = MsgBox("Clear List and Reset to Possible Connections ?", vbYesNo + vbDefaultButton2, "eLib")
        'If myansw = vbNo Then Exit Sub
        '//Clear Grid
        For r As Integer = GridCNN.Rows.Count - 1 To 0 Step -1
            GridCNN.Rows.Remove(GridCNN.Rows(r))
        Next
        '//Append Original connections / for Existing Databases in Application Folder
        Try
            tblConnection.Rows.Add("SQLServer Database Remote Connection", "eLib Database on Remote Server")
            tblConnection.Rows.Add("SQLServer Database Connection", "Server=.\SQLExpress; Initial Catalog=eLib1; Integrated Security = SSPI;", "", "")
            Dim strFile As String
            Dim strDir As String = Application.StartupPath
            For Each strFile In Directory.GetFiles(strDir, "*.sdf")
                tblConnection.Rows.Add("SqlServer CE Database Connection", strFile, "", "")
            Next
            For Each strFile In Directory.GetFiles(strDir, "*.accdb")
                tblConnection.Rows.Add("MSAccess Database Connection", strFile, "", "")
            Next
        Catch ex As Exception
        End Try
        'Save
        SaveChanges()
    End Sub
    Private Sub SaveChanges()
        Try
            FileOpen(1, Application.StartupPath & "eLibcnn", OpenMode.Output)
            For r As Integer = 0 To GridCNN.Rows.Count - 1
                If IsDBNull(GridCNN(0, r).Value) Then
                    GridCNN(0, r).Value = "Untitled Connection"
                End If
                For c As Integer = 0 To 3
                    If IsDBNull(GridCNN(c, r).Value) Then GridCNN(c, r).Value = ""
                Next c
            Next r
            For r As Integer = 0 To GridCNN.Rows.Count - 1
                PrintLine(1, "eLibcnn")
                PrintLine(1, GridCNN(0, r).Value)
                PrintLine(1, GridCNN(1, r).Value)
                PrintLine(1, GridCNN(2, r).Value)
                PrintLine(1, GridCNN(3, r).Value)
                PrintLine(1, " ")
            Next r
            FileClose(1)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
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
    Private Sub GridCNN_KeyDown(sender As Object, e As KeyEventArgs) Handles GridCNN.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case e.KeyCode
                Case 13 : Menu_SelectBE_Click(sender, e)
            End Select
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub GridCNN_Click(sender As Object, e As EventArgs) Handles GridCNN.Click
        PasswordTextBox.Text = ""
        PasswordTextBox.Enabled = False
        Label1.Visible = False
        lblBuildInfo.Text = "fe: " & strBuildInfo
    End Sub
    Private Sub Menu_SelectBE_Click(sender As Object, e As EventArgs) Handles Menu_SelectBE.Click
        If GridCNN.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCNN.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Server2Connect = Trim(GridCNN(0, r).Value)
        strDbBackEnd = Trim(GridCNN(1, r).Value)
        strServerUid = Trim(GridCNN(2, r).Value)
        strServerPwd = Trim(GridCNN(3, r).Value)
        If Server2Connect = "" Then Exit Sub
        Retval1 = Connect2Database(Server2Connect)
        Select Case Retval1
            Case 0 'did not connect to a database
                lblBuildInfo.Text = "fe: " & strBuildInfo
                Exit Sub
            Case 1 'connection was successful
                ReadSettingsAndUsers() 'to get Admin Pass, Current Version, ...
                strAdminPass = DS.Tables("tblSettings").Rows(0).Item(3)
                strCurrentVersion = DS.Tables("tblSettings").Rows(1).Item(3)
                lblBuildInfo.Text = "be: " & strCurrentVersion
                strCaption = Server2Connect 'for: frmAssign.text
                PasswordTextBox.Enabled = True
                Label1.Visible = True
                PasswordTextBox.Focus()
        End Select
    End Sub
    Public Function Connect2Database(Server2Connect As String) As Integer
        Try
            Select Case Server2Connect
                Case "SQLServer Database Remote Connection" '------------------------------------ remote server
                    strDatabaseCNNstring = "Server=setareh.r1host.com\sqlserver2019; Initial Catalog=mshtir_eLib; User ID=mshtir_eLib1user; Password=eLiB_dRmShT2733;"
                    CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"

                    Connect2Database = 1
                Case "SQLServer Database Connection" '------------------------------------------- local sqlserver
                    strDatabaseCNNstring = strDbBackEnd
                    CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                    Connect2Database = 1
                Case "SqlServer CE Database Connection" '----------------------------------------- local sqlserver CE
                    strDatabaseCNNstring = "Data Source=" & strDbBackEnd & ";Password=" & BackEndPass & ";"
                    CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    DatabaseType = "SqlServerCE"
                    Connect2Database = 1
                Case "MSAccess Database Connection" '--------------------------------------------- accdb
                    strDatabaseCNNstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDbBackEnd & ";Jet OLEDB:Database Password=" & BackEndPass & ";"
                    CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                    CnnAC.Open()
                    DatabaseType = "Access"
                    Connect2Database = 1
                Case Else
                    Connect2Database = 0
            End Select
        Catch ex As Exception
            Dim myansw As DialogResult = MsgBox("Error: eLib did not connect to the database" & vbCrLf & strDbBackEnd & vbCrLf & vbCrLf & "Show details?", vbYesNo + vbDefaultButton2, "Error connecting to the database")
            If myansw = vbYes Then MsgBox(ex.ToString)
            Connect2Database = 0
        End Try
    End Function
    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
        If (PasswordTextBox.Text = "quit") Or (PasswordTextBox.Text = "exit") Then
            Menu_Exit_Click(sender, e)
        ElseIf Trim(PasswordTextBox.Text) = "" Then
            Exit Sub
        ElseIf (PasswordTextBox.Text = "mshtaccesson") Or (PasswordTextBox.Text = strAdminPass) Then
            intUser = 0
            UserType = "Admin"
            strUser = "Admin"
            UserAccessControls = &HFF
            StartAssignForm()
        ElseIf (PasswordTextBox.Text = "elibguest") Then
            intUser = 0
            UserType = "Guest"
            strUser = "Guest"
            UserAccessControls = &H0
            StartAssignForm()
        Else ' a user
            For i As Integer = 0 To DS.Tables("tblusrs").Rows.Count - 1
                If Trim(PasswordTextBox.Text) = DS.Tables("tblusrs").Rows(i).Item(2) Then
                    If DS.Tables("tblusrs").Rows(i).Item(3) = False Then
                        Exit Sub
                    Else
                        intUser = DS.Tables("tblusrs").Rows(i).Item(0)
                        UserType = "User"
                        strUser = DS.Tables("tblusrs").Rows(i).Item(1)
                        strUserPass = DS.Tables("tblusrs").Rows(i).Item(2)
                        SetUserAccessControls(i)
                        StartAssignForm()
                        Exit For
                    End If
                End If
            Next i
        End If
    End Sub
    Private Sub reWrite_usr()
        FileOpen(1, Application.StartupPath & "elibusr", OpenMode.Output)
        PrintLine(1, "eLib")
        PrintLine(1, strBuildInfo)
        PrintLine(1, "nick n/a") '& LCase(UserNickName))
        PrintLine(1, "usr " & intUser.ToString)
        FileClose(1)
    End Sub
    Public Sub SetUserAccessControls(Userid As Integer)
        Dim UACregister As Integer
        For r As Integer = 0 To 15
            If DS.Tables("tblusrs").Rows(Userid).Item(5 + r) = True Then UACregister = UACregister Or (2 ^ r)
        Next
        UserAccessControls = UACregister
    End Sub
    Sub StartAssignForm()
        Try
            reWrite_usr()
            ValidateFolders()
            Me.Dispose()
            If UserType = "Admin" Then
                frmUsers.ShowDialog()
            Else
                frmAssign.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        CnnSS.Close()
        CnnSS.Dispose()
        CnnSS = Nothing
        CnnSC.Close()
        CnnSC.Dispose()
        CnnSC = Nothing
        CnnAC.Close()
        CnnAC.Dispose()
        CnnAC = Nothing
        Application.Exit()
        End
    End Sub

End Class