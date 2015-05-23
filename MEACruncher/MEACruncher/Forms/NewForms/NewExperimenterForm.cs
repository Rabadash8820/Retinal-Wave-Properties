using System;
using System.Linq;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using MEACruncher.Properties;
using NHibernate;
using System.Windows.Forms;

namespace MEACruncher.Forms.NewForms {
    internal partial class NewExperimenterForm : INewExperimenterForm {
        // CONSTRUCTORS
        public NewExperimenterForm() : base() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
            this.createEntity();
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            this.closeStuff();
        }
        private void FullNameTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            bool isValid = this.validText(
                RegexRes.PersonName,
                FullNameTextbox.Text,
                ValidateRes.ExperimenterFullName);
            e.Cancel = !isValid;
        }
        private void EmailTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            bool isValid = this.validText(
                RegexRes.EmailAddress,
                FullNameTextbox.Text,
                ValidateRes.EmailAddress);
            e.Cancel = !isValid;
        }
        private void PhoneTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            bool isValid = this.validText(
                RegexRes.PhoneNumber,
                FullNameTextbox.Text,
                ValidateRes.PhoneNumber);
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
        protected override Experimenter defaultEntity() {
            // Create/return a new Project with that title and the current date as the start date
            Experimenter entity = new Experimenter() {
                FullName  = DefaultRes.ExperimenterName,
                WorkEmail = DefaultRes.ExperimenterEmail,
                WorkPhone = DefaultRes.ExperimenterPhone,
                Comments  = DefaultRes.ExperimenterComments
            };
            return entity;
        }
        protected override void buildForm() {
            base.buildForm();

            // Add application settings
            RowStyle lastRow = MainTableLayout.RowStyles[MainTableLayout.RowStyles.Count - 1];
            lastRow.Height = Settings.Default.ContainerHeight;
            FullNameTextbox.Height = Settings.Default.ControlHeight;
            EmailTextbox.Height = Settings.Default.ControlHeight;
            PhoneTextbox.Height = Settings.Default.ControlHeight;

            // Add data bindings
            FullNameTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName(e => e.FullName));
            EmailTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName(e => e.WorkEmail));
            PhoneTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName(e => e.WorkPhone));
            CommentsTextbox.DataBindings.Add("Text", this.BoundEntity, propertyName(e => e.Comments));

            // Remaining formats...
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