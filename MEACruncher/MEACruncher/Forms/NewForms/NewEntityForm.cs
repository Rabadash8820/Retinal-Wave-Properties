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
        // VARIABLES
        protected E _entity;

        // EVENTS
        public event EntityCreatedEventHandler<E> EntityCreated;

        // CONSTRUCTOR
        public NewEntityForm() : base() {
            InitializeComponent();
        }

        // FUNCTIONS
        protected override void buildForm() {
            _entity = defaultEntity();
        }
        protected virtual E defaultEntity() { return default(E); }
        protected void createEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            if (!isUnique(_entity))
                return;

            // If not, persist this new Entity in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(_entity);
                trans.Commit();
            }
            onEntityCreated();
            closeStuff();
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