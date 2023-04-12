<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmUsers))
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_LoginAsUser = New ToolStripMenuItem()
        Menu_LoginAsAdmin = New ToolStripMenuItem()
        Menu_Tools = New ToolStripMenuItem()
        MenuTools_Scan = New ToolStripMenuItem()
        MenuTools_NewUser = New ToolStripMenuItem()
        MenuTools_DeleteUser = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripSeparator()
        MenuTools_Backup = New ToolStripMenuItem()
        MenuTools_Restore = New ToolStripMenuItem()
        MenuTools_Clear = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripSeparator()
        MenuTools_Settings = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        Menu_LogOut = New ToolStripMenuItem()
        GridUsers = New DataGridView()
        lblInfo = New Label()
        ContextMenuStrip1.SuspendLayout()
        CType(GridUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_LoginAsUser, Menu_LoginAsAdmin, Menu_Tools, ToolStripMenuItem2, Menu_LogOut})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(173, 98)
        ' 
        ' Menu_LoginAsUser
        ' 
        Menu_LoginAsUser.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_LoginAsUser.ForeColor = Color.Teal
        Menu_LoginAsUser.Name = "Menu_LoginAsUser"
        Menu_LoginAsUser.Size = New Size(172, 22)
        Menu_LoginAsUser.Text = "Login ..."' 
        ' Menu_LoginAsAdmin
        ' 
        Menu_LoginAsAdmin.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_LoginAsAdmin.ForeColor = Color.Teal
        Menu_LoginAsAdmin.Name = "Menu_LoginAsAdmin"
        Menu_LoginAsAdmin.Size = New Size(172, 22)
        Menu_LoginAsAdmin.Text = "Login as Admin ..."' 
        ' Menu_Tools
        ' 
        Menu_Tools.DropDownItems.AddRange(New ToolStripItem() {MenuTools_Scan, MenuTools_NewUser, MenuTools_DeleteUser, ToolStripMenuItem5, MenuTools_Backup, MenuTools_Restore, MenuTools_Clear, ToolStripMenuItem4, MenuTools_Settings})
        Menu_Tools.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Menu_Tools.Name = "Menu_Tools"
        Menu_Tools.Size = New Size(172, 22)
        Menu_Tools.Text = "Tools"' 
        ' MenuTools_Scan
        ' 
        MenuTools_Scan.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        MenuTools_Scan.Name = "MenuTools_Scan"
        MenuTools_Scan.Size = New Size(127, 22)
        MenuTools_Scan.Text = "Scan"' 
        ' MenuTools_NewUser
        ' 
        MenuTools_NewUser.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        MenuTools_NewUser.Name = "MenuTools_NewUser"
        MenuTools_NewUser.Size = New Size(127, 22)
        MenuTools_NewUser.Text = "New user"' 
        ' MenuTools_DeleteUser
        ' 
        MenuTools_DeleteUser.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        MenuTools_DeleteUser.ForeColor = Color.IndianRed
        MenuTools_DeleteUser.Name = "MenuTools_DeleteUser"
        MenuTools_DeleteUser.Size = New Size(127, 22)
        MenuTools_DeleteUser.Text = "Delete"' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(124, 6)
        ' 
        ' MenuTools_Backup
        ' 
        MenuTools_Backup.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        MenuTools_Backup.Name = "MenuTools_Backup"
        MenuTools_Backup.Size = New Size(127, 22)
        MenuTools_Backup.Text = "Backup"' 
        ' MenuTools_Restore
        ' 
        MenuTools_Restore.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        MenuTools_Restore.Name = "MenuTools_Restore"
        MenuTools_Restore.Size = New Size(127, 22)
        MenuTools_Restore.Text = "Restore"' 
        ' MenuTools_Clear
        ' 
        MenuTools_Clear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        MenuTools_Clear.ForeColor = Color.IndianRed
        MenuTools_Clear.Name = "MenuTools_Clear"
        MenuTools_Clear.Size = New Size(127, 22)
        MenuTools_Clear.Text = "Clear"' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(124, 6)
        ' 
        ' MenuTools_Settings
        ' 
        MenuTools_Settings.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        MenuTools_Settings.Name = "MenuTools_Settings"
        MenuTools_Settings.Size = New Size(127, 22)
        MenuTools_Settings.Text = "Settings"' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(169, 6)
        ' 
        ' Menu_LogOut
        ' 
        Menu_LogOut.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Menu_LogOut.ForeColor = Color.IndianRed
        Menu_LogOut.Name = "Menu_LogOut"
        Menu_LogOut.Size = New Size(172, 22)
        Menu_LogOut.Text = "Log out"' 
        ' GridUsers
        ' 
        GridUsers.AllowUserToAddRows = False
        GridUsers.AllowUserToDeleteRows = False
        GridUsers.AllowUserToResizeColumns = False
        GridUsers.AllowUserToResizeRows = False
        GridUsers.BackgroundColor = SystemColors.Control
        GridUsers.BorderStyle = BorderStyle.None
        GridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlDarkDark
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = Color.IndianRed
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False
        GridUsers.DefaultCellStyle = DataGridViewCellStyle1
        GridUsers.Dock = DockStyle.Top
        GridUsers.EditMode = DataGridViewEditMode.EditProgrammatically
        GridUsers.GridColor = SystemColors.Control
        GridUsers.Location = New Point(0, 0)
        GridUsers.Name = "GridUsers"
        GridUsers.RowHeadersVisible = False
        GridUsers.RowHeadersWidth = 15
        GridUsers.RowTemplate.Height = 25
        GridUsers.SelectionMode = DataGridViewSelectionMode.CellSelect
        GridUsers.Size = New Size(945, 234)
        GridUsers.TabIndex = 0
        GridUsers.TabStop = False
        ' 
        ' lblInfo
        ' 
        lblInfo.AutoSize = True
        lblInfo.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblInfo.ForeColor = Color.IndianRed
        lblInfo.Location = New Point(12, 242)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(12, 15)
        lblInfo.TabIndex = 1
        lblInfo.Text = "-"' 
        ' frmUsers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(945, 266)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(lblInfo)
        Controls.Add(GridUsers)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmUsers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Users setup"
        ContextMenuStrip1.ResumeLayout(False)
        CType(GridUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_LoginAsAdmin As ToolStripMenuItem
    Friend WithEvents GridUsers As DataGridView
    Friend WithEvents Menu_LoginAsUser As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_LogOut As ToolStripMenuItem
    Friend WithEvents lblInfo As Label
    Friend WithEvents Menu_Tools As ToolStripMenuItem
    Friend WithEvents MenuTools_NewUser As ToolStripMenuItem
    Friend WithEvents MenuTools_DeleteUser As ToolStripMenuItem
    Friend WithEvents MenuTools_Backup As ToolStripMenuItem
    Friend WithEvents MenuTools_Restore As ToolStripMenuItem
    Friend WithEvents MenuTools_Scan As ToolStripMenuItem
    Friend WithEvents MenuTools_Clear As ToolStripMenuItem
    Friend WithEvents MenuTools_Settings As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
End Class
