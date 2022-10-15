<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblFrontEnd = New System.Windows.Forms.Label()
        Me.lblBackEnd = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Copperplate Gothic Light", 40.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(143, 58)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "eLib"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Copperplate Gothic Light", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Label3.ForeColor = System.Drawing.Color.LightSlateGray
        Me.Label3.Location = New System.Drawing.Point(39, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(475, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "by Dr Majid Sharifi-Tehrany - Faculty of Science, SKU  (2022)"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'lblFrontEnd
        '
        Me.lblFrontEnd.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblFrontEnd.ForeColor = System.Drawing.Color.LightSlateGray
        Me.lblFrontEnd.Location = New System.Drawing.Point(334, 36)
        Me.lblFrontEnd.Name = "lblFrontEnd"
        Me.lblFrontEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrontEnd.Size = New System.Drawing.Size(188, 27)
        Me.lblFrontEnd.TabIndex = 4
        Me.lblFrontEnd.Text = "FrontEnd:"
        Me.lblFrontEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBackEnd
        '
        Me.lblBackEnd.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.lblBackEnd.ForeColor = System.Drawing.Color.LightSlateGray
        Me.lblBackEnd.Location = New System.Drawing.Point(334, 9)
        Me.lblBackEnd.Name = "lblBackEnd"
        Me.lblBackEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBackEnd.Size = New System.Drawing.Size(188, 27)
        Me.lblBackEnd.TabIndex = 5
        Me.lblBackEnd.Text = "BackEnd:"
        Me.lblBackEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(562, 115)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblBackEnd)
        Me.Controls.Add(Me.lblFrontEnd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Private WithEvents Label2 As Label
    Friend WithEvents lblFrontEnd As Label
    Friend WithEvents lblBackEnd As Label
End Class
