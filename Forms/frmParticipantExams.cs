using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmParticipantExams : Form
        {
        public frmParticipantExams ()
            {
            InitializeComponent ();
            }
        private void frmParticipantExams_Load (object sender, EventArgs e)
            {
            Width = 1150;
            Height = 600;
            RefreshCboEntries ();
            if (Participant.Id != 0)
                {
                cboEntries.SelectedValue = Participant.EntryId;
                RefreshGridParticipants (Participant.EntryId);
                GridParticipants.CurrentCell = GridParticipants.Rows [Participant.Index].Cells [2];
                }
            RefreshGridParticipantExam (Participant.Id);
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
                    RefreshGridParticipants (entryId);
                    }
                }
            catch { }
            }
        private void GridParticipants_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            int r = (int) GridParticipants.CurrentCell.RowIndex;
            if (r >= 0)
                {
                Participant.Id = Convert.ToInt32 (GridParticipants.Rows [r].Cells [0].Value);
                RefreshGridParticipantExam (Participant.Id);
                }
            }
        private void GridParticipantExams_CellContentDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            btnDeleteExam_Click (null, null);
            }
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
                            RefreshGridParticipants (intEntryId);
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
        private void btn_AddNewParticipant_Click (object sender, EventArgs e)
            {
            AddNewParticipant ();
            GridParticipants.Focus ();
            }
        private void btn_EditParticipant_Click (object sender, EventArgs e)
            {
            EditParticipant ();
            }
        private void btn_DeleteParticipant_Click (object sender, EventArgs e)
            {
            int r = GridParticipants.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                DialogResult myansw = MessageBox.Show ("Delete Participant?\n\nNotice:\nExamSheets of this participant will be deleted too", "eLib.Exams", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.OK)
                    {
                    Participant.Id = Convert.ToInt32 (GridParticipants.Rows [r].Cells [0].Value);
                    Testbank.DeleteOneParticipantFromEntry (Participant.Id);
                    RefreshGridParticipants (Convert.ToInt32 (cboEntries.SelectedValue));
                    RefreshGridParticipantExam (Exam.Id);
                    }
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
                    RefreshGridParticipantExam (Exam.Id);
                    }
                }
            }
        private void btnAddExamToParticipant_Click (object sender, EventArgs e)
            {
            if (GridParticipants.SelectedCells [0].RowIndex >= 0)
                {
                System.Windows.Forms.Form frm_SelectExam = new frmSelectExam ();
                frm_SelectExam.ShowDialog ();
                if (Exam.Id > 0)
                    {
                    Testbank.AddOneParticipant2Exam (Participant.Id, Exam.Id);
                    RefreshGridParticipantExam (Participant.Id);
                    }
                }
            else
                {
                MessageBox.Show ("Select a Participant from Left Panel", "eLib.Exams");
                }
            }
        private void btnDeleteExam_Click (object sender, EventArgs e)
            {
            //remove from grid2
            //0ID, 1Participant_ID, 2Exam_ID, 3ParticipantName, 4ParticipantPass, 5Started, 6DateTime, 7Finished
            if (!chkDoubleClickToDelete.Checked)
                {
                return;
                }
            int r = (int) GridParticipantExams.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                //confirm!
                DialogResult myansw = MessageBox.Show ("Are you sure?\nAll ExamSheet for the participant will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.No)
                    {
                    return;
                    }
                else
                    {
                    Exam.Id = Convert.ToInt32 (GridParticipantExams.Rows [r].Cells [1].Value);
                    Testbank.RemoveOneParticipantFromExam (Exam.Id, Participant.Id);
                    RefreshGridParticipantExam (Participant.Id);
                    }
                }
            }
        //Menu
        private void Menu1_Passwords_Click (object sender, EventArgs e)
            {
            int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
            Testbank.GetEntryParticipants (entryId);
            //0ID, 1Entry_ID, 2ParticipantName, 3ParticipantPass
            DialogResult myansw = MessageBox.Show ("Show QR-CODE ?", "eLib.Exams", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (myansw)
                {
                case DialogResult.Yes:
                        {
                        string strUsrPwds = "";
                        for (int i = 0; i < Db.DS.Tables ["tblEntryParticipants"].Rows.Count; i++)
                            {
                            strUsrPwds += Db.DS.Tables ["tblEntryParticipants"].Rows [i] [2].ToString () + "   /   " + Db.DS.Tables ["tblEntryParticipants"].Rows [i] [3].ToString () + "\n\n";
                            }
                        Client.GenerateQRCode (strUsrPwds);
                        Testbank.PrintoutEntryParticipantsUserPass (entryId);
                        break;
                        }
                case DialogResult.No:
                        {
                        Testbank.PrintoutEntryParticipantsUserPass (entryId);
                        break;
                        }
                case DialogResult.Cancel:
                        {
                        break;
                        }
                }
            }
        private void Menu2_PrintoutExamSheet_Click (object sender, EventArgs e)
            {
            int r1 = (int) GridParticipants.SelectedCells [0].RowIndex;
            int r2 = (int) GridParticipantExams.SelectedCells [0].RowIndex;
            if ((r1 >= 0) && (r2 >= 0))
                {
                if (!Convert.ToBoolean (GridParticipantExams.Rows [r2].Cells [6].Value))
                    {
                    Participant.Id = Convert.ToInt32 (GridParticipants.Rows [r1].Cells [0].Value);
                    Exam.Id = Convert.ToInt32 (GridParticipantExams.Rows [r2].Cells [1].Value);
                    Exam.Title = GridParticipantExams.Rows [r2].Cells [2].Value.ToString ();
                    Testbank.PrintoutRawExamSheets (Exam.Id, Participant.Id);
                    }
                else
                    {
                    MessageBox.Show (GridParticipants.Rows [r1].Cells [2].Value.ToString () + " has written this exam!");
                    }
                }
            }
        private void Menu2_PrintoutExamRecord_Click (object sender, EventArgs e)
            {
            int r1 = (int) GridParticipants.SelectedCells [0].RowIndex;
            int r2 = (int) GridParticipantExams.SelectedCells [0].RowIndex;
            if ((r1 >= 0) & (r2 >= 0))
                {
                if (Convert.ToBoolean (GridParticipantExams.Rows [r2].Cells [8].Value))
                    {
                    Participant.Id = Convert.ToInt32 (GridParticipants.Rows [r1].Cells [0].Value);
                    Exam.Id = Convert.ToInt32 (GridParticipantExams.Rows [r2].Cells [1].Value);
                    Exam.Title = GridParticipantExams.Rows [r2].Cells [2].Value.ToString ();
                    Testbank.PrintoutExamRecords (Exam.Id, Participant.Id);
                    }
                else
                    {
                    MessageBox.Show ("Participant has not finished this Exam!", "eLib");
                    }
                }
            }
        //methods
        private void RefreshCboEntries ()
            {
            try
                {
                cboEntries.DataSource = null;
                Testbank.GetEntries (User.Id);
                cboEntries.DataSource = Db.DS.Tables ["tblEntries"];
                cboEntries.DisplayMember = "EntryName";
                cboEntries.ValueMember = "ID";
                cboEntries.SelectedValue = Participant.Id;
                GridParticipants.DataSource = null;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void RefreshGridParticipants (int entryId)
            {
            GridParticipants.DataSource = null;
            Testbank.GetEntryParticipants (entryId);
            GridParticipants.DataSource = Db.DS.Tables ["tblEntryParticipants"];
            for (int i = 0, loopTo = GridParticipants.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                GridParticipants.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //0ID, 1Entry_ID, 2ParticipantName, 3ParticipantPass
            GridParticipants.Columns [0].Visible = false;   //ID
            GridParticipants.Columns [1].Visible = false;   //Entry_ID
            GridParticipants.Columns [2].Width = 180;       //ParticipantName
            GridParticipants.Columns [3].Width = 80;        //ParticipantPass
            //reset right
            GridParticipantExams.DataSource = null;
            }
        private void RefreshGridParticipantExam (int participantId)
            {
            if (participantId == 0)
                {
                return;
                }
            else
                {
                GridParticipantExams.DataSource = null;
                Testbank.GetAllParticipantExams (Participant.Id);
                GridParticipantExams.DataSource = Db.DS.Tables ["tblParticipantExams"];
                for (int i = 0, loopTo = GridParticipants.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                    {
                    GridParticipantExams.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                //0CourseName, 1Exams.ID, 2ExamTitle, 3ExamDuration, 4IsActive, 5Training, 6Started, 7ExamParticipants.DateTime, 8Finished
                GridParticipantExams.Columns [0].Width = 180;       //CourseName
                GridParticipantExams.Columns [1].Visible = false;   //Exams.ID
                GridParticipantExams.Columns [2].Width = 210;       //ExamTitle
                GridParticipantExams.Columns [3].Width = 60;        //ExamDuration
                GridParticipantExams.Columns [4].Width = 40;        //IsActive
                GridParticipantExams.Columns [5].Width = 40;        //Training
                GridParticipantExams.Columns [6].Width = 40;        //Started
                GridParticipantExams.Columns [7].Width = 140;       //ExamParticipants.DateTime
                GridParticipantExams.Columns [8].Width = 40;        //Finished
                }
            }
        private void AddNewParticipant ()
            {
            if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                string strParticipantName = "STDNT-" + (GridParticipants.Rows.Count + 1).ToString ();
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
                        RefreshGridParticipants (entryId);
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
            if ((GridParticipants.Rows.Count == 0) || (GridParticipants.SelectedCells [0].RowIndex == -1))
                {
                return;
                }
            else
                {
                //Grid1-cols: 0ID, 1Entry_ID, 2ParticipantName, 3ParticipantPass
                int intParticipantId = Convert.ToInt32 (GridParticipants.Rows [GridParticipants.SelectedCells [0].RowIndex].Cells [0].Value.ToString ());
                string strParticipantName = GridParticipants.Rows [GridParticipants.SelectedCells [0].RowIndex].Cells [2].Value.ToString ();
                string strParticipantPass = GridParticipants.Rows [GridParticipants.SelectedCells [0].RowIndex].Cells [3].Value.ToString ();
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
                            RefreshGridParticipants (intEntryId);
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        //exit
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }
