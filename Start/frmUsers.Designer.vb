<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsers))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_LoginAsAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_LoginAsUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Tools = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_NewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_DeleteUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_Backup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_Restore = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_Scan = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTools_Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_LogOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridUsers = New System.Windows.Forms.DataGridView()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_LoginAsAdmin, Me.Menu_LoginAsUser, Me.ToolStripMenuItem2, Me.Menu_Tools, Me.Menu_LogOut})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 120)
        '
        'Menu_LoginAsAdmin
        '
        Me.Menu_LoginAsAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu_LoginAsAdmin.ForeColor = System.Drawing.Color.DarkGreen
        Me.Menu_LoginAsAdmin.Name = "Menu_LoginAsAdmin"
        Me.Menu_LoginAsAdmin.Size = New System.Drawing.Size(180, 22)
        Me.Menu_LoginAsAdmin.Text = "Continue admin ..."
        '
        'Menu_LoginAsUser
        '
        Me.Menu_LoginAsUser.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu_LoginAsUser.ForeColor = System.Drawing.Color.DarkGreen
        Me.Menu_LoginAsUser.Name = "Menu_LoginAsUser"
        Me.Menu_LoginAsUser.Size = New System.Drawing.Size(180, 22)
        Me.Menu_LoginAsUser.Text = "Login user ..."
        '
        'Menu_Tools
        '
        Me.Menu_Tools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuTools_NewUser, Me.MenuTools_DeleteUser, Me.ToolStripMenuItem4, Me.MenuTools_Backup, Me.MenuTools_Restore, Me.MenuTools_Scan, Me.MenuTools_Clear, Me.ToolStripMenuItem5, Me.MenuTools_Settings})
        Me.Menu_Tools.Name = "Menu_Tools"
        Me.Menu_Tools.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Tools.Text = "Tools"
        '
        'MenuTools_NewUser
        '
        Me.MenuTools_NewUser.Name = "MenuTools_NewUser"
        Me.MenuTools_NewUser.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_NewUser.Text = "New user"
        '
        'MenuTools_DeleteUser
        '
        Me.MenuTools_DeleteUser.Name = "MenuTools_DeleteUser"
        Me.MenuTools_DeleteUser.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_DeleteUser.Text = "Delete"
        '
        'MenuTools_Backup
        '
        Me.MenuTools_Backup.Name = "MenuTools_Backup"
        Me.MenuTools_Backup.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_Backup.Text = "Backup"
        '
        'MenuTools_Restore
        '
        Me.MenuTools_Restore.Name = "MenuTools_Restore"
        Me.MenuTools_Restore.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_Restore.Text = "Restore"
        '
        'MenuTools_Scan
        '
        Me.MenuTools_Scan.Name = "MenuTools_Scan"
        Me.MenuTools_Scan.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_Scan.Text = "Scan"
        '
        'MenuTools_Clear
        '
        Me.MenuTools_Clear.Name = "MenuTools_Clear"
        Me.MenuTools_Clear.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_Clear.Text = "Clear"
        '
        'MenuTools_Settings
        '
        Me.MenuTools_Settings.Name = "MenuTools_Settings"
        Me.MenuTools_Settings.Size = New System.Drawing.Size(180, 22)
        Me.MenuTools_Settings.Text = "Settings"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_LogOut
        '
        Me.Menu_LogOut.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu_LogOut.Name = "Menu_LogOut"
        Me.Menu_LogOut.Size = New System.Drawing.Size(180, 22)
        Me.Menu_LogOut.Text = "Log out"
        '
        'GridUsers
        '
        Me.GridUsers.AllowUserToAddRows = False
        Me.GridUsers.AllowUserToDeleteRows = False
        Me.GridUsers.AllowUserToResizeColumns = False
        Me.GridUsers.AllowUserToResizeRows = False
        Me.GridUsers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridUsers.DefaultCellStyle = DataGridViewCellStyle1
        Me.GridUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridUsers.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.GridUsers.Location = New System.Drawing.Point(0, 0)
        Me.GridUsers.Name = "GridUsers"
        Me.GridUsers.RowHeadersVisible = False
        Me.GridUsers.RowHeadersWidth = 15
        Me.GridUsers.RowTemplate.Height = 25
        Me.GridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridUsers.Size = New System.Drawing.Size(1284, 234)
        Me.GridUsers.TabIndex = 0
        Me.GridUsers.TabStop = False
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblInfo.ForeColor = System.Drawing.Color.IndianRed
        Me.lblInfo.Location = New System.Drawing.Point(12, 242)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(12, 15)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "-"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(177, 6)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(177, 6)
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1284, 266)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.GridUsers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Users setup"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
