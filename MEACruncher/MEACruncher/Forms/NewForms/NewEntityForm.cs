using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;

using NHibernate;

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MEACruncher.Forms.NewForms {

    // BASE CLASS
    internal abstract partial class NewEntityForm : CRUDForm {
        // EVENTS
        public event EntityCreatedEventHandler EntityCreated;

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
            Entity e = defaultEntity();
            this.BoundEntity = new BindingSource();
            this.BoundEntity.DataSource = e;
        }
        protected virtual Entity defaultEntity() { return default(Entity); }
        protected void createEntity() {
            // Validate the new Entity to see if it will conflict with an existing record
            Entity e = this.BoundEntity.DataSource as Entity;
            if (!isUnique(e)) return;

            // If not, persist this new Entity in the database and close the form
            using (ITransaction trans = Session.BeginTransaction()) {
                Session.Save(e);
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
                EntityCreatedEventArgs args = new EntityCreatedEventArgs(this.BoundEntity.DataSource as Entity);
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
    }

}