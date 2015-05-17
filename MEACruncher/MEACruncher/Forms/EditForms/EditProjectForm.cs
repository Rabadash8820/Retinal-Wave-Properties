using System;
using MeaData;
using System.Data;
using System.Linq;
using MEACruncher.Events;
using System.Windows.Forms;
using MEACruncher.Properties;
using MEACruncher.Forms.AddForms;
using System.Collections.Generic;

namespace MEACruncher.Forms.EditForms {

    internal partial class EditProjectForm : IEditProjectForm {
        // CONSTRUCTORS
        public EditProjectForm() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void AddExperimenterButton_Click(object sender, EventArgs e) {
            AddExperimentersForm form = new AddExperimentersForm();
            form.EntitiesSelected += AddExperimentersForm_EntitiesSelected;
            form.ShowDialog();
        }
        protected void AddExperimentersForm_EntitiesSelected(object sender, EntitiesSelectedEventArgs<Experimenter> e) {
            // Create a list of default many-to-many objects
            IList<ProjectExperimenter> projExps = e.Entities.Select(entity =>
                new ProjectExperimenter() {
                    Project = _entity,
                    Experimenter = entity,
                    IsManager = false,
                    StartDate = _entity.DateStarted,
                    EndDate = default(DateTime)
                })
                .ToList();

            // Wrap them in a BindingSource object
            BindingSource bs = new BindingSource();
            bs.DataSource = projExps;

            // Bind these to the appropriate DataGridView
            FullNameColumn.DataPropertyName = "Experimenter.FullName";
            EmailColumn.DataPropertyName = "Experimenter.WorkEmail";
            PhoneColumn.DataPropertyName = "Experimenter.WorkPhone";
            CommentsColumn.DataPropertyName = "Experimenter.Comments";
            IsManagerColumn.DataPropertyName = "IsManager";
            StartDateColumn.DataPropertyName = "StartDate";
            EndDateColumn.DataPropertyName = "EndDate";
        }
        private void ExperimentersDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex == EndDateColumn.Index) {
                ProjectExperimenter pe = ExperimentersDGV.Rows[e.RowIndex].DataBoundItem as ProjectExperimenter;
                if (pe.EndDate == default(DateTime))
                    e.Value = Resources.DefaultRes.ProjectExperimenterEndDate;
            }
        }
        private void UpdateButton_Click(object sender, EventArgs e) {
            //this.updateEntity();
            this.Close();
        }

        // FUNCTIONS
        protected override void buildForm() {
            base.buildForm();

            // Add application settings
            RowStyle lastRow = MainTableLayout.RowStyles[MainTableLayout.RowStyles.Count - 1];
            lastRow.Height = Settings.Default.ContainerHeight;
            TitleTextbox.Height = Settings.Default.ControlHeight;
            DateStartedDateTimePicker.Height = Settings.Default.ControlHeight;

            DateStartedDateTimePicker.MaxDate = DateTime.Today;

            // Add data bindings
            TitleTextbox.DataBindings.Add("Text", _entity, "Title");
            DateStartedDateTimePicker.DataBindings.Add("Value", _entity, "DateStarted");
            CommentsTextbox.DataBindings.Add("Text", _entity, "Comments");
        }
    }

}