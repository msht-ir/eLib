
Imports System.Management
Module ModuleSecurity
    Dim Rndx As New Random()
    Sub SecurityValidateThisCopy()
        '//using management object and Using Win32_LogicalDisk To Obtain Disk Properties
        Dim oHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""C:""")
        oHD.[Get]() 'Get Info
        'Get SN from OS
        strDriveSerialNumber = Trim(oHD("VolumeSerialNumber").ToString())
        'Get Key from Settings
        strActivationKey = Trim(DS.Tables("tblSettings").Rows(12).Item(3))
        If Len(strActivationKey) > 2 Then
            nRequests = 10
            'Infer SN from Key
            Try
                strInferredSN = Trim(K2H(strActivationKey))
            Catch ex As Exception
                MsgBox("Error in K2H")
            End Try
        Else
            nRequests = Val(DS.Tables("tblSettings").Rows(12).Item(3))
        End If
        'Compare SN(OS) - SN(Key)
        If strInferredSN = strDriveSerialNumber Then
            KeyIsValid = True
        Else
            KeyIsValid = False
            frmSecurityActivation.ShowDialog()
        End If
    End Sub
    Public Function H2R(strDriveSN As String) As String
        'uses H to make a RCode string
        Dim R_Code As String = ""
        Dim Tid As Integer = 0
        Dim Addn As Integer = 0
        Dim Coeff As Integer = 0
        '1) --------------- ADD PREFIX
        'Tid: TableID
        Tid = Rndx.Next(1, 10) 'results[1-9]
        R_Code = Trim(Tid.ToString) 'save Tid before reducing 5 from it
        If Tid > 5 Then Tid = Tid - 5
        'Addn: Number of Null chars n:[1-4]
        Addn = Rndx.Next(32, 127) 'results[32-126]
        For x = 32 To 126
            If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Exit For
            End If
        Next
        R_Code = R_Code & Trim(Chr(Addn))
        For i As Integer = 1 To Coeff
            R_Code = R_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
        Next i
        '2) --------------- ADD DATA
        Dim strHH As String = ""
        For j = 1 To Len(strDriveSN)
            'Tid
            Tid = Rndx.Next(1, 10) 'results[1-9]
            R_Code = R_Code & Trim(Tid.ToString)
            If Tid > 5 Then Tid = Tid - 5
            'Addn
            Addn = Rndx.Next(32, 127) 'results[32-126]
            For x = 32 To 126
                If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Exit For
                End If
            Next
            R_Code = R_Code & Trim(Chr(Addn))
            For i As Integer = 1 To Coeff
                R_Code = R_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
            Next
            'Tid
            Tid = Rndx.Next(1, 10) 'results[1-9]
            R_Code = R_Code & Trim(Tid.ToString)
            If Tid > 5 Then Tid = Tid - 5
            'data
            strHH = Trim(Hex(DS.Tables("tblSecurityCodes").Rows(Asc(Mid(strDriveSN, j, 1)) - 32).Item(Tid)).ToString)
            If (Tid Mod 2 <> 0) Then 'Tid is odd
                strHH = Mid(strHH, 2, 1) & Mid(strHH, 1, 1)
            End If
            R_Code = R_Code & Trim(strHH)
        Next
        '3) --------------- ADD SUFFIX
        'nx: Number of Null chars in suffix
        Dim nx As Integer = Rndx.Next(1, 10) 'results[1-9]
        R_Code = R_Code & Trim(nx.ToString) 'save nx before reducing 5 from it
        If nx > 5 Then nx = nx - 5
        For i As Integer = 1 To nx
            R_Code = R_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
        Next
        H2R = R_Code
    End Function
    Public Function R2H(strRequestCode As String) As String
        Dim R_Code As String = strRequestCode
        Dim Tid As Integer = 0
        Dim Addn As Integer = 0
        Dim Coeff As Integer = 0
        Dim hexData As String = ""
        Dim decData As Integer = 0
        Dim strSN As String = ""
        Tid = Val(Mid(R_Code, 1, 1))
        If Tid > 5 Then Tid = Tid - 5
        Addn = Asc(Mid(R_Code, 2, 1))
        For x = 32 To 126
            If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Exit For
            End If
        Next
        R_Code = Mid(R_Code, 2 + Coeff + 1) 'Part-Prefix Removed
        'Begin parsing Part-Data
        While Len(R_Code) > 7
            'For Each one Char In SN:
            'Remove the leading null-chars
            Tid = Val(Mid(R_Code, 1, 1))
            If Tid > 5 Then Tid = Tid - 5
            Addn = Asc(Mid(R_Code, 2, 1))
            For x = 32 To 126
                If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Exit For
                End If
            Next
            R_Code = Mid(R_Code, 2 + Coeff + 1)
            'leading null-chars removed, OK
            Tid = Val(Mid(R_Code, 1, 1)) 'table-id of the data
            If Tid > 5 Then Tid = Tid - 5
            hexData = Mid(R_Code, 2, 2)
            If (Tid Mod 2 <> 0) Then 'Tid is odd
                hexData = Mid(hexData, 2, 1) & Mid(hexData, 1, 1) 're-invert
            End If
            decData = CInt("&H" & hexData)
            For x = 32 To 126
                If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = decData Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    strSN = strSN & Chr(DS.Tables("tblSecurityCodes").Rows(x - 32).Item(0)) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Exit For
                End If
            Next
            R_Code = Mid(R_Code, 4)
        End While
        R2H = strSN
    End Function
    Public Function H2K(strDriveSN As String) As String
        'uses H to make a KCode string
        Dim K_Code As String = ""
        Dim Tid As Integer = 0
        Dim Addn As Integer = 0
        Dim Coeff As Integer = 0
        '1a) --------------- ADD PREFIX-1
        'Tid: TableID
        Tid = Rndx.Next(1, 10) 'results[1-9]
        K_Code = Trim(Tid.ToString) 'save Tid before reducing 5 from it
        If Tid > 5 Then Tid = Tid - 5
        'Addn: Number of Null chars n:[1-4]
        Addn = Rndx.Next(32, 127) 'results[32-126]
        For x = 32 To 126
            If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Exit For
            End If
        Next
        K_Code = K_Code & Trim(Chr(Addn))
        For i As Integer = 1 To Coeff
            K_Code = K_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
        Next i
        '1b) --------------- ADD PREFIX-2
        'Tid: TableID
        Tid = Rndx.Next(1, 10) 'results[1-9]
        K_Code = K_Code & Trim(Tid.ToString) 'save Tid before reducing 5 from it
        If Tid > 5 Then Tid = Tid - 5
        'Addn: Number of Null chars n:[1-4]
        Addn = Rndx.Next(32, 127) 'results[32-126]
        For x = 32 To 126
            If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Exit For
            End If
        Next
        K_Code = K_Code & Trim(Chr(Addn))
        For i As Integer = 1 To Coeff
            K_Code = K_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
        Next i
        '2) --------------- ADD DATA
        Dim strHH As String = ""
        For j = 1 To Len(strDriveSN)
            'Tid
            Tid = Rndx.Next(1, 10) 'results[1-9]
            K_Code = K_Code & Trim(Tid.ToString)
            If Tid > 5 Then Tid = Tid - 5
            'Addn
            Addn = Rndx.Next(32, 127) 'results[32-126]
            For x = 32 To 126
                If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Exit For
                End If
            Next
            K_Code = K_Code & Trim(Chr(Addn))
            For i As Integer = 1 To Coeff
                K_Code = K_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
            Next
            'Tid
            Tid = Rndx.Next(1, 10) 'results[1-9]
            K_Code = K_Code & Trim(Tid.ToString)
            If Tid > 5 Then Tid = Tid - 5
            'data
            strHH = Trim(Hex(DS.Tables("tblSecurityCodes").Rows(Asc(Mid(strDriveSN, j, 1)) - 32).Item(Tid)).ToString)
            If (Tid Mod 2 <> 0) Then 'Tid is odd
                strHH = Mid(strHH, 2, 1) & Mid(strHH, 1, 1)
            End If
            K_Code = K_Code & Trim(strHH)
        Next
        '3) --------------- ADD SUFFIX
        'nx: Number of Null chars in suffix
        Dim nx As Integer = Rndx.Next(1, 10) 'results[1-9]
        K_Code = K_Code & Trim(nx.ToString) 'save nx before reducing 5 from it
        If nx > 5 Then nx = nx - 5
        For i As Integer = 1 To nx
            K_Code = K_Code & Chr(Rndx.Next(32, 127)) 'results[32-126]
        Next
        H2K = K_Code
    End Function
    Public Function K2H(strKeyCode As String) As String
        Dim K_Code As String = strKeyCode
        Dim Tid As Integer = 0
        Dim Addn As Integer = 0
        Dim Coeff As Integer = 0
        Dim hexData As String = ""
        Dim decData As Integer = 0
        Dim strSN As String = ""
        'Prefix1
        Tid = Val(Mid(K_Code, 1, 1))
        If Tid > 5 Then Tid = Tid - 5
        Addn = Asc(Mid(K_Code, 2, 1))
        For x = 32 To 126
            If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Exit For
            End If
        Next
        K_Code = Mid(K_Code, 2 + Coeff + 1) 'Part-Prefix-1 Removed
        'Prefix2
        Tid = Val(Mid(K_Code, 1, 1))
        If Tid > 5 Then Tid = Tid - 5
        Addn = Asc(Mid(K_Code, 2, 1))
        For x = 32 To 126
            If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                Exit For
            End If
        Next
        K_Code = Mid(K_Code, 2 + Coeff + 1) 'Part-Prefix-2 Removed
        'Begin parsing Part-Data
        While Len(K_Code) > 7
            'For Each one Char In SN:
            'Remove the leading null-chars
            Tid = Val(Mid(K_Code, 1, 1))
            If Tid > 5 Then Tid = Tid - 5
            Addn = Asc(Mid(K_Code, 2, 1))
            For x = 32 To 126
                If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = Addn Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Coeff = DS.Tables("tblSecurityCodes").Rows(x - 32).Item(6) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Exit For
                End If
            Next
            K_Code = Mid(K_Code, 2 + Coeff + 1)
            'leading null-chars removed, OK
            Tid = Val(Mid(K_Code, 1, 1)) 'table-id of the data
            If Tid > 5 Then Tid = Tid - 5
            hexData = Mid(K_Code, 2, 2)
            If (Tid Mod 2 <> 0) Then 'Tid is odd
                hexData = Mid(hexData, 2, 1) & Mid(hexData, 1, 1) 're-invert
            End If
            decData = CInt("&H" & hexData)
            For x = 32 To 126
                If DS.Tables("tblSecurityCodes").Rows(x - 32).Item(Tid) = decData Then 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    strSN = strSN & Chr(DS.Tables("tblSecurityCodes").Rows(x - 32).Item(0)) 'items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                    Exit For
                End If
            Next
            K_Code = Mid(K_Code, 4)
        End While
        K2H = strSN
    End Function

End Module
