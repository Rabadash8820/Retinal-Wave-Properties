using System;
using System.Linq;
using System.Collections.Generic;
using MeaData;
using NHibernate;
using System.Windows.Forms;

namespace MEACruncher {
    public partial class NewProjectForm : Form {
        // VARIABLES / EVENTS
        private ISession _db;
        private Project _proj;
        public event ProjectCreatedEventHandler ProjectCreated;

        // CONSTRUCTOR
        public NewProjectForm() {
            InitializeComponent();

            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();

            // Bind form controls to a new transient Project object
            _proj = defaultProject();
            this.TitleTextbox.DataBindings.Add("Text", _proj, "Title");
            this.DateStartedTimePicker.DataBindings.Add("Value", _proj, "DateStarted");
            this.CommentsTextbox.DataBindings.Add("Text", _proj, "Comments");
        }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
            // Validate the new Project to see if it will conflict with an existing project
            bool titleUnique = _db.QueryOver<Project>()
                                  .Where(p =>
                                      p.Title == _proj.Title &&
                                      p.DateStarted.Date == _proj.DateStarted.Date)
                                  .RowCount() == 0;

            // If so, then show a warning to the user
            if (!titleUnique) {
                DialogResult result = MessageBox.Show(
                    "An existing project already has this title and start date.  Please enter different values.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // Otherwise, persist this new Project in the database, ...
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(_proj);
                trans.Commit();
            }
            onProjectCreated();

            // ...display a success dialog to the user, and close the form
            MessageBox.Show("Project created successfully!",
                            "",
                            MessageBoxButtons.OK);
            closeStuff();
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            closeStuff();
        }

        // FUNCTIONS
        private Project defaultProject() {
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
        private void closeStuff() {
            _db.Close();
            this.Close();
        }
        private void onProjectCreated() {
            if (this.ProjectCreated != null) {
                Delegate[] subscribers = this.ProjectCreated.GetInvocationList();
                foreach (Delegate subscriber in subscribers) {
                    Control c = subscriber.Target as Control;
                    ProjectCreatedEventArgs pcea = new ProjectCreatedEventArgs(_proj);
                    if (c != null && c.InvokeRequired)
                        c.BeginInvoke(subscriber, this, pcea);
                    else
                        subscriber.DynamicInvoke(this, pcea);
                }
            }
        }

    }

}