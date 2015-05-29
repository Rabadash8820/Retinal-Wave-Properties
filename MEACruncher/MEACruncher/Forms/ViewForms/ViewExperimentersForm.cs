using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using R = MEACruncher.Resources;
using MEACruncher.Forms.NewForms;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms.ViewForms {

    internal partial class ViewExperimentersForm : ViewEntitiesForm {
        // CONSTRUCTORS
        public ViewExperimentersForm() : base() {
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
        protected override bool isCellValid(int colIndex, string input) {
            // Validate the cell value based on which column it is in
            if (colIndex == FullNameColumn.Index) {
                bool isValid = this.validText(
                    Resources.RegexRes.PersonName,
                    input,
                    Resources.ValidateRes.ExperimenterFullName);
                return isValid;
            }
            else if (colIndex == EmailColumn.Index) {
                bool isValid = this.validText(
                    Resources.RegexRes.EmailAddress,
                    input,
                    Resources.ValidateRes.EmailAddress);
                return isValid;
            }
            else if (colIndex == PhoneColumn.Index) {
                bool isValid = this.validText(
                    Resources.RegexRes.PhoneNumber,
                    input,
                    Resources.ValidateRes.PhoneNumber);
                return isValid;
            }

            // Should never execute
            return false;
        }
        protected override void deleteDependents() { }
        
    }

}