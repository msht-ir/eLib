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
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_AddNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_DeleteUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Scan = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Backup = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Restore = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ClearDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_LogOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridUsers = New System.Windows.Forms.DataGridView()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_LoginAsAdmin, Me.Menu_LoginAsUser, Me.ToolStripMenuItem1, Me.Menu_AddNewUser, Me.Menu_DeleteUser, Me.Menu_Settings, Me.ToolStripMenuItem2, Me.Menu_Scan, Me.Menu_Backup, Me.Menu_Restore, Me.Menu_ClearDB, Me.ToolStripMenuItem3, Me.Menu_LogOut})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 242)
        '
        'Menu_LoginAsAdmin
        '
        Me.Menu_LoginAsAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_LoginAsAdmin.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Menu_LoginAsAdmin.Name = "Menu_LoginAsAdmin"
        Me.Menu_LoginAsAdmin.Size = New System.Drawing.Size(191, 22)
        Me.Menu_LoginAsAdmin.Text = "Continue as admin ..."
        '
        'Menu_LoginAsUser
        '
        Me.Menu_LoginAsUser.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_LoginAsUser.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Menu_LoginAsUser.Name = "Menu_LoginAsUser"
        Me.Menu_LoginAsUser.Size = New System.Drawing.Size(191, 22)
        Me.Menu_LoginAsUser.Text = "Login as user ..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(188, 6)
        '
        'Menu_AddNewUser
        '
        Me.Menu_AddNewUser.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Menu_AddNewUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_AddNewUser.Name = "Menu_AddNewUser"
        Me.Menu_AddNewUser.Size = New System.Drawing.Size(191, 22)
        Me.Menu_AddNewUser.Text = "New user"
        '
        'Menu_DeleteUser
        '
        Me.Menu_DeleteUser.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_DeleteUser.Name = "Menu_DeleteUser"
        Me.Menu_DeleteUser.Size = New System.Drawing.Size(191, 22)
        Me.Menu_DeleteUser.Text = "Delete"
        '
        'Menu_Settings
        '
        Me.Menu_Settings.Name = "Menu_Settings"
        Me.Menu_Settings.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Settings.Text = "Settings"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(188, 6)
        '
        'Menu_Scan
        '
        Me.Menu_Scan.Name = "Menu_Scan"
        Me.Menu_Scan.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Scan.Text = "Scan"
        '
        'Menu_Backup
        '
        Me.Menu_Backup.Name = "Menu_Backup"
        Me.Menu_Backup.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Backup.Text = "Backup"
        '
        'Menu_Restore
        '
        Me.Menu_Restore.Name = "Menu_Restore"
        Me.Menu_Restore.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Restore.Text = "Restore"
        '
        'Menu_ClearDB
        '
        Me.Menu_ClearDB.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_ClearDB.Name = "Menu_ClearDB"
        Me.Menu_ClearDB.Size = New System.Drawing.Size(191, 22)
        Me.Menu_ClearDB.Text = "Clear"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(188, 6)
        '
        'Menu_LogOut
        '
        Me.Menu_LogOut.Name = "Menu_LogOut"
        Me.Menu_LogOut.Size = New System.Drawing.Size(191, 22)
        Me.Menu_LogOut.Text = "Logout"
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
    Friend WithEvents Menu_AddNewUser As ToolStripMenuItem
    Friend WithEvents Menu_DeleteUser As ToolStripMenuItem
    Friend WithEvents Menu_LoginAsUser As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_Settings As ToolStripMenuItem
    Friend WithEvents Menu_LogOut As ToolStripMenuItem
    Friend WithEvents Menu_Backup As ToolStripMenuItem
    Friend WithEvents Menu_Restore As ToolStripMenuItem
    Friend WithEvents Menu_Scan As ToolStripMenuItem
    Friend WithEvents Menu_ClearDB As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents lblInfo As Label
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
End Class
