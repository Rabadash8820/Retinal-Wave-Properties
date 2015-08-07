using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using MEACruncher.Properties;

using NHibernate;

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal partial class NewProjectForm : NewEntityForm {
        // CONSTRUCTORS
        public NewProjectForm() : base() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
            this.createEntity();
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            this.closeStuff();
        }
        private void TitleTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            bool isValid = this.validText(
                Resources.RegexRes.NonEmpty,
                TitleTextbox.Text,
                Resources.ValidateRes.ProjectTitle);
            e.Cancel = !isValid;
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

        // OVERRIDE FUNCTIONS
        protected override Entity defaultEntity() {
            // Get a list of all currently used Project titles on the default Date
            DateTime defaultDate = DateTime.Today;
            IList<string> titles = Session.QueryOver<Project>()
                                      .Where(p => p.DateStarted == defaultDate)
                                      .Select(p => p.Name)
                                      .List<string>();

            // Return the first title like baseStr, baseStr_1, baseStr_2, etc. that isn't already taken
            int num = 0;
            string defaultTitle = String.Format(DefaultRes.ProjectTitle, "");
            while (titles.Contains(defaultTitle))
                defaultTitle = String.Format(DefaultRes.ProjectTitle, "_" + (++num));

            // Create/return a new Project with that title and the current date as the start date
            Project entity = new Project() {
                Name = defaultTitle,
                DateStarted = defaultDate,
                Comments = DefaultRes.ProjectComments
            };
            return entity;
        }
        protected override void buildForm() {
            base.buildForm();

            // Add application settings
            RowStyle lastRow = MainTableLayout.RowStyles[MainTableLayout.RowStyles.Count - 1];
            lastRow.Height = Settings.Default.ContainerHeight;
            TitleTextbox.Height = Settings.Default.ControlHeight;
            DateStartedDateTimePicker.Height = Settings.Default.ControlHeight;

            // Add data bindings
            TitleTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName((Project e) => e.Name));
            DateStartedDateTimePicker.DataBindings.Add("Value", this.BoundEntity, propertyName((Project e) => e.DateStarted));
            CommentsTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName((Project e) => e.Comments));

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