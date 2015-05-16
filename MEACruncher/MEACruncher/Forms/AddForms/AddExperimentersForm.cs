using System;
using MeaData;
using System.Windows.Forms;
using MEACruncher.Properties;
using System.Collections.Generic;

namespace MEACruncher.Forms.AddForms {

    internal partial class AddExperimentersForm : IAddExperimentersForm {
        // CONSTRUCTORS
        public AddExperimentersForm() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void AddButton_Click(object sender, EventArgs e) {
            this.addEntities();
        }
        private void CancelAddButton_Click(object sender, EventArgs e) {
            this.closeStuff();
        }
        private void EntitiesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            EntitiesDGV.ClearSelection();
        }

        // FUNCTIONS
        protected override IList<Experimenter> loadEntities() {
            IList<Experimenter> entities = _db.QueryOver<Experimenter>()
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

            // Initialize the dataGridView
            FullNameColumn.DataPropertyName = "FullName";
            EmailColumn.DataPropertyName = "WorkEmail";
            PhoneColumn.DataPropertyName = "WorkPhone";
            CommentsColumn.DataPropertyName = "Comments";
            EntitiesDGV.AutoGenerateColumns = false;
            EntitiesDGV.DataBindingComplete += EntitiesDGV_DataBindingComplete;
            EntitiesDGV.DataSource = _entities;
        }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) {
            base.formatEntities(e);
        }
        protected override System.Collections.Generic.IList<Experimenter> selectedEntities() {
            IList<Experimenter> entities = new List<Experimenter>();
            foreach (DataGridViewRow row in EntitiesDGV.SelectedRows)
                entities.Add(row.DataBoundItem as Experimenter);
            return entities;
        }
    }

}