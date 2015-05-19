using System;
using MeaData;
using MEACruncher.Events;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms.AddForms {

    // BASE CLASS
    internal abstract partial class AddEntitiesForm<E> : CRUDForm<E> where E : Entity {
        // EVENTS
        public event EntitiesSelectedEventHandler<E> EntitiesSelected;

        // CONSTRUCTORS
        public AddEntitiesForm() {
            InitializeComponent();
        }

        // PROPERTIES
        protected BindingSource BoundEntities { get; set; }

        // FUNCTIONS
        protected virtual IList<E> loadEntities() { return new List<E>(); }
        protected virtual void formatEntities(DataGridViewCellFormattingEventArgs e) { }
        protected void addEntities() {
            onEntitiesSelected();
            closeStuff();
        }
        private void onEntitiesSelected() {
            if (this.EntitiesSelected == null)
                return;

            Delegate[] subscribers = this.EntitiesSelected.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                EntitiesSelectedEventArgs<E> args = new EntitiesSelectedEventArgs<E>(selectedEntities());
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        protected virtual IList<E> selectedEntities() { return new List<E>(); }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class IAddExperimentersForm : AddEntitiesForm<Experimenter> {
        public IAddExperimentersForm() : base() { }
    }

}