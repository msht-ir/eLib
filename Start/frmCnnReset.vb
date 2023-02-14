Imports System.Data.SqlClient
Imports System.IO

Public Class frmCnnReset
    Private Sub frmCnnReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListCnn.Items.Add("Library A")
        ListCnn.Items.Add("Library B")
        ListCnn.Items.Add("Portable Libraries")
        ListCnn.Items.Add("Library on Remote Server: needs Internet Connection")
        ListCnn.Items.Add("Developer's Library")
        ListCnn.SetItemChecked(0, True)
        ListCnn.SetItemChecked(1, False)
        ListCnn.SetItemChecked(2, False)
        ListCnn.SetItemChecked(3, False)
        ListCnn.SetItemChecked(4, False)
    End Sub
    Private Sub Menu_Reset_Click(sender As Object, e As EventArgs) Handles Menu_Reset.Click
        Try
            Dim eLibDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) & "\"
            FileOpen(1, Application.StartupPath & "eLibcnn", OpenMode.Output)
            If ListCnn.GetItemChecked(0) = True Then '//Library A
                Try
                    If Not System.IO.File.Exists(eLibDataPath & "eLibA.mdf") Then My.Computer.FileSystem.CopyFile(Application.StartupPath & "DBs\eLibA.mdf", eLibDataPath & "eLibA.mdf", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
                    If Not System.IO.File.Exists(eLibDataPath & "eLibA_log.ldf") Then My.Computer.FileSystem.CopyFile(Application.StartupPath & "DBs\eLibA_log.ldf", eLibDataPath & "eLibA_log.ldf", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
                    If CheckDBAttached2SqlServerExpress("eLibA") = "Attached" Then
                        PrintLine(1, "eLibcnn")
                        PrintLine(1, "Lib A")
                        PrintLine(1, "Server=.\SQLEXPRESS; Initial Catalog=eLibA; Integrated Security = SSPI;")
                        PrintLine(1, "")
                        PrintLine(1, "")
                        PrintLine(1, "---")
                    End If
                Catch ex As Exception
                End Try
                Try '//Try Attach: (\DBs\eLibA.mdf)
                    Dim conn1 As New SqlConnection("Data Source=.\" & strInstanceName & "; AttachDbFilename=" & eLibDataPath & "eLibA.mdf" & "; Database=eLibA; Integrated Security=SSPI")
                    If conn1.State = ConnectionState.Closed Then conn1.Open()
                    Dim cmd1 As New SqlCommand("SELECT * FROM usrs", conn1)
                    Dim da1 As New SqlDataAdapter
                    da1.SelectCommand = cmd1
                    cmd1.Dispose()
                    conn1.Close()
                    conn1.Dispose()
                Catch ex As Exception
                End Try
            End If
            If ListCnn.GetItemChecked(1) = True Then '//Library B
                Try
                    If Not System.IO.File.Exists(eLibDataPath & "eLibB.mdf") Then My.Computer.FileSystem.CopyFile(Application.StartupPath & "DBs\eLibB.mdf", eLibDataPath & "eLibB.mdf", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
                    If Not System.IO.File.Exists(eLibDataPath & "eLibB_log.ldf") Then My.Computer.FileSystem.CopyFile(Application.StartupPath & "DBs\eLibB_log.ldf", eLibDataPath & "eLibB_log.ldf", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
                    If CheckDBAttached2SqlServerExpress("eLibB") = "Attached" Then
                        PrintLine(1, "eLibcnn")
                        PrintLine(1, "Lib B")
                        PrintLine(1, "Server=.\SQLEXPRESS; Initial Catalog=eLibB; Integrated Security = SSPI;")
                        PrintLine(1, "")
                        PrintLine(1, "")
                        PrintLine(1, " ")
                    End If
                Catch ex As Exception
                End Try
                Try '//Try Attach: (\DBs\eLibB.mdf)
                    Dim conn2 As New SqlConnection("Data Source=.\" & strInstanceName & "; AttachDbFilename=" & eLibDataPath & "eLibB.mdf" & "; Database=eLibB; Integrated Security=SSPI")
                    If conn2.State = ConnectionState.Closed Then conn2.Open()
                    Dim cmd2 As New SqlCommand("SELECT * FROM usrs", conn2)
                    Dim da2 As New SqlDataAdapter
                    da2.SelectCommand = cmd2
                    cmd2.Dispose()
                    conn2.Close()
                    conn2.Dispose()
                Catch ex As Exception
                End Try
            End If
            If ListCnn.GetItemChecked(2) = True Then '//Portable Libraries
                Dim strFile As String
                Dim strDir As String = Application.StartupPath
                For Each strFile In Directory.GetFiles(strDir, "*.sdf")
                    PrintLine(1, "eLibcnn")
                    PrintLine(1, "Portable Lib")
                    PrintLine(1, strFile)
                    PrintLine(1, "")
                    PrintLine(1, "")
                    PrintLine(1, " ")
                Next
            End If
            If ListCnn.GetItemChecked(3) = True Then '//Library on Remote Server: needs Internet Connection
                PrintLine(1, "eLibcnn")
                PrintLine(1, "Remote Lib")
                PrintLine(1, "eLib Database on Remote Server")
                PrintLine(1, "")
                PrintLine(1, "")
                PrintLine(1, " ")
            End If
            If ListCnn.GetItemChecked(4) = True Then '//Developer's Library
                PrintLine(1, "eLibcnn")
                PrintLine(1, "Developer's Lib")
                PrintLine(1, "Server=.\SQLEXPRESS; Initial Catalog=eLib1; Integrated Security = SSPI;")
                PrintLine(1, "")
                PrintLine(1, "")
                PrintLine(1, " ")
            End If
            FileClose(1)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.Dispose()
    End Sub
    Private Function CheckDBAttached2SqlServerExpress(strCatalog As String) As String
        Using DBConn As New SqlConnection("Server=.\" & strInstanceName & "; Initial Catalog=" & strCatalog & "; Integrated Security = SSPI;")
            Try
                DBConn.Open()
                Dim DBCmd As New SqlCommand("Select * From usrs", DBConn)
                Dim rows As Integer = DBCmd.ExecuteNonQuery()
                CheckDBAttached2SqlServerExpress = "Attached"
            Catch ex As Exception
                CheckDBAttached2SqlServerExpress = ""
            End Try
            DBConn.Close()
        End Using
    End Function

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Me.Dispose()
    End Sub
End Class