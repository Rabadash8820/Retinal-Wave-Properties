using System;
using System.Windows.Forms;

using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;

using NHibernate;
using static MeaData.Util.Util;

namespace MEACruncher.Forms {

    internal partial class NewProjectForm : BaseForm {

        // ENCAPSULATED DATA
        private BindingSource _boundEntity;

        // INTERFACE
        public NewProjectForm() {
            InitializeComponent();

            // Bind controls to a new, default Entity
            _boundEntity = new BindingSource();
            _boundEntity.DataSource = new Project() {
                Name = DefaultRes.ProjectTitle,
                DateStarted = DateTime.Today,
                Comments = DefaultRes.ProjectComments
            };
            setDataBindings();

            // Adjust the DateTimePicker
            DateStartedPicker.MaxDate = DateTime.Today;
        }
        public event EventHandler<EntityCreatedEventArgs> EntityCreated;

        // EVENT HANDLERS
        private void UndoBtn_Click(object sender, EventArgs e) {

        }
        private void RedoBtn_Click(object sender, EventArgs e) {

        }
        private void CreateBtn_Click(object sender, EventArgs e) {
            // Validate Entity data provided by the user
            Project entity = _boundEntity.DataSource as Project;
            if (entity.Name == "") {
                MessageBox.Show(
                    ValidateRes.ProjectTitle,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                TitleTxt.Focus();
                return;
            }

            // If the Entity would create a duplicate in the database, show an error pop-up and return
            bool unique = _entityMgr.IsUnique(entity);
            if (!unique) {
                MessageBox.Show(
                    _entityMgr.DuplicateErrorMsg(entity),
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            // Otherwise, add this new Entity to the database
            //using (ITransaction trans = _db.BeginTransaction()) {
            //    _db.Save(entity);
            //    trans.Commit();
            //}

            // Fire the EntityCreated event and close
            this.OnEntityCreated(entity);
            this.Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        // HELPER FUNCTIONS
        private void setDataBindings() {
            TitleTxt.DataBindings.Add(
                GetPropertyName((TextBox c) => c.Text),
                _boundEntity,
                GetPropertyName((Project e) => e.Name));
            DateStartedPicker.DataBindings.Add(
                GetPropertyName((DateTimePicker c) => c.Value),
                _boundEntity,
                GetPropertyName((Project e) => e.DateStarted));
            CommentsTxt.DataBindings.Add(
                GetPropertyName((TextBox c) => c.Text),
                _boundEntity,
                GetPropertyName((Project e) => e.Comments));
        }
        private void OnEntityCreated(Project entity) {
            if (this.EntityCreated == null)
                return;

            Delegate[] subscribers = this.EntityCreated.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                EntityCreatedEventArgs args = new EntityCreatedEventArgs(entity);
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }

    }
}
