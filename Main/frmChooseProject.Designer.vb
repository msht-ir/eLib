<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChooseProject
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
        Me.ListProj = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu1_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu1_Active = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu1_Inactive = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu1_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu1_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListProd = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu2_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu2_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxProdNote = New System.Windows.Forms.TextBox()
        Me.txtSearchProj = New System.Windows.Forms.TextBox()
        Me.txtSearchProd = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListProj
        '
        Me.ListProj.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ListProj.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProj.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListProj.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListProj.FormattingEnabled = True
        Me.ListProj.ItemHeight = 17
        Me.ListProj.Location = New System.Drawing.Point(12, 28)
        Me.ListProj.Margin = New System.Windows.Forms.Padding(4)
        Me.ListProj.Name = "ListProj"
        Me.ListProj.Size = New System.Drawing.Size(304, 425)
        Me.ListProj.TabIndex = 0
        Me.ListProj.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu1_OK, Me.ToolStripMenuItem2, Me.Menu1_Active, Me.Menu1_Inactive, Me.Menu1_All, Me.ToolStripMenuItem1, Me.Menu1_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 126)
        '
        'Menu1_OK
        '
        Me.Menu1_OK.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Menu1_OK.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Menu1_OK.Name = "Menu1_OK"
        Me.Menu1_OK.Size = New System.Drawing.Size(152, 22)
        Me.Menu1_OK.Text = "Select Project"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'Menu1_Active
        '
        Me.Menu1_Active.Checked = True
        Me.Menu1_Active.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Menu1_Active.Name = "Menu1_Active"
        Me.Menu1_Active.Size = New System.Drawing.Size(152, 22)
        Me.Menu1_Active.Text = "Active"
        '
        'Menu1_Inactive
        '
        Me.Menu1_Inactive.Name = "Menu1_Inactive"
        Me.Menu1_Inactive.Size = New System.Drawing.Size(152, 22)
        Me.Menu1_Inactive.Text = "Inactive"
        '
        'Menu1_All
        '
        Me.Menu1_All.Name = "Menu1_All"
        Me.Menu1_All.Size = New System.Drawing.Size(152, 22)
        Me.Menu1_All.Text = "All"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'Menu1_Cancel
        '
        Me.Menu1_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu1_Cancel.Name = "Menu1_Cancel"
        Me.Menu1_Cancel.Size = New System.Drawing.Size(152, 22)
        Me.Menu1_Cancel.Text = "Cancel"
        '
        'ListProd
        '
        Me.ListProd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ListProd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProd.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListProd.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListProd.FormattingEnabled = True
        Me.ListProd.ItemHeight = 17
        Me.ListProd.Location = New System.Drawing.Point(324, 28)
        Me.ListProd.Margin = New System.Windows.Forms.Padding(4)
        Me.ListProd.Name = "ListProd"
        Me.ListProd.Size = New System.Drawing.Size(304, 425)
        Me.ListProd.TabIndex = 1
        Me.ListProd.TabStop = False
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu2_OK, Me.Menu2_Cancel})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(172, 48)
        '
        'Menu2_OK
        '
        Me.Menu2_OK.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Menu2_OK.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Menu2_OK.Name = "Menu2_OK"
        Me.Menu2_OK.Size = New System.Drawing.Size(171, 22)
        Me.Menu2_OK.Text = "Select subProject"
        '
        'Menu2_Cancel
        '
        Me.Menu2_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu2_Cancel.Name = "Menu2_Cancel"
        Me.Menu2_Cancel.Size = New System.Drawing.Size(171, 22)
        Me.Menu2_Cancel.Text = "Cancel"
        '
        'TextBoxProdNote
        '
        Me.TextBoxProdNote.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxProdNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxProdNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.TextBoxProdNote.ForeColor = System.Drawing.Color.Teal
        Me.TextBoxProdNote.Location = New System.Drawing.Point(337, 4)
        Me.TextBoxProdNote.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxProdNote.Name = "TextBoxProdNote"
        Me.TextBoxProdNote.Size = New System.Drawing.Size(291, 16)
        Me.TextBoxProdNote.TabIndex = 2
        Me.TextBoxProdNote.TabStop = False
        '
        'txtSearchProj
        '
        Me.txtSearchProj.BackColor = System.Drawing.SystemColors.Control
        Me.txtSearchProj.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearchProj.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.txtSearchProj.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSearchProj.Location = New System.Drawing.Point(12, 461)
        Me.txtSearchProj.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearchProj.Name = "txtSearchProj"
        Me.txtSearchProj.Size = New System.Drawing.Size(304, 17)
        Me.txtSearchProj.TabIndex = 0
        '
        'txtSearchProd
        '
        Me.txtSearchProd.BackColor = System.Drawing.SystemColors.Control
        Me.txtSearchProd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearchProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.txtSearchProd.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSearchProd.Location = New System.Drawing.Point(324, 461)
        Me.txtSearchProd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearchProd.Name = "txtSearchProd"
        Me.txtSearchProd.Size = New System.Drawing.Size(304, 17)
        Me.txtSearchProd.TabIndex = 1
        '
        'frmChooseProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(637, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtSearchProd)
        Me.Controls.Add(Me.txtSearchProj)
        Me.Controls.Add(Me.TextBoxProdNote)
        Me.Controls.Add(Me.ListProd)
        Me.Controls.Add(Me.ListProj)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChooseProject"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose a Project / subProject"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListProj As ListBox
    Friend WithEvents ListProd As ListBox
    Friend WithEvents TextBoxProdNote As TextBox
    Friend WithEvents txtSearchProj As TextBox
    Friend WithEvents txtSearchProd As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu1_Active As ToolStripMenuItem
    Friend WithEvents Menu1_Inactive As ToolStripMenuItem
    Friend WithEvents Menu1_All As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu1_Cancel As ToolStripMenuItem
    Friend WithEvents Menu1_OK As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_OK As ToolStripMenuItem
    Friend WithEvents Menu2_Cancel As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
End Class
