Imports System.IO
Imports ClosedXML.Excel
Imports ErikEJ.SqlCe

Module Module2
    Public Sub DeleteHtmlFiles()
        Dim strFilex As String = ""
        Dim strDirx As String = Application.StartupPath
        Try
            For Each strFilex In Directory.GetFiles(strDirx, "*.html")
                File.Delete(strFilex)
            Next
            '//Alternative Code:
            'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "eLibReport.html", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
            'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "eLibCollect.html", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
        End Try
    End Sub

    'ADMIN Add_User
    Public Sub AddNewUser()
        Retval1 = 2 'User
        Retval2 = 0 'New user
        frmProject.ShowDialog()
        strUser = strProjectName     'using shared variables
        strUserPass = strProjectNote 'using shared variables
        If Len(strUserPass) > 20 Then strUserPass = Microsoft.VisualBasic.Left(strUserPass, 20)
        If Retval1 = 1 Then
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            If Retval3 = -1 Then Retval3 = 1
                            strSQL = "INSERT INTO usrs (UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15) VALUES (@usrname, @usrpass, @usractive, '-',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@usrname", strUser)
                            cmd.Parameters.AddWithValue("@usrpass", strUserPass)
                            cmd.Parameters.AddWithValue("@usractive", Retval3)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnSS.Close()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            If Retval3 = 1 Then Retval3 = -1
                            strSQL = "INSERT INTO usrs (UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15) VALUES (@usrname, @usrpass, @usractive, '-',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                            Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@usrname", strUser)
                            cmd.Parameters.AddWithValue("@usrpass", strUserPass)
                            cmd.Parameters.AddWithValue("@usractive", Retval3)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                    Case "Access"
                        Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                            CnnAC.Open()
                            If Retval3 = 1 Then Retval3 = -1
                            strSQL = "INSERT INTO usrs (UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15) VALUES (@usrname, @usrpass, @usractive, '-',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                            Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@usrname", strUser)
                            cmd.Parameters.AddWithValue("@usrpass", strUserPass)
                            cmd.Parameters.AddWithValue("@usractive", Retval3)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnAC.Close()
                        End Using
                End Select
                '  MsgBox("User Created !", vbInformation, "eLib")
            Catch ex As Exception
                Dim myansw As DialogResult = MsgBox("Error Creating new User for " & DatabaseType & " Database" & vbCrLf & "Show Error Message ?", vbYesNo, "eLib")
                If myansw = vbYes Then MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    '//Admin SCAN_Folders
    Public Sub eLibScanNames()
        Dim resultx As String = ValidateFolders()
        If resultx <> "valid" Then
            Dim myansw As DialogResult = MsgBox("eLib Folders not valid !" & vbCrLf & "Correct them now ?", vbYesNo + vbDefaultButton2, "eLib")
            If myansw = vbYes Then frmSettings.ShowDialog()
            Exit Sub
        End If
        '//EXTRACT FileNames : DIR /s >> text files
        Process.Start("cmd.exe", "/C Dir " & strFolderPapers & " /s > " & Application.StartupPath & "eLibP.txt").WaitForExit()
        Process.Start("cmd.exe", "/C Dir " & strFolderBooks & " /s > " & Application.StartupPath & "eLibB.txt").WaitForExit()
        Process.Start("cmd.exe", "/C Dir " & strFolderManuals & " /s > " & Application.StartupPath & "eLibM.txt").WaitForExit()
        Process.Start("cmd.exe", "/C Dir " & strFolderLectures & " /s > " & Application.StartupPath & "eLibL.txt").WaitForExit()
        '//Extract lines of interest out of textfiles!
        Dim strLine As String = ""
        Dim strName As String = ""
        For Each flnm As String In {"eLibP", "eLibB", "eLibM", "eLibL"}
            FileOpen(1, Application.StartupPath & flnm & ".txt", OpenMode.Input)
            FileOpen(2, Application.StartupPath & flnm & "x.txt", OpenMode.Output)
            strLine = LineInput(1)
            strLine = LineInput(1)
            While Not EOF(1)
                Try
                    strLine = Trim(LineInput(1))
                    If Len(strLine) < 40 Then GoTo Lblx
                    If (strLine = "") Or (InStr(1, strLine, "<DIR>") <> 0) Or (InStr(1, strLine, "Directory Of") <> 0) Or (InStr(1, strLine, "File(s) ") <> 0) Or (InStr(1, strLine, "Total Files Listed:") <> 0) Or (InStr(1, strLine, "Dir(s) ") <> 0) Then GoTo Lblx
                    If InStr(1, strLine, "\") <> 0 Then GoTo Lblx
                    strName = Mid(strLine, 40, Len(strLine) - 39)
                    strName = RemoveExtension(strName)
                    If Len(strName) > 8 Then PrintLine(2, strName)
                Catch ex As Exception
                    MsgBox("Error:   " & vbCrLf & strName & vbCrLf & ex.ToString)
                End Try
Lblx:
            End While
            FileClose(1)
            FileClose(2)
        Next flnm
        '//Prepare Table cols for Import
        Try
            DS.Tables("tblRefs1").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE Papers.ID =1;", CnnSS)
                        DASS.Fill(DS, "tblRefs1")
                        CnnSS.Close()
                    End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE Papers.ID =1;", CnnSC)
                        DASC.Fill(DS, "tblRefs1")
                        CnnSC.Close()
                    End Using
                '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                        CnnAC.Open()
                        DAAC = New OleDb.OleDbDataAdapter("SELECT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE Papers.ID =1;", CnnAC)
                        DAAC.Fill(DS, "tblRefs1")
                        CnnAC.Close()
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '//TRUE value= +1/-1 ?
        DS.Tables("tblRefs1").Clear()
        Dim Trux As Integer = 0
        Select Case DatabaseType
            Case "SqlServer" : Trux = 1
            Case "Access" : Trux = -1
        End Select
        '//IMPORT into tblPapers
        For Each flnm As String In {"P", "B", "M", "L"}
            FileOpen(1, Application.StartupPath & "eLib" & flnm & "x.txt", OpenMode.Input)
            While Not EOF(1)
                strLine = LineInput(1)
                Select Case flnm
                    Case "P" : DS.Tables("tblRefs1").Rows.Add(1, strLine, Trux, 0, 0, 0, "-")
                    Case "B" : DS.Tables("tblRefs1").Rows.Add(1, strLine, 0, Trux, 0, 0, "-")
                    Case "M" : DS.Tables("tblRefs1").Rows.Add(1, strLine, 0, 0, Trux, 0, "-")
                    Case "L" : DS.Tables("tblRefs1").Rows.Add(1, strLine, 0, 0, 0, Trux, "-")
                End Select
            End While
            FileClose(1)
            Application.DoEvents()
        Next flnm
        '//Remove Duplicates
        '//

        '//BULK-COPY
        BulkCopyPaperNames()
        '//Delete temporary files
        For Each flnm As String In {"eLibP", "eLibB", "eLibM", "eLibL"}
            If Dir(Application.StartupPath + flnm & ".txt") <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + flnm & ".txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
            If Dir(Application.StartupPath + flnm & "x.txt") <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + flnm & "x.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
        Next flnm
    End Sub
    Public Sub BulkCopyPaperNames()
        On Error Resume Next
        Select Case DatabaseType'-------- Bulk Copy -------- Bulk Copy -------- Bulk Copy -------- Bulk Copy 
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    Dim bCopy As New SqlClient.SqlBulkCopy(CnnSS)
                    bCopy.DestinationTableName = "Papers"
                    bCopy.BatchSize = DS.Tables("tblRefs1").Rows.Count
                    bCopy.WriteToServer(DS.Tables("tblRefs1"))
                    CnnSS.Close()
                End Using
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    'On Error GoTo 0
                    Dim options As SqlCeBulkCopyOptions = New SqlCeBulkCopyOptions
                    options = options Or SqlCeBulkCopyOptions.KeepNulls
                    Dim bCopy As New ErikEJ.SqlCe.SqlCeBulkCopy(CnnSC, options)
                    bCopy.DestinationTableName = "Papers"
                    bCopy.BatchSize = DS.Tables("tblRefs1").Rows.Count
                    bCopy.WriteToServer(DS.Tables("tblRefs1"))
                    CnnSC.Close()
                End Using
            Case "Access"
                '//Notice: no solution yet!   //work around:
                'Save data to a temp Excel file
                On Error GoTo 0
                Using WB As IXLWorkbook = New XLWorkbook
                    DS.Tables("tblRefs1").Clear()
                    DAAC = New OleDb.OleDbDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID ORDER BY Papers.ID;", CnnAC)
                    DAAC.Fill(DS, "tblRefs1")
                    Dim WS1 As IXLWorksheet = WB.Worksheets.Add("Papers")
                    WS1.Cell(1, 1).Value = "ID"
                    WS1.Cell(1, 2).Value = "PaperName"
                    WS1.Cell(1, 3).Value = "IsPaper"
                    WS1.Cell(1, 4).Value = "IsBook"
                    WS1.Cell(1, 5).Value = "IsManual"
                    WS1.Cell(1, 6).Value = "IsLecture"
                    WS1.Cell(1, 7).Value = "Notes"
                    For iRow As Integer = 1 To DS.Tables("tblRefs1").Rows.Count
                        For iCol = 1 To 7
                            WS1.Cell(iRow + 1, iCol).Value = DS.Tables("tblRefs1").Rows(iRow - 1).Item(iCol - 1)
                        Next iCol
                    Next iRow
                End Using
                '//Then, import from that excel file
                '//
        End Select
    End Sub
    Public Sub eLibScanPaths()
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
        Try '//Delete TABLE Paths - (formerly: TMPeLibPapers)
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "DELETE FROM Paths"
                    Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmdx.CommandType = CommandType.Text
                    Dim ix As Integer = cmdx.ExecuteNonQuery()
                Case "SqlServerCE"
                    strSQL = "DELETE FROM Paths"
                    Dim cmdx As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                    cmdx.CommandType = CommandType.Text
                    Dim ix As Integer = cmdx.ExecuteNonQuery()
                Case "Access"
                    strSQL = "DELETE FROM Paths"
                    Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmdx.CommandType = CommandType.Text
                    Dim ix As Integer = cmdx.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Process.Start("cmd.exe", "/C Dir " & strFolderPapers & " /s /b > " & Application.StartupPath & "eLibPz.txt").WaitForExit()
        Process.Start("cmd.exe", "/C Dir " & strFolderBooks & " /s /b > " & Application.StartupPath & "eLibBz.txt").WaitForExit()
        Process.Start("cmd.exe", "/C Dir " & strFolderManuals & " /s /b > " & Application.StartupPath & "eLibMz.txt").WaitForExit()
        Process.Start("cmd.exe", "/C Dir " & strFolderLectures & " /s /b > " & Application.StartupPath & "eLibLz.txt").WaitForExit()
        Try
            DS.Tables("tblRefPaths").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("SELECT ID, FilePath FROM Paths  WHERE ID =1;", CnnSS)
                    DASS.Fill(DS, "tblRefPaths")
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, FilePath FROM Paths  WHERE ID =1;", CnnSC)
                    DASC.Fill(DS, "tblRefPaths")
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("SELECT ID, FilePath FROM Paths  WHERE ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblRefPaths")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'Load fromTextFiles into tblTables:
        Dim A As String = ""
        For Each flnm As String In {"P", "B", "M", "L"}
            FileOpen(1, Application.StartupPath & "eLib" & flnm & "z.txt", OpenMode.Input)
            While Not EOF(1)
                Try
                    A = LineInput(1)
                    DS.Tables("tblRefPaths").Rows.Add(1, A)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End While
            FileClose(1)
            Application.DoEvents()
        Next flnm
        '//SqlServer-BulkCopy
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Dim bCopy As New SqlClient.SqlBulkCopy(CnnSS)
                    bCopy.DestinationTableName = "Paths"
                    bCopy.BatchSize = DS.Tables("tblRefPaths").Rows.Count
                    bCopy.WriteToServer(DS.Tables("tblRefPaths"))
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    Dim bCopy As New ErikEJ.SqlCe.SqlCeBulkCopy(CnnSC, 0)
                    bCopy.DestinationTableName = "Paths"
                    bCopy.BatchSize = DS.Tables("tblRefPaths").Rows.Count
                    bCopy.WriteToServer(DS.Tables("tblRefPaths"))
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                Case "Access"
                    '//do workaround!
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '//Delete temporary files
        For Each flnm As String In {"eLibP", "eLibB", "eLibM", "eLibL"}
            If Dir(Application.StartupPath + flnm & "z.txt") <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + flnm & "z.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
        Next flnm
        '//CLOSE ALL Connections
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
    End Sub
    Function RemoveExtension(strFlnm As String)
        strExt = ""
        strExt = LCase(Microsoft.VisualBasic.Right(strFlnm, 5))
        If strExt = ".docx" Or strExt = ".xlsx" Or strExt = ".pptx" Then
            strFlnm = Microsoft.VisualBasic.Left(strFlnm, Len(strFlnm) - 5)
            GoTo lblReturn
        End If
        strExt = LCase(Microsoft.VisualBasic.Right(strFlnm, 4))
        If strExt = ".pdf" Or strExt = ".doc" Or strExt = ".xls" Or strExt = ".ppt" Or strExt = ".bmp" Or strExt = ".jpg" Or strExt = ".png" Or strExt = ".txt" Then
            strFlnm = Microsoft.VisualBasic.Left(strFlnm, Len(strFlnm) - 4)
            GoTo lblReturn
        End If
lblReturn:
        RemoveExtension = strFlnm
    End Function
    '//Admin DB_Backup-Restore
    Public Sub eLib_Backup()
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
        Using WB As IXLWorkbook = New XLWorkbook
            Retval1 = 0
            '//-------------------------------------------------------------------------------------- 0 users
            Try
                DS.Tables("tblUsrs").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS = New SqlClient.SqlDataAdapter("SELECT ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs ORDER BY ID;", CnnSS)
                        DASS.Fill(DS, "tblUsrs")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                    Case "SqlServerCE"
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs ORDER BY ID;", CnnSC)
                        DASC.Fill(DS, "tblUsrs")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                    Case "Access"
                        DAAC = New OleDb.OleDbDataAdapter("SELECT ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs ORDER BY ID;", CnnAC)
                        DAAC.Fill(DS, "tblUsrs")
                End Select
                Dim WS0 As IXLWorksheet = WB.Worksheets.Add("Usrs")
                WS0.Cell(1, 1).Value = "ID"
                WS0.Cell(1, 2).Value = "UsrName"
                WS0.Cell(1, 3).Value = "UsrPass"
                WS0.Cell(1, 4).Value = "UsrActive"
                WS0.Cell(1, 5).Value = "UsrNote"
                WS0.Cell(1, 6).Value = "acc00"
                WS0.Cell(1, 7).Value = "acc01"
                WS0.Cell(1, 8).Value = "acc02"
                WS0.Cell(1, 9).Value = "acc03"
                WS0.Cell(1, 10).Value = "acc04"
                WS0.Cell(1, 11).Value = "acc05"
                WS0.Cell(1, 12).Value = "acc06"
                WS0.Cell(1, 13).Value = "acc07"
                WS0.Cell(1, 14).Value = "acc08"
                WS0.Cell(1, 15).Value = "acc09"
                WS0.Cell(1, 16).Value = "acc10"
                WS0.Cell(1, 17).Value = "acc11"
                WS0.Cell(1, 18).Value = "acc12"
                WS0.Cell(1, 19).Value = "acc13"
                WS0.Cell(1, 20).Value = "acc14"
                WS0.Cell(1, 21).Value = "acc15"
                For iRow As Integer = 1 To DS.Tables("tblUsrs").Rows.Count
                    For iCol = 1 To 21
                        WS0.Cell(iRow + 1, iCol).Value = DS.Tables("tblUsrs").Rows(iRow - 1).Item(iCol - 1)
                    Next iCol
                Next iRow
            Catch ex As Exception
                MsgBox("Error in Exporting Users")
                Exit Sub
            End Try
            '//-------------------------------------------------------------------------------------- 1 Papers
            Try
                DS.Tables("tblRefs1").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS = New SqlClient.SqlDataAdapter("SELECT Distinct ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Note FROM Papers ORDER BY ID;", CnnSS)
                        DASS.Fill(DS, "tblRefs1")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                    Case "SqlServerCE"
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Distinct ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Note FROM Papers ORDER BY ID;", CnnSC)
                        DASC.Fill(DS, "tblRefs1")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                    Case "Access"
                        'DAAC = New OleDb.OleDbDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID ORDER BY Papers.ID;", CnnAC)
                        DAAC = New OleDb.OleDbDataAdapter("SELECT Distinct ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Note FROM Papers ORDER BY ID;", CnnAC)
                        DAAC.Fill(DS, "tblRefs1")
                End Select
                Dim WS1 As IXLWorksheet = WB.Worksheets.Add("Papers")
                WS1.Cell(1, 1).Value = "ID"
                WS1.Cell(1, 2).Value = "PaperName"
                WS1.Cell(1, 3).Value = "IsPaper"
                WS1.Cell(1, 4).Value = "IsBook"
                WS1.Cell(1, 5).Value = "IsManual"
                WS1.Cell(1, 6).Value = "IsLecture"
                WS1.Cell(1, 7).Value = "Note"
                For iRow As Integer = 1 To DS.Tables("tblRefs1").Rows.Count
                    For iCol = 1 To 7
                        WS1.Cell(iRow + 1, iCol).Value = DS.Tables("tblRefs1").Rows(iRow - 1).Item(iCol - 1)
                    Next iCol
                Next iRow
            Catch ex As Exception
                MsgBox("Error in Exporting Refs")
                Exit Sub
            End Try
            '//-------------------------------------------------------------------------------------- 2 Projects
            Try
                DS.Tables("tblProject").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Order By ID"
                        DASS = New SqlClient.SqlDataAdapter(strSQL, CnnSS)
                        DASS.Fill(DS, "tblProject")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                    Case "SqlServerCE"
                        strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Order By ID"
                        DASC = New SqlServerCe.SqlCeDataAdapter(strSQL, CnnSC)
                        DASC.Fill(DS, "tblProject")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                    Case "Access"
                        strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Order By ID"
                        DAAC = New OleDb.OleDbDataAdapter(strSQL, CnnAC)
                        DAAC.Fill(DS, "tblProject")
                End Select
                Dim WS2 As IXLWorksheet = WB.Worksheets.Add("Projects")
                WS2.Cell(1, 1).Value = "ID"
                WS2.Cell(1, 2).Value = "ProjectName"
                WS2.Cell(1, 3).Value = "Notes"
                WS2.Cell(1, 4).Value = "Active"
                WS2.Cell(1, 5).Value = "user_ID"
                For iRow As Integer = 1 To DS.Tables("tblProject").Rows.Count
                    For iCol = 1 To 5
                        WS2.Cell(iRow + 1, iCol).Value = DS.Tables("tblProject").Rows(iRow - 1).Item(iCol - 1)
                    Next iCol
                Next iRow
            Catch ex As Exception
                MsgBox("Error in Exporting Projects")
                Exit Sub
            End Try
            '//-------------------------------------------------------------------------------------- 3 Products
            Try
                DS.Tables("tblProduct").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS = New SqlClient.SqlDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product Order by ID", CnnSS)
                        DASS.Fill(DS, "tblProduct")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                    Case "SqlServerCE"
                        DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product Order by ID", CnnSC)
                        DASC.Fill(DS, "tblProduct")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                    Case "Access"
                        DAAC = New OleDb.OleDbDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product Order by ID", CnnAC)
                        DAAC.Fill(DS, "tblProduct")
                End Select
                Dim WS3 As IXLWorksheet = WB.Worksheets.Add("Products")
                WS3.Cell(1, 1).Value = "ID"
                WS3.Cell(1, 2).Value = "ProductName"
                WS3.Cell(1, 3).Value = "Notes"
                WS3.Cell(1, 4).Value = "Project_ID"
                For iRow As Integer = 1 To DS.Tables("tblProduct").Rows.Count
                    For iCol = 1 To 4
                        WS3.Cell(iRow + 1, iCol).Value = DS.Tables("tblProduct").Rows(iRow - 1).Item(iCol - 1)
                    Next iCol
                Next iRow
            Catch ex As Exception
                MsgBox("Error in Exporting subProjects")
                Exit Sub
            End Try
            '//-------------------------------------------------------------------------------------- 4 Assignments
            Try
                DS.Tables("tblAssignments").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS = New SqlClient.SqlDataAdapter("SELECT Paper_Product.ID, Paper_ID, Product_ID, Paper_Product.Note, Imp1, Imp2, Imp3, ImR FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID ORDER BY Paper_Product.ID;", CnnSS)
                        DASS.Fill(DS, "tblAssignments")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                    Case "SqlServerCE"
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Paper_Product.ID, Paper_ID, Product_ID, Paper_Product.Note, Imp1, Imp2, Imp3, ImR FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID ORDER BY Paper_Product.ID;", CnnSC)
                        DASC.Fill(DS, "tblAssignments")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                    Case "Access"
                        DAAC = New OleDb.OleDbDataAdapter("SELECT Paper_Product.ID, Paper_ID, Product_ID, Paper_Product.Note, Imp1, Imp2, Imp3, ImR FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID ORDER BY Paper_Product.ID;", CnnAC)
                        DAAC.Fill(DS, "tblAssignments")
                End Select
                Dim WS4 As IXLWorksheet = WB.Worksheets.Add("Assignments")
                WS4.Cell(1, 1).Value = "ID"
                WS4.Cell(1, 2).Value = "Paper_ID"
                WS4.Cell(1, 3).Value = "Product_ID"
                WS4.Cell(1, 4).Value = "Note"
                WS4.Cell(1, 5).Value = "Imp1"
                WS4.Cell(1, 6).Value = "Imp2"
                WS4.Cell(1, 7).Value = "Imp3"
                WS4.Cell(1, 8).Value = "ImR"
                For iRow As Integer = 1 To DS.Tables("tblAssignments").Rows.Count
                    For iCol = 1 To 8
                        WS4.Cell(iRow + 1, iCol).Value = DS.Tables("tblAssignments").Rows(iRow - 1).Item(iCol - 1)
                    Next iCol
                Next iRow
            Catch ex As Exception
                MsgBox("Error in Exporting Assignments")
                Exit Sub
            End Try
            '//-------------------------------------------------------------------------------------- 5 ProductNotes
            Try
                DS.Tables("tblProductNotes").Clear()
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS = New SqlClient.SqlDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes ORDER BY ID;", CnnSS)
                        DASS.Fill(DS, "tblProductNotes")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                    Case "SqlServerCE"
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes ORDER BY ID;", CnnSC)
                        DASC.Fill(DS, "tblProductNotes")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
                    Case "Access"
                        DAAC = New OleDb.OleDbDataAdapter("SELECT ID, NoteDatum, [Note], Product_ID FROM ProductNotes ORDER BY ID;", CnnAC)
                        DAAC.Fill(DS, "tblProductNotes")
                End Select
                Dim WS5 As IXLWorksheet = WB.Worksheets.Add("ProductNotes")
                WS5.Cell(1, 1).Value = "ID"
                WS5.Cell(1, 2).Value = "NoteDatum"
                WS5.Cell(1, 3).Value = "Note"
                WS5.Cell(1, 4).Value = "Product_ID"
                For iRow As Integer = 1 To DS.Tables("tblProductNotes").Rows.Count
                    For iCol = 1 To 4
                        WS5.Cell(iRow + 1, iCol).Value = DS.Tables("tblProductNotes").Rows(iRow - 1).Item(iCol - 1)
                    Next iCol
                Next iRow
            Catch ex As Exception
                MsgBox("Error in Exporting subProjectNotes")
                Exit Sub
            End Try
            '//Save Excel
            WB.SaveAs(Application.StartupPath & "eLibExport" & System.DateTime.Now.ToString("yyyyMMddHHmmss") & ".xlsx")
            Retval1 = 1
        End Using
        '//CLOSE ALL Connections
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
    End Sub
    Public Sub eLib_Restore()
        '//File Dialog to get address of Restore_Media (Excel File) ---------------------------------------------- A  A  A  A  A  A  A  A  A  A  A  
        Retval1 = 0
        Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "eLib Restore Media|*.xlsx"}
            If dialog.ShowDialog = DialogResult.OK Then
                strFilename = dialog.FileName
            Else
                Exit Sub
            End If
        End Using
        '//Initiate tbls (ensure cols are constructed) -------------------------------------------------------------- B  B  B  B  B  B  B  B  B  B  B
        'Notice: Codes (for accdb) Are ABANDONED (restore from within Access)
        'tblUsrs
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
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs WHERE ID =1;", CnnSS)
                    DASS.Fill(DS, "tblUsrs")
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs WHERE ID =1;", CnnSC)
                    DASC.Fill(DS, "tblUsrs")
                        '--------- access --------- access --------- access --------- access --------- access --------- access --------- access 
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs WHERE ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblUsrs")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'tblRefs1        
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Papers.ID =1;", CnnSS)
                    DASS.Fill(DS, "tblRefs1")
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Papers.ID =1;", CnnSC)
                    DASC.Fill(DS, "tblRefs1")
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access 
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note From Papers INNER Join (Paper_Product INNER Join (Project INNER Join Product On Project.ID = Product.Project_ID) ON Paper_Product.Product_ID = Product.ID) ON Papers.ID = Paper_Product.Paper_ID WHERE Papers.ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblRefs1")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'tblProject      
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("Select ID, ProjectName, Notes, Active, user_ID FROM Project WHERE ID =1;", CnnSS)
                    DASS.Fill(DS, "tblProject")
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, ProjectName, Notes, Active, user_ID FROM Project WHERE ID =1;", CnnSC)
                    DASC.Fill(DS, "tblProject")
                    '--------- access --------- access --------- access --------- access --------- access --------- access --------- access 
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("Select ID, ProjectName, Notes, Active, user_ID FROM Project WHERE ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblProject")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'tblProduct      
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product WHERE ID =1;", CnnSS)
                    DASS.Fill(DS, "tblProduct")
              '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product WHERE ID =1;", CnnSC)
                    DASC.Fill(DS, "tblProduct")
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access 
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("Select ID, ProductName, Notes, Project_ID FROM Product WHERE ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblProduct")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'tblAssignments  
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("SELECT Paper_Product.ID, Paper_ID, Product_ID, ProductName, Paper_Product.Note, user_ID FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID WHERE Paper_Product.ID =1;", CnnSS)
                    DASS.Fill(DS, "tblAssignments")
                    '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE ---------
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Paper_Product.ID, Paper_ID, Product_ID, ProductName, Paper_Product.Note, user_ID FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID WHERE Paper_Product.ID =1;", CnnSC)
                    DASC.Fill(DS, "tblAssignments")
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access 
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("SELECT Paper_Product.ID, Paper_ID, Product_ID, ProductName, Paper_Product.Note, user_ID FROM Project INNER JOIN (Product INNER JOIN Paper_Product ON Product.ID = Paper_Product.Product_ID) ON Project.ID = Product.Project_ID WHERE Paper_Product.ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblAssignments")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'tblProductNotes 
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes WHERE ID =1;", CnnSS)
                    DASS.Fill(DS, "tblProductNotes")
               '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
                Case "SqlServerCE"
                    DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, NoteDatum, Note, Product_ID FROM ProductNotes WHERE ID =1;", CnnSC)
                    DASC.Fill(DS, "tblProductNotes")
               '--------- access --------- access --------- access --------- access --------- access --------- access --------- access 
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("SELECT ID, NoteDatum, [Note], Product_ID FROM ProductNotes WHERE ID =1;", CnnAC)
                    DAAC.Fill(DS, "tblProductNotes")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '//Del Database Tables Rows ----------------------------------------------------------------------------- C  C  C  C  C  C  C  C  C  C  C
        WipeOutAndResetCurrentDatabase()
        If (Retval1 = 0) Or (Retval2 = 0) Then
            Exit Sub
        End If
        '//Restore back data from Excel (strFileName) to tbls (DataTables) {usr, Papers, Project, Product, ...} ----- D  D  D  D  D  D  D  D  D  D
        Retval1 = 0
        Using WB As IXLWorkbook = New XLWorkbook(strFilename)
            '//-----Restore--------Restore----------Restore--------Restore---------Restore---------Restore-------- 0 users
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT usrs ON"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT usrs ON"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            Try
                Dim WS0 As IXLWorksheet = WB.Worksheets(0)
                Dim iRow As Integer = 0
                Dim strUserNote As String = ""
                Dim boolUserActive As Integer = 0
                For Each Rowx As IXLRow In WS0.Rows()
                    iRow = iRow + 1
                    If iRow > 1 Then
                        intUser = Int(WS0.Cell(iRow, 1).Value)
                        strUser = WS0.Cell(iRow, 2).Value
                        strUserPass = WS0.Cell(iRow, 3).Value
                        If WS0.Cell(iRow, 4).Value = "TRUE" Then boolUserActive = 1 Else boolUserActive = 0
                        strUserNote = WS0.Cell(iRow, 5).Value
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "INSERT INTO usrs (ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15) VALUES (@id, @usrname, @usrpass, @usractive, @usrnote,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intUser)
                                cmd.Parameters.AddWithValue("@usrname", strUser)
                                cmd.Parameters.AddWithValue("@usrpass", strUserPass)
                                cmd.Parameters.AddWithValue("@usractive", boolUserActive.ToString)
                                cmd.Parameters.AddWithValue("@usrnote", strUserNote)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new user" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "SqlServerCE"
                                If boolUserActive = 1 Then boolUserActive = -1
                                strSQL = "INSERT INTO usrs (ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15) VALUES (@id, @usrname, @usrpass, @usractive, @usrnote,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intUser)
                                cmd.Parameters.AddWithValue("@usrname", strUser)
                                cmd.Parameters.AddWithValue("@usrpass", strUserPass)
                                cmd.Parameters.AddWithValue("@usractive", boolUserActive)
                                cmd.Parameters.AddWithValue("@usrnote", strUserNote)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new user" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "Access"
                                If boolUserActive = 1 Then boolUserActive = -1
                                strSQL = "INSERT INTO usrs (ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15) VALUES (@id, @usrname, @usrpass, @usractive, @usrnote,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intUser)
                                cmd.Parameters.AddWithValue("@usrname", strUser)
                                cmd.Parameters.AddWithValue("@usrpass", strUserPass)
                                cmd.Parameters.AddWithValue("@usractive", boolUserActive.ToString)
                                cmd.Parameters.AddWithValue("@usrnote", strUserNote)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new user " & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                        End Select
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error in Importing Users" & vbCrLf & ex.ToString)
                Exit Sub
            End Try
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT usrs OFF"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT usrs OFF"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            '//-----Restore--------Restore----------Restore--------Restore---------Restore---------Restore-------- 1 Papers
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Papers ON"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Papers ON"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            Try
                Dim WS1 As IXLWorksheet = WB.Worksheets(1)
                Dim iRow As Integer = 0
                Dim intPaperID As Integer = 0
                Dim strPaperName As String = ""
                Dim boolIsPaper As Integer = 0
                Dim boolIsBook As Integer = 0
                Dim boolIsManual As Integer = 0
                Dim boolIsLecture As Integer = 0
                Dim strPaperNote As String = ""
                For Each Rowx As IXLRow In WS1.Rows()
                    iRow = iRow + 1
                    If iRow > 1 Then
                        intPaperID = Int(WS1.Cell(iRow, 1).Value)
                        strPaperName = WS1.Cell(iRow, 2).Value
                        If WS1.Cell(iRow, 3).Value = "TRUE" Then boolIsPaper = 1 Else boolIsPaper = 0
                        If WS1.Cell(iRow, 4).Value = "TRUE" Then boolIsBook = 1 Else boolIsBook = 0
                        If WS1.Cell(iRow, 5).Value = "TRUE" Then boolIsManual = 1 Else boolIsManual = 0
                        If WS1.Cell(iRow, 6).Value = "TRUE" Then boolIsLecture = 1 Else boolIsLecture = 0
                        strPaperNote = WS1.Cell(iRow, 7).Value
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "INSERT INTO Papers (ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Note) VALUES (@id, @papername, @ispaper, @isbook, @ismanual, @islecture, @notes)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intPaperID)
                                cmd.Parameters.AddWithValue("@papername", strPaperName)
                                cmd.Parameters.AddWithValue("@ispaper", boolIsPaper.ToString)
                                cmd.Parameters.AddWithValue("@isbook", boolIsBook.ToString)
                                cmd.Parameters.AddWithValue("@ismanual", boolIsManual.ToString)
                                cmd.Parameters.AddWithValue("@islecture", boolIsLecture.ToString)
                                cmd.Parameters.AddWithValue("@notes", strPaperNote)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new paper" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "SqlServerCE"
                                If boolIsPaper = 1 Then boolIsPaper = -1
                                If boolIsBook = 1 Then boolIsBook = -1
                                If boolIsManual = 1 Then boolIsManual = -1
                                If boolIsLecture = 1 Then boolIsLecture = -1
                                strSQL = "INSERT INTO Papers (ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Note) VALUES (@id, @papername, @ispaper, @isbook, @ismanual, @islecture, @notes)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intPaperID)
                                cmd.Parameters.AddWithValue("@papername", strPaperName)
                                cmd.Parameters.AddWithValue("@ispaper", boolIsPaper)
                                cmd.Parameters.AddWithValue("@isbook", boolIsBook)
                                cmd.Parameters.AddWithValue("@ismanual", boolIsManual)
                                cmd.Parameters.AddWithValue("@islecture", boolIsLecture)
                                cmd.Parameters.AddWithValue("@notes", strPaperNote)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new paper" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "Access"
                                If boolIsPaper = 1 Then boolIsPaper = -1
                                If boolIsBook = 1 Then boolIsBook = -1
                                If boolIsManual = 1 Then boolIsManual = -1
                                If boolIsLecture = 1 Then boolIsLecture = -1
                                strSQL = "INSERT INTO Papers (ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Note) VALUES (@id, @papername, @ispaper, @isbook, @ismanual, @islecture, @notes)"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intPaperID)
                                cmd.Parameters.AddWithValue("@papername", strPaperName)
                                cmd.Parameters.AddWithValue("@ispaper", boolIsPaper.ToString)
                                cmd.Parameters.AddWithValue("@isbook", boolIsBook.ToString)
                                cmd.Parameters.AddWithValue("@ismanual", boolIsManual.ToString)
                                cmd.Parameters.AddWithValue("@islecture", boolIsLecture.ToString)
                                cmd.Parameters.AddWithValue("@notes", strPaperNote)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new paper " & iRow.ToString & "  /  " & strPaperName & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                        End Select
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error in Importing Papers" & vbCrLf & ex.ToString)
                Exit Sub
            End Try
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Papers OFF"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Papers OFF"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            '//-----Restore--------Restore----------Restore--------Restore---------Restore---------Restore-------- 2 Projects
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Project ON"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Project ON"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            Try
                Dim WS2 As IXLWorksheet = WB.Worksheets(2)
                Dim iRow As Integer = 0
                Dim intProjectID As Integer = 0
                Dim strProjectName As String = ""
                Dim strProjectNotes As String = ""
                Dim boolProjectActive As Integer = 0
                Dim intUserID As Integer = 0
                For Each Rowx As IXLRow In WS2.Rows()
                    iRow = iRow + 1
                    If iRow > 1 Then
                        intProjectID = Int(WS2.Cell(iRow, 1).Value)
                        strProjectName = WS2.Cell(iRow, 2).Value
                        strProjectNotes = WS2.Cell(iRow, 3).Value
                        If WS2.Cell(iRow, 4).Value = "TRUE" Then boolProjectActive = 1 Else boolProjectActive = 0
                        intUserID = Int(WS2.Cell(iRow, 5).Value)
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "INSERT INTO Project (ID, ProjectName, Notes, Active, user_ID) VALUES (@id, @projectname, @notes, @active, @userid)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProjectID)
                                cmd.Parameters.AddWithValue("@projectname", strProjectName)
                                cmd.Parameters.AddWithValue("@notes", strProjectNotes)
                                cmd.Parameters.AddWithValue("@active", boolProjectActive.ToString)
                                cmd.Parameters.AddWithValue("@userid", intUserID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new project" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "SqlServerCE"
                                If boolProjectActive = 1 Then boolProjectActive = -1
                                strSQL = "INSERT INTO Project (ID, ProjectName, Notes, Active, user_ID) VALUES (@id, @projectname, @notes, @active, @userid)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProjectID)
                                cmd.Parameters.AddWithValue("@projectname", strProjectName)
                                cmd.Parameters.AddWithValue("@notes", strProjectNotes)
                                cmd.Parameters.AddWithValue("@active", boolProjectActive)
                                cmd.Parameters.AddWithValue("@userid", intUserID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new project" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "Access"
                                If boolProjectActive = 1 Then boolProjectActive = -1
                                strSQL = "INSERT INTO Project (ID, ProjectName, Notes, Active, user_ID) VALUES (@id, @projectname, @notes, @active, @userid)"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProjectID)
                                cmd.Parameters.AddWithValue("@projectname", strProjectName)
                                cmd.Parameters.AddWithValue("@notes", strProjectNotes)
                                cmd.Parameters.AddWithValue("@active", boolProjectActive.ToString)
                                cmd.Parameters.AddWithValue("@userid", intUserID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new project " & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                        End Select
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error in Importing Projects" & vbCrLf & ex.ToString)
                Exit Sub
            End Try
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Project OFF"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Project OFF"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            '//-----Restore--------Restore----------Restore--------Restore---------Restore---------Restore-------- 3 Products
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Product ON"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Product ON"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            Try
                Dim WS3 As IXLWorksheet = WB.Worksheets(3)
                Dim iRow As Integer = 0
                Dim intProductID As Integer = 0
                Dim strProductName As String = ""
                Dim strProductNotes As String = ""
                Dim intProjectID As Integer = 0
                For Each Rowx As IXLRow In WS3.Rows()
                    iRow = iRow + 1
                    If iRow > 1 Then
                        intProductID = Int(WS3.Cell(iRow, 1).Value)
                        strProductName = WS3.Cell(iRow, 2).Value
                        strProductNotes = WS3.Cell(iRow, 3).Value
                        intProjectID = Int(WS3.Cell(iRow, 4).Value)
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "INSERT INTO Product (ID, ProductName, Notes, Project_ID) VALUES (@id, @productname, @notes, @projectid)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProductID)
                                cmd.Parameters.AddWithValue("@productname", strProductName)
                                cmd.Parameters.AddWithValue("@notes", strProductNotes)
                                cmd.Parameters.AddWithValue("@projectid", intProjectID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new product" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "SqlServerCE"
                                strSQL = "INSERT INTO Product (ID, ProductName, Notes, Project_ID) VALUES (@id, @productname, @notes, @projectid)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProductID)
                                cmd.Parameters.AddWithValue("@productname", strProductName)
                                cmd.Parameters.AddWithValue("@notes", strProductNotes)
                                cmd.Parameters.AddWithValue("@projectid", intProjectID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new product" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "Access"
                                strSQL = "INSERT INTO Product (ID, ProductName, Notes, Project_ID) VALUES (@id, @productname, @notes, @projectid)"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProductID)
                                cmd.Parameters.AddWithValue("@productname", strProductName)
                                cmd.Parameters.AddWithValue("@notes", strProductNotes)
                                cmd.Parameters.AddWithValue("@projectid", intProjectID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new project " & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                        End Select
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error in Importing Products" & vbCrLf & ex.ToString)
                Exit Sub
            End Try
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Product OFF"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Product OFF"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            '//-----Restore--------Restore----------Restore--------Restore---------Restore---------Restore-------- 4 Assignments
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Paper_Product ON"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Paper_Product ON"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            Try
                Dim WS4 As IXLWorksheet = WB.Worksheets(4)
                Dim iRow As Integer = 0
                Dim intPaperProduct As Integer = 0
                Dim intPaperID As Integer = 0
                Dim intProductID As Integer = 0
                Dim strPaperProductNote As String = ""
                Dim boolImp1 As Integer = 0
                Dim boolImp2 As Integer = 0
                Dim boolImp3 As Integer = 0
                Dim boolImR As Integer = 0
                For Each Rowx As IXLRow In WS4.Rows()
                    iRow = iRow + 1
                    If iRow > 1 Then
                        intPaperProduct = Int(WS4.Cell(iRow, 1).Value)
                        intPaperID = Int(WS4.Cell(iRow, 2).Value)
                        intProductID = Int(WS4.Cell(iRow, 3).Value)
                        strPaperProductNote = WS4.Cell(iRow, 4).Value
                        If WS4.Cell(iRow, 5).Value = "TRUE" Then boolImp1 = 1 Else boolImp1 = 0
                        If WS4.Cell(iRow, 6).Value = "TRUE" Then boolImp2 = 1 Else boolImp2 = 0
                        If WS4.Cell(iRow, 7).Value = "TRUE" Then boolImp3 = 1 Else boolImp3 = 0
                        If WS4.Cell(iRow, 8).Value = "TRUE" Then boolImR = 1 Else boolImR = 0
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "INSERT INTO Paper_Product (ID, Paper_ID, Product_ID, Note, Imp1, Imp2, Imp3, ImR) VALUES (@id, @paperid, @productid, @note, @imp1, @imp2, @imp3, @imr)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intPaperProduct)
                                cmd.Parameters.AddWithValue("@paperid", intPaperID.ToString)
                                cmd.Parameters.AddWithValue("@productid", intProductID.ToString)
                                cmd.Parameters.AddWithValue("@note", strPaperProductNote)
                                cmd.Parameters.AddWithValue("@imp1", boolImp1.ToString)
                                cmd.Parameters.AddWithValue("@imp2", boolImp2.ToString)
                                cmd.Parameters.AddWithValue("@imp3", boolImp3.ToString)
                                cmd.Parameters.AddWithValue("@imr", boolImR.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new Assignments" & iRow.ToString & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "SqlServerCE"
                                If boolImp1 = 1 Then boolImp1 = -1
                                If boolImp2 = 1 Then boolImp2 = -1
                                If boolImp3 = 1 Then boolImp3 = -1
                                If boolImR = 1 Then boolImR = -1
                                strSQL = "INSERT INTO Paper_Product (ID, Paper_ID, Product_ID, Note, Imp1, Imp2, Imp3, ImR) VALUES (@id, @paperid, @productid, @note, @imp1, @imp2, @imp3, @imr)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intPaperProduct)
                                cmd.Parameters.AddWithValue("@paperid", intPaperID.ToString)
                                cmd.Parameters.AddWithValue("@productid", intProductID.ToString)
                                cmd.Parameters.AddWithValue("@note", strPaperProductNote)
                                cmd.Parameters.AddWithValue("@imp1", boolImp1)
                                cmd.Parameters.AddWithValue("@imp2", boolImp2)
                                cmd.Parameters.AddWithValue("@imp3", boolImp3)
                                cmd.Parameters.AddWithValue("@imr", boolImR)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new Assignments" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "Access"
                                If boolImp1 = 1 Then boolImp1 = -1
                                If boolImp2 = 1 Then boolImp2 = -1
                                If boolImp3 = 1 Then boolImp3 = -1
                                If boolImR = 1 Then boolImR = -1
                                strSQL = "INSERT INTO Paper_Product (ID, Paper_ID, Product_ID, Note, Imp1, Imp2, Imp3, ImR) VALUES (@id, @paperid, @productid, @note, @imp1, @imp2, @imp3, @imr)"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intPaperProduct)
                                cmd.Parameters.AddWithValue("@paperid", intPaperID.ToString)
                                cmd.Parameters.AddWithValue("@productid", intProductID.ToString)
                                cmd.Parameters.AddWithValue("@note", strPaperProductNote)
                                cmd.Parameters.AddWithValue("@imp1", boolImp1.ToString)
                                cmd.Parameters.AddWithValue("@imp2", boolImp2.ToString)
                                cmd.Parameters.AddWithValue("@imp3", boolImp3.ToString)
                                cmd.Parameters.AddWithValue("@imr", boolImR.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new Assignments " & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                        End Select
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error in Importing Assignments" & vbCrLf & ex.ToString)
                Exit Sub
            End Try
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT Paper_Product OFF"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT Paper_Product OFF"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            '//-----Restore--------Restore----------Restore--------Restore---------Restore---------Restore-------- 5 ProductNotes
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT ProductNotes ON"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT ProductNotes ON"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            Try
                Dim WS5 As IXLWorksheet = WB.Worksheets(5)
                Dim iRow As Integer = 0
                Dim intProductNote As Integer = 0
                Dim strNoteDatum As String = ""
                Dim strNotes As String = ""
                Dim intProductID As Integer = 0
                For Each Rowx As IXLRow In WS5.Rows()
                    iRow = iRow + 1
                    If iRow > 1 Then
                        intProductNote = Int(WS5.Cell(iRow, 1).Value)
                        strNoteDatum = WS5.Cell(iRow, 2).Value
                        strNotes = WS5.Cell(iRow, 3).Value
                        intProductID = Int(WS5.Cell(iRow, 4).Value)
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "INSERT INTO ProductNotes (ID, NoteDatum, Note, Product_ID) VALUES (@id, @datum, @note, @productid)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProductNote)
                                cmd.Parameters.AddWithValue("@datum", strNoteDatum)
                                cmd.Parameters.AddWithValue("@note", strNotes)
                                cmd.Parameters.AddWithValue("@productid", intProductID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new ProductNotes" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "SqlServerCE"
                                strSQL = "INSERT INTO ProductNotes (ID, NoteDatum, Note, Product_ID) VALUES (@id, @datum, @note, @productid)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProductNote)
                                cmd.Parameters.AddWithValue("@datum", strNoteDatum)
                                cmd.Parameters.AddWithValue("@note", strNotes)
                                cmd.Parameters.AddWithValue("@productid", intProductID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new ProductNotes" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                            Case "Access"
                                strSQL = "INSERT INTO ProductNotes (ID, NoteDatum, [Note], Product_ID) VALUES (@id, @datum, @note, @productid)"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intProductNote)
                                cmd.Parameters.AddWithValue("@datum", strNoteDatum)
                                cmd.Parameters.AddWithValue("@note", strNotes)
                                cmd.Parameters.AddWithValue("@productid", intProductID.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                Catch ex As Exception
                                    MsgBox("Error creating new ProductNotes " & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                End Try
                        End Select
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error in Importing ProductNotes" & vbCrLf & ex.ToString)
                Exit Sub
            End Try
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "SET IDENTITY_INSERT ProductNotes OFF"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "SET IDENTITY_INSERT ProductNotes OFF"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        '    'no solution for accdb! 
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
                'Exit Sub
            End Try
            'RESTORE FINISHED SUCCESSFULLY! ------------------------------------------------------------------------ Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z  Z
            Retval1 = 1
        End Using
        '//CLOSE ALL Connections
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
    End Sub
    Public Sub WipeOutAndResetCurrentDatabase()
        '//Assuming that A CONNECTION is Already OPEN for this SUB
        Retval1 = 0
        '//Clear DataTables 
        DS.Tables("tblUsrs").Clear()
        DS.Tables("tblRefs1").Clear()
        DS.Tables("tblProject").Clear()
        DS.Tables("tblProduct").Clear()
        DS.Tables("tblAssignments").Clear()
        DS.Tables("tblRefs2").Clear() 'not necessary
        DS.Tables("tblProductNotes").Clear()
        '//Del Database Tables Rows 
        Try
            For Each strTableName In {"usrs", "Papers", "Paths", "Project", "Product", "Paper_Product", "ProductNotes"}
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "DELETE FROM " & strTableName & ";"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "DELETE FROM " & strTableName & ";"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access" '//Codes (for accdb) Are ABANDONED (restore from within Access)
                        strSQL = "DELETE * FROM " & strTableName & ";"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select
            Next
            Retval1 = 1
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        '//RESEED Table IDs to 1
        Retval2 = 0
        Try
            For Each strTableName In {"usrs", "Papers", "Paths", "Project", "Product", "Paper_Product", "ProductNotes"}
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "DBCC CHECKIDENT (" & strTableName & ", RESEED, 1)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "SqlServerCE"
                        strSQL = "ALTER TABLE " & strTableName & " ALTER COLUMN [Id] IDENTITY (1, 1)"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access" 'Different method of reseting ID for accdb //Codes (for accdb) Are ABANDONED (restore from within Access)
                        'Copy a Table
                        strSQL = "SELECT * INTO " & strTableName & "_new FROM " & strTableName & ";"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        'Del Old Table
                        strSQL = "DROP TABLE " & strTableName & ";"
                        Dim cmd2 As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd2.CommandType = CommandType.Text
                        i = cmd2.ExecuteNonQuery()
                        'Copy back the Table
                        strSQL = "SELECT * INTO " & strTableName & " FROM " & strTableName & "_new;"
                        Dim cmd3 As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd3.CommandType = CommandType.Text
                        i = cmd3.ExecuteNonQuery()
                        'Del middle Table
                        strSQL = "DROP TABLE " & strTableName & "_new;"
                        Dim cmd4 As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd4.CommandType = CommandType.Text
                        i = cmd4.ExecuteNonQuery()
                End Select
            Next
            Retval2 = 1
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub



    '//QRCODE
    Sub QRCodeGen(strText2Code)
        'On Error Resume Next
        Try
            Dim strFile As String
            Dim strDir As String = Application.StartupPath
            For Each strFile In Directory.GetFiles(strDir, "eLibQRCode*.*")
                File.Delete(strFile)
            Next
        Catch ex As Exception
            'MsgBox("Error deleting old files ...  " & ex.ToString)
        End Try
        Try
            Dim strFlnm As String = "eLibQRCode" & System.DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim strQRCodeTextFilename As String = Application.StartupPath & strFlnm & ".iQR"
            Dim strQRCodeImageFileName As String = Application.StartupPath & strFlnm & ".PNG"
            FileOpen(1, strQRCodeTextFilename, OpenMode.Output)
            PrintLine(1, strText2Code)
            FileClose(1)
            Dim strQRCodeGenType As String = "58"
            Process.Start(Application.StartupPath & "Zint\Zint.exe", "-b " & strQRCodeGenType & " -o " & strQRCodeImageFileName & " -i " & strQRCodeTextFilename).WaitForExit()
            Application.DoEvents()
            strFilename = strQRCodeImageFileName
            My.Computer.FileSystem.DeleteFile(strQRCodeTextFilename, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
            frmQR.ShowDialog()
        Catch ex As Exception
            MsgBox("Error Creating QRCode!" & ex.ToString)
        End Try

    End Sub

    '//URLs
    Sub SearchScholar(strSearchScholar As String)
        'Search Google Scholar
        strSearchScholar = Replace(strSearchScholar, " ", "+")
        strSearchScholar = Replace(strSearchScholar, "-", " ")
        Select Case Right(strSearchScholar, 4)
            Case ".doc", ".pdf", ".xls", ".ppt" : strSearchScholar = Microsoft.VisualBasic.Left(strSearchScholar, Len(strSearchScholar) - 4)
            Case "docx", "xlsx", "pptx" : strSearchScholar = Microsoft.VisualBasic.Left(strSearchScholar, Len(strSearchScholar) - 5)
        End Select
        Dim StrURLx As String = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C5&q=" & strSearchScholar & "&btnG="
        OpenAURL(StrURLx)
    End Sub
    Sub OpenAURL(StrURL)
        Try
            Dim pWeb As Process = New Process()
            pWeb.StartInfo.UseShellExecute = True
            pWeb.StartInfo.FileName = "microsoft-edge:" & StrURL
            pWeb.Start()
        Catch ex As Exception
            MsgBox("Edge Internet browser not found!", vbOKOnly, "eLib") 'MsgBox(ex.ToString)
        End Try
    End Sub





    'Waiting Codes ... Journals
    Public Sub CloseAllWordInstances()
        '        '    Dim objWordx As Object
        '        '    Do
        '        '        On Error Resume Next
        '        'Set objWordx = GetObject(, "Word.Application")
        '        'If Not objWordx Is Nothing Then
        '        '            objWordx.Quit
        '        '    Set objWordx = Nothing
        '        'End If
        '        '    Loop Until objWordx Is Nothing

    End Sub
    Sub CloseAllExcelInstances()
        '        '        On Error Resume Next
        '        '        Dim objXLi As Excel.Application
        '        'Set objXLi = GetObject(, "Excel.Application")
        '        'If Not (objXLi Is Nothing) Then
        '        '            objXLi.Application.DisplayAlerts = False
        '        '            objXLi.Workbooks.Close
        '        '            objXLi.Quit
        '        '    Set objXLi = Nothing
        '        'End If

    End Sub


End Module
