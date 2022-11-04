'Imports DocumentFormat.OpenXml.Office2010.ExcelAc

Imports System.IO

Module Module1
    '//Connection  {AC:Access - SS:SqlServer - SC:SqlServerCE}
    Public DatabaseType As String = ""
    Public strDatabaseCNNstring As String = ""
    Public Server2Connect As String = ""
    Public CnnSS As New SqlClient.SqlConnection
    Public CmdSS As New SqlClient.SqlCommand
    Public DASS As New SqlClient.SqlDataAdapter
    Public CnnSC As New SqlServerCe.SqlCeConnection
    Public CmdSC As New SqlServerCe.SqlCeCommand
    Public DASC As New SqlServerCe.SqlCeDataAdapter
    Public CnnAC As New OleDb.OleDbConnection
    Public CmdAC As New OleDb.OleDbCommand
    Public DAAC As New OleDb.OleDbDataAdapter

    Public DS As New DataSet
    Public strDbBackEnd As String = ""                ' // (read from cnn file) Path of Backend file on local or server 
    Public BackEndPass As String = "eLibSiliconPower" ' //encryption password of ACCDB Backend file
    Public strServerUid As String = ""
    Public strServerPwd As String = ""
    Public strSQL As String
    '//OS and Settings
    Public strBuildInfo As String   'as Build 000.00.00
    Public strCurrentVersion As String = ""
    Public tblxSecurityConverter As New System.Data.DataTable
    Public tblSettings As New System.Data.DataTable
    Public ReportSettings As Integer = &H3 ' &H2C = &B000000011 = 3 
    '//Vars
    Public Retval1, Retval2, Retval3, Retval4 As Integer
    Public UserNickName As String = ""
    Public strAdminPass As String = ""
    Public strUserPass As String = ""
    Public UserType As String = ""             'ADMIN | USER 
    Public UserAccessControls As Integer = 0  'acc1-acc15 (user access controls)
    Public intUser As Integer = 0
    Public strUser As String = ""
    Public strFolderPapers As String = ""
    Public strFolderBooks As String = ""
    Public strFolderManuals As String = ""
    Public strFolderLectures As String = ""
    Public strFolderTemp As String = ""
    Public strFolderSaveACopy As String = ""
    Public intProj As Integer = 0
    Public strProjectName As String = ""
    Public strProjectNote As String = ""
    Public intProd As Integer = 0
    Public strProductName As String = ""
    Public intProdNote As Integer = 0
    Public strProdNote As String = ""
    Public strDateTime As String = ""
    Public intRef As Integer = 0
    Public intRefType As Integer = 0
    Public strRefType As String = ""
    Public strRef As String = ""
    Public strRefNote As String = ""
    Public intAssign As Integer = 0
    Public strAssignNote As String = ""
    Public strPath As String = ""
    Public strFilename As String = ""             ' // path of text file for backend.path, user.id, pass strings
    Public strExt As String = ""
    Public strCaption As String = ""
    Public strReportsFooter As String = "eLib Desktop App [ www.msht.ir ],  by: Dr. Majid Sharifi-Tehrani, Faculty of Science (SKU), 2022"

    '//TABLES//
    Public tblusrs As New System.Data.DataTable
    Public tblRefs1 As New System.Data.DataTable
    Public tblAssignments As New System.Data.DataTable
    Public tblProject As New System.Data.DataTable
    Public tblProduct As New System.Data.DataTable
    Public tblRefs2 As New System.Data.DataTable
    Public tblProductNotes As New System.Data.DataTable
    Public tblRefPaths As New System.Data.DataTable
    Public tblProj_tmp As New System.Data.DataTable
    Public tblProd_tmp As New System.Data.DataTable
    Public tblProd_tmp2 As New System.Data.DataTable
    Public tblAssign_tmp As New System.Data.DataTable 'for Editting a Ref using frmImport 
    '--
    Public tblTEMPeLibSaveAs As New System.Data.DataTable

    '//Journals
    'Public tbleLibJCR As New System.Data.DataTable
    'Public tblSCOPUS_2018 As New System.Data.DataTable
    'Public tblSCOPUS_2019 As New System.Data.DataTable
    'Public tblSCOPUS_2020 As New System.Data.DataTable
    'Public tbleLib_02CATs2014 As New System.Data.DataTable
    'Public tbleLib_01SNIPs As New System.Data.DataTable
    'Public tbleLib_03JCR2014 As New System.Data.DataTable
    'Public tbleLib_03JCR2015 As New System.Data.DataTable
    'Public tbleLib_03JCR2016 As New System.Data.DataTable
    'Public tbleLib_03JCR2017 As New System.Data.DataTable
    'Public tbleLib_03JCR2018 As New System.Data.DataTable
    'Public tbleLib_03JCR2019 As New System.Data.DataTable
    'Public tbleLib_03JCR2020 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2014 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2015 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2016 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2017 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2018 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2019 As New System.Data.DataTable
    'Public tbleLib_04MIF_AIF2020 As New System.Data.DataTable
    'Public tbleLibJournals_Profile As New System.Data.DataTable
    'Public tbleLibJournals_ProfileSCOPUS As New System.Data.DataTable
    'Public tbleLibJournals_Profile_elibJCR As New System.Data.DataTable

    '//Lecture-Notes
    'Public tblTerms As New System.Data.DataTable
    'Public tblProg_Courses As New System.Data.DataTable
    'Public tblProg_Students As New System.Data.DataTable
    'Public tblTempSTUDENTS As New System.Data.DataTable
    'Public tblStudents As New System.Data.DataTable
    'Public tblLect_Notes As New System.Data.DataTable
    'Public tblLect_Students As New System.Data.DataTable
    'Public tblCourses As New System.Data.DataTable

    '//Desk-Notes
    'Public tblMainSubjects As New System.Data.DataTable
    'Public tblItems As New System.Data.DataTable
    'Public tblItems_Data As New System.Data.DataTable




    Sub Main()
        CreateTables()
        frmCNN.ShowDialog()
    End Sub
    Sub CreateTables()
        '//Settings usrs
        DS.Tables.Add("tblusrs")
        DS.Tables.Add("tblSettings")
        DS.Tables.Add("tblxSecurityConverter")

        '//eLib
        DS.Tables.Add("tblRefs1")
        DS.Tables.Add("tblAssignments")
        DS.Tables.Add("tblProject")
        DS.Tables.Add("tblProduct")
        DS.Tables.Add("tblRefs2")
        DS.Tables.Add("tblProductNotes")
        DS.Tables.Add("tblRefPaths")
        DS.Tables.Add("tblProj_tmp") 'for frm.selectProj/Prod
        DS.Tables.Add("tblProd_tmp") 'for frm.selectProj/Prod
        DS.Tables.Add("tblProd_tmp2") 'for frm.ImportRef
        DS.Tables("tblProd_tmp2").Columns.Add("ProdId", GetType(Integer))
        DS.Tables("tblProd_tmp2").Columns.Add("ProdName", GetType(String))
        '--
        DS.Tables.Add("tblTEMPeLibSaveAs")
        DS.Tables.Add("tblTempExcelSheetsList")
        DS.Tables.Add("tblTempExporteLibAssignments")

        '//Journals
        'DS.Tables.Add("tbleLibJCR")
        'DS.Tables.Add("tblSCOPUS_2018")
        'DS.Tables.Add("tblSCOPUS_2019")
        'DS.Tables.Add("tblSCOPUS_2020")
        'DS.Tables.Add("tbleLib_02CATs2014")
        'DS.Tables.Add("tbleLib_01SNIPs")
        'DS.Tables.Add("tbleLib_03JCR2014")
        'DS.Tables.Add("tbleLib_03JCR2015")
        'DS.Tables.Add("tbleLib_03JCR2016")
        'DS.Tables.Add("tbleLib_03JCR2017")
        'DS.Tables.Add("tbleLib_03JCR2018")
        'DS.Tables.Add("tbleLib_03JCR2019")
        'DS.Tables.Add("tbleLib_03JCR2020")
        'DS.Tables.Add("tbleLib_04MIF_AIF2014")
        'DS.Tables.Add("tbleLib_04MIF_AIF2015")
        'DS.Tables.Add("tbleLib_04MIF_AIF2016")
        'DS.Tables.Add("tbleLib_04MIF_AIF2017")
        'DS.Tables.Add("tbleLib_04MIF_AIF2018")
        'DS.Tables.Add("tbleLib_04MIF_AIF2019")
        'DS.Tables.Add("tbleLib_04MIF_AIF2020")
        'DS.Tables.Add("tbleLibJournals_Profile")
        'DS.Tables.Add("tbleLibJournals_ProfileSCOPUS")
        'DS.Tables.Add("tbleLibJournals_Profile_elibJCR")

        '//Lecture-Notes
        'DS.Tables.Add("tblTerms")
        'DS.Tables.Add("tblProg_Courses")
        'DS.Tables.Add("tblProg_Students")
        'DS.Tables.Add("tblTempSTUDENTS")
        'DS.Tables.Add("tblStudents")
        'DS.Tables.Add("tblLect_Notes")
        'DS.Tables.Add("tblLect_Students")
        'DS.Tables.Add("tblCourses")

        '//Desk-Notes
        'DS.Tables.Add("tblMainSubjects")
        'DS.Tables.Add("tblItems")
        'DS.Tables.Add("tblItems_Data")

    End Sub
    Public Sub ReadSettingsAndUsers()
        '0  AdminPass         '1  CurrentVersion    '2  FolderBooks       '3  FolderLectutes
        '4  FolderManuals     '5  FolderPapers      '6  FolderSaveACopy   '7  FolderTemp
        '8  ImportAskFolder   '9  Owner             '10 QRCodeType        '11 SearchRefType     '12 SecurityCheck
        DS.Tables("tblUsrs").Clear()
        DS.Tables("tblSettings").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    '//Users 
                    DASS = New SqlClient.SqlDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs", CnnSS)
                    DASS.Fill(DS, "tblUsrs")
                    '//Settings 
                    DASS = New SqlClient.SqlDataAdapter("SELECT ID, sttHeader, sttKey, sttValue, sttNote From Settings ORDER BY sttKey", CnnSS)
                    DASS.Fill(DS, "tblSettings")
                    CnnSS.Close()
                End Using
                '--------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE --------- sqlserverCE
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs", CnnSC)
                    DASC.Fill(DS, "tblUsrs")
                    '//Settings 
                    DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, sttHeader, sttKey, sttValue, sttNote From Settings ORDER BY sttKey", CnnSC)
                    DASC.Fill(DS, "tblSettings")
                    CnnSC.Close()
                End Using
                '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
            Case "Access"
                Using CnnAC = New OleDb.OleDbConnection(strDatabaseCNNstring)
                    CnnAC.Open()
                    '//Users
                    DAAC = New OleDb.OleDbDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs", CnnAC)
                    DAAC.Fill(DS, "tblUsrs")
                    '//Settings
                    DAAC = New OleDb.OleDbDataAdapter("SELECT ID, sttHeader, sttKey, sttValue, sttNote From Settings ORDER BY sttKey", CnnAC)
                    DAAC.Fill(DS, "tblSettings")
                    CnnAC.Close()
                End Using
        End Select
        strFolderTemp = DS.Tables("tblSettings").Rows(7).Item(3)

    End Sub
    Public Function ValidateFolders() As String
        Retval1 = 1 'set initial value > 1
        While Retval1 > 0
            'Folder Paths
            strFolderPapers = DS.Tables("tblSettings").Rows(5).Item(3)
            strFolderBooks = DS.Tables("tblSettings").Rows(2).Item(3)
            strFolderManuals = DS.Tables("tblSettings").Rows(4).Item(3)
            strFolderLectures = DS.Tables("tblSettings").Rows(3).Item(3)
            strFolderSaveACopy = DS.Tables("tblSettings").Rows(6).Item(3)
            strFolderTemp = DS.Tables("tblSettings").Rows(7).Item(3)
            Dim Errmsg As String = ""
            Retval1 = 0
            If Not System.IO.Directory.Exists(strFolderPapers) Then Retval1 = (Retval1 Or 1) : Errmsg = Errmsg & strFolderPapers & vbCrLf
            If Not System.IO.Directory.Exists(strFolderBooks) Then Retval1 = (Retval1 Or 2) : Errmsg = Errmsg & strFolderBooks & vbCrLf
            If Not System.IO.Directory.Exists(strFolderManuals) Then Retval1 = (Retval1 Or 4) : Errmsg = Errmsg & strFolderManuals & vbCrLf
            If Not System.IO.Directory.Exists(strFolderLectures) Then Retval1 = (Retval1 Or 8) : Errmsg = Errmsg & strFolderLectures & vbCrLf
            'If Not System.IO.Directory.Exists(strFolderSaveACopy) Then Retval1 = (Retval1 Or 16)
            'If Not System.IO.Directory.Exists(strFolderTemp) Then Retval1 = (Retval1 Or 32)
            If Retval1 > 0 Then
                Dim myansw As DialogResult = MsgBox("Missing lib Folders:" & vbCrLf & Errmsg & vbCrLf & "(YES): Create Folders  /  (NO): Select from Existing Folders", vbYesNo + vbDefaultButton2 + vbExclamation, "eLib")
                Select Case myansw
                    Case vbYes
                        Try 'Create Missing Folders
                            If Retval1 And 1 = 1 Then System.IO.Directory.CreateDirectory(strFolderPapers)
                            If Retval1 And 2 = 2 Then System.IO.Directory.CreateDirectory(strFolderBooks)
                            If Retval1 And 4 = 4 Then System.IO.Directory.CreateDirectory(strFolderManuals)
                            If Retval1 And 8 = 8 Then System.IO.Directory.CreateDirectory(strFolderLectures)
                        Catch ex As Exception
                            Dim myansw2 As DialogResult = MsgBox("Error Creating Folders..." & vbCrLf & "Choose from Existing Folders ?", vbOKCancel, "eLib")
                            Select Case myansw2
                                Case vbOK
                                    frmSettings.ShowDialog()
                                Case vbCancel
                                    CnnSS.Close()
                                    CnnSS.Dispose()
                                    CnnSC.Close()
                                    CnnSC.Dispose()
                                    CnnAC.Close()
                                    CnnAC.Dispose()
                                    Application.Exit()
                                    End
                            End Select
                        End Try
                    Case vbNo
                        frmSettings.ShowDialog() 'Dialog: frmSETTINGS
                End Select
            End If
        End While
        ValidateFolders = "valid"
    End Function
End Module
