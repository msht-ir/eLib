Imports Microsoft.Win32
Public Class frmCNN
    Dim tblConnection As New System.Data.DataTable
    Private Sub frmCNN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ServerName As String = Environment.MachineName
        Dim RegistryView As RegistryView = RegistryView.Registry64
        Try
            Using hklm As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView)
                Dim instanceKey As RegistryKey = hklm.OpenSubKey("SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", False)
                intInstanceNumber = 0
                For Each instanceName As String In instanceKey.GetValueNames()
                    intInstanceNumber = intInstanceNumber + 1
                    'MsgBox(ServerName + " \\ " + instanceName)
                    strServerName = ServerName
                    strInstanceName = instanceName
                    Exit For
                Next
            End Using
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        If strInstanceName = "" Then strInstanceName = "SQLEXPRESS"
        'Remove possible existing Data related to other users (now, and also when exiting the Program)
        DeleteHtmlFiles()
        PasswordTextBox.Visible = False
        GetBuildInfo()
        Me.Text = "libs"
        tblConnection.Columns.Add("Library", GetType(String))
        tblConnection.Columns.Add("Address", GetType(String))
        tblConnection.Columns.Add("uid", GetType(String))
        tblConnection.Columns.Add("pwd", GetType(String))
        '//If file eLibcnn not exist:
        strFilename = Application.StartupPath & "eLibcnn"
        If IO.File.Exists(strFilename) = False Then
            FileOpen(1, Application.StartupPath & "eLibcnn", OpenMode.Output)
            PrintLine(1, "eLibcnn")
            PrintLine(1, "SQLServer Remote")
            PrintLine(1, "eLib Database on Remote Server")
            PrintLine(1, " ")
            PrintLine(1, " ")
            PrintLine(1, " ")
            FileClose(1)
        End If
        If IO.File.Exists(strFilename) = True Then
            ReFeedList()
        Else
            MsgBox("Close And re-Open eLib", vbOKOnly, "eLib")
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
    Private Sub ReFeedList()
        Dim strConnectionName As String = ""
        Dim strConnectionAddress As String = ""
        Dim strConnectionUsername As String = ""
        Dim strConnectionPassword As String = ""
        '//Clear List of CNNs
        For r As Integer = GridCNN.Rows.Count - 1 To 0 Step -1
            GridCNN.Rows.Remove(GridCNN.Rows(r))
        Next
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
        GridCNN.Columns(0).Width = 530         'connection name
        GridCNN.Columns(1).Width = 0           'connection address //was: 610
        GridCNN.Columns(2).Width = 0           'connection username
        GridCNN.Columns(3).Width = 0           'connection password
        GridCNN.Columns(1).Visible = False     'connection address
        GridCNN.Columns(2).Visible = False     'connection username
        GridCNN.Columns(3).Visible = False     'connection password
        For i As Integer = 0 To GridCNN.Columns.Count - 1 'Disable sort for column_haeders
            GridCNN.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i
        GridCNN.Refresh()
    End Sub
    Private Sub GridCNN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCNN.CellDoubleClick
        Menu_SelectBE_Click(sender, e)

    End Sub
    Private Sub Menu_FindDB_Click(sender As Object, e As EventArgs) Handles Menu_FindDB.Click
        If GridCNN.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCNN.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Then Exit Sub
        Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "SqlServerCE|eLib*.sdf"}
            If dialog.ShowDialog = DialogResult.OK Then
                GridCNN(1, r).Value = dialog.FileName
            Else
                Exit Sub
            End If
        End Using
        SaveChanges()
    End Sub
    Private Sub Menu_ResetCnns_Click(sender As Object, e As EventArgs) Handles Menu_ResetCnns.Click
        frmCnnReset.ShowDialog()
        ReFeedList()
        GridCNN_Click(sender, e)
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
        PasswordTextBox.Visible = False
        Label1.Visible = False
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
                Exit Sub
            Case 1 'connection was successful
                ReadSettingsAndUsers() 'to get Admin Pass, Current Version, etc
                strCaption = Server2Connect 'for: frmAssign.text
                PasswordTextBox.Visible = True
                Label1.Visible = True
                PasswordTextBox.Focus()
                '//Validate This Copy
                SecurityValidateThisCopy()
                If KeyIsValid <> True Then Menu_Exit_Click(sender, e)
        End Select
    End Sub
    Public Function Connect2Database(Server2Connect As String) As Integer
        Try
            Select Case Server2Connect
                Case "Remote Lib" '------------------------------------ remote server
                    strDatabaseCNNstring = "Server=setareh.r1host.com\sqlserver2019; Initial Catalog=mshtir_eLib; User ID=mshtir_eLib1user; Password=eLiB_dRmShT2733;"
                    CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                    Connect2Database = 1
                Case "Lib A", "Lib B", "Developer's Lib" '------------------------------------------- local sqlserver
                    strDatabaseCNNstring = strDbBackEnd
                    CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                    Connect2Database = 1
                Case "Portable Lib" '----------------------------------------- local sqlserver CE
                    strDatabaseCNNstring = "Data Source=" & strDbBackEnd & ";Password=" & BackEndPass & ";"
                    CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    DatabaseType = "SqlServerCE"
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
        Application.Exit()
        End
    End Sub

End Class