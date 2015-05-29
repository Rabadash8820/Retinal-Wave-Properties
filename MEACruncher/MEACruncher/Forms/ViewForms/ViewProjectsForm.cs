using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using MEACruncher.Forms.EditForms;
using MEACruncher.Forms.NewForms;
using R = MEACruncher.Resources;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms.ViewForms {

    internal partial class ViewProjectsForm : ViewEntitiesForm {
        // CONSTRUCTORS
        public ViewProjectsForm() : base() {
            InitializeComponent();
        }

        // FUNCTIONS
        protected override IList<Entity> loadEntities() {
            IList<Entity> entities = Session.QueryOver<Project>()
                                         .OrderBy(p => p.Title).Asc
                                         .OrderBy(p => p.DateStarted).Asc
                                         .List<Entity>();
            return entities;
        }
        protected override void buildForm() {
            base.buildForm();

            // Resize dataGridView columns
            foreach (DataGridViewColumn column in EntitiesDGV.Columns)
                autofit(column);
            CommentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        protected override void createDataBindings() {
            base.createDataBindings();

            TitleColumn.DataPropertyName = propertyName((Project e) => e.Title);
            DateStartedColumn.DataPropertyName = propertyName((Project e) => e.DateStarted);
            CommentsColumn.DataPropertyName = propertyName((Project e) => e.Comments);
        }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) {
            base.formatEntities(e);

            // Display dates started as dates only (no time info)
            if (e.ColumnIndex != DateStartedColumn.Index)
                return;
            DateTime? dateTime = e.Value as DateTime?;
            e.Value = dateTime.Value.ToShortDateString();
        }
        protected override bool isCellValid(int index, string input) {
            if (index == TitleColumn.Index) {
                bool isValid = this.validText(
                    Resources.RegexRes.NonEmpty,
                    input,
                    Resources.ValidateRes.ProjectTitle);
                return isValid;
            }
            else if (index == DateStartedColumn.Index) {
                bool isValid = validDate(input);
                return isValid;
            }

            // Should never execute
            return false;
        }
        protected override void deleteDependents() { }

    }

}