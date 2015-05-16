using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using NHibernate;

namespace MEACruncher.Forms {

    // BASE CLASS
    internal abstract partial class ViewEntitiesForm<E> : CRUDForm<E> where E : Entity  {
        // VARIABLES
        protected BindingSource _entities;

        // EVENTS
        public event EntitiesSelectedEventHandler<E> EntitiesSelected;

        // CONSTRUCTORS
        public ViewEntitiesForm() : base() {
            InitializeComponent();
            _entities = new BindingSource();    // Apparently this needs to happen before derived classes call their InitializeComponent()
        }

        // EVENT HANDLERS
        protected void NewEntityForm_EntityCreated(object sender, EntityCreatedEventArgs<E> e) {
            _entities.Add(e.Entity);
        }
        protected void EditEntityForm_EntityUpdated(object sender, EntityUpdatedEventArgs<E> e) {
            _db.Refresh(e.Entity);
        }
        protected void ViewEntitiesForm_Load(object sender, EventArgs e) {
            _entities.DataSource = loadEntities();
        }

        // FUNCTIONS
        protected abstract IList<E> loadEntities();
        protected abstract void formatEntities(DataGridViewCellFormattingEventArgs e);
        protected abstract void deleteDependents();
        protected bool entityDeleted(E entity, string message) {
            // Show a dialog asking the user if they really want to delete the record
            DialogResult result = MessageBox.Show(message,
                                                  Application.ProductName,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning,
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                return false;

            // Remove record associated with this DataGridViewRow from the database
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Delete(entity);
                deleteDependents();
                trans.Commit();
            }
            return true;
        }
        protected void updateEntity(E entity) {
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Update(entity);
                trans.Commit();
            }
        }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class IViewProjectsForm : ViewEntitiesForm<Project> {
        public IViewProjectsForm() : base() { }
        protected override void deleteDependents() { }
        protected override IList<Project> loadEntities() { return new List<Project>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }
    internal class IViewExperimentersForm : ViewEntitiesForm<Experimenter> {
        public IViewExperimentersForm() : base() { }
        protected override void deleteDependents() { }
        protected override IList<Experimenter> loadEntities() { return new List<Experimenter>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }
    internal class IViewOrganizationsForm : ViewEntitiesForm<Organization> {
        public IViewOrganizationsForm() : base() { }
        protected override void deleteDependents() { }
        protected override IList<Organization> loadEntities() { return new List<Organization>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }

}