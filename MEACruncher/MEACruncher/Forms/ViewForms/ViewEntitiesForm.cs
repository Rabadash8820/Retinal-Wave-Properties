using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using NHibernate;

namespace MEACruncher.Forms.ViewForms {

    // BASE CLASS
    internal abstract partial class ViewEntitiesForm<E> : CRUDForm<E> where E : Entity  {
        // VARIABLES
        protected BindingSource _entities;

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
            //this.refresh();
        }
        protected void AddEntitiesForm_EntitiesSelected(object sender, EntitiesSelectedEventArgs<E> e) {
            this.addEntities();
        }
        protected void ViewEntitiesForm_Load(object sender, EventArgs e) {
            _entities.DataSource = loadEntities();
        }

        // FUNCTIONS
        protected virtual IList<E> loadEntities() { return new List<E>(); }
        protected virtual void formatEntities(DataGridViewCellFormattingEventArgs e) { }
        protected virtual void deleteDependents() { }
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
        protected virtual void addEntities() { }
        protected override void closeStuff() {
            base.closeStuff();
            _db.Close();
        }
        protected virtual void refresh() { }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class IViewProjectsForm : ViewEntitiesForm<Project> {
        public IViewProjectsForm() : base() { }
    }
    internal class IViewExperimentersForm : ViewEntitiesForm<Experimenter> {
        public IViewExperimentersForm() : base() { }
    }
    internal class IViewOrganizationsForm : ViewEntitiesForm<Organization> {
        public IViewOrganizationsForm() : base() { }
    }

}