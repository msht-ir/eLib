<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReadRef
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
        Me.ListPaths = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Read = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Locate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_SaveACopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_OpenSaveFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Email = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListPaths
        '
        Me.ListPaths.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ListPaths.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListPaths.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListPaths.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPaths.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.ListPaths.ForeColor = System.Drawing.Color.IndianRed
        Me.ListPaths.FormattingEnabled = True
        Me.ListPaths.ItemHeight = 17
        Me.ListPaths.Location = New System.Drawing.Point(0, 0)
        Me.ListPaths.Name = "ListPaths"
        Me.ListPaths.Size = New System.Drawing.Size(1205, 80)
        Me.ListPaths.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Read, Me.Menu_Edit, Me.Menu_Locate, Me.ToolStripMenuItem1, Me.Menu_SaveACopy, Me.Menu_OpenSaveFolder, Me.Menu_Email, Me.ToolStripMenuItem3, Me.Menu_Delete, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 192)
        '
        'Menu_Read
        '
        Me.Menu_Read.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_Read.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Menu_Read.Name = "Menu_Read"
        Me.Menu_Read.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Read.Text = "Read ..."
        '
        'Menu_Edit
        '
        Me.Menu_Edit.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_Edit.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Edit.Text = "Edit ..."
        '
        'Menu_Locate
        '
        Me.Menu_Locate.Name = "Menu_Locate"
        Me.Menu_Locate.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Locate.Text = "Locate"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_SaveACopy
        '
        Me.Menu_SaveACopy.Name = "Menu_SaveACopy"
        Me.Menu_SaveACopy.Size = New System.Drawing.Size(147, 22)
        Me.Menu_SaveACopy.Text = "Save a Copy"
        '
        'Menu_OpenSaveFolder
        '
        Me.Menu_OpenSaveFolder.Name = "Menu_OpenSaveFolder"
        Me.Menu_OpenSaveFolder.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OpenSaveFolder.Text = "SaveAs Folder"
        '
        'Menu_Email
        '
        Me.Menu_Email.Enabled = False
        Me.Menu_Email.Name = "Menu_Email"
        Me.Menu_Email.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Email.Text = "Email"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_Delete
        '
        Me.Menu_Delete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Menu_Delete.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Delete.Name = "Menu_Delete"
        Me.Menu_Delete.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Delete.Text = "Delete"
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Cancel.Text = "Exit"
        '
        'frmReadRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1205, 80)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.ListPaths)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReadRef"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DblClick to READ"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListPaths As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Read As ToolStripMenuItem
    Friend WithEvents Menu_SaveACopy As ToolStripMenuItem
    Friend WithEvents Menu_OpenSaveFolder As ToolStripMenuItem
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents Menu_Delete As ToolStripMenuItem
    Friend WithEvents Menu_Locate As ToolStripMenuItem
    Friend WithEvents Menu_Email As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
