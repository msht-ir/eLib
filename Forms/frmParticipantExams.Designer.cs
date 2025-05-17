namespace eLib.Forms
    {
    partial class frmParticipantExams
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle ();
            panel1 = new System.Windows.Forms.Panel ();
            lblExit = new System.Windows.Forms.Label ();
            GridParticipants = new System.Windows.Forms.DataGridView ();
            MenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu1_Passwords = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            cboEntries = new System.Windows.Forms.ComboBox ();
            GridParticipantExams = new System.Windows.Forms.DataGridView ();
            MenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_PrintoutExamSheet = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_PrintoutExamRecord = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            btnEditEntry = new System.Windows.Forms.Button ();
            btn_EditParticipant = new System.Windows.Forms.Button ();
            btn_AddNewParticipant = new System.Windows.Forms.Button ();
            btnAddNewEntry = new System.Windows.Forms.Button ();
            btn_DeleteParticipant = new System.Windows.Forms.Button ();
            btnDeleteEntry = new System.Windows.Forms.Button ();
            btnAddExamToParticipant = new System.Windows.Forms.Button ();
            btnDeleteExam = new System.Windows.Forms.Button ();
            chkDoubleClickToDelete = new System.Windows.Forms.CheckBox ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridParticipants).BeginInit ();
            MenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridParticipantExams).BeginInit ();
            MenuStrip2.SuspendLayout ();
            SuspendLayout ();
            // 
            // panel1
            // 
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 517);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1125, 20);
            panel1.TabIndex = 28;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (0, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (1125, 20);
            lblExit.TabIndex = 26;
            lblExit.Text = "Back";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // GridParticipants
            // 
            GridParticipants.AllowUserToAddRows = false;
            GridParticipants.AllowUserToDeleteRows = false;
            GridParticipants.AllowUserToOrderColumns = true;
            GridParticipants.AllowUserToResizeColumns = false;
            GridParticipants.AllowUserToResizeRows = false;
            GridParticipants.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            GridParticipants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridParticipants.ColumnHeadersVisible = false;
            GridParticipants.ContextMenuStrip = MenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridParticipants.DefaultCellStyle = dataGridViewCellStyle1;
            GridParticipants.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridParticipants.GridColor = System.Drawing.Color.WhiteSmoke;
            GridParticipants.Location = new System.Drawing.Point (52, 44);
            GridParticipants.Name = "GridParticipants";
            GridParticipants.RowHeadersVisible = false;
            GridParticipants.Size = new System.Drawing.Size (283, 451);
            GridParticipants.TabIndex = 29;
            GridParticipants.CellClick += GridParticipants_CellClick;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu1_Passwords, toolStripMenuItem2, Menu1_Exit });
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new System.Drawing.Size (139, 54);
            // 
            // Menu1_Passwords
            // 
            Menu1_Passwords.Name = "Menu1_Passwords";
            Menu1_Passwords.Size = new System.Drawing.Size (138, 22);
            Menu1_Passwords.Text = "Passwords...";
            Menu1_Passwords.Click += Menu1_Passwords_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size (135, 6);
            // 
            // Menu1_Exit
            // 
            Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu1_Exit.Name = "Menu1_Exit";
            Menu1_Exit.Size = new System.Drawing.Size (138, 22);
            Menu1_Exit.Text = "Exit";
            Menu1_Exit.Click += Menu1_Exit_Click;
            // 
            // cboEntries
            // 
            cboEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEntries.FormattingEnabled = true;
            cboEntries.Location = new System.Drawing.Point (52, 12);
            cboEntries.Name = "cboEntries";
            cboEntries.Size = new System.Drawing.Size (193, 23);
            cboEntries.TabIndex = 28;
            cboEntries.SelectedIndexChanged += cboEntries_SelectedIndexChanged;
            // 
            // GridParticipantExams
            // 
            GridParticipantExams.AllowUserToAddRows = false;
            GridParticipantExams.AllowUserToDeleteRows = false;
            GridParticipantExams.AllowUserToOrderColumns = true;
            GridParticipantExams.AllowUserToResizeColumns = false;
            GridParticipantExams.AllowUserToResizeRows = false;
            GridParticipantExams.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            GridParticipantExams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridParticipantExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridParticipantExams.ContextMenuStrip = MenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridParticipantExams.DefaultCellStyle = dataGridViewCellStyle2;
            GridParticipantExams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridParticipantExams.GridColor = System.Drawing.Color.WhiteSmoke;
            GridParticipantExams.Location = new System.Drawing.Point (341, 44);
            GridParticipantExams.Name = "GridParticipantExams";
            GridParticipantExams.RowHeadersVisible = false;
            GridParticipantExams.Size = new System.Drawing.Size (780, 451);
            GridParticipantExams.TabIndex = 30;
            GridParticipantExams.CellContentDoubleClick += GridParticipantExams_CellContentDoubleClick;
            // 
            // MenuStrip2
            // 
            MenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_PrintoutExamSheet, Menu2_PrintoutExamRecord, toolStripMenuItem1, Menu2_Exit });
            MenuStrip2.Name = "contextMenuStrip1";
            MenuStrip2.Size = new System.Drawing.Size (181, 76);
            // 
            // Menu2_PrintoutExamSheet
            // 
            Menu2_PrintoutExamSheet.Name = "Menu2_PrintoutExamSheet";
            Menu2_PrintoutExamSheet.Size = new System.Drawing.Size (180, 22);
            Menu2_PrintoutExamSheet.Text = "Exam Sheet (empty)";
            Menu2_PrintoutExamSheet.Click += Menu2_PrintoutExamSheet_Click;
            // 
            // Menu2_PrintoutExamRecord
            // 
            Menu2_PrintoutExamRecord.Name = "Menu2_PrintoutExamRecord";
            Menu2_PrintoutExamRecord.Size = new System.Drawing.Size (180, 22);
            Menu2_PrintoutExamRecord.Text = "Exam Records";
            Menu2_PrintoutExamRecord.Click += Menu2_PrintoutExamRecord_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size (177, 6);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new System.Drawing.Size (180, 22);
            Menu2_Exit.Text = "Exit";
            Menu2_Exit.Click += Menu2_Exit_Click;
            // 
            // btnEditEntry
            // 
            btnEditEntry.Font = new System.Drawing.Font ("Courier New", 11F);
            btnEditEntry.Location = new System.Drawing.Point (311, 12);
            btnEditEntry.Name = "btnEditEntry";
            btnEditEntry.Size = new System.Drawing.Size (24, 24);
            btnEditEntry.TabIndex = 35;
            btnEditEntry.Text = "I";
            btnEditEntry.UseVisualStyleBackColor = true;
            btnEditEntry.Click += btnEditEntry_Click;
            // 
            // btn_EditParticipant
            // 
            btn_EditParticipant.Font = new System.Drawing.Font ("Courier New", 11F);
            btn_EditParticipant.Location = new System.Drawing.Point (5, 142);
            btn_EditParticipant.Name = "btn_EditParticipant";
            btn_EditParticipant.Size = new System.Drawing.Size (41, 24);
            btn_EditParticipant.TabIndex = 34;
            btn_EditParticipant.Text = "I";
            btn_EditParticipant.UseVisualStyleBackColor = true;
            btn_EditParticipant.Click += btn_EditParticipant_Click;
            // 
            // btn_AddNewParticipant
            // 
            btn_AddNewParticipant.Font = new System.Drawing.Font ("Courier New", 11F);
            btn_AddNewParticipant.Location = new System.Drawing.Point (5, 82);
            btn_AddNewParticipant.Name = "btn_AddNewParticipant";
            btn_AddNewParticipant.Size = new System.Drawing.Size (41, 24);
            btn_AddNewParticipant.TabIndex = 33;
            btn_AddNewParticipant.Text = "+";
            btn_AddNewParticipant.UseVisualStyleBackColor = true;
            btn_AddNewParticipant.Click += btn_AddNewParticipant_Click;
            // 
            // btnAddNewEntry
            // 
            btnAddNewEntry.Font = new System.Drawing.Font ("Courier New", 11F);
            btnAddNewEntry.Location = new System.Drawing.Point (251, 12);
            btnAddNewEntry.Name = "btnAddNewEntry";
            btnAddNewEntry.Size = new System.Drawing.Size (24, 24);
            btnAddNewEntry.TabIndex = 32;
            btnAddNewEntry.Text = "+";
            btnAddNewEntry.UseVisualStyleBackColor = true;
            btnAddNewEntry.Click += btnAddNewEntry_Click;
            // 
            // btn_DeleteParticipant
            // 
            btn_DeleteParticipant.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btn_DeleteParticipant.Location = new System.Drawing.Point (5, 112);
            btn_DeleteParticipant.Name = "btn_DeleteParticipant";
            btn_DeleteParticipant.Size = new System.Drawing.Size (41, 24);
            btn_DeleteParticipant.TabIndex = 37;
            btn_DeleteParticipant.Text = "-";
            btn_DeleteParticipant.UseVisualStyleBackColor = true;
            btn_DeleteParticipant.Click += btn_DeleteParticipant_Click;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnDeleteEntry.Location = new System.Drawing.Point (281, 12);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new System.Drawing.Size (24, 24);
            btnDeleteEntry.TabIndex = 36;
            btnDeleteEntry.Text = "-";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnDeleteEntry_Click;
            // 
            // btnAddExamToParticipant
            // 
            btnAddExamToParticipant.Font = new System.Drawing.Font ("Courier New", 11F);
            btnAddExamToParticipant.Location = new System.Drawing.Point (976, 12);
            btnAddExamToParticipant.Name = "btnAddExamToParticipant";
            btnAddExamToParticipant.Size = new System.Drawing.Size (108, 24);
            btnAddExamToParticipant.TabIndex = 38;
            btnAddExamToParticipant.Text = "+ Exam";
            btnAddExamToParticipant.UseVisualStyleBackColor = true;
            btnAddExamToParticipant.Click += btnAddExamToParticipant_Click;
            // 
            // btnDeleteExam
            // 
            btnDeleteExam.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnDeleteExam.Location = new System.Drawing.Point (1090, 12);
            btnDeleteExam.Name = "btnDeleteExam";
            btnDeleteExam.Size = new System.Drawing.Size (28, 24);
            btnDeleteExam.TabIndex = 39;
            btnDeleteExam.Text = "-";
            btnDeleteExam.UseVisualStyleBackColor = true;
            btnDeleteExam.Click += btnDeleteExam_Click;
            // 
            // chkDoubleClickToDelete
            // 
            chkDoubleClickToDelete.AutoSize = true;
            chkDoubleClickToDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            chkDoubleClickToDelete.Location = new System.Drawing.Point (1008, 503);
            chkDoubleClickToDelete.Name = "chkDoubleClickToDelete";
            chkDoubleClickToDelete.Size = new System.Drawing.Size (113, 19);
            chkDoubleClickToDelete.TabIndex = 40;
            chkDoubleClickToDelete.Text = "DoubleClick: Del";
            chkDoubleClickToDelete.UseVisualStyleBackColor = true;
            // 
            // frmParticipantExams
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (1125, 537);
            ControlBox = false;
            Controls.Add (chkDoubleClickToDelete);
            Controls.Add (btnDeleteExam);
            Controls.Add (btnAddExamToParticipant);
            Controls.Add (btn_DeleteParticipant);
            Controls.Add (btnDeleteEntry);
            Controls.Add (btnEditEntry);
            Controls.Add (btn_EditParticipant);
            Controls.Add (btn_AddNewParticipant);
            Controls.Add (btnAddNewEntry);
            Controls.Add (GridParticipantExams);
            Controls.Add (GridParticipants);
            Controls.Add (cboEntries);
            Controls.Add (panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmParticipantExams";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Participant Exams";
            Load += frmParticipantExams_Load;
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridParticipants).EndInit ();
            MenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridParticipantExams).EndInit ();
            MenuStrip2.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.DataGridView GridParticipants;
        private System.Windows.Forms.ComboBox cboEntries;
        private System.Windows.Forms.DataGridView GridParticipantExams;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.Button btn_EditParticipant;
        private System.Windows.Forms.Button btn_AddNewParticipant;
        private System.Windows.Forms.Button btnAddNewEntry;
        private System.Windows.Forms.ContextMenuStrip MenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutExamSheet;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutExamRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Menu2_Exit;
        private System.Windows.Forms.Button btn_DeleteParticipant;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnAddExamToParticipant;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.CheckBox chkDoubleClickToDelete;
        private System.Windows.Forms.ContextMenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Passwords;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Exit;
        }
    }