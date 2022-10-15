<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCNN
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCNN))
        Me.GridCNN = New System.Windows.Forms.DataGridView()
        Me.MenuStripCNN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_SelectBE = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_AddCNN = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_FindDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ResetCnns = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Guide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBuildInfo = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridCNN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStripCNN.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridCNN
        '
        Me.GridCNN.AllowUserToAddRows = False
        Me.GridCNN.AllowUserToDeleteRows = False
        Me.GridCNN.AllowUserToResizeColumns = False
        Me.GridCNN.AllowUserToResizeRows = False
        Me.GridCNN.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridCNN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCNN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCNN.ContextMenuStrip = Me.MenuStripCNN
        Me.GridCNN.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridCNN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridCNN.GridColor = System.Drawing.Color.Lavender
        Me.GridCNN.Location = New System.Drawing.Point(0, 0)
        Me.GridCNN.MultiSelect = False
        Me.GridCNN.Name = "GridCNN"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridCNN.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridCNN.RowHeadersVisible = False
        Me.GridCNN.RowHeadersWidth = 20
        Me.GridCNN.RowTemplate.Height = 25
        Me.GridCNN.Size = New System.Drawing.Size(839, 199)
        Me.GridCNN.TabIndex = 3
        '
        'MenuStripCNN
        '
        Me.MenuStripCNN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_SelectBE, Me.ToolStripMenuItem2, Me.Menu_AddCNN, Me.Menu_Edit, Me.Menu_FindDB, Me.Menu_Remove, Me.Menu_ResetCnns, Me.Menu_Guide, Me.ToolStripMenuItem3, Me.Menu_Exit})
        Me.MenuStripCNN.Name = "MenuStripCNN"
        Me.MenuStripCNN.Size = New System.Drawing.Size(133, 192)
        '
        'Menu_SelectBE
        '
        Me.Menu_SelectBE.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_SelectBE.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Menu_SelectBE.Name = "Menu_SelectBE"
        Me.Menu_SelectBE.Size = New System.Drawing.Size(132, 22)
        Me.Menu_SelectBE.Text = "Connect ..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(129, 6)
        '
        'Menu_AddCNN
        '
        Me.Menu_AddCNN.Name = "Menu_AddCNN"
        Me.Menu_AddCNN.Size = New System.Drawing.Size(132, 22)
        Me.Menu_AddCNN.Text = "Add"
        '
        'Menu_Edit
        '
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.Size = New System.Drawing.Size(132, 22)
        Me.Menu_Edit.Text = "Edit"
        '
        'Menu_FindDB
        '
        Me.Menu_FindDB.Name = "Menu_FindDB"
        Me.Menu_FindDB.Size = New System.Drawing.Size(132, 22)
        Me.Menu_FindDB.Text = "Find ..."
        '
        'Menu_Remove
        '
        Me.Menu_Remove.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Remove.Name = "Menu_Remove"
        Me.Menu_Remove.Size = New System.Drawing.Size(132, 22)
        Me.Menu_Remove.Text = "Delete"
        '
        'Menu_ResetCnns
        '
        Me.Menu_ResetCnns.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Menu_ResetCnns.ForeColor = System.Drawing.Color.OliveDrab
        Me.Menu_ResetCnns.Name = "Menu_ResetCnns"
        Me.Menu_ResetCnns.Size = New System.Drawing.Size(132, 22)
        Me.Menu_ResetCnns.Text = "Reset"
        '
        'Menu_Guide
        '
        Me.Menu_Guide.Name = "Menu_Guide"
        Me.Menu_Guide.Size = New System.Drawing.Size(132, 22)
        Me.Menu_Guide.Text = "Guide"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(129, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(132, 22)
        Me.Menu_Exit.Text = "Quit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Copperplate Gothic Light", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(12, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(85, 35)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "eLib"
        '
        'lblBuildInfo
        '
        Me.lblBuildInfo.AutoSize = True
        Me.lblBuildInfo.Font = New System.Drawing.Font("Copperplate Gothic Light", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblBuildInfo.ForeColor = System.Drawing.Color.LightSlateGray
        Me.lblBuildInfo.Location = New System.Drawing.Point(96, 216)
        Me.lblBuildInfo.Name = "lblBuildInfo"
        Me.lblBuildInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBuildInfo.Size = New System.Drawing.Size(120, 14)
        Me.lblBuildInfo.TabIndex = 5
        Me.lblBuildInfo.Text = "Build 14010402"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.Navy
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PasswordTextBox.Enabled = False
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PasswordTextBox.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.PasswordTextBox.Location = New System.Drawing.Point(415, 214)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.PasswordTextBox.Size = New System.Drawing.Size(88, 16)
        Me.PasswordTextBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(339, 212)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Password:"
        Me.Label1.Visible = False
        '
        'frmCNN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(839, 240)
        Me.ContextMenuStrip = Me.MenuStripCNN
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.lblBuildInfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridCNN)
        Me.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCNN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eLib"
        CType(Me.GridCNN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStripCNN.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridCNN As DataGridView
    Friend WithEvents MenuStripCNN As ContextMenuStrip
    Friend WithEvents Menu_SelectBE As ToolStripMenuItem
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_FindDB As ToolStripMenuItem
    Friend WithEvents Menu_AddCNN As ToolStripMenuItem
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents راهنماToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Menu_Guide As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Private WithEvents Label2 As Label
    Friend WithEvents lblBuildInfo As Label
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Menu_Remove As ToolStripMenuItem
    Friend WithEvents Menu_ResetCnns As ToolStripMenuItem
End Class
