using MeaData;
using MeaData.Util;
using static MeaData.Util.Util;
using MEACruncher.Events;
using LocalizedResX;

using NHibernate;

using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal partial class ViewProjectsForm : BaseForm {
        // HIDDEN FIELDS
        private int _oldPanelHeight;

        // INTERFACE
        public ViewProjectsForm() : base() {
            InitializeComponent();
            
            setDataBindings();
            loadEntities();
        }
        public event EventHandler<EntityUpdatedEventArgs> EntityUpdated;

        // EVENT HANDLERS
        private void NewBtn_Click(object sender, EventArgs e) {
            NewProjectForm form = new NewProjectForm();
            form.EntityCreated += NewForm_EntityCreated;
            form.ShowDialog();
        }
        private void EditBtn_Click(object sender, EventArgs e) {

        }
        private void DeleteBtn_Click(object sender, EventArgs e) {
            if (EntitiesDGV.SelectedRows.Count == 0)
                return;

            // If some DataGridViewRows are selected, then remove them and delete their data
            IEnumerable<Project> entities = EntitiesDGV.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem as Project);
            DbBoundList<Project> list = (EntitiesDGV.DataSource as BindingSource).DataSource as DbBoundList<Project>;
            foreach (Project p in entities)
                list.Remove(p);
        }
        private void CloseBtn_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void UndoBtn_Click(object sender, EventArgs e) {

        }
        private void RedoBtn_Click(object sender, EventArgs e) {

        }
        private void NewForm_EntityCreated(object sender, EntityCreatedEventArgs e) {
            DbBoundList<Project> entities = (EntitiesDGV.DataSource as BindingSource).DataSource as DbBoundList<Project>;
            entities.Add(e.Entity as Project);
        }
        
        private void EntitiesDGV_RowEnter(object sender, DataGridViewCellEventArgs e) {
            Project root = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Project;
            loadAssocPopulations(root);
            PopulationsDGV.Refresh();
        }
        private void EntitiesDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            EntitiesDGV.BeginEdit(true);
        }
        private void EntitiesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex == DateStartedCol.Index) {
                Project entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Project;
                e.Value = entity.DateStarted.ToShortDateString();
            }
        }
        private void EntitiesDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            int col = e.ColumnIndex;
            DataGridViewCell cell = EntitiesDGV.Rows[e.RowIndex].Cells[col];

            // Don't bother validating if the cell being left never got input focus
            Control editCtrl = EntitiesDGV.EditingControl;
            if (editCtrl == null)
                return;
            TextBox textCell = editCtrl as TextBox;

            // Check that a title was entered
            if (col == TitleCol.Index) {
                bool valid = Validator.NonEmpty(e.FormattedValue as string);
                cell.ErrorText = (valid ? "" : ValidateRes.ProjectTitle);
            }

            // Check that a valid start date was provided
            else if (col == DateStartedCol.Index) {
                string errText = "";
                DateTime latest = DateTime.Today;
                DateTime earliest = new DateTime(1900, 1, 1);
                string dateStr = e.FormattedValue as string;
                bool validDateFormat = Validator.Date(dateStr);
                if (!validDateFormat) {
                    errText = ValidateRes.ProjectStartDateFormat;
                    textCell.Text = earliest.ToShortDateString();
                }
                else {
                    DateTime date = DateTime.Parse(dateStr);
                    bool dateBtwn = (earliest <= date && date <= latest);
                    if (!dateBtwn) {
                        errText = String.Format(ValidateRes.ProjectStartDate,
                            earliest.ToShortDateString(),
                            latest.ToShortDateString());
                    }
                    else
                        textCell.Text = date.ToShortDateString();
                }
                cell.ErrorText = errText;
            }
        }
        private void EntitiesDGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            // Cancel validation if any cells have invalid data
            DataGridViewRow row = EntitiesDGV.Rows[e.RowIndex];
            foreach (DataGridViewCell cell in row.Cells){
                if (cell.ErrorText != "") {
                    e.Cancel = true;
                    return;
                }
            }

            // If the databound Entity would create a duplicate in the database,
            // then set the row's error text and cancel
            try {
                Project entity = row.DataBoundItem as Project;
                bool unique = _entityMgr.IsUnique(entity);
                if (!unique) {
                    row.ErrorText = _entityMgr.DuplicateErrorMsg(entity);
                    e.Cancel = true;
                }
            }
            catch (IndexOutOfRangeException) { }
        }
        private void EntitiesDGV_RowValidated(object sender, DataGridViewCellEventArgs e) {
            // Clear error texts
            DataGridViewRow row = EntitiesDGV.Rows[e.RowIndex];
            foreach (DataGridViewCell cell in row.Cells)
                cell.ErrorText = "";
            row.ErrorText = "";

            // Update this row's bound Entity in the database
            Project entity = row.DataBoundItem as Project;
            update(entity);

            // Fire the EntityUpdated event
            EntityUpdatedEventArgs args = new EntityUpdatedEventArgs(entity);
            this.OnEntityUpdated(args);
        }
        private void EntitiesDGV_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            int col = e.ColumnIndex;
            DataGridViewCell cell = EntitiesDGV.Rows[e.RowIndex].Cells[col];

            // Squash format errors in the DateStarted column
            if (col == DateStartedCol.Index) {
                e.ThrowException = false;
                cell.ErrorText = ValidateRes.ProjectStartDateFormat;
                cell.Value = default(DateTime);
            }
        }

        // HELPER FUNCTIONS
        private void setDataBindings() {
            // Don't auto generate columns
            EntitiesDGV.AutoGenerateColumns = false;
            PopulationsDGV.AutoGenerateColumns = false;

            // Set DataBindings for the main DataGridView
            TitleCol.DataPropertyName       = GetPropertyName((Project e) => e.Name);
            DateStartedCol.DataPropertyName = GetPropertyName((Project e) => e.DateStarted);
            CommentsCol.DataPropertyName    = GetPropertyName((Project e) => e.Comments);

            // Set DataBindings for the Populations DataGridView
            PopNameCol.DataPropertyName = GetPropertyName((Population p) => p.Name);
            PopAgesCol.DataPropertyName = $"{GetPropertyName((Population p) => p.Ages)}.Count";
            PopConditionsCol.DataPropertyName = $"{GetPropertyName((Population p) => p.Conditions)}.Count";
            PopStrainsCol.DataPropertyName = $"{GetPropertyName((Population p) => p.Strains)}.Count";
            PopTissueTypesCol.DataPropertyName = $"{GetPropertyName((Population p) => p.TissueTypes)}.Count";
            PopCommentsCol.DataPropertyName = GetPropertyName((Population p) => p.Comments);
        }
        private void loadEntities() {
            // Select Entities from the database
            IList<Project> entities = _db.QueryOver<Project>().List();

            // Bind the result set to the DataGridView
            DbBoundList<Project> list = new DbBoundList<Project>(_db, entities) {
                Sortable      = true,
                AllowEdit     = true,
                AllowNew      = true,
                AllowRemove   = true,
                DbCreates     = true,
                DbUpdates     = false,  // We don't wanna update the database everytime user types a character!
                DbDeletes     = true
            };
            BindingSource bs = new BindingSource(list, null) { AllowNew = true };
            EntitiesDGV.DataSource = bs;
        }
        private void loadAssocPopulations(Project project) {
            // Select Entities from the database
            IList<Population> entities = _db.QueryOver<Population>()
                                            .JoinQueryOver<Project>(pop => pop.Projects)
                                            .Where(proj => proj.Guid == project.Guid)
                                            .List();

            // Bind the result set to the DataGridView
            DbBoundList<Population> list = new DbBoundList<Population>(_db, entities) {
                Sortable = true,
                AllowEdit = true,
                AllowNew = true,
                AllowRemove = true,
                DbCreates = true,
                DbUpdates = false,  // We don't wanna update the database everytime user types a character!
                DbDeletes = true
            };
            BindingSource bs = new BindingSource(list, null) { AllowNew = true };
            PopulationsDGV.DataSource = bs;
        }
        private void update(Project entity) {
            // Update the database
            // The try/catch block is need during row deletions for some reason
            try {
                using (ITransaction trans = _db.BeginTransaction()) {
                    _db.Update(entity);
                    trans.Commit();
                }
            }
            catch (IndexOutOfRangeException) { }
        }
        private void OnEntityUpdated(EntityUpdatedEventArgs args) {
            this.EntityUpdated?.Invoke(this, args);
        }

        private void AssocBtn_Click(object sender, EventArgs e) {
            int oldW = this.Size.Width;
            int oldH = this.Size.Height;

            bool collapsed = MainSplit.Panel2Collapsed;
            if (collapsed) {
                Size newSize = new Size(oldW, oldH + _oldPanelHeight + MainSplit.SplitterWidth + 3);    // +3 is a temporary fix, not sure what this number should really be
                this.Size = newSize;
                MainSplit.Panel2Collapsed = !collapsed;
            }
            else {
                _oldPanelHeight = MainSplit.Panel2.Height;
                Size newSize = new Size(oldW, oldH - _oldPanelHeight - MainSplit.SplitterWidth);
                this.Size = newSize;
                MainSplit.Panel2Collapsed = !collapsed;
            }

        }
    }

}
