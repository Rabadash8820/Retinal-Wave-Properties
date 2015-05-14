using NHibernate;
using MeaData;
using MEACruncher.Events;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal partial class ViewExperimentersForm : IViewExperimentersForm {
        // CONSTRUCTORS
        public ViewExperimentersForm() : base() { }

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
            bool cancelDelete = !entityDeleted(e.Row.DataBoundItem as Experimenter);
            e.Cancel = cancelDelete;
        }
        private void DeleteButton_Click(object sender, System.EventArgs e) {
            Experimenter entity = EntitiesDGV.SelectedRows[0].DataBoundItem as Experimenter;
            if (entityDeleted(entity))
                _entities.Remove(entity);
        }
        private void EntitiesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            this.formatEntities(e);
        }
        private void NewButton_Click(object sender, EventArgs e) {
            NewExperimenterForm form = new NewExperimenterForm();
            form.EntityCreated += NewEntityForm_EntityCreated;
            form.ShowDialog();
        }
        private void NewProjectForm_EntityCreated(object sender, EntityCreatedEventArgs<Project> e) {
            _entities.Add(e.Entity);
        }
        private void EntitiesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            EntitiesDGV.ClearSelection();
        }

        // FUNCTIONS
        protected override void construct() {
            InitializeComponent();
            base.construct();
        }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) {
            base.formatEntities(e);

        }
        protected override void deleteDependents() { }
        protected override IList<Experimenter> loadEntities() {
            IList<Experimenter> entities = _db.QueryOver<Experimenter>()
                                              .OrderBy(e => e.FullName).Asc
                                              .List();
            return entities;
        }
        protected override void buildForm() {
            // Initialize the dataGridView
            FullNameColumn.DataPropertyName = "FullName";
            EmailColumn.DataPropertyName    = "WorkEmail";
            PhoneColumn.DataPropertyName    = "WorkPhone";
            CommentsColumn.DataPropertyName = "Comments";
            EntitiesDGV.AutoGenerateColumns = false;
            EntitiesDGV.DataBindingComplete += EntitiesDGV_DataBindingComplete;
            EntitiesDGV.DataSource = _entities;
        }

    }

}