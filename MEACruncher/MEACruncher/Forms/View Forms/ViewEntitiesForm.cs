using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using NHibernate;

namespace MEACruncher.Forms {

    // BASE CLASS
    internal abstract partial class ViewEntitiesForm<E> : Form where E : Entity {
        // VARIABLES
        protected ISession _db;
        protected BindingSource _entities;
        private static bool _initialized = false;
        private delegate string deletetion(E entity);
        private static Dictionary<Type, deletetion> _deleteWarning;

        // CONSTRUCTORS
        public ViewEntitiesForm() {
            InitializeComponent();
            _entities = new BindingSource();    // Apparently this needs to happen before derived classes call their InitializeComponent()
        }

        // EVENT HANDLERS
        protected void NewEntityForm_EntityCreated(object sender, EntityCreatedEventArgs<E> e) {
            _entities.Add(e.Entity);
        }

        // FUNCTIONS
        protected virtual void initialize() {
            // Initialize static members
            if (!_initialized)
                staticInitialize();

            // Initialize instance members
            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();
            _entities.DataSource = loadEntities();

            // Initialize form controls
            buildForm();
        }
        private void staticInitialize() {
            // Associated a duplicate Entity error with each Entity type
            _deleteWarning = new Dictionary<Type, deletetion>() {
                { typeof(Project),      e => String.Format(DeleteRes.ProjectWarning, (e as Project).Title) },
                { typeof(Experimenter), e => String.Format(DeleteRes.ExperimenterWarning, (e as Experimenter).FullName) },
            };

            _initialized = true;
        }
        protected abstract IList<E> loadEntities();
        protected abstract void buildForm();
        protected abstract void formatEntities(DataGridViewCellFormattingEventArgs e);
        protected abstract void deleteDependents();
        protected bool validate(string regexStr, string input, string message) {
            // If the input returns exactly one match, then return true
            regexStr = "^" + regexStr + "$";
            Regex regex = new Regex(regexStr);
            int numMatches = regex.Matches(input).Count;
            if (numMatches == 1) return true;

            // Otherwise display an error message box and return false
            message.Insert(0, String.Format(ValidateRes.Message, input));
            MessageBox.Show(
                message,
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            return false;
        }
        protected bool validDate(string dateStr) {
            // Return false if the string isn't in the right format
            bool isValidStr = this.validate(
                Resources.RegexRes.Date,
                dateStr,
                Resources.ValidateRes.Date);
            if (!isValidStr) return false;

            // If the numbers for month, day, and year are valid, then return true
            try {
                int[] parts = dateStr.Split('/')
                                     .Select(p => Convert.ToInt32(p))
                                     .ToArray();
                new DateTime(parts[2], parts[0], parts[1]);
                return true;
            }

            // Otherwise, show an error dialog and return false
            catch (ArgumentOutOfRangeException) {
                string message = String.Format(ValidateRes.DateValue, DateTime.Today);
                MessageBox.Show(
                    message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
        }
        protected bool entityDeleted(E entity) {
            // Show a dialog asking the user if they really want to delete the record
            string message = _deleteWarning[typeof(E)](entity);
            DialogResult result = MessageBox.Show(message,
                                                  Application.ProductName,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning,
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
                return false;

            // Remove record associated with this DataGridViewRow from the database
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Delete(entity);
                deleteDependents();
                trans.Commit();
            }
            return true;
        }
        protected void closeStuff() {
            _db.Close();
            this.Close();
        }
    }

    // DERIVED CLASSES (so VS designer will work)
    internal class IViewProjectsForm : ViewEntitiesForm<Project> {
        protected override void deleteDependents() { }
        protected override IList<Project> loadEntities() { return new List<Project>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }
    internal class IViewExperimentersForm : ViewEntitiesForm<Experimenter> {
        protected override void deleteDependents() { }
        protected override IList<Experimenter> loadEntities() { return new List<Experimenter>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }
    internal class IViewOrganizationsForm : ViewEntitiesForm<Organization> {
        protected override void deleteDependents() { }
        protected override IList<Organization> loadEntities() { return new List<Organization>(); }
        protected override void buildForm() { }
        protected override void formatEntities(DataGridViewCellFormattingEventArgs e) { }
    }

}