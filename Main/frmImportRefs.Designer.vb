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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu1_Select = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu1_Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu1_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu1_Exit = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.CheckAskDest = New System.Windows.Forms.CheckBox()
        Me.lblExt = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblCreated = New System.Windows.Forms.Label()
        Me.lblModified = New System.Windows.Forms.Label()
        Me.RadiobtnOpen = New System.Windows.Forms.RadioButton()
        Me.RadiobtnMove = New System.Windows.Forms.RadioButton()
        Me.RadiobtnInspect = New System.Windows.Forms.RadioButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTitle
        '
        Me.txtTitle.AllowDrop = True
        Me.txtTitle.BackColor = System.Drawing.SystemColors.Control
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTitle.ContextMenuStrip = Me.ContextMenuStrip1
        Me.txtTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtTitle.ForeColor = System.Drawing.Color.IndianRed
        Me.txtTitle.Location = New System.Drawing.Point(0, 0)
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(821, 69)
        Me.txtTitle.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu1_Select, Me.Menu1_Paste, Me.Menu1_Move, Me.ToolStripMenuItem1, Me.Menu1_Exit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 98)
        '
        'Menu1_Select
        '
        Me.Menu1_Select.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu1_Select.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu1_Select.Name = "Menu1_Select"
        Me.Menu1_Select.Size = New System.Drawing.Size(130, 22)
        Me.Menu1_Select.Text = "1- Select ..."
        '
        'Menu1_Paste
        '
        Me.Menu1_Paste.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu1_Paste.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu1_Paste.Name = "Menu1_Paste"
        Me.Menu1_Paste.Size = New System.Drawing.Size(130, 22)
        Me.Menu1_Paste.Text = "2- Title"
        '
        'Menu1_Move
        '
        Me.Menu1_Move.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.Menu1_Move.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu1_Move.Name = "Menu1_Move"
        Me.Menu1_Move.Size = New System.Drawing.Size(130, 22)
        Me.Menu1_Move.Text = "3- Move"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(127, 6)
        '
        'Menu1_Exit
        '
        Me.Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu1_Exit.Name = "Menu1_Exit"
        Me.Menu1_Exit.Size = New System.Drawing.Size(130, 22)
        Me.Menu1_Exit.Text = "Exit"
        '
        'ListProduct
        '
        Me.ListProduct.BackColor = System.Drawing.SystemColors.Control
        Me.ListProduct.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProduct.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListProduct.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point)
        Me.ListProduct.ForeColor = System.Drawing.Color.DarkCyan
        Me.ListProduct.FormattingEnabled = True
        Me.ListProduct.ItemHeight = 20
        Me.ListProduct.Location = New System.Drawing.Point(258, 121)
        Me.ListProduct.Name = "ListProduct"
        Me.ListProduct.Size = New System.Drawing.Size(347, 100)
        Me.ListProduct.TabIndex = 1
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu2_Add, Me.Menu2_Remove, Me.Menu2_Clear})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(148, 70)
        '
        'Menu2_Add
        '
        Me.Menu2_Add.Name = "Menu2_Add"
        Me.Menu2_Add.Size = New System.Drawing.Size(147, 22)
        Me.Menu2_Add.Text = "+ Add Project"
        '
        'Menu2_Remove
        '
        Me.Menu2_Remove.Name = "Menu2_Remove"
        Me.Menu2_Remove.Size = New System.Drawing.Size(147, 22)
        Me.Menu2_Remove.Text = "- Remove"
        '
        'Menu2_Clear
        '
        Me.Menu2_Clear.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu2_Clear.Name = "Menu2_Clear"
        Me.Menu2_Clear.Size = New System.Drawing.Size(147, 22)
        Me.Menu2_Clear.Text = "Clear all"
        '
        'radioPaper
        '
        Me.radioPaper.AutoSize = True
        Me.radioPaper.Checked = True
        Me.radioPaper.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.radioPaper.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.radioPaper.Location = New System.Drawing.Point(9, 4)
        Me.radioPaper.Name = "radioPaper"
        Me.radioPaper.Size = New System.Drawing.Size(57, 19)
        Me.radioPaper.TabIndex = 2
        Me.radioPaper.TabStop = True
        Me.radioPaper.Text = "Paper"
        Me.radioPaper.UseVisualStyleBackColor = True
        '
        'radioBook
        '
        Me.radioBook.AutoSize = True
        Me.radioBook.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.radioBook.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.radioBook.Location = New System.Drawing.Point(96, 4)
        Me.radioBook.Name = "radioBook"
        Me.radioBook.Size = New System.Drawing.Size(54, 19)
        Me.radioBook.TabIndex = 3
        Me.radioBook.TabStop = True
        Me.radioBook.Text = "Book"
        Me.radioBook.UseVisualStyleBackColor = True
        '
        'radioManual
        '
        Me.radioManual.AutoSize = True
        Me.radioManual.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.radioManual.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.radioManual.Location = New System.Drawing.Point(181, 4)
        Me.radioManual.Name = "radioManual"
        Me.radioManual.Size = New System.Drawing.Size(65, 19)
        Me.radioManual.TabIndex = 4
        Me.radioManual.TabStop = True
        Me.radioManual.Text = "Manual"
        Me.radioManual.UseVisualStyleBackColor = True
        '
        'radioLecture
        '
        Me.radioLecture.AutoSize = True
        Me.radioLecture.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.radioLecture.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.radioLecture.Location = New System.Drawing.Point(273, 4)
        Me.radioLecture.Name = "radioLecture"
        Me.radioLecture.Size = New System.Drawing.Size(68, 19)
        Me.radioLecture.TabIndex = 5
        Me.radioLecture.TabStop = True
        Me.radioLecture.Text = "Lecture"
        Me.radioLecture.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.LightGray
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNote.ContextMenuStrip = Me.ContextMenuStrip1
        Me.txtNote.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtNote.Location = New System.Drawing.Point(258, 227)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(347, 20)
        Me.txtNote.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.radioPaper)
        Me.Panel1.Controls.Add(Me.radioBook)
        Me.Panel1.Controls.Add(Me.radioManual)
        Me.Panel1.Controls.Add(Me.radioLecture)
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Location = New System.Drawing.Point(258, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(347, 27)
        Me.Panel1.TabIndex = 7
        '
        'lblPath
        '
        Me.lblPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblPath.ForeColor = System.Drawing.Color.IndianRed
        Me.lblPath.Location = New System.Drawing.Point(3, 74)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(857, 14)
        Me.lblPath.TabIndex = 8
        Me.lblPath.Text = "Drop a Ref  ^"
        Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckAskDest
        '
        Me.CheckAskDest.AutoSize = True
        Me.CheckAskDest.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckAskDest.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.CheckAskDest.Location = New System.Drawing.Point(536, 261)
        Me.CheckAskDest.Name = "CheckAskDest"
        Me.CheckAskDest.Size = New System.Drawing.Size(45, 15)
        Me.CheckAskDest.TabIndex = 16
        Me.CheckAskDest.Text = "Ask"
        Me.CheckAskDest.UseVisualStyleBackColor = True
        '
        'lblExt
        '
        Me.lblExt.AutoSize = True
        Me.lblExt.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblExt.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblExt.Location = New System.Drawing.Point(23, 125)
        Me.lblExt.Name = "lblExt"
        Me.lblExt.Size = New System.Drawing.Size(10, 13)
        Me.lblExt.TabIndex = 17
        Me.lblExt.Text = "."
        Me.lblExt.Visible = False
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblSize.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblSize.Location = New System.Drawing.Point(23, 144)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(10, 13)
        Me.lblSize.TabIndex = 18
        Me.lblSize.Text = "."
        Me.lblSize.Visible = False
        '
        'lblCreated
        '
        Me.lblCreated.AutoSize = True
        Me.lblCreated.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblCreated.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblCreated.Location = New System.Drawing.Point(23, 163)
        Me.lblCreated.Name = "lblCreated"
        Me.lblCreated.Size = New System.Drawing.Size(10, 13)
        Me.lblCreated.TabIndex = 19
        Me.lblCreated.Text = "."
        Me.lblCreated.Visible = False
        '
        'lblModified
        '
        Me.lblModified.AutoSize = True
        Me.lblModified.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblModified.ForeColor = System.Drawing.Color.SlateBlue
        Me.lblModified.Location = New System.Drawing.Point(23, 181)
        Me.lblModified.Name = "lblModified"
        Me.lblModified.Size = New System.Drawing.Size(10, 13)
        Me.lblModified.TabIndex = 20
        Me.lblModified.Text = "."
        Me.lblModified.Visible = False
        '
        'RadiobtnOpen
        '
        Me.RadiobtnOpen.AutoSize = True
        Me.RadiobtnOpen.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadiobtnOpen.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.RadiobtnOpen.Location = New System.Drawing.Point(375, 261)
        Me.RadiobtnOpen.Name = "RadiobtnOpen"
        Me.RadiobtnOpen.Size = New System.Drawing.Size(51, 15)
        Me.RadiobtnOpen.TabIndex = 21
        Me.RadiobtnOpen.Text = "Open"
        Me.RadiobtnOpen.UseVisualStyleBackColor = True
        '
        'RadiobtnMove
        '
        Me.RadiobtnMove.AutoSize = True
        Me.RadiobtnMove.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadiobtnMove.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.RadiobtnMove.Location = New System.Drawing.Point(453, 261)
        Me.RadiobtnMove.Name = "RadiobtnMove"
        Me.RadiobtnMove.Size = New System.Drawing.Size(51, 15)
        Me.RadiobtnMove.TabIndex = 22
        Me.RadiobtnMove.Text = "Move"
        Me.RadiobtnMove.UseVisualStyleBackColor = True
        '
        'RadiobtnInspect
        '
        Me.RadiobtnInspect.AutoSize = True
        Me.RadiobtnInspect.Checked = True
        Me.RadiobtnInspect.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadiobtnInspect.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.RadiobtnInspect.Location = New System.Drawing.Point(278, 261)
        Me.RadiobtnInspect.Name = "RadiobtnInspect"
        Me.RadiobtnInspect.Size = New System.Drawing.Size(72, 15)
        Me.RadiobtnInspect.TabIndex = 23
        Me.RadiobtnInspect.TabStop = True
        Me.RadiobtnInspect.Text = "Inspect"
        Me.RadiobtnInspect.UseVisualStyleBackColor = True
        '
        'frmImportRefs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(821, 291)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.RadiobtnInspect)
        Me.Controls.Add(Me.RadiobtnMove)
        Me.Controls.Add(Me.RadiobtnOpen)
        Me.Controls.Add(Me.lblModified)
        Me.Controls.Add(Me.lblCreated)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblExt)
        Me.Controls.Add(Me.CheckAskDest)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ListProduct)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.txtTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportRefs"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
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
    Friend WithEvents lblPath As Label
    Friend WithEvents CheckAskDest As CheckBox
    Friend WithEvents lblExt As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblCreated As Label
    Friend WithEvents lblModified As Label
    Friend WithEvents RadiobtnOpen As RadioButton
    Friend WithEvents RadiobtnMove As RadioButton
    Friend WithEvents RadiobtnInspect As RadioButton
End Class
