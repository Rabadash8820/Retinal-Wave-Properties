using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal abstract partial class AddEntitiesForm : CRUDForm {
        // EVENTS
        public event EntitiesSelectedEventHandler EntitiesSelected;

        // CONSTRUCTORS
        public AddEntitiesForm() {
            InitializeComponent();
        }

        // PROPERTIES
        protected BindingSource BoundEntities { get; set; }

        // EVENT HANDLERS
        private void AddButton_Click(object sender, EventArgs e) {
            onEntitiesSelected();
            closeStuff();
        }
        private void CancelAddButton_Click(object sender, EventArgs e) {
            this.closeStuff();
        }
        private void EntitiesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            EntitiesDGV.ClearSelection();
        }

        // FUNCTIONS
        protected virtual IList<Entity> loadEntities() { return new List<Entity>(); }
        protected override void buildForm() {
            base.buildForm();

            // Apply application settings
            EntitiesDGV.DefaultCellStyle.BackColor = Settings.Default.DgvCellBackColor;
            EntitiesDGV.DefaultCellStyle.ForeColor = Settings.Default.DgvCellForeColor;
            EntitiesDGV.ColumnHeadersDefaultCellStyle.BackColor = Settings.Default.DgvHeaderBackColor;
            EntitiesDGV.ColumnHeadersDefaultCellStyle.ForeColor = Settings.Default.DgvHeaderForeColor;
            RowStyle lastRow = MainTableLayout.RowStyles[MainTableLayout.RowStyles.Count - 1];
            lastRow.Height = Settings.Default.ContainerHeight;

            // Create data bindings
            this.BoundEntities.DataSource = loadEntities();
            this.createDataBindings();
            EntitiesDGV.AutoGenerateColumns = false;
            EntitiesDGV.DataBindingComplete += EntitiesDGV_DataBindingComplete;
            EntitiesDGV.DataSource = this.BoundEntities;
        }
        protected override void createDataBindings() {
            base.createDataBindings();
        }
        protected void autofit(DataGridViewColumn column) {
            // Make the column wide enough to show all cell content, but let the user resize it still
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            int autoWidth = column.Width;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = autoWidth;
        }
        protected virtual void formatEntities(DataGridViewCellFormattingEventArgs e) { }
        private void onEntitiesSelected() {
            if (this.EntitiesSelected == null)
                return;

            Delegate[] subscribers = this.EntitiesSelected.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                EntitiesSelectedEventArgs args = new EntitiesSelectedEventArgs(selectedEntities());
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        protected virtual IList<Entity> selectedEntities() { return new List<Entity>(); }
    }

}