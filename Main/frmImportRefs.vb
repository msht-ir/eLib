Imports System.Buffers
Imports System.Reflection.Emit
Imports System.Windows
Imports DocumentFormat.OpenXml.Office2010.ExcelAc
Imports DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Vml

Public Class frmImportRefs
    Dim strTitleA As String
    Dim strTitleB As String
    '//formLOAD
    Private Sub frmImportRefs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadSettingsAndUsers()
        DS.Tables("tblProd_tmp2").Clear()
        ListProduct.DataSource = DS.Tables("tblProd_tmp2")
        ListProduct.ValueMember = "ProdId"
        ListProduct.DisplayMember = "ProdName"
        Select Case Retval3
            Case 0 'Import a ref (regularly)
            Case 1, 2 'EditRef / NewRef Mode : Disable SelectRef / Paste / AssignList : Just Move with new {type/title/note} w/o any change in assignments!
                txtTitle.Text = strRef
                txtNote.Text = strRefNote
                strFilename = strPath
                Select Case Trim(strRefType)
                    Case "Paper" : radioPaper.Checked = True
                    Case "Book" : radioBook.Checked = True
                    Case "Manual" : radioManual.Checked = True
                    Case "Lecture" : radioLecture.Checked = True
                End Select
                For i As Integer = 0 To DS.Tables("tblAssignments").Rows.Count - 1
                    '//tblProd_tmp2 Cols: {ProdId, ProdName}
                    intProd = DS.Tables("tblAssignments").Rows(i).Item(2)
                    strProductName = DS.Tables("tblAssignments").Rows(i).Item(3)
                    DS.Tables("tblProd_tmp2").Rows.Add(intProd, strProductName)
                Next i
                Retval4 = 1 'A Ref is Ready to Move
        End Select
        If Retval3 = 1 Then
            Menu1_Select.Enabled = False
            Menu1_Paste.Enabled = False
            ListProduct.Enabled = False
        End If
    End Sub

    '//MENU_2 (Select Assignments)
    Private Sub Menu2_Add_Click(sender As Object, e As EventArgs) Handles Menu2_Add.Click
        '//Add
        frmChooseProject.ShowDialog()
        If Retval1 <> 2 Then Exit Sub '{Retval1: 2: A product is selected 1: A project is selected 0: Cancelled}
        '//tblProd_tmp2 Cols: {ProdId, ProdName}
        DS.Tables("tblProd_tmp2").Rows.Add(intProd, strProductName)
    End Sub
    Private Sub Menu2_Remove_Click(sender As Object, e As EventArgs) Handles Menu2_Remove.Click
        '//Remove
        If ListProduct.Items.Count = 0 Then Exit Sub
        If ListProduct.SelectedItems.Count = 0 Then Exit Sub 'No cells is selected
        Dim i As Integer = ListProduct.SelectedIndex
        DS.Tables("tblProd_tmp2").Rows.RemoveAt(i)
    End Sub
    Private Sub Menu2_Clear_Click(sender As Object, e As EventArgs) Handles Menu2_Clear.Click
        '//Clear
        DS.Tables("tblProd_tmp2").Clear()
    End Sub

    '//MENU_1 -SELECT
    Private Sub Menu1_Select_Click(sender As Object, e As EventArgs) Handles Menu1_Select.Click
        Retval4 = 0 'Nothing is ready to move into eLibFolders (After processing the Title, Retval4 will be 1)
        txtNote.Text = ""
        txtTitle.Text = ""
        Dim idx As Integer = 0
        Using dialog As New OpenFileDialog With {.InitialDirectory = strFolderTemp, .Filter = "eLib Refs|*.*"}
            If dialog.ShowDialog = DialogResult.OK Then
                strFilename = dialog.FileName
                txtTitle.Text = eLibParseRefFileName(strFilename)
                Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strFilename, vbNormalFocus)
                txtTitle.Focus() 'Ready for Paste
                '//Update strFolderTemp
                strFolderTemp = strPath
                For r As Integer = 0 To DS.Tables("tblSettings").Rows.Count - 1
                    If DS.Tables("tblSettings").Rows(r).Item(2) = "FolderTemp" Then
                        idx = DS.Tables("tblSettings").Rows(r).Item(0)
                        Exit For
                    End If
                Next
                Select Case DatabaseType
                    Case "SqlServer"
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE ID = @ID"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@sttvalue", strPath)
                            cmd.Parameters.AddWithValue("@ID", idx.ToString)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnSS.Close()
                        End Using
                    Case "SqlServerCE"
                        Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                            CnnSC.Open()
                            strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE ID = @ID"
                            Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@sttvalue", strPath)
                            cmd.Parameters.AddWithValue("@ID", idx.ToString)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                            CnnSC.Close()
                        End Using
                End Select
                Retval4 = 1 'A strFileName (original) is Ready to be Moved into eLibFolders (as txtTitle.Text)
            Else 'Nothing selected via File Dialog
                Exit Sub
            End If
        End Using
    End Sub
    Private Function eLibParseRefFileName(strTitleA As String) As String
        eLibParseRefFileName = ""
        Dim j As Integer = 0
        For i As Integer = 1 To 5
            j = 0
            j = InStr(j + 1, strTitleA, ":")
            If j > 2 Then
                strTitleB = Microsoft.VisualBasic.Left(strTitleA, j - 1) & "-" & Mid(strTitleA, j + 1)
                strTitleA = strTitleB
            End If
            j = 0
            j = InStr(j + 1, strTitleA, "?")
            If j > 0 Then
                strTitleB = Microsoft.VisualBasic.Left(strTitleA, j - 1) & "-" & Mid(strTitleA, j + 1)
                strTitleA = strTitleB
            End If
        Next i
lblNextBackslash:
        Dim intPosBackslash As Integer = 0
        intPosBackslash = InStr(1, strTitleA, "\")
        If intPosBackslash <> 0 Then
            strTitleA = Mid(strTitleA, intPosBackslash + 1)
            GoTo lblNextBackslash
        End If
        strExt = Microsoft.VisualBasic.Right(strTitleA, 4)
        strPath = Microsoft.VisualBasic.Left(strFilename, Len(strFilename) - Len(strTitleA))
        Select Case strExt
            Case "docx", "xlsx", "pptx"
                strTitleA = Microsoft.VisualBasic.Left(strTitleA, Len(strTitleA) - 5)
                strExt = "." & strExt
            Case ".pdf", ".doc", ".xls", ".ppt", ".jpg", ".bmp", ".MP4", ".txt"
                strTitleA = Microsoft.VisualBasic.Left(strTitleA, Len(strTitleA) - 4)
            Case Else 'Unknown Extension!
                strTitleA = Microsoft.VisualBasic.Left(strTitleA, Len(strTitleA) - 4)
        End Select
        eLibParseRefFileName = strTitleA
    End Function
    '//MENU_1 -PASTE
    Private Sub Menu1_Paste_Click(sender As Object, e As EventArgs) Handles Menu1_Paste.Click
        Dim strx As String = ""
        Dim intCR1 As Integer = 0
        Dim intCR2 As Integer = 0
        Dim intCR3 As Integer = 0
        Dim intCR4 As Integer = 0
        Dim intCR5 As Integer = 0
        Dim intSpc1 As Integer = 0
        Dim intSpc2 As Integer = 0
        Dim intSpc3 As Integer = 0
        Dim intSpc4 As Integer = 0
        Dim intNLn As Integer = 0
        Dim strAuthor As String = ""
        Dim strP As String = ""
        On Error Resume Next
        txtTitle.Text = My.Computer.Clipboard.GetText() 'Paste to textbox
        txtTitle.SelectionStart = 0
        txtTitle.Focus()
        strx = txtTitle.Text
lblStart:
        '//CR: Cariage Return | NLn: number of lines
        intCR1 = 0 : intCR2 = 0 : intCR3 = 0 : intCR4 = 0 : intCR5 = 0
        intNLn = 0
        intSpc1 = InStr(1, strx, " ")
        '//Count Number of Lines in string_Title
        intCR1 = InStr(1, strx, Chr(13))
        If intCR1 > 1 Then 'there are 2 lines
            intNLn = 2
        Else
            intNLn = 1
            GoTo lblPARSE
        End If
        intCR2 = InStr(intCR1 + 2, strx, Chr(13))
        If intCR2 > 1 Then 'oh! there are 3 lines
            intNLn = 3
        Else
            GoTo lblPARSE
        End If
        intCR3 = InStr(intCR2 + 2, strx, Chr(13))
        If intCR3 > 1 Then 'oh! there are 4 lines
            intNLn = 4
        Else
            GoTo lblPARSE
        End If
        intCR4 = InStr(intCR3 + 2, strx, Chr(13))
        If intCR4 > 1 Then 'wow! there are 5 lines
            intNLn = 5
        Else
            GoTo lblPARSE
        End If
        intCR5 = InStr(intCR4 + 2, strx, Chr(13))
        If intCR5 > 1 Then 'ok! there are 6 lines
            intNLn = 6
        End If
lblPARSE:
        '//Concatenate separate lines into one line!
        Select Case intNLn
            Case 1 '1 Lines, 0 CRs :Do Nothing
            Case 2 '2 Lines, 1 CRs
                strAuthor = Mid(strx, intCR1 + 2, Len(strx) - intCR1)
                strAuthor = eLibParseAuthorLine(strAuthor)
                strP = Microsoft.VisualBasic.Left(strx, intCR1 - 1)
            Case 3 '3 Lines, 2 CRs
                strAuthor = Mid(strx, intCR2 + 2, Len(strx) - intCR2)
                strAuthor = eLibParseAuthorLine(strAuthor)
                strP = Microsoft.VisualBasic.Left(strx, intCR1 - 1) & " "
                strP = strP & Mid(strx, (intCR1 + 2), (intCR2 - intCR1 - 2))
            Case 4 '4 Lines, 3 CRs
                strAuthor = Mid(strx, intCR3 + 2, Len(strx) - intCR3)
                strAuthor = eLibParseAuthorLine(strAuthor)
                strP = Microsoft.VisualBasic.Left(strx, intCR1 - 1) & " "
                strP = strP & Mid(strx, (intCR1 + 2), (intCR2 - intCR1 - 2)) & " "
                strP = strP & Mid(strx, (intCR2 + 2), (intCR3 - intCR2 - 2))
            Case 5 '5 Lines, 4 CRs
                strAuthor = Mid(strx, intCR4 + 2, Len(strx) - intCR4)
                strAuthor = eLibParseAuthorLine(strAuthor)
                strP = Microsoft.VisualBasic.Left(strx, intCR1 - 1) & " "
                strP = strP & Mid(strx, (intCR1 + 2), (intCR2 - intCR1 - 2)) & " "
                strP = strP & Mid(strx, (intCR2 + 2), (intCR3 - intCR2 - 2)) & " "
                strP = strP & Mid(strx, (intCR3 + 2), (intCR4 - intCR3 - 2))
            Case 6 '6 Lines, 5 CRs
                strAuthor = Mid(strx, intCR5 + 2, Len(strx) - intCR5)
                strAuthor = eLibParseAuthorLine(strAuthor)
                strP = Microsoft.VisualBasic.Left(strx, intSpc1 - 1) & " "
                strP = strP & Mid(strx, (intCR1 + 2), (intCR2 - intCR1 - 2)) & " "
                strP = strP & Mid(strx, (intCR2 + 2), (intCR3 - intCR2 - 2)) & " "
                strP = strP & Mid(strx, (intCR3 + 2), (intCR4 - intCR3 - 2)) & " "
                strP = strP & Mid(strx, (intCR4 + 2), (intCR5 - intCR4 - 2))
            Case Else
                Exit Sub 'do nothing
        End Select
        '//Remove Bad chars
        strP = eLib_BadCharRemover(strP)
        If Val(strP) < 1000 Then 'Sin Yr
            strP = "0000 " & strAuthor & "- " & strP
        Else 'Con Yr!
            intSpc1 = InStr(1, strP, " ")
            If Len(Trim(Str(Val(strP)))) = 4 And (intSpc1 < 1 Or intSpc1 > 5) Then 'Yr is attached to title
                strP = Microsoft.VisualBasic.Left(strP, 4) & " " & strAuthor & "- " & Mid(strP, 5)
            Else 'Separate Yr is available
                strP = Microsoft.VisualBasic.Left(strP, 5) & strAuthor & "- " & Mid(strP, 6)
            End If
        End If
        txtTitle.Text = strP
        txtTitle.SelectionStart = 0
        txtTitle.SelectionLength = 4
    End Sub
    Function eLibParseAuthorLine(strAuthorx) As String
        Dim tmpspace As Integer = 0
        Dim tmp0 As Integer = 0
        Dim tmp1 As Integer = 0
        Dim tmp2 As Integer = 0
        Dim tmp3 As Integer = 0
        Dim tmp4 As Integer = 0
        Dim tmp5 As Integer = 0
        Dim tmpx1 As Integer = 0
        Dim tmpx2 As Integer = 0
        eLibParseAuthorLine = ""
        strAuthorx = Trim(strAuthorx)
        For j As Integer = 1 To 5
            tmpspace = InStr(1, strAuthorx, " ")
            If tmpspace > 0 Then strAuthorx = Mid(strAuthorx, tmpspace + 1, Len(strAuthorx) - tmpspace)
            strAuthorx = Trim(strAuthorx)
        Next j
        '//Remove numbers and signs * '
        For i As Integer = 1 To 10
            tmp0 = InStr(1, strAuthorx, "0")
            If tmp0 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmp0 - 1) + Mid(strAuthorx, tmp0 + 1)
            tmp1 = InStr(1, strAuthorx, "1")
            If tmp1 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmp1 - 1) + Mid(strAuthorx, tmp1 + 1)
            tmp2 = InStr(1, strAuthorx, "2")
            If tmp2 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmp2 - 1) + Mid(strAuthorx, tmp2 + 1)
            tmp3 = InStr(1, strAuthorx, "3")
            If tmp3 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmp3 - 1) + Mid(strAuthorx, tmp3 + 1)
            tmp4 = InStr(1, strAuthorx, "4")
            If tmp4 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmp4 - 1) + Mid(strAuthorx, tmp4 + 1)
            tmp5 = InStr(1, strAuthorx, "5")
            If tmp5 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmp5 - 1) + Mid(strAuthorx, tmp5 + 1)
            tmpx1 = InStr(1, strAuthorx, ",")
            If tmpx1 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmpx1 - 1) + " " + Mid(strAuthorx, tmpx1 + 1)
            tmpx2 = InStr(1, strAuthorx, "*")
            If tmpx2 > 0 Then strAuthorx = Microsoft.VisualBasic.Left(strAuthorx, tmpx2 - 1) + " " + Mid(strAuthorx, tmpx2 + 1)
        Next i
        eLibParseAuthorLine = Trim(strAuthorx)
    End Function
    Function eLib_BadCharRemover(strP As String) As String
        Dim tmpPos As Integer = 0
        tmpPos = InStr(1, strP, ":") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "/") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "\") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "=") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "*") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "?") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "<") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "<") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "!") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "@") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "#") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "$") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "%") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "^") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "&") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "+") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "=") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "'") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, ";") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        tmpPos = InStr(1, strP, "’") : If tmpPos <> 0 Then strP = Microsoft.VisualBasic.Left(strP, tmpPos - 1) + "-" + Mid(strP, tmpPos + 1)
        eLib_BadCharRemover = strP
    End Function
    '//MENU_1 -MOVE
    Private Sub Menu1_Move_Click(sender As Object, e As EventArgs) Handles Menu1_Move.Click
        '//Move the Ref (and Assignments?) to eLib
        If (Retval4 = 0) Or (Microsoft.VisualBasic.Left(Trim(txtTitle.Text), 2) = "//") Then
            Menu1_Select_Click(sender, e)
            Exit Sub
        End If
        Dim strTitle As String = Trim(txtTitle.Text)
        Dim Radiox As Integer = 0
        Dim DestinationFolder As String = ""
        If radioPaper.Checked = True Then Radiox = 1
        If radioBook.Checked = True Then Radiox = 2
        If radioManual.Checked = True Then Radiox = 3
        If radioLecture.Checked = True Then Radiox = 4
        Select Case Radiox
            Case 1 : DestinationFolder = strFolderPapers   'from tblSettings
            Case 2 : DestinationFolder = strFolderBooks    'from tblSettings
            Case 3 : DestinationFolder = strFolderManuals  'from tblSettings
            Case 4 : DestinationFolder = strFolderLectures 'from tblSettings
            Case Else : Exit Sub
        End Select
        strExt = Microsoft.VisualBasic.Right(strFilename, 4)
        If Microsoft.VisualBasic.Left(strExt, 1) <> "." Then strExt = "." & strExt
        FolderBrowserDialog1.SelectedPath = DestinationFolder & "\"  'OR Environment.SpecialFolder.Desktop
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            DestinationFolder = FolderBrowserDialog1.SelectedPath
        Else
            Exit Sub
        End If
        Try
            My.Computer.FileSystem.MoveFile(strFilename, DestinationFolder & "\" & strTitle & strExt, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
            '//Add data to elib Tables
            Dim boolIsPaper As Boolean = 0
            Dim boolIsBook As Boolean = 0
            Dim boolIsManual As Boolean = 0
            Dim boolIsLecture As Boolean = 0
            Select Case Radiox
                Case 1 : boolIsPaper = 1
                Case 2 : boolIsBook = 1
                Case 3 : boolIsManual = 1
                Case 4 : boolIsLecture = 1
                Case Else : Exit Sub
            End Select
            Dim strPaperNote As String = txtNote.Text
            If strPaperNote = "" Then strPaperNote = "-"
            Select Case Retval3
                Case 0, 2 '//------------------------------------------------------------------------------- ImportRef /NewRefDoc Mode: Add Title to tblPapers
                    Select Case DatabaseType
                        Case "SqlServer"
                            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                CnnSS.Open()
                                strSQL = "INSERT INTO Papers (PaperName, IsPaper, IsBook, IsManual, IsLecture, Note) VALUES (@papername, @ispaper, @isbook, @ismanual, @islecture, @notes)"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@papername", strTitle)
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
                                CnnSS.Close()
                            End Using
                        Case "SqlServerCE"
                            Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                CnnSC.Open()
                                If boolIsPaper = 1 Then boolIsPaper = -1
                                If boolIsBook = 1 Then boolIsBook = -1
                                If boolIsManual = 1 Then boolIsManual = -1
                                If boolIsLecture = 1 Then boolIsLecture = -1
                                strSQL = "INSERT INTO Papers (PaperName, IsPaper, IsBook, IsManual, IsLecture, Note) VALUES (@papername, @ispaper, @isbook, @ismanual, @islecture, @notes)"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@papername", strTitle)
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
                                CnnSC.Close()
                            End Using
                    End Select
                Case 1 '//------------------------------------------------------------------------------- Edit Ref Mode: Update Title in tblPapers
                    Select Case DatabaseType
                        Case "SqlServer"
                            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                CnnSS.Open()
                                strSQL = "UPDATE Papers SET PaperName=@papername, IsPaper=@ispaper, IsBook=@isbook, IsManual=@ismanual, IsLecture=@islecture, [Note]=@note WHERE ID=@id;"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@papername", strTitle)
                                cmd.Parameters.AddWithValue("@ispaper", boolIsPaper.ToString)
                                cmd.Parameters.AddWithValue("@isbook", boolIsBook.ToString)
                                cmd.Parameters.AddWithValue("@ismanual", boolIsManual.ToString)
                                cmd.Parameters.AddWithValue("@islecture", boolIsLecture.ToString)
                                cmd.Parameters.AddWithValue("@note", strPaperNote)
                                cmd.Parameters.AddWithValue("@id", intRef.ToString)
                                Dim i As Integer = cmd.ExecuteNonQuery()
                                CnnSS.Close()
                            End Using
                        Case "SqlServerCE"
                            Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                CnnSC.Open()
                                If boolIsPaper = 1 Then boolIsPaper = -1
                                If boolIsBook = 1 Then boolIsBook = -1
                                If boolIsManual = 1 Then boolIsManual = -1
                                If boolIsLecture = 1 Then boolIsLecture = -1
                                strSQL = "UPDATE Papers SET PaperName=@papername, IsPaper=@ispaper, IsBook=@isbook, IsManual=@ismanual, IsLecture=@islecture, [Note]=@note WHERE ID=@id"
                                Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@papername", strTitle)
                                cmd.Parameters.AddWithValue("@ispaper", boolIsPaper.ToString)
                                cmd.Parameters.AddWithValue("@isbook", boolIsBook.ToString)
                                cmd.Parameters.AddWithValue("@ismanual", boolIsManual.ToString)
                                cmd.Parameters.AddWithValue("@islecture", boolIsLecture.ToString)
                                cmd.Parameters.AddWithValue("@notes", strPaperNote)
                                cmd.Parameters.AddWithValue("@id", intRef.ToString)
                                Dim i As Integer = cmd.ExecuteNonQuery()
                                CnnSC.Close()
                            End Using
                    End Select
            End Select
            '//Add strPath (of new Ref) into tblPaths **************************************************************************************
            strPath = DestinationFolder & "\" & strTitle & strExt
            Select Case DatabaseType
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        strSQL = "INSERT INTO Paths (FilePath) VALUES (@filepath)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@filepath", strPath)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Error creating new paper's Path" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                        End Try
                        CnnSS.Close()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        strSQL = "INSERT INTO Paths (FilePath) VALUES (@filepath)"
                        Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@filepath", strPath)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Error creating new paper's Path" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                        End Try
                        CnnSC.Close()
                    End Using
            End Select
            Select Case Retval3
                Case 0, 2 'Import Ref Mode
                    '//Find ID of the new Ref in tblPapers (Import Mode Only)
                    DS.Tables("tblRefs1").Clear()
                    Dim Fltr As String = "PaperName='" & strTitle & "'"
                    Select Case DatabaseType
                        Case "SqlServer"
                            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                CnnSS.Open()
                                DASS = New SqlClient.SqlDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.ID DESC;", CnnSS)
                                DASS.Fill(DS, "tblRefs1")
                                CnnSS.Close()
                            End Using
                        Case "SqlServerCE"
                            Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                CnnSC.Open()
                                DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.ID DESC;", CnnSC)
                                DASC.Fill(DS, "tblRefs1")
                                CnnSC.Close()
                            End Using
                    End Select
                    Dim idx As Integer = DS.Tables("tblRefs1").Rows(0).Item(0)
                    Dim idy As Integer = 0

                    For k As Integer = 0 To DS.Tables("tblProd_tmp2").Rows.Count - 1
                        idy = DS.Tables("tblProd_tmp2").Rows(k).Item(0)
                        Select Case DatabaseType ' ----  SqlServer ---- / ----  SqlServerCE ---- / ---- Access ----
                            Case "SqlServer"
                                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                                    CnnSS.Open()
                                    strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Parameters.AddWithValue("@paperid", idx)
                                    cmd.Parameters.AddWithValue("@productid", idy)
                                    Try
                                        Dim i As Integer = cmd.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("Error creating new paper's Path" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                    End Try
                                    CnnSS.Close()
                                End Using
                            Case "SqlServerCE"
                                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                                    CnnSC.Open()
                                    strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
                                    Dim cmd As New SqlServerCe.SqlCeCommand(strSQL, CnnSC)
                                    cmd.CommandType = CommandType.Text
                                    cmd.Parameters.AddWithValue("@paperid", idx)
                                    cmd.Parameters.AddWithValue("@productid", idy)
                                    Try
                                        Dim i As Integer = cmd.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("Error creating new paper's Path" & vbCrLf & ex.ToString, vbOKOnly, "eLib")
                                    End Try
                                    CnnSC.Close()
                                End Using
                        End Select
                    Next k
                Case 1 ' Edit Ref Mode
                    'Do nothing, keep existing Assignments if any
            End Select
            '//Finish Up
            Retval4 = 0 'Ready for 'Selecting' another Ref
            Select Case Retval3
                Case 0 'ImportRefMode
                    txtTitle.Text = "//imported: " & strTitle & vbCrLf & "//assigned to: " & DS.Tables("tblProd_tmp2").Rows.Count.ToString & " items(s)   //ref note: " & txtNote.Text & vbCrLf & "--"
                    txtNote.Text = ""
                Case 1 'EditRefMode
                    Menu1_Exit_Click(sender, e)
                Case 2 'CreateNewRefMode
                    Menu1_Exit_Click(sender, e)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu1_Exit_Click(sender As Object, e As EventArgs) Handles Menu1_Exit.Click
        Me.Dispose()
    End Sub
End Class