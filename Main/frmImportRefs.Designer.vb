<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportRefs
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
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.ListProduct = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu2_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu2_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu2_Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.radioPaper = New System.Windows.Forms.RadioButton()
        Me.radioBook = New System.Windows.Forms.RadioButton()
        Me.radioManual = New System.Windows.Forms.RadioButton()
        Me.radioLecture = New System.Windows.Forms.RadioButton()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu1_Select = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu1_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu1_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu1_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.SystemColors.Control
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtTitle.ForeColor = System.Drawing.Color.IndianRed
        Me.txtTitle.Location = New System.Drawing.Point(0, 0)
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(910, 69)
        Me.txtTitle.TabIndex = 0
        '
        'ListProduct
        '
        Me.ListProduct.BackColor = System.Drawing.SystemColors.Control
        Me.ListProduct.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProduct.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListProduct.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListProduct.FormattingEnabled = True
        Me.ListProduct.ItemHeight = 17
        Me.ListProduct.Location = New System.Drawing.Point(118, 83)
        Me.ListProduct.Name = "ListProduct"
        Me.ListProduct.Size = New System.Drawing.Size(347, 102)
        Me.ListProduct.TabIndex = 1
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu2_Add, Me.Menu2_Remove, Me.Menu2_Clear})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(118, 70)
        '
        'Menu2_Add
        '
        Me.Menu2_Add.Name = "Menu2_Add"
        Me.Menu2_Add.Size = New System.Drawing.Size(117, 22)
        Me.Menu2_Add.Text = "Add"
        '
        'Menu2_Remove
        '
        Me.Menu2_Remove.Name = "Menu2_Remove"
        Me.Menu2_Remove.Size = New System.Drawing.Size(117, 22)
        Me.Menu2_Remove.Text = "Remove"
        '
        'Menu2_Clear
        '
        Me.Menu2_Clear.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu2_Clear.Name = "Menu2_Clear"
        Me.Menu2_Clear.Size = New System.Drawing.Size(117, 22)
        Me.Menu2_Clear.Text = "Clear"
        '
        'radioPaper
        '
        Me.radioPaper.AutoSize = True
        Me.radioPaper.Checked = True
        Me.radioPaper.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.radioPaper.Location = New System.Drawing.Point(16, 16)
        Me.radioPaper.Name = "radioPaper"
        Me.radioPaper.Size = New System.Drawing.Size(62, 23)
        Me.radioPaper.TabIndex = 2
        Me.radioPaper.TabStop = True
        Me.radioPaper.Text = "Paper"
        Me.radioPaper.UseVisualStyleBackColor = True
        '
        'radioBook
        '
        Me.radioBook.AutoSize = True
        Me.radioBook.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.radioBook.Location = New System.Drawing.Point(16, 40)
        Me.radioBook.Name = "radioBook"
        Me.radioBook.Size = New System.Drawing.Size(58, 23)
        Me.radioBook.TabIndex = 3
        Me.radioBook.TabStop = True
        Me.radioBook.Text = "Book"
        Me.radioBook.UseVisualStyleBackColor = True
        '
        'radioManual
        '
        Me.radioManual.AutoSize = True
        Me.radioManual.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.radioManual.Location = New System.Drawing.Point(16, 64)
        Me.radioManual.Name = "radioManual"
        Me.radioManual.Size = New System.Drawing.Size(73, 23)
        Me.radioManual.TabIndex = 4
        Me.radioManual.TabStop = True
        Me.radioManual.Text = "Manual"
        Me.radioManual.UseVisualStyleBackColor = True
        '
        'radioLecture
        '
        Me.radioLecture.AutoSize = True
        Me.radioLecture.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.radioLecture.Location = New System.Drawing.Point(16, 88)
        Me.radioLecture.Name = "radioLecture"
        Me.radioLecture.Size = New System.Drawing.Size(72, 23)
        Me.radioLecture.TabIndex = 5
        Me.radioLecture.TabStop = True
        Me.radioLecture.Text = "Lecture"
        Me.radioLecture.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.SystemColors.Control
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNote.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtNote.Location = New System.Drawing.Point(485, 83)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(415, 18)
        Me.txtNote.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu1_Select, Me.Menu1_Paste, Me.Menu1_Move, Me.ToolStripMenuItem1, Me.Menu1_Exit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(120, 98)
        '
        'Menu1_Select
        '
        Me.Menu1_Select.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Menu1_Select.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Menu1_Select.Name = "Menu1_Select"
        Me.Menu1_Select.Size = New System.Drawing.Size(119, 22)
        Me.Menu1_Select.Text = "Select ..."
        '
        'Menu1_Paste
        '
        Me.Menu1_Paste.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Menu1_Paste.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Menu1_Paste.Name = "Menu1_Paste"
        Me.Menu1_Paste.Size = New System.Drawing.Size(119, 22)
        Me.Menu1_Paste.Text = "Paste"
        '
        'Menu1_Move
        '
        Me.Menu1_Move.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Menu1_Move.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Menu1_Move.Name = "Menu1_Move"
        Me.Menu1_Move.Size = New System.Drawing.Size(119, 22)
        Me.Menu1_Move.Text = "Move"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(116, 6)
        '
        'Menu1_Exit
        '
        Me.Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu1_Exit.Name = "Menu1_Exit"
        Me.Menu1_Exit.Size = New System.Drawing.Size(119, 22)
        Me.Menu1_Exit.Text = "Exit"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.radioPaper)
        Me.Panel1.Controls.Add(Me.radioBook)
        Me.Panel1.Controls.Add(Me.radioManual)
        Me.Panel1.Controls.Add(Me.radioLecture)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 136)
        Me.Panel1.TabIndex = 7
        '
        'frmImportRefs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(910, 205)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.ListProduct)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportRefs"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import"
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTitle As TextBox
    Friend WithEvents ListProduct As ListBox
    Friend WithEvents radioPaper As RadioButton
    Friend WithEvents radioBook As RadioButton
    Friend WithEvents radioManual As RadioButton
    Friend WithEvents radioLecture As RadioButton
    Friend WithEvents txtNote As TextBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_Add As ToolStripMenuItem
    Friend WithEvents Menu2_Remove As ToolStripMenuItem
    Friend WithEvents Menu2_Clear As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu1_Select As ToolStripMenuItem
    Friend WithEvents Menu1_Paste As ToolStripMenuItem
    Friend WithEvents Menu1_Move As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu1_Exit As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
