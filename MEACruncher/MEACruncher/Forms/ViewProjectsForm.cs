using NHibernate;
using MeaData;
using MEACruncher.Events;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    public partial class ViewProjectsForm : Form {

        // VARIABLES
        private ISession _db;
        private BindingSource _projects;

        // CONSTRUCTORS
        public ViewProjectsForm() {
            InitializeComponent();

            initialize();

        }

        // EVENT HANDLERS
        private void CancelEditButton_Click(object sender, System.EventArgs e) {
            closeStuff();
        }
        private void ProjectsDGV_SelectionChanged(object sender, System.EventArgs e) {
            bool rowSelected = (ProjectsDGV.SelectedRows.Count > 0);
            EditButton.Enabled = rowSelected;
            DeleteButton.Enabled = rowSelected;
        }
        private void ProjectsDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            bool cancelDelete = !recordDeleted(e.Row.DataBoundItem as Project);
            e.Cancel = cancelDelete;
        }
        private void DeleteButton_Click(object sender, System.EventArgs e) {
            Project p = ProjectsDGV.SelectedRows[0].DataBoundItem as Project;
            if (recordDeleted(p))
                _projects.Remove(p);
        }
        private void ProjectsDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex != DateStartedColumn.Index)
                return;
            DateTime? dateTime = e.Value as DateTime?;
            e.Value = dateTime.Value.Date;
        }
        private void NewButton_Click(object sender, EventArgs e) {
            NewProjectForm npf = new NewProjectForm();
            npf.EntityCreated += NewProjectForm_EntityCreated;
            npf.ShowDialog();
        }
        void NewProjectForm_EntityCreated(object sender, EntityCreatedEventArgs<Project> e) {
            _projects.Add(e.Entity);
        }
        void ProjectsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            ProjectsDGV.ClearSelection();
        }

        // FUNCTIONS
        private void initialize() {
            // Set private members
            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();
            _projects = new BindingSource();
            _projects.DataSource = _db.QueryOver<Project>()
                                      .OrderBy(p => p.Title).Asc
                                      .OrderBy(p => p.DateStarted).Asc
                                      .List();

            // Initialize the dataGridView
            TitleColumn.DataPropertyName = "Title";
            DateStartedColumn.DataPropertyName = "DateStarted";
            CommentsColumn.DataPropertyName = "Comments";
            ProjectsDGV.AutoGenerateColumns = false;
            ProjectsDGV.DataBindingComplete += ProjectsDGV_DataBindingComplete;
            ProjectsDGV.DataSource = _projects;
        }
        private bool recordDeleted(Project p) {
            // Show a dialog asking the user if they really want to delete the record
            DialogResult result = MessageBox.Show("Are you sure you want to delete this Project and all of its results?",
                                                  "",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning,
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                return false;

            // Remove record associated with this DataGridViewRow from the database
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Delete(p);
                trans.Commit();
            }
            return true;
        }
        private void closeStuff() {
            _db.Close();
            this.Close();
        }

    }

}