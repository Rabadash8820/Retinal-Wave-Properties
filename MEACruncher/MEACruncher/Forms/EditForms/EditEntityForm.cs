using System;
using MeaData;
using NHibernate;
using MEACruncher.Events;
using System.Windows.Forms;

namespace MEACruncher.Forms {

    // BASE CLASS
    public abstract partial class EditEntityForm : CRUDForm {
        // EVENTS
        public event EntityUpdatedEventHandler EntityUpdated;

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
            Entity e = EntityManager.Recall() as Entity;
            this.BoundEntity = new BindingSource();
            this.BoundEntity.DataSource = e;
        }
        protected void updateEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            Entity e = this.BoundEntity.DataSource as Entity;
            if (!isUnique(e)) return;

            // If not, persist this new Entity in the database and close the form
            using (ITransaction trans = Session.BeginTransaction()) {
                Session.Update(e);
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
                EntityUpdatedEventArgs args = new EntityUpdatedEventArgs(this.BoundEntity.DataSource as Entity);
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
    }

}