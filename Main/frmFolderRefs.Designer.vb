<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFolderRefs
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_SelectFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Read = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Assign = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CopyTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_SubFolders = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Inverse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_None = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu2_Papers = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu2_Books = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu2_Manuals = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu2_Lectures = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu2_LastVisited = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListPaths = New System.Windows.Forms.CheckedListBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_SelectFolder, Me.Menu_Read, Me.Menu_Assign, Me.Menu_CopyTitle, Me.ToolStripMenuItem2, Me.Menu_SubFolders, Me.Menu_Inverse, Me.Menu_None, Me.ToolStripMenuItem1, Me.Menu_Exit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(158, 192)
        '
        'Menu_SelectFolder
        '
        Me.Menu_SelectFolder.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_SelectFolder.ForeColor = System.Drawing.Color.SeaGreen
        Me.Menu_SelectFolder.Name = "Menu_SelectFolder"
        Me.Menu_SelectFolder.Size = New System.Drawing.Size(157, 22)
        Me.Menu_SelectFolder.Text = "Select Folder ..."
        '
        'Menu_Read
        '
        Me.Menu_Read.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_Read.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Menu_Read.Name = "Menu_Read"
        Me.Menu_Read.Size = New System.Drawing.Size(157, 22)
        Me.Menu_Read.Text = "Read"
        '
        'Menu_Assign
        '
        Me.Menu_Assign.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu_Assign.ForeColor = System.Drawing.Color.SeaGreen
        Me.Menu_Assign.Name = "Menu_Assign"
        Me.Menu_Assign.Size = New System.Drawing.Size(157, 22)
        Me.Menu_Assign.Text = "Assign ..."
        '
        'Menu_CopyTitle
        '
        Me.Menu_CopyTitle.Name = "Menu_CopyTitle"
        Me.Menu_CopyTitle.Size = New System.Drawing.Size(157, 22)
        Me.Menu_CopyTitle.Text = "Copy title"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(154, 6)
        '
        'Menu_SubFolders
        '
        Me.Menu_SubFolders.Checked = True
        Me.Menu_SubFolders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Menu_SubFolders.Name = "Menu_SubFolders"
        Me.Menu_SubFolders.Size = New System.Drawing.Size(157, 22)
        Me.Menu_SubFolders.Text = "Subfolders"
        '
        'Menu_Inverse
        '
        Me.Menu_Inverse.Name = "Menu_Inverse"
        Me.Menu_Inverse.Size = New System.Drawing.Size(157, 22)
        Me.Menu_Inverse.Text = "Inverse"
        '
        'Menu_None
        '
        Me.Menu_None.Name = "Menu_None"
        Me.Menu_None.Size = New System.Drawing.Size(157, 22)
        Me.Menu_None.Text = "None"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(154, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(157, 22)
        Me.Menu_Exit.Text = "Exit"
        '
        'lblPath
        '
        Me.lblPath.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lblPath.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblPath.Location = New System.Drawing.Point(12, 6)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(1194, 15)
        Me.lblPath.TabIndex = 2
        Me.lblPath.Text = "-"
        Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu2_Papers, Me.Menu2_Books, Me.Menu2_Manuals, Me.Menu2_Lectures, Me.ToolStripMenuItem4, Me.Menu2_LastVisited})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(181, 142)
        '
        'Menu2_Papers
        '
        Me.Menu2_Papers.Name = "Menu2_Papers"
        Me.Menu2_Papers.Size = New System.Drawing.Size(180, 22)
        Me.Menu2_Papers.Text = "Papers"
        '
        'Menu2_Books
        '
        Me.Menu2_Books.Name = "Menu2_Books"
        Me.Menu2_Books.Size = New System.Drawing.Size(180, 22)
        Me.Menu2_Books.Text = "Books"
        '
        'Menu2_Manuals
        '
        Me.Menu2_Manuals.Name = "Menu2_Manuals"
        Me.Menu2_Manuals.Size = New System.Drawing.Size(180, 22)
        Me.Menu2_Manuals.Text = "Manuals"
        '
        'Menu2_Lectures
        '
        Me.Menu2_Lectures.Name = "Menu2_Lectures"
        Me.Menu2_Lectures.Size = New System.Drawing.Size(180, 22)
        Me.Menu2_Lectures.Text = "Lectures"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(177, 6)
        '
        'Menu2_LastVisited
        '
        Me.Menu2_LastVisited.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu2_LastVisited.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Menu2_LastVisited.Name = "Menu2_LastVisited"
        Me.Menu2_LastVisited.Size = New System.Drawing.Size(180, 22)
        Me.Menu2_LastVisited.Text = "Last folder"
        '
        'ListPaths
        '
        Me.ListPaths.BackColor = System.Drawing.SystemColors.Control
        Me.ListPaths.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListPaths.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListPaths.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListPaths.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.ListPaths.FormattingEnabled = True
        Me.ListPaths.Location = New System.Drawing.Point(0, 28)
        Me.ListPaths.Name = "ListPaths"
        Me.ListPaths.Size = New System.Drawing.Size(1218, 440)
        Me.ListPaths.TabIndex = 3
        '
        'frmFolderRefs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1218, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListPaths)
        Me.Controls.Add(Me.lblPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFolderRefs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folder Refs"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Assign As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_Inverse As ToolStripMenuItem
    Friend WithEvents Menu_None As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents Menu_SubFolders As ToolStripMenuItem
    Friend WithEvents Menu_SelectFolder As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblPath As Label
    Friend WithEvents ListPaths As CheckedListBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_Papers As ToolStripMenuItem
    Friend WithEvents Menu2_Books As ToolStripMenuItem
    Friend WithEvents Menu2_Manuals As ToolStripMenuItem
    Friend WithEvents Menu2_Lectures As ToolStripMenuItem
    Friend WithEvents Menu2_LastVisited As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents Menu_Read As ToolStripMenuItem
    Friend WithEvents Menu_CopyTitle As ToolStripMenuItem
End Class
