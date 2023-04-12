﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmSettings))
        GridSettings = New DataGridView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_ExitSetup = New ToolStripMenuItem()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        CType(GridSettings, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GridSettings
        ' 
        GridSettings.AllowUserToAddRows = False
        GridSettings.AllowUserToDeleteRows = False
        GridSettings.AllowUserToOrderColumns = True
        GridSettings.AllowUserToResizeColumns = False
        GridSettings.AllowUserToResizeRows = False
        GridSettings.BackgroundColor = SystemColors.Control
        GridSettings.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        GridSettings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        GridSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = Color.IndianRed
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        GridSettings.DefaultCellStyle = DataGridViewCellStyle2
        GridSettings.Dock = DockStyle.Top
        GridSettings.EditMode = DataGridViewEditMode.EditProgrammatically
        GridSettings.GridColor = SystemColors.ControlLight
        GridSettings.Location = New Point(0, 0)
        GridSettings.Name = "GridSettings"
        GridSettings.RowHeadersVisible = False
        GridSettings.RowTemplate.Height = 25
        GridSettings.SelectionMode = DataGridViewSelectionMode.CellSelect
        GridSettings.Size = New Size(616, 405)
        GridSettings.TabIndex = 12
        GridSettings.TabStop = False
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_ExitSetup})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(181, 48)
        ' 
        ' Menu_ExitSetup
        ' 
        Menu_ExitSetup.ForeColor = Color.IndianRed
        Menu_ExitSetup.Name = "Menu_ExitSetup"
        Menu_ExitSetup.Size = New Size(180, 22)
        Menu_ExitSetup.Text = "Save and Exit"' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(616, 443)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(GridSettings)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        CType(GridSettings, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents GridSettings As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_ExitSetup As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
