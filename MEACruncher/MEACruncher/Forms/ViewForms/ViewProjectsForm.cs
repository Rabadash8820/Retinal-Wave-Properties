using NHibernate;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Properties;
using MEACruncher.Forms;
using R = MEACruncher.Resources;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MEACruncher.Forms {

    internal partial class ViewProjectsForm : ViewEntitiesForm {
        // CONSTRUCTORS
        public ViewProjectsForm() : base() {
            InitializeComponent();
        }

        // ENCAPSULATED MEMBERS
        private DataGridViewTextBoxColumn TitleColumn;
        private DataGridViewTextBoxColumn DateStartedColumn;
        private DataGridViewTextBoxColumn CommentsColumn;

        // FUNCTIONS
        protected override IList<Entity> loadEntities() {
            IList<Entity> entities = Session.QueryOver<Project>()
                                            .OrderBy(p => p.Name).Asc
                                            .OrderBy(p => p.DateStarted).Asc
                                            .List<Entity>();
            return entities;
        }
        protected override void buildForm() {
            base.buildForm();

            // Define DataGridViewColumns
            this.TitleColumn.HeaderText = "Title";
            this.TitleColumn.MaxInputLength = 25;
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.Width = 58;

            this.DateStartedColumn.HeaderText = "Date Started";
            this.DateStartedColumn.Name = "DateStartedColumn";

            this.CommentsColumn.HeaderText = "Comments";
            this.CommentsColumn.Name = "CommentsColumn";

            // Add these columns to the DataGridView
            EntitiesDGV.Columns.AddRange(new DataGridViewColumn[] {
                TitleColumn,
                DateStartedColumn,
                CommentsColumn
            });

            // Resize dataGridView columns
            foreach (DataGridViewColumn column in EntitiesDGV.Columns)
                autofit(column);
            CommentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        protected override void createDataBindings() {
            base.createDataBindings();

            TitleColumn.DataPropertyName = propertyName((Project e) => e.Name);
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