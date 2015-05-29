using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using R = MEACruncher.Resources;
using MEACruncher.Forms.NewForms;

using NHibernate;

using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MEACruncher.Forms.ViewForms {

    internal abstract partial class ViewEntitiesForm : CRUDForm  {
        // CONSTRUCTORS
        public ViewEntitiesForm() : base() {
            InitializeComponent();
            this.BoundEntities = new BindingSource();    // Apparently this needs to happen before derived classes call their InitializeComponent()
        }

        // PROPERTIES
        protected BindingSource BoundEntities { get; set; }

        // EVENT HANDLERS
        private void EntitiesDGV_SelectionChanged(object sender, System.EventArgs e) {
            bool rowSelected = (EntitiesDGV.SelectedRows.Count > 0);
            EditButton.Enabled = rowSelected;
            DeleteButton.Enabled = rowSelected;
        }
        private void EntitiesDGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            Entity entity = e.Row.DataBoundItem as Entity;
            string message = EntityManager.DeleteMessage(entity);
            bool cancelDelete = !entityDeleted(entity, message);
            e.Cancel = cancelDelete;
        }
        private void EntitiesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            this.formatEntities(e);
        }
        private void NewButton_Click(object sender, EventArgs e) {
            Type entityType = this.BoundEntities.DataSource.GetType().GetElementType();
            NewEntityForm form = EntityManager.ShowNewForm(entityType);
            form.EntityCreated += NewEntityForm_EntityCreated;
            form.ShowDialog();
        }
        private void EditButton_Click(object sender, EventArgs e) {
            //EditExperimenterForm form = new EditExperimenterForm();
            //form.EntityUpdated += EditEntityForm_EntityUpdated;
            //form.ShowDialog();
        }
        private void DeleteButton_Click(object sender, System.EventArgs e) {
            Entity entity = EntitiesDGV.SelectedRows[0].DataBoundItem as Entity;
            string message = EntityManager.DeleteMessage(entity);
            if (entityDeleted(entity, message))
                this.BoundEntities.Remove(entity);
        }
        private void CancelEditButton_Click(object sender, System.EventArgs e) {
            closeStuff();
        }
        private void UndoButton_Click(object sender, EventArgs e) {
            this.MementoManager.Undo();
            this.manageUndoRedo();
        }
        private void RedoButton_Click(object sender, EventArgs e) {
            this.MementoManager.Redo();
            this.manageUndoRedo();
        }
        private void UndoButton_EnabledChanged(object sender, EventArgs e) {

        }
        private void RedoButton_EnabledChanged(object sender, EventArgs e) {

        }

        private void EntitiesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            EntitiesDGV.ClearSelection();
        }
        private void EntitiesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            EntitiesDGV.BeginEdit(true);
        }
        private void EntitiesDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            bool isValid = isCellValid(e.ColumnIndex, e.FormattedValue as string);
            e.Cancel = isValid;
        }
        private void EntitiesDGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            DataGridViewCell thisCell = EntitiesDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Entity entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Entity;
            
            // If the row's associated Entity isn't unique then activate the last-edited cell for the user to fix
            bool unique = isUnique(entity);
            if (!unique) {
                EntitiesDGV.CurrentCell = thisCell;         // ********** CurrentCell may already be set here! *************
                EntitiesDGV.BeginEdit(true);
                e.Cancel = true;
            }
        }
        private void EntitiesDGV_RowValidated(object sender, DataGridViewCellEventArgs e) {
            Entity entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Entity;
            this.updateEntity(entity);
        }

        protected void NewEntityForm_EntityCreated(object sender, EntityCreatedEventArgs e) {
            this.BoundEntities.Add(e.Entity);
        }
        protected void EditEntityForm_EntityUpdated(object sender, EntityUpdatedEventArgs e) {
            this.refreshStuff();
        }

        // FUNCTIONS
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

            // Remaining formats...
            this.manageUndoRedo();
        }
        protected override void createDataBindings() {
            base.createDataBindings();
        }
        protected override void manageUndoRedo() {
            base.manageUndoRedo();

            // Enable/disable the undo/redo buttons and set their tooltip text accordingly
            UndoButton.Enabled = this.MementoManager.CanUndo;
            RedoButton.Enabled = this.MementoManager.CanRedo;
            MainToolTip.SetToolTip(UndoButton, this.MementoManager.TopUndoMessage);
            MainToolTip.SetToolTip(RedoButton, this.MementoManager.TopRedoMessage);
        }
        protected virtual bool isCellValid(int index, string input) { return false; }
        protected void autofit(DataGridViewColumn column) {
            // Make the column wide enough to show all cell content, but let the user resize it still
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            int autoWidth = column.Width;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = autoWidth;
        }
        protected virtual IList<Entity> loadEntities() { return new List<Entity>(); }
        protected virtual void formatEntities(DataGridViewCellFormattingEventArgs e) { }
        protected virtual void deleteDependents() { }
        protected bool entityDeleted(Entity entity, string message) {
            // Show a dialog asking the user if they really want to delete the record
            DialogResult result = MessageBox.Show(message,
                                                  Application.ProductName,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning,
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                return false;

            // Remove record associated with this DataGridViewRow from the database
            using (ITransaction trans = Session.BeginTransaction()) {
                Session.Delete(entity);
                deleteDependents();
                trans.Commit();
            }
            return true;
        }
        protected void updateEntity(Entity entity) {
            // Called whenever data is updated by a ViewForm's DataGridView
            using (ITransaction trans = Session.BeginTransaction()) {
                Session.Update(entity);
                trans.Commit();
            }
        }
        protected override void closeStuff() {
            base.closeStuff();
            Session.Close();
        }
        protected virtual void refreshStuff() {
            // Called whenever data was updated on a different Form
            EntitiesDGV.Refresh();
        }
    }

}