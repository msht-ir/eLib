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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmCNN))
        GridCNN = New DataGridView()
        MenuStripCNN = New ContextMenuStrip(components)
        Menu_SelectBE = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        Menu_ResetCnns = New ToolStripMenuItem()
        Menu_FindDB = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripSeparator()
        Menu_Guide = New ToolStripMenuItem()
        Menu_Exit = New ToolStripMenuItem()
        PasswordTextBox = New TextBox()
        Label1 = New Label()
        CType(GridCNN, ComponentModel.ISupportInitialize).BeginInit()
        MenuStripCNN.SuspendLayout()
        SuspendLayout()
        ' 
        ' GridCNN
        ' 
        GridCNN.AllowUserToAddRows = False
        GridCNN.AllowUserToDeleteRows = False
        GridCNN.AllowUserToResizeColumns = False
        GridCNN.AllowUserToResizeRows = False
        GridCNN.BackgroundColor = SystemColors.Control
        GridCNN.BorderStyle = BorderStyle.None
        GridCNN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridCNN.ColumnHeadersVisible = False
        GridCNN.ContextMenuStrip = MenuStripCNN
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle1.SelectionForeColor = Color.IndianRed
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False
        GridCNN.DefaultCellStyle = DataGridViewCellStyle1
        GridCNN.Dock = DockStyle.Top
        GridCNN.EditMode = DataGridViewEditMode.EditProgrammatically
        GridCNN.GridColor = SystemColors.Control
        GridCNN.Location = New Point(0, 0)
        GridCNN.MultiSelect = False
        GridCNN.Name = "GridCNN"
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.InfoText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        GridCNN.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        GridCNN.RowHeadersVisible = False
        GridCNN.RowHeadersWidth = 20
        GridCNN.RowTemplate.Height = 25
        GridCNN.Size = New Size(544, 134)
        GridCNN.TabIndex = 3
        ' 
        ' MenuStripCNN
        ' 
        MenuStripCNN.Items.AddRange(New ToolStripItem() {Menu_SelectBE, ToolStripMenuItem2, Menu_ResetCnns, Menu_FindDB, ToolStripMenuItem3, Menu_Guide, Menu_Exit})
        MenuStripCNN.Name = "MenuStripCNN"
        MenuStripCNN.Size = New Size(131, 126)
        ' 
        ' Menu_SelectBE
        ' 
        Menu_SelectBE.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_SelectBE.ForeColor = Color.DarkGoldenrod
        Menu_SelectBE.Name = "Menu_SelectBE"
        Menu_SelectBE.Size = New Size(130, 22)
        Menu_SelectBE.Text = "Log in"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(127, 6)
        ' 
        ' Menu_ResetCnns
        ' 
        Menu_ResetCnns.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Menu_ResetCnns.ForeColor = SystemColors.ControlText
        Menu_ResetCnns.Name = "Menu_ResetCnns"
        Menu_ResetCnns.Size = New Size(130, 22)
        Menu_ResetCnns.Text = "Libraries ..."
        ' 
        ' Menu_FindDB
        ' 
        Menu_FindDB.Name = "Menu_FindDB"
        Menu_FindDB.Size = New Size(130, 22)
        Menu_FindDB.Text = "Find libs ..."
        Menu_FindDB.Visible = False
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(127, 6)
        ' 
        ' Menu_Guide
        ' 
        Menu_Guide.Name = "Menu_Guide"
        Menu_Guide.Size = New Size(130, 22)
        Menu_Guide.Text = "Help"
        ' 
        ' Menu_Exit
        ' 
        Menu_Exit.ForeColor = Color.IndianRed
        Menu_Exit.Name = "Menu_Exit"
        Menu_Exit.Size = New Size(130, 22)
        Menu_Exit.Text = "Quit"
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.BackColor = SystemColors.Control
        PasswordTextBox.BorderStyle = BorderStyle.None
        PasswordTextBox.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        PasswordTextBox.ForeColor = SystemColors.ActiveCaption
        PasswordTextBox.Location = New Point(77, 161)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "-"c
        PasswordTextBox.Size = New Size(138, 16)
        PasswordTextBox.TabIndex = 6
        PasswordTextBox.Visible = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Copperplate Gothic Light", 11F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.IndianRed
        Label1.Location = New Point(17, 161)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 16)
        Label1.TabIndex = 7
        Label1.Text = "Login"
        Label1.Visible = False
        ' 
        ' frmCNN
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(544, 205)
        ContextMenuStrip = MenuStripCNN
        ControlBox = False
        Controls.Add(GridCNN)
        Controls.Add(Label1)
        Controls.Add(PasswordTextBox)
        ForeColor = Color.DarkSlateGray
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmCNN"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Libs"
        CType(GridCNN, ComponentModel.ISupportInitialize).EndInit()
        MenuStripCNN.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents GridCNN As DataGridView
    Friend WithEvents MenuStripCNN As ContextMenuStrip
    Friend WithEvents Menu_SelectBE As ToolStripMenuItem
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_FindDB As ToolStripMenuItem
    Friend WithEvents راهنماToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Menu_Guide As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Menu_ResetCnns As ToolStripMenuItem
End Class
