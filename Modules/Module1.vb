'Imports DocumentFormat.OpenXml.Office2010.ExcelAc

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
    '//Server
    Public strServerName As String = ""
    Public strInstanceName As String = ""
    Public intInstanceNumber As Integer = 0
    '//DS
    Public DS As New DataSet
    Public strDbBackEnd As String = ""                ' // (read from cnn file) Path of Backend file on local or server 
    Public BackEndPass As String = "eLibSiliconPower" ' //Password of local sqlserver CE Backend
    Public strServerUid As String = ""
    Public strServerPwd As String = ""
    Public strSQL As String
    '//OS and Settings
    Public strBuildInfo As String   'as Build 000.00.00
    Public strCurrentVersion As String = ""
    Public ReportSettings As Integer = &H3 ' &H2C = &B000000011 = 3 
    Public KeyIsValid As Boolean = False
    'Serial Number and Activation
    Public strDriveSerialNumber As String = ""
    Public strActivationKey As String = ""
    Public strInferredSN As String = ""
    Public nRequests As Integer = 0
    '//Vars
    Public Retval1, Retval2, Retval3, Retval4 As Integer
    Public UserNickName As String = ""
    Public strAdminPass As String = ""
    Public strUserPass As String = ""
    Public UserType As String = "" 'ADMIN | USER 
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
    Public strFilename As String = "" ' // path of text file for backend.path, user.id, pass strings
    Public strExt As String = ""
    Public DestinationFolder As String = "" 'for Importing Refs
    Public strCaption As String = ""
    Public strReportsFooter As String = "eLib Desktop App [ www.msht.ir ],  by: Dr. Majid Sharifi-Tehrani, Faculty of Science (SKU), 2023"
    '//TABLES//
    Public tblSettings As New System.Data.DataTable
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
    Public tblAssign_tmp As New System.Data.DataTable 'to Edit a Ref using frmImport 
    Public tblSecurityCodes As New System.Data.DataTable
    Sub Main()
        Application.EnableVisualStyles()
        CreateTables()
        frmCNN.ShowDialog()
    End Sub
    Sub CreateTables()
        '//Settings usrs
        DS.Tables.Add("tblusrs")
        DS.Tables.Add("tblSettings")
        'DS.Tables.Add("tblxSecurityConverter")
        '//eLib
        DS.Tables.Add("tblRefs1")
        DS.Tables.Add("tblAssignments")
        DS.Tables.Add("tblProject")
        DS.Tables.Add("tblProduct")
        DS.Tables.Add("tblRefs2")
        DS.Tables.Add("tblProductNotes")
        DS.Tables.Add("tblRefPaths")
        DS.Tables.Add("tblProj_tmp")  'for frm.selectProj/Prod
        DS.Tables.Add("tblProd_tmp")  'for frm.selectProj/Prod
        DS.Tables.Add("tblProd_tmp2") 'for frm.ImportRef
        DS.Tables("tblProd_tmp2").Columns.Add("ProdId", GetType(Integer))
        DS.Tables("tblProd_tmp2").Columns.Add("ProdName", GetType(String))
        '--
        DS.Tables.Add("tblSecurityCodes")
        DS.Tables("tblSecurityCodes").Columns.Add("Ascii_Code", GetType(Integer))
        DS.Tables("tblSecurityCodes").Columns.Add("Alt1", GetType(Integer))
        DS.Tables("tblSecurityCodes").Columns.Add("Alt2", GetType(Integer))
        DS.Tables("tblSecurityCodes").Columns.Add("Alt3", GetType(Integer))
        DS.Tables("tblSecurityCodes").Columns.Add("Alt4", GetType(Integer))
        DS.Tables("tblSecurityCodes").Columns.Add("Alt5", GetType(Integer))
        DS.Tables("tblSecurityCodes").Columns.Add("Coeff", GetType(Integer))
        '//
        DS.Tables("tblSecurityCodes").Rows.Add(32, 54, 79, 106, 61, 124, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(33, 87, 80, 33, 43, 47, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(34, 76, 81, 125, 82, 48, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(35, 100, 43, 96, 62, 106, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(36, 117, 44, 63, 34, 60, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(37, 55, 45, 107, 111, 109, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(38, 103, 35, 76, 72, 73, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(39, 37, 36, 97, 81, 41, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(40, 52, 95, 98, 83, 53, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(41, 42, 96, 32, 74, 89, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(42, 85, 32, 45, 64, 54, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(43, 114, 33, 35, 60, 87, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(44, 108, 34, 36, 109, 88, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(45, 86, 107, 95, 73, 117, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(46, 118, 76, 79, 124, 55, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(47, 88, 97, 80, 47, 103, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(48, 75, 98, 81, 48, 100, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(49, 82, 99, 43, 106, 76, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(50, 63, 100, 44, 33, 75, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(51, 94, 101, 121, 125, 37, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(52, 62, 46, 65, 96, 52, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(53, 34, 73, 99, 63, 33, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(54, 111, 72, 100, 107, 125, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(55, 72, 111, 122, 38, 96, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(56, 81, 110, 46, 41, 64, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(57, 83, 74, 110, 105, 99, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(58, 56, 105, 101, 97, 90, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(59, 126, 106, 123, 98, 91, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(60, 61, 122, 42, 32, 116, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(61, 43, 123, 62, 45, 120, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(62, 124, 42, 34, 35, 70, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(63, 47, 62, 90, 36, 61, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(64, 48, 94, 91, 95, 43, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(65, 51, 77, 116, 79, 82, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(66, 112, 78, 120, 80, 63, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(67, 57, 84, 66, 102, 94, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(68, 84, 38, 67, 103, 62, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(69, 78, 104, 86, 100, 34, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(70, 66, 47, 118, 76, 111, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(71, 92, 48, 68, 75, 72, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(72, 71, 92, 69, 37, 81, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(73, 102, 126, 70, 52, 83, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(74, 115, 125, 71, 53, 56, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(75, 50, 93, 52, 89, 126, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(76, 36, 108, 53, 54, 92, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(77, 95, 40, 89, 87, 107, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(78, 79, 63, 61, 88, 38, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(79, 98, 124, 82, 117, 74, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(80, 32, 75, 58, 55, 105, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(81, 45, 37, 83, 93, 97, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(82, 73, 102, 59, 126, 98, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(83, 41, 114, 49, 92, 32, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(84, 53, 50, 113, 56, 45, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(85, 89, 115, 39, 94, 35, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(86, 35, 51, 40, 108, 36, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(87, 106, 112, 41, 114, 95, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(88, 60, 57, 64, 115, 79, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(89, 109, 103, 60, 50, 80, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(90, 33, 85, 109, 51, 102, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(91, 125, 119, 38, 112, 115, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(92, 96, 39, 111, 57, 50, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(93, 64, 109, 72, 84, 51, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(94, 99, 41, 73, 85, 112, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(95, 90, 64, 74, 119, 57, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(96, 91, 60, 105, 77, 118, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(97, 116, 61, 124, 78, 84, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(98, 120, 82, 75, 104, 78, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(99, 70, 83, 37, 58, 58, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(100, 107, 58, 54, 59, 113, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(101, 38, 59, 87, 49, 55, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(102, 74, 49, 88, 113, 59, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(103, 105, 113, 117, 39, 121, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(104, 69, 55, 49, 40, 68, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(105, 44, 56, 119, 101, 69, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(106, 121, 65, 126, 46, 44, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(107, 80, 66, 92, 67, 39, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(108, 110, 67, 93, 86, 65, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(109, 122, 86, 94, 118, 66, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(110, 58, 118, 108, 68, 71, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(111, 97, 68, 114, 69, 110, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(112, 113, 69, 115, 44, 122, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(113, 39, 70, 50, 121, 40, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(114, 68, 71, 51, 65, 101, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(115, 119, 52, 112, 99, 46, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(116, 104, 53, 57, 90, 67, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(117, 93, 89, 84, 91, 86, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(118, 123, 90, 85, 116, 77, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(119, 77, 91, 56, 120, 123, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(120, 59, 116, 77, 70, 42, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(121, 49, 120, 78, 66, 85, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(122, 65, 121, 102, 71, 119, 3)
        DS.Tables("tblSecurityCodes").Rows.Add(123, 40, 54, 103, 110, 104, 4)
        DS.Tables("tblSecurityCodes").Rows.Add(124, 101, 87, 104, 122, 93, 1)
        DS.Tables("tblSecurityCodes").Rows.Add(125, 46, 88, 47, 123, 114, 2)
        DS.Tables("tblSecurityCodes").Rows.Add(126, 67, 117, 48, 42, 108, 3)
    End Sub
    Public Sub ReadSettingsAndUsers()
        'col sttKey: recs 0-12
        '0  AdminPass         '1  CurrentVersion    '2  FolderBooks       '3  FolderLectutes
        '4  FolderManuals     '5  FolderPapers      '6  FolderSaveACopy   '7  FolderTemp
        '8  ImportAskFolder   '9  Owner             '10 QRCodeType        '11 SearchRefType     '12 SecurityCheck
        DS.Tables("tblUsrs").Clear()
        DS.Tables("tblSettings").Clear()
        Select Case DatabaseType
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
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    '//Users 
                    DASC = New SqlServerCe.SqlCeDataAdapter("Select ID, UsrName, UsrPass, UsrActive, UsrNote, acc00, acc01, acc02, acc03, acc04, acc05, acc06, acc07, acc08, acc09, acc10, acc11, acc12, acc13, acc14, acc15 FROM usrs", CnnSC)
                    DASC.Fill(DS, "tblUsrs")
                    '//Settings 
                    DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, sttHeader, sttKey, sttValue, sttNote From Settings ORDER BY sttKey", CnnSC)
                    DASC.Fill(DS, "tblSettings")
                    CnnSC.Close()
                End Using
        End Select
        strAdminPass = DS.Tables("tblSettings").Rows(0).Item(3)
        strCurrentVersion = DS.Tables("tblSettings").Rows(1).Item(3)
        strFolderTemp = DS.Tables("tblSettings").Rows(7).Item(3)
        'add more vars here
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
                                    'CnnAC.Close()
                                    'CnnAC.Dispose()
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
