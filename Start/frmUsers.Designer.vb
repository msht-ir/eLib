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
        Me.Menu_AddNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_DeleteUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Login = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridUsers = New System.Windows.Forms.DataGridView()
        Me.Menu_Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddNewUser, Me.Menu_DeleteUser, Me.Menu_Login, Me.Menu_Settings, Me.ToolStripMenuItem2, Me.Menu_Exit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 142)
        '
        'Menu_AddNewUser
        '
        Me.Menu_AddNewUser.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_AddNewUser.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Menu_AddNewUser.Name = "Menu_AddNewUser"
        Me.Menu_AddNewUser.Size = New System.Drawing.Size(180, 22)
        Me.Menu_AddNewUser.Text = "Add new user"
        '
        'Menu_DeleteUser
        '
        Me.Menu_DeleteUser.Name = "Menu_DeleteUser"
        Me.Menu_DeleteUser.Size = New System.Drawing.Size(180, 22)
        Me.Menu_DeleteUser.Text = "Delete"
        '
        'Menu_Login
        '
        Me.Menu_Login.Name = "Menu_Login"
        Me.Menu_Login.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Login.Text = "Login"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Exit.Text = "Exit"
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
        Me.GridUsers.Size = New System.Drawing.Size(1257, 307)
        Me.GridUsers.TabIndex = 0
        Me.GridUsers.TabStop = False
        '
        'Menu_Settings
        '
        Me.Menu_Settings.Name = "Menu_Settings"
        Me.Menu_Settings.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Settings.Text = "Settings"
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1257, 338)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.GridUsers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Users"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents GridUsers As DataGridView
    Friend WithEvents Menu_AddNewUser As ToolStripMenuItem
    Friend WithEvents Menu_DeleteUser As ToolStripMenuItem
    Friend WithEvents Menu_Login As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_Settings As ToolStripMenuItem
End Class
