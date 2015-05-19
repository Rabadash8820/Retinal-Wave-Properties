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
        // CONSTRUCTORS
        public ViewEntitiesForm() : base() {
            InitializeComponent();
            this.BoundEntities = new BindingSource();    // Apparently this needs to happen before derived classes call their InitializeComponent()
        }

        // PROPERTIES
        protected BindingSource BoundEntities { get; set; }

        // EVENT HANDLERS
        protected void NewEntityForm_EntityCreated(object sender, EntityCreatedEventArgs<E> e) {
            this.BoundEntities.Add(e.Entity);
        }
        protected void EditEntityForm_EntityUpdated(object sender, EntityUpdatedEventArgs<E> e) {
            this.refreshStuff();
        }

        // FUNCTIONS
        protected override void buildForm() {
            base.buildForm();
            this.BoundEntities.DataSource = loadEntities();
        }
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
            // Called whenever data is updated by a ViewForm's DataGridView
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Update(entity);
                trans.Commit();
            }
        }
        protected override void closeStuff() {
            base.closeStuff();
            _db.Close();
        }
        protected virtual void refreshStuff() {
            // Called whenever data was updated on a different Form
        }
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