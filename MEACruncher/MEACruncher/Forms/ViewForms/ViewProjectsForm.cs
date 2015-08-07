using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;

using NHibernate;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MEACruncher.Forms {

    public partial class ViewProjectsForm : Form {
        // INTERFACE
        public ViewProjectsForm() {
            InitializeComponent();

            setDataBindings();
            loadEntities();
        }
        public event EntityUpdatedEventHandler EntityUpdated;

        // EVENT HANDLERS
        private void CloseBtn_Click(object sender, System.EventArgs e) {
            this.Close();
        }

        private void EditBtn_Click(object sender, System.EventArgs e) {

        }

        private void NewBtn_Click(object sender, System.EventArgs e) {
            NewProjectForm form = new NewProjectForm();
            form.EntityCreated += NewForm_EntityCreated;
            form.ShowDialog();
        }
        private void UndoBtn_Click(object sender, System.EventArgs e) {

        }

        private void RedoBtn_Click(object sender, System.EventArgs e) {

        }
        void NewForm_EntityCreated(object sender, Events.EntityCreatedEventArgs e) {
            loadEntities();
        }
        private void EntitiesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex == DateStartedCol.Index) {
                Project entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Project;
                e.Value = entity.DateStarted.ToShortDateString();
            }
        }
        private void EntitiesDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            // Check that a title was entered
            int col = e.ColumnIndex;
            DataGridViewCell cell = EntitiesDGV.Rows[e.RowIndex].Cells[col];
            if (col == TitleCol.Index) {
                bool valid = Util.validText(RegexRes.NonEmpty, e.FormattedValue as string);
                cell.ErrorText = (valid ? "" : ValidateRes.ProjectTitle);
            }

            // Check that a valid start date was provided
            else if (col == DateStartedCol.Index) {
                string validStr = Util.validDate(
                    e.FormattedValue as string,
                    new DateTime(1970, 1, 1),
                    DateTime.Today);
                cell.ErrorText = validStr;
            }
        }
        private void EntitiesDGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            // Cancel validation if any cells have invalid data
            DataGridViewRow row = EntitiesDGV.Rows[e.RowIndex];
            foreach (DataGridViewCell cell in row.Cells){
                if (cell.ErrorText != "") {
                    e.Cancel = true;
                    return;
                }
            }

            // Clear cell error texts
            foreach (DataGridViewCell cell in row.Cells)
                cell.ErrorText = "";

            // If the databound Entity would create a duplicate in the database,
            // then set the row's error text and cancel
            Project entity = row.DataBoundItem as Project;
            bool unique = EntityManager.IsUnique(entity);
            if (!unique) {
                row.ErrorText = EntityManager.DuplicateErrorMsg(entity);
                e.Cancel = true;
            }
        }
        private void EntitiesDGV_RowValidated(object sender, DataGridViewCellEventArgs e) {
            // Clear error texts
            DataGridViewRow row = EntitiesDGV.Rows[e.RowIndex];
            foreach (DataGridViewCell cell in row.Cells)
                cell.ErrorText = "";
            row.ErrorText = "";

            // Update this row's bound Entity in the database
            Project entity = row.DataBoundItem as Project;
            using (ISession db = Program.MeaDataDb.Session) {
                using (ITransaction trans = db.BeginTransaction()) {
                    db.Update(entity);
                    trans.Commit();
                }
            }

            // Fire the EntityUpdated event
            this.OnEntityUpdated(entity);
        }

        // HELPER FUNCTIONS
        private void setDataBindings() {
            TitleCol.DataPropertyName = Util.GetPropertyName((Project e) => e.Name);
            DateStartedCol.DataPropertyName = Util.GetPropertyName((Project e) => e.DateStarted);
            CommentsCol.DataPropertyName = Util.GetPropertyName((Project e) => e.Comments);
        }
        private void loadEntities() {
            // Select Entities from the database
            IList<Project> entities;
            using (ISession db = Program.MeaDataDb.Session) {
                entities = db.QueryOver<Project>().List();
            }

            // Bind the result set to the DataGridView
            BindingSource bs = new BindingSource();
            bs.DataSource = entities;
            EntitiesDGV.AutoGenerateColumns = false;
            EntitiesDGV.DataSource = bs;
        }
        private void OnEntityUpdated(Project entity) {
            if (this.EntityUpdated == null)
                return;

            Delegate[] subscribers = this.EntityUpdated.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                EntityUpdatedEventArgs args = new EntityUpdatedEventArgs(entity);
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }

    }

}
