Public Class frmChooseProject
    Private Sub frmChooseProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DS.Tables("tblProj_tmp").Clear()
        DS.Tables("tblProd_tmp").Clear()
        GetListProj(intUser, 0) 'activex {0:active 1:inactive 2:all}
        ListProj.DataSource = DS.Tables("tblProj_tmp")
        ListProj.DisplayMember = "ProjectName"
        ListProj.ValueMember = "ID"
        DS.Tables("tblProd_tmp").Clear()

    End Sub

    'List1 Search Project
    Private Sub TextSearchProj_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProj.TextChanged
        DS.Tables("tblProj_tmp").Clear()
        DS.Tables("tblProd_tmp").Clear()
        If Trim(txtSearchProj.Text) = "" Then
            txtSearchProj.Text = ""
        Else
            Dim searchString As String = Trim(txtSearchProj.Text)
            FindProject(searchString)
            ListProj.SelectedValue = -1
            Menu1_Active.Checked = False
            Menu1_Inactive.Checked = False
            Menu1_All.Checked = False
            DS.Tables("tblprod_tmp").Clear()
            txtSearchProd.Text = Trim(txtSearchProd.Text)
        End If
    End Sub
    Private Sub FindProject(searchString As String)
        searchString = "(ProjectName Like '%" & searchString & "%' OR ProjectName Like '%" & searchString & "%') AND (user_ID = " & intUser.ToString & ")"
        Try
            DS.Tables("tblProj_tmp").Clear()
            Select Case DatabaseType
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT ID, ProjectName FROM Project  WHERE (" + searchString + ") ORDER BY ProjectName DESC;", CnnSS)
                        DASS.Fill(DS, "tblProj_tmp")
                        CnnSS.Close()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT ID, ProjectName FROM Project  WHERE (" + searchString + ") ORDER BY ProjectName DESC;", CnnSC)
                        DASC.Fill(DS, "tblProj_tmp")
                        CnnSC.Close()
                    End Using
            End Select
            ListProj.DataSource = DS.Tables("tblProj_tmp")
            ListProj.DisplayMember = "ProjectName"
            ListProj.ValueMember = "ID"
        Catch ex As Exception
        End Try
    End Sub

    'List1 Project
    Private Sub GetListProj(usrid As Integer, activex As Integer)
        'activex {0:active 1:inactive 2:all}
        DS.Tables("tblProj_tmp").Clear()
        Select Case DatabaseType
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    Select Case activex
                        Case 0 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active= 1 Order By ProjectName"
                        Case 1 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active = 0 Order By ProjectName"
                        Case 2 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                    End Select
                    DASS = New SqlClient.SqlDataAdapter(strSQL, CnnSS)
                    DASS.Fill(DS, "tblProj_tmp")
                    CnnSS.Close()
                End Using
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    Select Case activex
                        Case 0 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active= 1 Order By ProjectName"
                        Case 1 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " AND Active = 0 Order By ProjectName"
                        Case 2 : strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Project Where user_ID = " & usrid.ToString & " Order By ProjectName"
                    End Select
                    DASC = New SqlServerCe.SqlCeDataAdapter(strSQL, CnnSC)
                    DASC.Fill(DS, "tblProj_tmp")
                    CnnSC.Close()
                End Using
        End Select
    End Sub
    Private Sub Menu1_Active_Click(sender As Object, e As EventArgs) Handles Menu1_Active.Click
        DS.Tables("tblProj_tmp").Clear()
        DS.Tables("tblProd_tmp").Clear()
        GetListProj(intUser, 0) 'activex {0:active 1:inactive 2:all}
        ListProj.DataSource = DS.Tables("tblProj_tmp")
        ListProj.DisplayMember = "ProjectName"
        ListProj.ValueMember = "ID"
        DS.Tables("tblProd_tmp").Clear()
        Menu1_Active.Checked = True
        Menu1_Inactive.Checked = False
        Menu1_All.Checked = False
        txtSearchProj.Text = ""
    End Sub
    Private Sub Menu1_Inactive_Click(sender As Object, e As EventArgs) Handles Menu1_Inactive.Click
        DS.Tables("tblProj_tmp").Clear()
        DS.Tables("tblProd_tmp").Clear()
        GetListProj(intUser, 1) 'activex {0:active 1:inactive 2:all}
        ListProj.DataSource = DS.Tables("tblProj_tmp")
        ListProj.DisplayMember = "ProjectName"
        ListProj.ValueMember = "ID"
        DS.Tables("tblProd_tmp").Clear()
        Menu1_Active.Checked = False
        Menu1_Inactive.Checked = True
        Menu1_All.Checked = False
        txtSearchProj.Text = ""
    End Sub
    Private Sub Menu1_All_Click(sender As Object, e As EventArgs) Handles Menu1_All.Click
        DS.Tables("tblProj_tmp").Clear()
        DS.Tables("tblProd_tmp").Clear()
        GetListProj(intUser, 2) 'activex {0:active 1:inactive 2:all}
        ListProj.DataSource = DS.Tables("tblProj_tmp")
        ListProj.DisplayMember = "ProjectName"
        ListProj.ValueMember = "ID"
        DS.Tables("tblProd_tmp").Clear()
        Menu1_Active.Checked = False
        Menu1_Inactive.Checked = False
        Menu1_All.Checked = True
        txtSearchProj.Text = ""
    End Sub
    Private Sub ListProj_Click(sender As Object, e As EventArgs) Handles ListProj.Click
        If ListProj.SelectedIndex = -1 Then Exit Sub
        Try
            Dim projid As Integer = ListProj.SelectedValue
            If projid > 0 Then GetListProd(projid)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ListProj_DoubleClick(sender As Object, e As EventArgs) Handles ListProj.DoubleClick
        Menu1_OK_Click(sender, e)
    End Sub
    Private Sub Menu1_OK_Click(sender As Object, e As EventArgs) Handles Menu1_OK.Click
        If ListProj.SelectedIndex = -1 Then
            Exit Sub
        Else
            intProj = ListProj.SelectedValue
            strProjectName = ListProj.Text 'check if this line of code is interferring, if not, keep it!
            Retval1 = 1 'Project Selected
            Me.Dispose()
        End If
    End Sub
    Private Sub Menu1_Cancel_Click(sender As Object, e As EventArgs) Handles Menu1_Cancel.Click
        Retval1 = 0 'Cancelled
        Me.Dispose()
    End Sub

    'List2 Search Product
    Private Sub txtSearchProd_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProd.TextChanged
        Try
            DS.Tables("tblProd_tmp").Clear()
            If Trim(txtSearchProd.Text) = "" Then
                txtSearchProd.Text = ""
            Else
                Dim searchString As String = Trim(txtSearchProd.Text)
                FindProduct(searchString)
                ListProd.SelectedValue = -1
                Menu1_Active.Checked = False
                Menu1_Inactive.Checked = False
                Menu1_All.Checked = False
                DS.Tables("tblproj_tmp").Clear()
                txtSearchProj.Text = Trim(txtSearchProj.Text)
            End If
        Catch ex As Exception
            MsgBox("1" & ex.ToString)
        End Try
    End Sub
    Private Sub FindProduct(searchString As String)
        searchString = "(ProductName Like '%" & searchString & "%' OR ProductName Like '%" & searchString & "%') AND (user_ID = " & intUser.ToString & ")"
        Try
            DS.Tables("tblProj_tmp").Clear()
            Select Case DatabaseType
                Case "SqlServer"
                    Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                        CnnSS.Open()
                        DASS = New SqlClient.SqlDataAdapter("SELECT Product.ID, ProductName, Product.Notes FROM Project INNER JOIN Product ON Project.ID = Product.Project_ID WHERE (" + searchString + ") ORDER BY ProductName DESC;", CnnSS)
                        DASS.Fill(DS, "tblProd_tmp")
                        CnnSS.Close()
                    End Using
                Case "SqlServerCE"
                    Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                        CnnSC.Open()
                        DASC = New SqlServerCe.SqlCeDataAdapter("SELECT Product.ID, ProductName, Product.Notes FROM Project INNER JOIN Product ON Project.ID = Product.Project_ID WHERE (" + searchString + ") ORDER BY ProductName DESC;", CnnSC)
                        DASC.Fill(DS, "tblProd_tmp")
                        CnnSC.Close()
                    End Using
            End Select
            ListProd.DataSource = DS.Tables("tblProd_tmp")
            ListProd.DisplayMember = "ProductName"
            ListProd.ValueMember = "ID"
        Catch ex As Exception
        End Try
    End Sub

    'List2 Product
    Private Sub GetListProd(Projid As Integer)
        'activex {0:active 1:inactive 2:all}
        DS.Tables("tblProd_tmp").Clear()
        Select Case DatabaseType
            Case "SqlServer"
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    strSQL = "Select ID, ProductName, Notes FROM Product Where Project_ID = " & Projid.ToString & " Order By ProductName"
                    DASS = New SqlClient.SqlDataAdapter(strSQL, CnnSS)
                    DASS.Fill(DS, "tblProd_tmp")
                    CnnSS.Close()
                End Using
            Case "SqlServerCE"
                Using CnnSC = New SqlServerCe.SqlCeConnection(strDatabaseCNNstring)
                    CnnSC.Open()
                    strSQL = "Select ID, ProductName, Notes FROM Product Where Project_ID = " & Projid.ToString & " Order By ProductName"
                    DASC = New SqlServerCe.SqlCeDataAdapter(strSQL, CnnSC)
                    DASC.Fill(DS, "tblProd_tmp")
                    CnnSC.Close()
                End Using
        End Select
        ListProd.DataSource = DS.Tables("tblProd_tmp")
        ListProd.DisplayMember = "ProductName"
        ListProd.ValueMember = "ID"
    End Sub
    Private Sub ListProd_Click(sender As Object, e As EventArgs) Handles ListProd.Click
        If ListProd.SelectedIndex = -1 Then Exit Sub
        TextBoxProdNote.Text = DS.Tables("tblProd_tmp").Rows(ListProd.SelectedIndex).Item(2)
    End Sub
    Private Sub ListProd_DoubleClick(sender As Object, e As EventArgs) Handles ListProd.DoubleClick
        Menu2_OK_Click(sender, e)
    End Sub
    Private Sub Menu2_OK_Click(sender As Object, e As EventArgs) Handles Menu2_OK.Click
        If ListProd.SelectedIndex = -1 Then
            Exit Sub
        Else
            intProd = ListProd.SelectedValue
            strProdNote = Trim(TextBoxProdNote.Text)
            strProductName = ListProd.Text
            Retval1 = 2 'OK , one Product is Selected
            Me.Dispose()
        End If
    End Sub
    Private Sub Menu2_Cancel_Click(sender As Object, e As EventArgs) Handles Menu2_Cancel.Click
        Retval1 = 0 'Canceled
        Me.Dispose()
    End Sub

End Class