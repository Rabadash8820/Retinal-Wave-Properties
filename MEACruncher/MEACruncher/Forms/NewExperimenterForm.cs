using System;
using System.Linq;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using NHibernate;
using System.Windows.Forms;

namespace MEACruncher.Forms {
    public partial class NewExperimenterForm : Form {
        // VARIABLES / EVENTS
        private ISession _db;
        private Experimenter _experimenter;
        public event EntityCreatedEventHandler<Project> ProjectCreated;

        // CONSTRUCTOR
        public NewExperimenterForm() {
            InitializeComponent();

            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();

            // Bind form controls to a new transient Project object
            _experimenter = defaultEntity();
            this.TitleTextbox.DataBindings.Add("Text", _experimenter, "Title");
            this.CommentsTextbox.DataBindings.Add("Text", _experimenter, "Comments");
        }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
            // Validate the new Project to see if it will conflict with an existing project
            bool unique = _db.QueryOver<Experimenter>()
                                  .Where(exp =>
                                      exp.FullName == _experimenter.FullName &&
                                      exp.WorkEmail == _experimenter.WorkEmail &&
                                      exp.WorkPhone == _experimenter.WorkPhone)
                                  .RowCount() == 0;

            // If so, then show a warning to the user
            if (!unique) {
                DialogResult result = MessageBox.Show(
                    "An existing experimenter already has this name, email, and phone number.  Please enter different values.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // Otherwise, persist this new record in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(_experimenter);
                trans.Commit();
            }
            onRecordCreated();
            closeStuff();
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            closeStuff();
        }

        // FUNCTIONS
        private Experimenter defaultEntity() {
            // Create/return a new Experimenter with default values
            Experimenter e = new Experimenter() {
                FullName = "",
                WorkEmail = "",
                WorkPhone = "",
                Comments = "That guy from that one place."
            };
            return e;
        }
        private void closeStuff() {
            _db.Close();
            this.Close();
        }
        private void onRecordCreated() {
            if (this.ProjectCreated != null) {
                Delegate[] subscribers = this.ProjectCreated.GetInvocationList();
                foreach (Delegate subscriber in subscribers) {
                    Control c = subscriber.Target as Control;
                    EntityCreatedEventArgs<Experimenter> args = new EntityCreatedEventArgs<Experimenter>(_experimenter);
                    if (c != null && c.InvokeRequired)
                        c.BeginInvoke(subscriber, this, args);
                    else
                        subscriber.DynamicInvoke(this, args);
                }
            }
        }

    }

}