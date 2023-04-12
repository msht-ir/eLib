<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecurityActivation
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
        Panel1 = New Panel()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        Menu2_Exit = New ToolStripMenuItem()
        Label3 = New Label()
        txtOwner = New TextBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_Request = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        Menu_Exit = New ToolStripMenuItem()
        Label2 = New Label()
        Timer1 = New Timer(components)
        Panel1.SuspendLayout()
        ContextMenuStrip2.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AllowDrop = True
        Panel1.BackColor = SystemColors.Control
        Panel1.ContextMenuStrip = ContextMenuStrip2
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 100)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(679, 101)
        Panel1.TabIndex = 8
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {Menu2_Exit})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(94, 26)
        ' 
        ' Menu2_Exit
        ' 
        Menu2_Exit.ForeColor = Color.IndianRed
        Menu2_Exit.Name = "Menu2_Exit"
        Menu2_Exit.Size = New Size(93, 22)
        Menu2_Exit.Text = "Exit"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.IndianRed
        Label3.Location = New Point(209, 51)
        Label3.Name = "Label3"
        Label3.Size = New Size(247, 16)
        Label3.TabIndex = 10
        Label3.Text = "Drop 'eLibKey' File HERE"
        ' 
        ' txtOwner
        ' 
        txtOwner.BackColor = SystemColors.ButtonFace
        txtOwner.BorderStyle = BorderStyle.None
        txtOwner.ContextMenuStrip = ContextMenuStrip1
        txtOwner.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        txtOwner.ForeColor = Color.IndianRed
        txtOwner.Location = New Point(124, 56)
        txtOwner.Name = "txtOwner"
        txtOwner.Size = New Size(425, 18)
        txtOwner.TabIndex = 0
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_Request, ToolStripMenuItem1, Menu_Exit})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(117, 54)
        ' 
        ' Menu_Request
        ' 
        Menu_Request.Name = "Menu_Request"
        Menu_Request.Size = New Size(116, 22)
        Menu_Request.Text = "Request"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(113, 6)
        ' 
        ' Menu_Exit
        ' 
        Menu_Exit.ForeColor = Color.IndianRed
        Menu_Exit.Name = "Menu_Exit"
        Menu_Exit.Size = New Size(116, 22)
        Menu_Exit.Text = "Exit"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = SystemColors.ActiveCaption
        Label2.Location = New Point(221, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(215, 25)
        Label2.TabIndex = 9
        Label2.Text = "Request Activation Key"
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 3000
        ' 
        ' frmSecurityActivation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(679, 201)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(txtOwner)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSecurityActivation"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Registeration"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ContextMenuStrip2.ResumeLayout(False)
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtOwner As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Request As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_Exit As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
End Class
