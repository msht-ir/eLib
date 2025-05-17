using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmSelectParticipants : Form
        {
        public frmSelectParticipants ()
            {
            InitializeComponent ();
            }
        private void frmSelectParticipants_Load (object sender, EventArgs e)
            {
            this.Width = 960;
            this.Height = 570;
            lblExamName.Text = Exam.Title;
            RefreshCboEntries ();
            RefreshGrid2 (Exam.Id);
            lblTrainingExam.Visible = (Exam.Training) ? true : false;
            }
        private void cboEntries_SelectedIndexChanged (object sender, EventArgs e)
            {
            try
                {
                if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                    {
                    return;
                    }
                else
                    {
                    int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                    RefreshGrid1 (entryId);
                    }
                }
            catch { }
            }
        private void lblTrainingExam_DoubleClick (object sender, EventArgs e)
            {
            //Convert a training exam to a real exam

            }
        //combo
        private void btnAddNewEntry_Click (object sender, EventArgs e)
            {
            string strEntryName = Interaction.InputBox ("Entry / Class / Group - Name:", "eLib", "new Entry" + (cboEntries.Items.Count + 1).ToString ());
            if (!string.IsNullOrEmpty (strEntryName))
                {
                int newEntryId = Testbank.AddNewEntry (User.Id, strEntryName);
                RefreshCboEntries ();
                cboEntries.Focus ();
                cboEntries.SelectedValue = newEntryId;
                }
            }
        private void btnEditEntry_Click (object sender, EventArgs e)
            {
            try
                {
                if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                    {
                    return;
                    }
                else
                    {
                    int intEntryId = Convert.ToInt32 (cboEntries.SelectedValue);
                    string strEntryName = Interaction.InputBox ("New Name:", "eLib", cboEntries.Text);
                    if (!string.IsNullOrEmpty (strEntryName))
                        {
                        if (Testbank.UpdateEntry (intEntryId, strEntryName))
                            {
                            RefreshCboEntries ();
                            RefreshGrid1 (intEntryId);
                            cboEntries.Focus ();
                            cboEntries.SelectedValue = intEntryId;
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void lblExamName_Click (object sender, EventArgs e)
            {
            RefreshGrid2 (Exam.Id);
            }
        //grids        
        private void btn_AddNewParticipant_Click (object sender, EventArgs e)
            {
            AddNewParticipant ();
            Grid1.Focus ();
            }
        private void btn_EditParticipant_Click (object sender, EventArgs e)
            {
            EditParticipant ();
            }
        private void btnAddParticipantToExam_Click (object sender, EventArgs e)
            {
            int r = (int) Grid1.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                Participant.Id = Convert.ToInt32 (Grid1.Rows [r].Cells [0].Value);
                Testbank.AddOneParticipant2Exam (Participant.Id, Exam.Id);
                RefreshGrid2 (Exam.Id);
                }
            }
        private void btnDeleteEntry_Click (object sender, EventArgs e)
            {
            if ((cboEntries.Items.Count > 0) && (cboEntries.SelectedIndex >= 0))
                {
                DialogResult myansw = MessageBox.Show ("Delete Entry?\n\nAll participants in this entry and their ExamSheets will be deleted", "eLib.Exams", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.OK)
                    {
                    Participant.EntryId = (int) cboEntries.SelectedValue;
                    Testbank.DeleteAnEntry (Participant.EntryId);
                    RefreshCboEntries ();
                    RefreshGrid2 (Exam.Id);
                    }
                }
            }
        private void btn_DeleteParticipant_Click (object sender, EventArgs e)
            {
            int r = Grid1.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                DialogResult myansw = MessageBox.Show ("Delete Participant?\n\nNotice:\nExamSheets of this participant will be deleted too", "eLib.Exams", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.OK)
                    {
                    Participant.Id = Convert.ToInt32 (Grid1.Rows [r].Cells [0].Value);
                    Testbank.DeleteOneParticipantFromEntry (Participant.Id);
                    RefreshGrid1 (Convert.ToInt32 (cboEntries.SelectedValue));
                    RefreshGrid2 (Exam.Id);
                    }
                }
            }
        private void Grid1_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            //add to grid2
            if (chkEnableDoubleClick.Checked)
                {
                btnAddParticipantToExam_Click (null, null);
                }
            }
        private void Grid2_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            //remove from grid2
            //0ID, 1Participant_ID, 2Exam_ID, 3ParticipantName, 4ParticipantPass, 5Started, 6DateTime, 7Finished
            if (!chkDoubleClickToDelete.Checked)
                {
                return;
                }
            int r = (int) Grid2.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                //confirm!
                DialogResult myansw = MessageBox.Show ("Are you sure?\nThe participants and it's ExamSheet will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.No)
                    {
                    return;
                    }
                else
                    {
                    int examParticipantId = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                    Participant.Id = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                    Testbank.RemoveOneParticipantFromExam (Exam.Id, Participant.Id);
                    RefreshGrid2 (Exam.Id);
                    }
                }
            }
        //Menu1
        private void Menu1_AddNewParticipant_Click (object sender, EventArgs e)
            {
            AddNewParticipant ();
            }
        private void Menu1_EditParticipant_Click (object sender, EventArgs e)
            {
            EditParticipant ();
            Grid1.Focus ();
            }
        private void Menu1_SelectAll_Click (object sender, EventArgs e)
            {
            if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                AddAllParticipants2Exam (entryId, Exam.Id);
                RefreshGrid2 (Exam.Id);
                }
            }
        private void Menu1_ParticipantExams_Click (object sender, EventArgs e)
            {
            try
                {
                int r = Grid1.SelectedCells [0].RowIndex;
                if (r >= 0)
                    {
                    Participant.Id = Convert.ToInt32 (Grid1.Rows [r].Cells [0].Value.ToString ());
                    Participant.Index = Convert.ToInt32 (Grid1.CurrentCell.RowIndex.ToString ());
                    Participant.EntryId = (int) cboEntries.SelectedValue;
                    this.Dispose ();
                    var frmParticExams = new frmParticipantExams ();
                    frmParticExams.ShowDialog ();
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        //Menu2
        private void Menu2_RemoveAllParticipants_Click (object sender, EventArgs e)
            {
            //confirm!
            DialogResult myansw = MessageBox.Show ("Are you sure?\nAll participants and thrir ExamSheets will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                {
                return;
                }
            else
                {
                for (int i = 0; i < Grid2.Rows.Count; i++)
                    {
                    Participant.Id = Convert.ToInt32 (Grid2.Rows [i].Cells [1].Value);
                    Testbank.RemoveOneParticipantFromExam (Exam.Id, Participant.Id);
                    }
                RefreshGrid2 (Exam.Id);
                }
            }
        private void Menu2_PrintoutPasswords_Click (object sender, EventArgs e)
            {
            Testbank.GetExamParticipants (Exam.Id);
            //0ID, 1Participant_ID, 2Exam_ID, 3ParticipantName, 4ParticipantPass, 5Started, 6DateTime, 7Finished
            DialogResult myansw = MessageBox.Show ("Show QR-CODE ?", "eLib.Exams", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (myansw)
                {
                case DialogResult.Yes:
                        {
                        string strUsrPwds = "";
                        for (int i = 0; i < Db.DS.Tables ["tblExamParticipants"].Rows.Count; i++)
                            {
                            strUsrPwds += Db.DS.Tables ["tblExamParticipants"].Rows [i] [3].ToString () + "   /   " + Db.DS.Tables ["tblExamParticipants"].Rows [i] [4].ToString () + "\n\n";
                            }
                        Client.GenerateQRCode (strUsrPwds);
                        Testbank.PrintoutExamParticipantsUserPass ();
                        break;
                        }
                case DialogResult.No:
                        {
                        Testbank.PrintoutExamParticipantsUserPass ();
                        break;
                        }
                case DialogResult.Cancel:
                        {
                        break;
                        }
                }
            }
        private void Menu2_PrintoutExamsheets_Click (object sender, EventArgs e)
            {
            int r = (int) Grid2.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                Participant.Id = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                Testbank.PrintoutRawExamSheets (Exam.Id, Participant.Id);
                }
            }
        private void Menu2_PrintoutMarks_Click (object sender, EventArgs e)
            {
            Testbank.PrintoutExamMarks (Exam.Id);
            }
        private void Menu2_PrintoutParticipantRecord_Click (object sender, EventArgs e)
            {
            int r = (int) Grid2.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                if (Convert.ToBoolean (Grid2.Rows [r].Cells [7].Value) == true)
                    {
                    Participant.Id = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                    Testbank.PrintoutExamRecords (Exam.Id, Participant.Id);
                    }
                else
                    {
                    MessageBox.Show ("Participant has not finished the Exam!", "eLib");
                    }
                }
            }
        //Exit
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        //methods
        private void AddNewParticipant ()
            {
            if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                string strParticipantName = "STDNT-" + (Grid1.Rows.Count + 1).ToString ();
                string strParticipantPass = Strings.Left (strParticipantName, 4) + DateTime.Now.ToString ("mmss");
                //dialog
                Project.Name = strParticipantName;
                Project.Note = strParticipantPass;
                Client.DialogRequestParams = 128; //dialog for: new user pass
                My.MyProject.Forms.frmProject.ShowDialog ();
                if (Client.DialogRequestParams == 16) //bit5(00010000): bit5=0:cancel, bit5=1(value=16):save
                    {
                    Project.Note += "--------";//Ensure pass is at least  8chars
                    strParticipantName = Strings.Left (Project.Name, 40);
                    strParticipantPass = Strings.Left (Project.Note, 8);
                    //update
                    try
                        {
                        Testbank.AddNewParticipant2Entry (entryId, strParticipantName, strParticipantPass);
                        RefreshGrid1 (entryId);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        private void EditParticipant ()
            {
            if ((Grid1.Rows.Count == 0) || (Grid1.SelectedCells [0].RowIndex == -1))
                {
                return;
                }
            else
                {
                //Grid1-cols: 0ID, 1Entry_ID, 2ParticipantName, 3ParticipantPass
                int intParticipantId = Convert.ToInt32 (Grid1.Rows [Grid1.SelectedCells [0].RowIndex].Cells [0].Value.ToString ());
                string strParticipantName = Grid1.Rows [Grid1.SelectedCells [0].RowIndex].Cells [2].Value.ToString ();
                string strParticipantPass = Grid1.Rows [Grid1.SelectedCells [0].RowIndex].Cells [3].Value.ToString ();
                //dialog
                Project.Name = strParticipantName;
                Project.Note = strParticipantPass;
                Client.DialogRequestParams = 136; //dialog for: edit user pass
                My.MyProject.Forms.frmProject.ShowDialog ();
                if (Client.DialogRequestParams == 16) //bit5(00010000): bit5=0:cancel, bit5=1(value=16):save
                    {
                    Project.Note += "--------";//Ensure pass is at least  8chars
                    strParticipantName = Strings.Left (Project.Name, 40);
                    strParticipantPass = Strings.Left (Project.Note, 8);
                    //update
                    try
                        {
                        if (Testbank.UpdateParticipant (intParticipantId, strParticipantName, strParticipantPass))
                            {
                            int intEntryId = Convert.ToInt32 (cboEntries.SelectedValue);
                            RefreshGrid1 (intEntryId);
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        public void AddAllParticipants2Exam (int entryId, int examId)
            {
            progressBar1.Visible = true;
            int rows = Db.DS.Tables ["tblEntryParticipants"].Rows.Count;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = rows;
            for (int i = 0; i < Db.DS.Tables ["tblEntryParticipants"].Rows.Count; i++)
                {
                progressBar1.Value = i + 1;
                Participant.Id = Convert.ToInt32 (Db.DS.Tables ["tblEntryParticipants"].Rows [i] [0].ToString ());
                bool boolExist = false;
                for (int j = 0; j < Grid2.RowCount; j++)
                    {
                    if (Convert.ToInt32 (Grid2.Rows [j].Cells [1].Value) == Participant.Id)
                        {
                        boolExist = true;
                        break;
                        }
                    }
                if (!boolExist)
                    {
                    Testbank.AddOneParticipant2Exam (Participant.Id, examId);
                    }
                }
            progressBar1.Visible = false;
            }
        private void RefreshCboEntries ()
            {
            try
                {
                cboEntries.DataSource = null;
                Testbank.GetEntries (User.Id);
                cboEntries.DataSource = Db.DS.Tables ["tblEntries"];
                cboEntries.DisplayMember = "EntryName";
                cboEntries.ValueMember = "ID";
                cboEntries.SelectedIndex = -1;
                Grid1.DataSource = null;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void RefreshGrid1 (int entryId)
            {
            Grid1.DataSource = null;
            Testbank.GetEntryParticipants (entryId);
            Grid1.DataSource = Db.DS.Tables ["tblEntryParticipants"];
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                Grid1.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //ID, Entry_ID, ParticipantName, ParticipantPass
            Grid1.Columns [0].Visible = false;   //ID
            Grid1.Columns [1].Visible = false;   //Entry_ID
            Grid1.Columns [2].Width = 210;       //ParticipantName
            Grid1.Columns [3].Width = 110;       //ParticipantPass
            }
        private void RefreshGrid2 (int examId)
            {
            Grid2.DataSource = null;
            Testbank.GetExamParticipants (examId);
            Grid2.DataSource = Db.DS.Tables ["tblExamParticipants"];
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                Grid2.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //0ID, 1Participant_ID, 2Exam_ID, 3ParticipantName, 4ParticipantPass, 5Started, 6DateTime, 7Finished
            Grid2.Columns [0].Visible = false;   //ID
            Grid2.Columns [1].Visible = false;   //Participant_ID
            Grid2.Columns [2].Visible = false;   //Exam_ID
            Grid2.Columns [3].Width = 180;       //ParticipantName
            Grid2.Columns [4].Width = 90;        //ParticipantPass
            Grid2.Columns [5].Width = 40;        //Started
            Grid2.Columns [6].Width = 120;       //DateTime
            Grid2.Columns [7].Width = 40;        //Finished
            }
        }
    }
