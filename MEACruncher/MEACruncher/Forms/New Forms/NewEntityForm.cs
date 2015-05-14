using System;
using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    // BASE CLASS
    internal abstract partial class NewEntityForm<E> : Form where E : Entity {
        // VARIABLES
        protected E _entity;
        protected ISession _db;
        private static bool _initialized = false;
        private static Dictionary<Type, string> _duplicateError;

        // EVENTS
        public event EntityCreatedEventHandler<E> EntityCreated;

        // CONSTRUCTOR
        public NewEntityForm() {
            InitializeComponent();
            construct();
        }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            closeStuff();
        }

        // MEMBER FUNCTIONS
        protected virtual void construct() {
            // Initialize static members
            if (!_initialized)
                staticInitialize();

            // Initialize instance members
            //_db = DbManager.SessionFactory(Database.MeaData).OpenSession();
            _entity = defaultEntity();

            // Initialize form controls
            buildForm();
        }
        private static void staticInitialize() {
            // Associated a duplicate Entity error with each Entity type
            _duplicateError = new Dictionary<Type, string>(){
                { typeof(Project),      DuplicateRes.ProjectError      },
                { typeof(Experimenter), DuplicateRes.ExperimenterError },
            };

            _initialized = true;
        }
        protected void createEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            bool unique = isUnique();

            // If so, then show a warning to the user
            if (!unique) {
                DialogResult result = MessageBox.Show(
                    _duplicateError[typeof(E)],
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // Otherwise, persist this new Entity in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                persistEntity();
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
        protected abstract void buildForm();
        protected abstract E defaultEntity();
        protected abstract bool isUnique();
        protected abstract void persistEntity();

    }

    // DERIVED CLASSES (so VS designer will work)
    internal class INewProjectForm : NewEntityForm<Project> {
        protected override void buildForm() { }
        protected override Project defaultEntity() { return new Project(); }
        protected override bool isUnique() { return true; }
        protected override void persistEntity() { }
    }
    internal class INewExperimenterForm : NewEntityForm<Experimenter> {
        protected override void buildForm() { }
        protected override Experimenter defaultEntity() { return new Experimenter(); }
        protected override bool isUnique() { return true; }
        protected override void persistEntity() { }
    }
    internal class INewOrganizationForm : NewEntityForm<Organization> {
        protected override void buildForm() { }
        protected override Organization defaultEntity() { return new Organization(); }
        protected override bool isUnique() { return true; }
        protected override void persistEntity() { }
    }

}