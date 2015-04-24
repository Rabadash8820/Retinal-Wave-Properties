using System;
using System.Linq;
using System.Collections.Generic;
using Neuro;
using NHibernate;
using System.Windows.Forms;

namespace MEACruncher {
    public partial class NewProjectForm : Form {
        // VARIABLES / EVENTS
        private ISession _db;
        private Project _proj;
        public event EventHandler ProjectCreated;

        // CONSTRUCTOR
        public NewProjectForm() {
            InitializeComponent();

            _db = DbManager.StartSessionWith(Database.MeaData);

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
                                  .Where(p => p.Title == _proj.Title)
                                  .RowCount() == 0;

            // If so, then show a warning to the user
            if (!titleUnique) {
                DialogResult result = MessageBox.Show(
                    "An existing project already has this title.  Please enter a different one.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // Otherwise, persist this new Project in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(_proj);
                trans.Commit();
            }
            onProjectCreated();
            destruct();
        }
        private void TitleTextbox_TextChanged(object sender, EventArgs e) {

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
        private void onProjectCreated() {
            if (this.ProjectCreated != null) {
                foreach (Delegate subscriber in this.ProjectCreated.GetInvocationList()) {
                    Control c = subscriber.Target as Control;
                    object[] args = new object[] { this, EventArgs.Empty };
                    if (c != null && c.InvokeRequired)
                        c.BeginInvoke(subscriber, args);
                    else
                        subscriber.DynamicInvoke(args);
                }
            }
        }
        private void destruct() {
            _db.Close();
            this.Close();
        }

        private void CancelCreateButton_Click(object sender, EventArgs e) {
            destruct();
        }

    }

}