<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCnnReset
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
        components = New ComponentModel.Container()
        ListCnn = New CheckedListBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_Reset = New ToolStripMenuItem()
        Menu_Cancel = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListCnn
        ' 
        ListCnn.BackColor = SystemColors.MenuBar
        ListCnn.BorderStyle = BorderStyle.None
        ListCnn.ContextMenuStrip = ContextMenuStrip1
        ListCnn.Dock = DockStyle.Top
        ListCnn.Font = New Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point)
        ListCnn.ForeColor = Color.Teal
        ListCnn.FormattingEnabled = True
        ListCnn.Location = New Point(0, 0)
        ListCnn.Name = "ListCnn"
        ListCnn.Size = New Size(409, 154)
        ListCnn.TabIndex = 3
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_Reset, Menu_Cancel})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(111, 48)
        ' 
        ' Menu_Reset
        ' 
        Menu_Reset.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Menu_Reset.Name = "Menu_Reset"
        Menu_Reset.Size = New Size(110, 22)
        Menu_Reset.Text = "OK"
        ' 
        ' Menu_Cancel
        ' 
        Menu_Cancel.ForeColor = Color.IndianRed
        Menu_Cancel.Name = "Menu_Cancel"
        Menu_Cancel.Size = New Size(110, 22)
        Menu_Cancel.Text = "Cancel"
        ' 
        ' frmCnnReset
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(409, 189)
        ControlBox = False
        Controls.Add(ListCnn)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmCnnReset"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmCnnReset"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListCnn As CheckedListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Reset As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
End Class
