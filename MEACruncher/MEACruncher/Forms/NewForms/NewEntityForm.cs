using System;
using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MEACruncher.Forms.NewForms {

    // BASE CLASS
    internal abstract partial class NewEntityForm<E> : CRUDForm<E> where E : Entity {
        // EVENTS
        public event EntityCreatedEventHandler<E> EntityCreated;

        // CONSTRUCTOR
        public NewEntityForm() : base() {
            InitializeComponent();
        }

        // PROPERTIES
        protected BindingSource BoundEntity { get; set; }

        // FUNCTIONS
        protected override void buildForm() {
            base.buildForm();

            // Create a default Entity and bind to it
            E e = defaultEntity();
            this.BoundEntity = new BindingSource();
            this.BoundEntity.DataSource = e;
        }
        protected virtual E defaultEntity() { return default(E); }
        protected void createEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            E e = this.BoundEntity.DataSource as E;
            if (!isUnique(e)) return;

            // If not, persist this new Entity in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(e);
                trans.Commit();
            }
            onEntityCreated();
            closeStuff();
        }
        private void onEntityCreated() {
            if (this.EntityCreated == null)
                return;

            Delegate[] subscribers = this.EntityCreated.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                EntityCreatedEventArgs<E> args = new EntityCreatedEventArgs<E>(this.BoundEntity.DataSource as E);
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class INewProjectForm : NewEntityForm<Project> {
        public INewProjectForm() : base() { }
    }
    internal class INewExperimenterForm : NewEntityForm<Experimenter> {
        public INewExperimenterForm() : base() { }
    }
    internal class INewOrganizationForm : NewEntityForm<Organization> {
        public INewOrganizationForm() : base() { }
    }

}