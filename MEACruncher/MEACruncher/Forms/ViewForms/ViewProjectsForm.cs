using MeaData;

using NHibernate;

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MEACruncher.Forms {

    public partial class ViewProjectsForm : Form {

        // ENCAPSULATED MEMBERS
        private ISession _db;

        // INTERFACE
        public ViewProjectsForm() {
            InitializeComponent();

            _db = Program.MeaDataDb.Session;

            setDataBindings();
        }

        // EVENT HANDLERS
        private void EntitiesDGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            Project entity = EntitiesDGV.Rows[e.RowIndex].DataBoundItem as Project;
            e.Cancel = !isUnique(entity);
        }
        private void EntitiesDGV_RowValidated(object sender, DataGridViewCellEventArgs e) {
            using (ITransaction trans = _db.BeginTransaction()) {
                DataGridViewRow row = EntitiesDGV.Rows[e.RowIndex];
                Project entity = row.DataBoundItem as Project;
                _db.Update(entity);
                row.ErrorText = "";
            }
        }

        // HELPER FUNCTIONS
        private void setDataBindings() {
            // Set data bindings on the DataGridViewColumns
            TitleCol.DataPropertyName = Util.GetPropertyName((Project p) => p.Name);
            DateStartedCol.DataPropertyName = Util.GetPropertyName((Project p) => p.DateStarted);
            CommentsCol.DataPropertyName = Util.GetPropertyName((Project p) => p.Comments);

            // Set the DataGridView's DataSource
            BindingSource bs = new BindingSource();
            IList<Project> entities = _db.QueryOver<Project>().List();
            bs.DataSource = entities;
            EntitiesDGV.DataSource = bs;
        }
        private bool isUnique(Project p) {
            return true;
        }

        private void ViewProjectsForm_FormClosed(object sender, FormClosedEventArgs e) {
            _db.Close();
        }

    }

}
