Public Class frmSecurityActivation
    Dim CurrentUserIsmsht As Boolean = False
    Private Sub frmSecurityActivation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOwner.Focus()
        txtOwner.Text = "Enter Your Name Here"
        txtOwner.SelectionStart = 0
        txtOwner.SelectionLength = 20
        Timer1.Enabled = False
    End Sub
    Private Sub txtOwner_TextChanged(sender As Object, e As EventArgs) Handles txtOwner.TextChanged
        Select Case LCase(txtOwner.Text)
            Case "i am programmer", "i'm programmer", "im programmer", "improgrammer"
                txtOwner.Text = "Password: "
                txtOwner.SelectionStart = 10
            Case "i am user", "i'm user", "im user", "imuser"
                CurrentUserIsmsht = False
                txtOwner.Text = "Enter Your Name Here"
                txtOwner.SelectionStart = 0
                txtOwner.SelectionLength = 20
                txtOwner.PasswordChar = ""
                Timer1.Enabled = False
            Case "password: m"
                txtOwner.PasswordChar = "-"
            Case "password: msht2733"
                CurrentUserIsmsht = True
                txtOwner.Text = "Welcome"
                txtOwner.SelectionStart = 0
                txtOwner.SelectionLength = 7
                txtOwner.PasswordChar = ""
            Case "reset counter"
                If CurrentUserIsmsht = True Then
                    txtOwner.Text = "RESET the Requests Counter? Yes|No"
                    txtOwner.SelectionStart = 28
                    txtOwner.SelectionLength = 7
                    txtOwner.PasswordChar = ""
                End If
            Case "hint"
                MsgBox("m---2---", vbOKOnly, "eLib")
            Case "exit", "quit"
                txtOwner.Text = "Exit Activation Form? Yes|No"
                txtOwner.SelectionStart = 22
                txtOwner.SelectionLength = 6
                txtOwner.PasswordChar = ""
            Case "exit activation form? yes"
                Menu_Exit_Click()
            Case "exit activation form? n"
                txtOwner.Text = "Enter Your Name Here"
                txtOwner.SelectionStart = 0
                txtOwner.SelectionLength = 20
                txtOwner.PasswordChar = ""
                Timer1.Enabled = False
            Case "reset the requests counter? yes"
                Select Case DatabaseType
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@sttvalue", "0")
                            cmd.Parameters.AddWithValue("@sttkey", "SecurityCheck")
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnSS.Close()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                            Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@sttvalue", "0")
                            cmd.Parameters.AddWithValue("@sttkey", "SecurityCheck")
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                End Select
                txtOwner.Text = "Done"
                txtOwner.SelectionStart = 0
                txtOwner.SelectionLength = 4
                KeyIsValid = False
                nRequests = 0
        End Select
    End Sub
    '//Request
    Private Sub Menu_Request_Click() Handles Menu_Request.Click
        If nRequests >= 5 Then
            txtOwner.Focus()
            txtOwner.Text = "You've requested 5 times"
            txtOwner.SelectionStart = 0
            txtOwner.SelectionLength = Len(txtOwner.Text)
            Timer1.Enabled = True
            Exit Sub
        Else
            nRequests = nRequests + 1
        End If
        'Generate R-Code usinf DriveSerialNumber
        Dim strClientName As String = UCase(Environment.MachineName)
        txtOwner.Text = Trim(txtOwner.Text)
        If (Len(txtOwner.Text)) < 4 Or (txtOwner.Text = "Enter Your Name Here") Then
            txtOwner.Focus()
            txtOwner.SelectionStart = 0
            txtOwner.SelectionLength = Len(txtOwner.Text)
            Exit Sub
        End If
        'Create R-Code
        Dim RCode As String = H2R(strDriveSerialNumber)
        'Request file
        FileOpen(1, Application.StartupPath & "eLibRequest", OpenMode.Output)
        PrintLine(1, "#eLibKeyRequest")
        PrintLine(1, "owner: " & txtOwner.Text)
        PrintLine(1, "device: " & strClientName)
        PrintLine(1, "RCode")
        PrintLine(1, RCode)
        PrintLine(1, "--------------------------")
        PrintLine(1, "  Send to:")
        PrintLine(1, "  msht.ir@gmail.com / msht.ir@outlook.com")
        FileClose(1)
        KeyIsValid = False
        txtOwner.Focus()
        txtOwner.Text = "Send 'eLibRequest' to: msht.ir@gmail.com"
        txtOwner.SelectionStart = 0
        txtOwner.SelectionLength = Len(txtOwner.Text)
        'Count requests in settings, and limit them!
        Select Case DatabaseType
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", nRequests.ToString)
                    cmd.Parameters.AddWithValue("@sttkey", "SecurityCheck")
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    CnnSS.Close()
                End Using
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                    Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttvalue", nRequests.ToString)
                    cmd.Parameters.AddWithValue("@sttkey", "SecurityCheck")
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    CnnSC.Close()
                End Using
        End Select
    End Sub
    'B) Activation
    Private Sub Panel1_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter
        'Display behavior of the mouse icon
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Panel1_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop
        'GET SINGLE FILE PATH FROM DROPPED FILE
        Dim strFilex As String = e.Data.GetData(DataFormats.FileDrop)(0)
        Dim strDevice As String = ""
        Dim strAccountOwner As String = ""
        Try
            FileOpen(1, strFilex, OpenMode.Input)
            Dim strx As String = LineInput(1)
            If (Trim(strx) = "#eLibKeyRequest") Or (Trim(strx) = "#eLibKey") Then
                strx = LineInput(1) 'Owner
                strAccountOwner = strx
                strx = LineInput(1) 'Device Name
                strDevice = strx
                strx = LineInput(1) 'R/K?
                Select Case strx
                    Case "RCode" ' Hi msht, use SN' to create a K-Code file for the user 
                        If CurrentUserIsmsht = False Then
                            txtOwner.Focus()
                            txtOwner.Text = "Drop an 'eLibKey' File"
                            txtOwner.SelectionStart = 0
                            txtOwner.SelectionLength = Len(txtOwner.Text)
                            FileClose()
                            Exit Sub
                        End If
                        strx = LineInput(1) 'R-Code string
                        'Extract SN, Create K-Code
                        strActivationKey = H2K(R2H(strx))
                        'Activation-Key file
                        FileOpen(2, Application.StartupPath & "eLibKey", OpenMode.Output)
                        PrintLine(2, "#eLibKey")
                        PrintLine(2, strAccountOwner) ' owner: ---
                        PrintLine(2, strDevice) ' device: ---
                        PrintLine(2, "KCode")
                        PrintLine(2, strActivationKey)
                        FileClose(2)
                        KeyIsValid = False
                        txtOwner.Focus()
                        txtOwner.Text = "File 'eLibKey' Created"
                        txtOwner.SelectionStart = 0
                        txtOwner.SelectionLength = Len(txtOwner.Text)
                    Case "KCode"
                        strx = LineInput(1) 'K-Code string
                        'Convert KCode to retrieve SN' then compare to SN, if OK, activate this Installation 
                        strInferredSN = K2H(strx)
                        If strInferredSN = strDriveSerialNumber Then
                            KeyIsValid = True
                            'Save Activation Key (K-Code) to Settings table 
                            If Mid(strAccountOwner, 1, 7) = "owner: " Then
                                strAccountOwner = Mid(strAccountOwner, 8)
                            End If
                            Select Case DatabaseType
                                Case "SqlServer"
                                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                        CnnSS.Open()
                                        'Save Key
                                        strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                                        Dim cmd1 As New SqlClient.SqlCommand(strSQL, CnnSS)
                                        cmd1.CommandType = CommandType.Text
                                        cmd1.Parameters.AddWithValue("@sttvalue", strx)
                                        cmd1.Parameters.AddWithValue("@sttkey", "SecurityCheck")
                                        Dim i1 As Integer = cmd1.ExecuteNonQuery()
                                        'Save OwnerName
                                        strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                                        Dim cmd2 As New SqlClient.SqlCommand(strSQL, CnnSS)
                                        cmd2.CommandType = CommandType.Text
                                        cmd2.Parameters.AddWithValue("@sttvalue", strAccountOwner)
                                        cmd2.Parameters.AddWithValue("@sttkey", "Owner")
                                        Dim i2 As Integer = cmd2.ExecuteNonQuery()
                                        CnnSS.Close()
                                    End Using
                                    FileClose(1)
                                Case "SqlServerCE"
                                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                        CnnSC.Open()
                                        'Save Key
                                        strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                                        Dim cmd1 As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                        cmd1.CommandType = CommandType.Text
                                        cmd1.Parameters.AddWithValue("@sttvalue", strx)
                                        cmd1.Parameters.AddWithValue("@sttkey", "SecurityCheck")
                                        Dim i1 As Integer = cmd1.ExecuteNonQuery()
                                        'Save OwnerName
                                        strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE sttKey = @sttkey"
                                        Dim cmd2 As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                        cmd2.CommandType = CommandType.Text
                                        cmd2.Parameters.AddWithValue("@sttvalue", strAccountOwner)
                                        cmd2.Parameters.AddWithValue("@sttkey", "Owner")
                                        Dim i2 As Integer = cmd2.ExecuteNonQuery()
                                        CnnSC.Close()
                                    End Using
                                    FileClose(1)
                            End Select
                            txtOwner.Focus()
                            txtOwner.Text = "eLib ACTIVATED Successfully"
                            txtOwner.SelectionStart = 0
                            txtOwner.SelectionLength = Len(txtOwner.Text)
                            Timer1.Enabled = True
                        Else
                            KeyIsValid = False
                            txtOwner.Text = "Invalid Key"
                            txtOwner.SelectionStart = 0
                            txtOwner.SelectionLength = Len(txtOwner.Text)
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FileClose(1)
    End Sub
    'C) EXIT
    Private Sub Menu_Exit_Click() Handles Menu_Exit.Click
        Me.Dispose()
    End Sub
    Private Sub Menu2_Exit_Click() Handles Menu2_Exit.Click
        Me.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Menu_Exit_Click()
    End Sub
    Private Sub Label2_Click() Handles Label2.Click
        MsgBox("Right click :   Menu  >  Request", vbOKOnly, "eLib")
        'Dim myansw As DialogResult = MsgBox("Request Activation-Key for this name:" & vbCrLf & txtOwner.Text & vbCrLf & "Continue ?", vbOKCancel + vbDefaultButton2, "eLib")
        'If myansw = vbOK Then Menu_Request_Click()
        txtOwner.Focus()
        txtOwner.SelectionStart = 0
        txtOwner.SelectionLength = Len(txtOwner.Text)
    End Sub


End Class