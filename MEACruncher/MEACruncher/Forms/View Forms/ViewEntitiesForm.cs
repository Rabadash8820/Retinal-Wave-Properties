using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using NHibernate;

namespace MEACruncher.Forms {

    // BASE CLASS
    internal abstract partial class ViewEntitiesForm<E> : Form where E : Entity {
        // VARIABLES
        protected ISession _db;
        protected BindingSource _entities;
        private static bool _initialized = false;
        private static Dictionary<Type, string> _deleteWarning;

        // CONSTRUCTORS
        public ViewEntitiesForm() {
            InitializeComponent();
            _entities = new BindingSource();    // This needs to be called before a child's InitializeComponent() for some reason
            construct();
        }

        // EVENT HANDLERS
        protected void NewEntityForm_EntityCreated(object sender, EntityCreatedEventArgs<E> e) {
            _entities.Add(e.Entity);
        }

        // FUNCTIONS
        protected virtual void construct() {
            // Initialize static members
            if (!_initialized)
                staticInitialize();

            // Initialize instance members
            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();
            _entities.DataSource = loadEntities();

            // Initialize form controls
            buildForm();
        }
        private void staticInitialize() {
            // Associated a duplicate Entity error with each Entity type
            _deleteWarning = new Dictionary<Type, string>() {
                { typeof(Project),      DeleteRes.ProjectWarning      },
                { typeof(Experimenter), DeleteRes.ExperimenterWarning },
            };

            _initialized = true;
        }
        protected abstract IList<E> loadEntities();
        protected abstract void buildForm();
        protected abstract void formatEntities(DataGridViewCellFormattingEventArgs e);
        protected abstract void deleteDependents();
        protected bool entityDeleted(E e) {
            // Show a dialog asking the user if they really want to delete the record
            DialogResult result = MessageBox.Show(_deleteWarning[typeof(E)],
                                                  Application.ProductName,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning,
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                return false;

            // Remove record associated with this DataGridViewRow from the database
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Delete(e);
                deleteDependents();
                trans.Commit();
            }
            return true;
        }
        protected void closeStuff() {
            _db.Close();
            this.Close();
        }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class IViewProjectsForm : ViewEntitiesForm<Project> {
        protected override void deleteDependents() { }
        protected override IList<Project> loadEntities() { return new List<Project>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }
    internal class IViewExperimentersForm : ViewEntitiesForm<Experimenter> {
        protected override void deleteDependents() { }
        protected override IList<Experimenter> loadEntities() { return new List<Experimenter>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }
    internal class IViewOrganizationsForm : ViewEntitiesForm<Organization> {
        protected override void deleteDependents() { }
        protected override IList<Organization> loadEntities() { return new List<Organization>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }

}