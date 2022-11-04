Public Class frmSettings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadSettingsAndUsers()
        GridSettings.DataSource = DS.Tables("tblSettings")
        GridSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridSettings.Columns(0).Visible = False    'ID
        GridSettings.Columns(1).Visible = False    'Header
        GridSettings.Columns(2).Width = 160        'Key
        GridSettings.Columns(3).Width = 180        'Value
        GridSettings.Columns(4).Width = 250        'Note
        For k As Integer = 0 To GridSettings.Columns.Count - 1
            GridSettings.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
        Next k
    End Sub
    Private Sub GridSettings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridSettings.CellDoubleClick
        '0  AdminPass         '1  CurrentVersion    '2  FolderBooks       '3  FolderLectutes
        '4  FolderManuals     '5  FolderPapers      '6  FolderSaveACopy   '7  FolderTemp
        '8  ImportAskFolder   '9  Owner             '10 QRCodeType        '11 SearchRefType     '12 SecurityCheck
        If GridSettings.RowCount < 1 Then Exit Sub
        Dim r As Integer = e.RowIndex 'count from 0
        Dim c As Integer = e.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        If c <> 3 Then Exit Sub
        Dim Keyx As String = DS.Tables("tblsettings").Rows(r).Item(2)
        Dim valx As String = DS.Tables("tblsettings").Rows(r).Item(3)
        Select Case r
            Case 0, 1, 9, 10, 11 'using INPUTBOX
                valx = InputBox("Enter new Value for   " & Keyx, "Settings", valx)
                DS.Tables("tblSettings").Rows(r).Item(3) = valx
            Case 2, 3, 4, 5, 6 'using FolderPicker
                FolderBrowserDialog1.SelectedPath = Application.StartupPath ' Environment.SpecialFolder.Desktop ' "D:\"
                If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                    valx = FolderBrowserDialog1.SelectedPath
                Else
                    valx = InputBox("Enter new Value for   " & Keyx, "Settings", valx)
                End If
                DS.Tables("tblSettings").Rows(r).Item(3) = valx
            Case 8 'ToggleY/N
                If DS.Tables("tblSettings").Rows(r).Item(3) = "NO" Then DS.Tables("tblSettings").Rows(r).Item(3) = "YES" Else DS.Tables("tblSettings").Rows(r).Item(3) = "NO"
        End Select
        SaveSettings()
    End Sub
    Private Sub SaveSettings()
        For r As Integer = 0 To GridSettings.Rows.Count - 1
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", DS.Tables("tblsettings").Rows(r).Item(3))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                        CnnSS.Close()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE ID = @ID"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", DS.Tables("tblsettings").Rows(r).Item(3))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                        CnnSC.Close()
                    End Using
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        strSQL = "UPDATE Settings SET sttValue = @sttvalue WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", DS.Tables("tblsettings").Rows(r).Item(3))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                        CnnAC.Close()
                    End Using
            End Select
        Next r
    End Sub
    Private Sub Menu_ExitSetup_Click() Handles Menu_ExitSetup.Click
        SaveSettings()
        ReadSettingsAndUsers() 'to refresh tblSettings
        Me.Dispose()
    End Sub
    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            'MsgBox("Use menu to Exit", vbOKOnly, "eLib")
        End If

    End Sub

End Class