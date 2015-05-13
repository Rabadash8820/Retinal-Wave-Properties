using System;
using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal partial class NewProjectForm : INewProjectForm {
        // CONSTRUCTORS
        public NewProjectForm() : base() { }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
            this.createEntity();
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            this.closeStuff();
        }

        // OVERRIDE FUNCTIONS
        protected override void construct() {
            InitializeComponent();
            base.construct();
        }
        protected override Project defaultEntity() {
            // Get a list of all currently used Project titles in the database
            IList<string> titles = _db.QueryOver<Project>()
                                      .Select(p => p.Title)
                                      .List<string>();

            // Return the first title like baseStr, baseStr_1, baseStr_2, etc. that isn't already taken
            int num = 0;
            string title = "Project";
            while (titles.Contains(title))
                title = String.Format("{0}_{1}", "Project", ++num);

            // Create/return a new Project with that title and the current date as the start date
            Project proj = new Project() {
                Title = title,
                DateStarted = DateTime.Now,
                Comments = "A new project for analyzing MEA data."
            };
            return proj;
        }
        protected override void buildForm() {
            TitleTextbox.DataBindings.Add("Text", _entity, "Title");
            DateStartedDateTimePicker.DataBindings.Add("Value", _entity, "DateStarted");
            CommentsTextbox.DataBindings.Add("Text", _entity, "Comments");
        }
        protected override bool isUnique() {
            int numProjects = _db.QueryOver<Project>()
                                 .Where(p =>
                                     p.Title == _entity.Title &&
                                     p.DateStarted.Date == _entity.DateStarted.Date)
                                 .RowCount();
            return (numProjects == 0);
        }
    }

}