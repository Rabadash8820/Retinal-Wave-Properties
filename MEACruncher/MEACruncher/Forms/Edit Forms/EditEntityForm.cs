using System;
using MeaData;
using NHibernate;
using MEACruncher.Events;
using System.Windows.Forms;

namespace MEACruncher.Forms {

    // BASE CLASS
    public abstract partial class EditEntityForm<E> : CRUDForm<E> where E : Entity {
        // VARIABLES
        protected E _entity;

        // EVENTS
        public event EntityUpdatedEventHandler<E> EntityUpdated;

        // CONSTRUCTOR
        public EditEntityForm() : base() {
            InitializeComponent();
        }

        // FUNCTIONS
        protected void updateEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            if (!isUnique(_entity))
                return;

            // If not, persist this new Entity in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Update(_entity);
                trans.Commit();
            }
            onEntityUpdated();
            closeStuff();
        }
        private void onEntityUpdated() {
            if (this.EntityUpdated != null) {
                Delegate[] subscribers = this.EntityUpdated.GetInvocationList();
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
    internal class IEditProjectForm : EditEntityForm<Project> {
        public IEditProjectForm() : base() { }
        protected override void buildForm() { }
    }
    internal class IEditExperimenterForm : EditEntityForm<Experimenter> {
        public IEditExperimenterForm() : base() { }
        protected override void buildForm() { }
    }

}