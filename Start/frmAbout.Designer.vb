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
        Me.components = New System.ComponentModel.Container()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblFrontEnd = New System.Windows.Forms.Label()
        Me.lblBackEnd = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 48.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Label2.ForeColor = System.Drawing.Color.Goldenrod
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(147, 86)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "eLib"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'lblFrontEnd
        '
        Me.lblFrontEnd.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblFrontEnd.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFrontEnd.Location = New System.Drawing.Point(373, 61)
        Me.lblFrontEnd.Name = "lblFrontEnd"
        Me.lblFrontEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrontEnd.Size = New System.Drawing.Size(178, 27)
        Me.lblFrontEnd.TabIndex = 4
        Me.lblFrontEnd.Text = "FrontEnd:"
        Me.lblFrontEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBackEnd
        '
        Me.lblBackEnd.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblBackEnd.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblBackEnd.Location = New System.Drawing.Point(373, 34)
        Me.lblBackEnd.Name = "lblBackEnd"
        Me.lblBackEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBackEnd.Size = New System.Drawing.Size(178, 27)
        Me.lblBackEnd.TabIndex = 5
        Me.lblBackEnd.Text = "BackEnd:"
        Me.lblBackEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(563, 68)
        Me.Panel1.TabIndex = 6
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(563, 185)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblBackEnd)
        Me.Controls.Add(Me.lblFrontEnd)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "دانشگاه شهرکرد، دانشکده علوم پايه"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Private WithEvents Label2 As Label
    Friend WithEvents lblFrontEnd As Label
    Friend WithEvents lblBackEnd As Label
    Friend WithEvents Panel1 As Panel
End Class
