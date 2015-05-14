using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal partial class ViewProjectsForm : IViewProjectsForm {
        // CONSTRUCTORS
        public ViewProjectsForm() : base() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void ViewProjectsForm_Load(object sender, EventArgs e) {
            this.initialize();
        }
        private void CancelEditButton_Click(object sender, System.EventArgs e) {
            closeStuff();
        }
        private void EntitiesDGV_SelectionChanged(object sender, System.EventArgs e) {
            bool rowSelected = (EntitiesDGV.SelectedRows.Count > 0);
            EditButton.Enabled = rowSelected;
            DeleteButton.Enabled = rowSelected;
        }
        private void EntitiesDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            bool cancelDelete = !entityDeleted(e.Row.DataBoundItem as Project);
            e.Cancel = cancelDelete;
        }
        private void DeleteButton_Click(object sender, System.EventArgs e) {
            Project entity = EntitiesDGV.SelectedRows[0].DataBoundItem as Project;
            if (entityDeleted(entity))
                _entities.Remove(entity);
        }
        private void EntitiesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            this.formatEntities(e);
        }
        private void NewButton_Click(object sender, EventArgs e) {
            NewProjectForm form = new NewProjectForm();
            form.EntityCreated += NewEntityForm_EntityCreated;
            form.ShowDialog();
        }
        private void NewProjectForm_EntityCreated(object sender, EntityCreatedEventArgs<Project> e) {
            _entities.Add(e.Entity);
        }
        private void EntitiesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            EntitiesDGV.ClearSelection();
        }
        private void EntitiesDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            // Validate the cell value based on which column it is in
            int index = e.ColumnIndex;
            string input = e.FormattedValue as string;
            if (index == TitleColumn.Index) {
                bool isValid = this.validate(
                    Resources.RegexRes.NonEmpty, 
                    input,
                    Resources.ValidateRes.ProjectTitle);
                e.Cancel = !isValid;
            }
            else if (index == DateStartedColumn.Index) {
                bool isValid = validDate(input);
                e.Cancel = !isValid;
            }
        }

        // FUNCTIONS
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) {
            base.formatEntities(e);

            // Display dates started as dates only (no time info)
            if (e.ColumnIndex != DateStartedColumn.Index)
                return;
            DateTime? dateTime = e.Value as DateTime?;
            e.Value = dateTime.Value.ToShortDateString();
        }
        protected override void deleteDependents() { }
        protected override IList<Project> loadEntities() {
            IList<Project> entities = _db.QueryOver<Project>()
                                        .OrderBy(p => p.Title).Asc
                                        .OrderBy(p => p.DateStarted).Asc
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

            // Initialize the dataGridView
            TitleColumn.DataPropertyName       = "Title";
            DateStartedColumn.DataPropertyName = "DateStarted";
            CommentsColumn.DataPropertyName    = "Comments";
            EntitiesDGV.AutoGenerateColumns = false;
            EntitiesDGV.DataBindingComplete += EntitiesDGV_DataBindingComplete;
            EntitiesDGV.DataSource = _entities;
        }

    }

}