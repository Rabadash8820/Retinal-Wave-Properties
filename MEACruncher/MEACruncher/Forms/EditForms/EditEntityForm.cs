using System;
using MeaData;
using NHibernate;
using MEACruncher.Events;
using System.Windows.Forms;

namespace MEACruncher.Forms.EditForms {

    // BASE CLASS
    public abstract partial class EditEntityForm<E> : CRUDForm<E> where E : Entity {
        // EVENTS
        public event EntityUpdatedEventHandler<E> EntityUpdated;

        // CONSTRUCTOR
        public EditEntityForm() : base() {
            InitializeComponent();
        }

        // PROPERTIES
        protected BindingSource BoundEntity { get; set; }

        // FUNCTIONS
        protected override void buildForm() {
            base.buildForm();

            // Recall an Entity from the DbManager and bind to it
            Entity e = EntityManager.Recall() as E;
            this.BoundEntity = new BindingSource();
            this.BoundEntity.DataSource = e;
        }
        protected void updateEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            E e = this.BoundEntity.DataSource as E;
            if (!isUnique(e)) return;

            // If not, persist this new Entity in the database and close the form
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Update(e);
                trans.Commit();
            }
            onEntityUpdated();
            closeStuff();
        }
        private void onEntityUpdated() {
            if (this.EntityUpdated == null)
                return;

            Delegate[] subscribers = this.EntityUpdated.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                EntityUpdatedEventArgs<E> args = new EntityUpdatedEventArgs<E>(this.BoundEntity.DataSource as E);
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class IEditProjectForm : EditEntityForm<Project> {
        public IEditProjectForm() : base() { }
    }
    internal class IEditExperimenterForm : EditEntityForm<Experimenter> {
        public IEditExperimenterForm() : base() { }
    }

}