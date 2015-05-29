using MeaData;
using MEACruncher.Properties;

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms.AddForms {

    internal partial class AddExperimentersForm : AddEntitiesForm {
        // CONSTRUCTORS
        public AddExperimentersForm() {
            InitializeComponent();
        }

        // FUNCTIONS
        protected override IList<Entity> loadEntities() {
            IList<Entity> entities = Session.QueryOver<Experimenter>()
                                            .OrderBy(e => e.FullName).Asc
                                            .List<Entity>();
            return entities;
        }
        protected override void buildForm() {
            base.buildForm();

            // Autofit columns but keep them resizable
            foreach (DataGridViewColumn column in EntitiesDGV.Columns)
                autofit(column);
            CommentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        protected override void createDataBindings() {
            base.createDataBindings();

            FullNameColumn.DataPropertyName = propertyName((Experimenter e) => e.FullName);
            EmailColumn.DataPropertyName = propertyName((Experimenter e) => e.WorkEmail);
            PhoneColumn.DataPropertyName = propertyName((Experimenter e) => e.WorkPhone);
            CommentsColumn.DataPropertyName = propertyName((Experimenter e) => e.Comments);
        }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) {
            base.formatEntities(e);
        }
        protected override IList<Entity> selectedEntities() {
            IList<Entity> entities = new List<Entity>();
            foreach (DataGridViewRow row in EntitiesDGV.SelectedRows)
                entities.Add(row.DataBoundItem as Experimenter);
            return entities;
        }
    }

}