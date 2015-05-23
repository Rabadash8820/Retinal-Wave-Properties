using System;
using MeaData;
using System.Data;
using System.Linq;
using MEACruncher.Events;
using System.Windows.Forms;
using MEACruncher.Properties;
using System.Linq.Expressions;
using MEACruncher.Forms.AddForms;
using System.Collections.Generic;

namespace MEACruncher.Forms.EditForms {

    internal partial class EditProjectForm : IEditProjectForm {
        // CONSTRUCTORS
        public EditProjectForm() : base() {
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
            Project p = this.BoundEntity.DataSource as Project;
            IList<ProjectExperimenter> projExps = e.Entities.Select(entity =>
                new ProjectExperimenter() {
                    Project = p,
                    Experimenter = entity,
                    IsManager = false,
                    StartDate = p.DateStarted,
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
            this.updateEntity();
            this.closeStuff();
        }
        private void UndoButton_Click(object sender, EventArgs e) {
            this.MementoManager.Undo();
            this.manageUndoRedo();
        }
        private void RedoButton_Click(object sender, EventArgs e) {
            this.MementoManager.Redo();
            this.manageUndoRedo();
        }
        private void UndoButton_EnabledChanged(object sender, EventArgs e) {

        }
        private void RedoButton_EnabledChanged(object sender, EventArgs e) {

        }

        // FUNCTIONS
        protected override void buildForm() {
            base.buildForm();

            // Add application settings
            RowStyle lastRow = MainTableLayout.RowStyles[MainTableLayout.RowStyles.Count - 1];
            lastRow.Height = Settings.Default.ContainerHeight;
            TitleTextbox.Height = Settings.Default.ControlHeight;
            DateStartedDateTimePicker.Height = Settings.Default.ControlHeight;

            // Add data bindings
            TitleTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName(e => e.Title));
            DateStartedDateTimePicker.DataBindings.Add("Value", this.BoundEntity, propertyName(e => e.DateStarted));
            CommentsTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName(e => e.Comments));

            // Remaining formats...
            DateStartedDateTimePicker.MaxDate = DateTime.Today;
            this.manageUndoRedo();
        }
        protected override void manageUndoRedo() {
            base.manageUndoRedo();

            // Enable/disable the undo/redo buttons and set their tooltip text accordingly
            UndoButton.Enabled = this.MementoManager.CanUndo;
            RedoButton.Enabled = this.MementoManager.CanRedo;
            MainToolTip.SetToolTip(UndoButton, this.MementoManager.TopUndoMessage);
            MainToolTip.SetToolTip(RedoButton, this.MementoManager.TopRedoMessage);
        }

    }

}