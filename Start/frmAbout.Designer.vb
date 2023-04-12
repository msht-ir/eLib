<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAbout
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
        Label2 = New Label()
        Timer1 = New Timer(components)
        lblBackEnd = New Label()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.ControlLight
        Label2.Font = New Font("Consolas", 32.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = SystemColors.ActiveCaption
        Label2.Location = New Point(226, 7)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.No
        Label2.Size = New Size(118, 51)
        Label2.TabIndex = 1
        Label2.Text = "eLib"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 5000
        ' 
        ' lblBackEnd
        ' 
        lblBackEnd.Font = New Font("Consolas", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        lblBackEnd.ForeColor = SystemColors.ControlDarkDark
        lblBackEnd.Location = New Point(12, 65)
        lblBackEnd.Name = "lblBackEnd"
        lblBackEnd.RightToLeft = RightToLeft.No
        lblBackEnd.Size = New Size(539, 27)
        lblBackEnd.TabIndex = 5
        lblBackEnd.Text = "BackEnd:"
        lblBackEnd.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Consolas", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ControlDarkDark
        Label1.Location = New Point(12, 98)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.No
        Label1.Size = New Size(539, 27)
        Label1.TabIndex = 6
        Label1.Text = "Developed by: Majid Sharifi-Tehrani"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' frmAbout
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(563, 139)
        ControlBox = False
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(lblBackEnd)
        ForeColor = Color.Navy
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAbout"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "eLib"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Timer1 As Timer
    Private WithEvents Label2 As Label
    Friend WithEvents lblBackEnd As Label
    Friend WithEvents Label1 As Label
End Class
