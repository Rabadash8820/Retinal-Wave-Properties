using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using R = MEACruncher.Resources;
using MEACruncher.Forms.NewForms;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms.ViewForms {

    internal partial class ViewExperimentersForm : IViewExperimentersForm {
        // CONSTRUCTORS
        public ViewExperimentersForm() : base() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void CancelEditButton_Click(object sender, System.EventArgs e) {
            closeStuff();
        }
        private void EntitiesDGV_SelectionChanged(object sender, System.EventArgs e) {
            bool rowSelected = (EntitiesDGV.SelectedRows.Count > 0);
            EditButton.Enabled = rowSelected;
            DeleteButton.Enabled = rowSelected;
        }
        private void EntitiesDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            Experimenter entity = e.Row.DataBoundItem as Experimenter;
            string message = String.Format(R.DeleteRes.ExperimenterWarning, entity.FullName);
            bool cancelDelete = !entityDeleted(entity, message);
            e.Cancel = cancelDelete;
        }
        private void EntitiesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            this.formatEntities(e);
        }
        private void NewButton_Click(object sender, EventArgs e) {
            NewExperimenterForm form = new NewExperimenterForm();
            form.EntityCreated += NewEntityForm_EntityCreated;
            form.ShowDialog();
        }
        private void EditButton_Click(object sender, EventArgs e) {
            //EditExperimenterForm form = new EditExperimenterForm();
            //form.EntityUpdated += EditEntityForm_EntityUpdated;
            //form.ShowDialog();
        }
        private void DeleteButton_Click(object sender, System.EventArgs e) {
            Experimenter entity = EntitiesDGV.SelectedRows[0].DataBoundItem as Experimenter;
            string message = String.Format(R.DeleteRes.ExperimenterWarning, entity.FullName);
            if (entityDeleted(entity, message))
                this.BoundEntities.Remove(entity);
        }
        private void NewProjectForm_EntityCreated(object sender, EntityCreatedEventArgs<Project> e) {
            this.BoundEntities.Add(e.Entity);
        }
        private void EntitiesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            EntitiesDGV.ClearSelection();
        }
        private void EntitiesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            EntitiesDGV.BeginEdit(true);
        }
        private void EntitiesDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            // Validate the cell value based on which column it is in
            int index = e.ColumnIndex;
            string input = e.FormattedValue as string;
            if (index == FullNameColumn.Index) {
                bool isValid = this.validate(
                    Resources.RegexRes.PersonName,
                    input,
                    Resources.ValidateRes.ExperimenterFullName);
                e.Cancel = !isValid;
            }
            else if (index == EmailColumn.Index) {
                bool isValid = this.validate(
                    Resources.RegexRes.EmailAddress,
                    input,
                    Resources.ValidateRes.EmailAddress);
                e.Cancel = !isValid;
            }
            else if (index == PhoneColumn.Index) {
                bool isValid = this.validate(
                    Resources.RegexRes.PhoneNumber,
                    input,
                    Resources.ValidateRes.PhoneNumber);
                e.Cancel = !isValid;
            }
        }
        private void EntitiesDGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            Experimenter entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Experimenter;
            bool unique = isUnique(entity);
            if (!unique) {
                e.Cancel = true;
                EntitiesDGV.CurrentCell = EntitiesDGV.Rows[e.RowIndex].Cells[FullNameColumn.Index];
                EntitiesDGV.BeginEdit(true);
            }
        }
        private void EntitiesDGV_RowValidated(object sender, DataGridViewCellEventArgs e) {
            Experimenter entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Experimenter;
            this.updateEntity(entity);
        }

        // FUNCTIONS
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) {
            base.formatEntities(e);

        }
        protected override void deleteDependents() { }
        protected override IList<Experimenter> loadEntities() {
            IList<Experimenter> entities = Session.QueryOver<Experimenter>()
                                              .OrderBy(e => e.FullName).Asc
                                              .List();
            return entities;
        }
        protected override void buildForm() {
            base.buildForm();

            // Apply application settings
            EntitiesDGV.DefaultCellStyle.BackColor = Settings.Default.DgvCellBackColor;
            EntitiesDGV.DefaultCellStyle.ForeColor = Settings.Default.DgvCellForeColor;
            EntitiesDGV.ColumnHeadersDefaultCellStyle.BackColor = Settings.Default.DgvHeaderBackColor;
            EntitiesDGV.ColumnHeadersDefaultCellStyle.ForeColor = Settings.Default.DgvHeaderForeColor;
            RowStyle lastRow = MainTableLayout.RowStyles[MainTableLayout.RowStyles.Count - 1];
            lastRow.Height = Settings.Default.ContainerHeight;

            // Create data bindings
            FullNameColumn.DataPropertyName = propertyName(e => e.FullName);
            EmailColumn.DataPropertyName = propertyName(e => e.WorkEmail);
            PhoneColumn.DataPropertyName = propertyName(e => e.WorkPhone);
            CommentsColumn.DataPropertyName = propertyName(e => e.Comments);
            EntitiesDGV.AutoGenerateColumns = false;
            EntitiesDGV.DataBindingComplete += EntitiesDGV_DataBindingComplete;
            EntitiesDGV.DataSource = this.BoundEntities;

            // Resize dataGridView columns
            foreach (DataGridViewColumn column in EntitiesDGV.Columns)
                autofit(column);
            CommentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        protected override void refreshStuff() {
            base.refreshStuff();
            EntitiesDGV.Refresh();
        }
        
    }

}