<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProject
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtProjectNote = New System.Windows.Forms.TextBox()
        Me.CheckBoxActive = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtProjectName = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.txtProjectNote)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 77)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 68)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'txtProjectNote
        '
        Me.txtProjectNote.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtProjectNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProjectNote.Location = New System.Drawing.Point(60, 24)
        Me.txtProjectNote.Name = "txtProjectNote"
        Me.txtProjectNote.Size = New System.Drawing.Size(456, 16)
        Me.txtProjectNote.TabIndex = 1
        Me.txtProjectNote.Text = "-"
        '
        'CheckBoxActive
        '
        Me.CheckBoxActive.AutoSize = True
        Me.CheckBoxActive.Checked = True
        Me.CheckBoxActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxActive.Location = New System.Drawing.Point(23, 43)
        Me.CheckBoxActive.Name = "CheckBoxActive"
        Me.CheckBoxActive.Size = New System.Drawing.Size(59, 19)
        Me.CheckBoxActive.TabIndex = 0
        Me.CheckBoxActive.TabStop = False
        Me.CheckBoxActive.Text = "Active"
        Me.CheckBoxActive.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Save, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(111, 48)
        '
        'Menu_Save
        '
        Me.Menu_Save.Name = "Menu_Save"
        Me.Menu_Save.Size = New System.Drawing.Size(110, 22)
        Me.Menu_Save.Text = "Save"
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(110, 22)
        Me.Menu_Cancel.Text = "Cancel"
        '
        'txtProjectName
        '
        Me.txtProjectName.BackColor = System.Drawing.SystemColors.Control
        Me.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProjectName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtProjectName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProjectName.Location = New System.Drawing.Point(23, 13)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(247, 20)
        Me.txtProjectName.TabIndex = 0
        '
        'frmProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(517, 145)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.CheckBoxActive)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProject"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtProjectNote As TextBox
    Friend WithEvents CheckBoxActive As CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Save As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents txtProjectName As MaskedTextBox
End Class
