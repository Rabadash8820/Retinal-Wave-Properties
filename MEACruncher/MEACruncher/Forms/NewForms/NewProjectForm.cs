using System;
using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using MEACruncher.Properties;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms.NewForms {

    internal partial class NewProjectForm : INewProjectForm {
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
            bool isValid = this.validate(
                Resources.RegexRes.NonEmpty,
                TitleTextbox.Text,
                Resources.ValidateRes.ProjectTitle);
            e.Cancel = !isValid;
        }

        // OVERRIDE FUNCTIONS
        protected override Project defaultEntity() {
            // Get a list of all currently used Project titles on the default Date
            DateTime defaultDate = DateTime.Today;
            IList<string> titles = _db.QueryOver<Project>()
                                      .Where(p => p.DateStarted == defaultDate)
                                      .Select(p => p.Title)
                                      .List<string>();

            // Return the first title like baseStr, baseStr_1, baseStr_2, etc. that isn't already taken
            int num = 0;
            string defaultTitle = String.Format(DefaultRes.ProjectTitle, "");
            while (titles.Contains(defaultTitle))
                defaultTitle = String.Format(DefaultRes.ProjectTitle, "_" + (++num));

            // Create/return a new Project with that title and the current date as the start date
            Project entity = new Project() {
                Title = defaultTitle,
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

            DateStartedDateTimePicker.MaxDate = DateTime.Today;

            // Add data bindings
            TitleTextbox.DataBindings.Add("Text", _entity, "Title");
            DateStartedDateTimePicker.DataBindings.Add("Value", _entity, "DateStarted");
            CommentsTextbox.DataBindings.Add("Text", _entity, "Comments");
        }

    }

}