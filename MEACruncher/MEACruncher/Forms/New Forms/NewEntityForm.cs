using System;
using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MEACruncher.Forms {

    // BASE CLASS
    internal abstract partial class NewEntityForm<E> : Form where E : Entity {
        // VARIABLES
        protected E _entity;
        protected ISession _db;
        private static bool _initialized = false;
        private delegate string duplication(E entity);
        private static Dictionary<Type, duplication> _duplicateError;

        // EVENTS
        public event EntityCreatedEventHandler<E> EntityCreated;

        // CONSTRUCTOR
        public NewEntityForm() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            closeStuff();
        }

        // MEMBER FUNCTIONS
        protected virtual void initialize() {
            // Initialize static members
            if (!_initialized)
                staticInitialize();

            // Initialize instance members
            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();
            _entity = defaultEntity();

            // Initialize form controls
            buildForm();
        }
        private static void staticInitialize() {
            // Associated a duplicate Entity error with each Entity type
            _duplicateError = new Dictionary<Type, duplication>(){
                { typeof(Project),      e => String.Format(DuplicateRes.ProjectError, (e as Project).Title, (e as Project).DateStarted.ToShortDateString()) },
                { typeof(Experimenter), e => String.Format(DuplicateRes.ExperimenterError, (e as Experimenter).FullName) },
            };

            _initialized = true;
        }
        protected void createEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            bool unique = isUnique();

            // If so, then show a warning to the user
            if (!unique) {
                string message = _duplicateError[typeof(E)](_entity) + "\n\n" + DuplicateRes.Message;
                DialogResult result = MessageBox.Show(
                    message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // Otherwise, persist this new Entity in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(_entity);
                trans.Commit();
            }
            onEntityCreated();
            closeStuff();
        }
        protected void closeStuff() {
            _db.Close();
            this.Close();
        }
        private void onEntityCreated() {
            if (this.EntityCreated != null) {
                Delegate[] subscribers = this.EntityCreated.GetInvocationList();
                foreach (Delegate subscriber in subscribers) {
                    Control c = subscriber.Target as Control;
                    EntityCreatedEventArgs<E> args = new EntityCreatedEventArgs<E>(_entity);
                    if (c != null && c.InvokeRequired)
                        c.BeginInvoke(subscriber, this, args);
                    else
                        subscriber.DynamicInvoke(this, args);
                }
            }
        }
        protected bool validate(string regexStr, string input, string message) {
            // If the input returns exactly one match, then return true
            regexStr = "^" + regexStr + "$";
            Regex regex = new Regex(regexStr);
            int numMatches = regex.Matches(input).Count;
            if (numMatches == 1) return true;

            // Otherwise display an error message box and return false
            message.Insert(0, String.Format(ValidateRes.Message, input));
            MessageBox.Show(
                message,
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            return false;
        }
        protected abstract void buildForm();
        protected abstract E defaultEntity();
        protected abstract bool isUnique();

    }

    // DERIVED CLASSES (so VS designer will work)
    internal class INewProjectForm : NewEntityForm<Project> {
        protected override void buildForm() { }
        protected override Project defaultEntity() { return new Project(); }
        protected override bool isUnique() { return true; }
    }
    internal class INewExperimenterForm : NewEntityForm<Experimenter> {
        protected override void buildForm() { }
        protected override Experimenter defaultEntity() { return new Experimenter(); }
        protected override bool isUnique() { return true; }
    }
    internal class INewOrganizationForm : NewEntityForm<Organization> {
        protected override void buildForm() { }
        protected override Organization defaultEntity() { return new Organization(); }
        protected override bool isUnique() { return true; }
    }

}