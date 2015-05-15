using System;
using MeaData;
using NHibernate;
using System.Linq;
using System.Windows.Forms;
using MEACruncher.Resources;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MEACruncher.Forms {

    public abstract partial class CRUDForm<E> : Form where E : Entity {
        // VARIABLES
        protected ISession _db;
        private static bool _initialized = false;
        private delegate string duplication(E entity);
        private delegate bool uniqueness(E entity);
        private static Dictionary<Type, duplication> _duplicateError;
        private Dictionary<Type, uniqueness> _uniqueness;

        // CONSTRUCTORS
        public CRUDForm() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void CRUDForm_Load(object sender, EventArgs e) {
            this.initialize();
        }

        // FUNCTIONS
        protected void initialize() {
            // Initialize static and instance members
            if (!_initialized)
                staticInit();
            instanceInit();

            // Initialize form controls
            buildForm();
        }
        private static void staticInit() {
            // Associated error messages with each Entity type
            _duplicateError = new Dictionary<Type, duplication>(){
                { typeof(Project),      e => String.Format(DuplicateRes.ProjectError, (e as Project).Title, (e as Project).DateStarted.ToShortDateString()) },
                { typeof(Experimenter), e => String.Format(DuplicateRes.ExperimenterError, (e as Experimenter).FullName) },
            };

            _initialized = true;
        }
        private void instanceInit() {
            // Open an NHibernate session with the database
            _db = DbManager.SessionFactory(Database.MeaData).OpenSession();

            // For each Entity type, associate a method to determine if it is duplicating an Entity already in the database
            _uniqueness = new Dictionary<Type, uniqueness>() {
                // Projects
                { typeof(Project), e => {
                    Project e1 = e as Project;
                    return _db.QueryOver<Project>()
                              .Where(e2 =>
                                  e2.Title == e1.Title &&
                                  e2.DateStarted.Date == e1.DateStarted.Date)
                              .RowCount() == 0; }
                },

                // Experimenters
                { typeof(Experimenter), e => {
                    Experimenter e1 = e as Experimenter;
                    return _db.QueryOver<Experimenter>()
                              .Where(e2 =>
                                  e2.FullName == e1.FullName &&
                                  e2.WorkEmail == e1.WorkEmail &&
                                  e2.WorkPhone == e1.WorkPhone)
                              .RowCount() == 0; }
                },
            };
        }
        protected abstract void buildForm();
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
        protected bool isUnique(E entity) {
            // If this Entity is not unique, show an error message
            bool unique = _uniqueness[typeof(E)](entity);
            if (!unique) {
                string message = _duplicateError[typeof(E)](entity) + "\n\n" + DuplicateRes.Message;
                MessageBox.Show(
                    message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
            }
            return unique;
        }
        protected void closeStuff() {
            _db.Close();
            this.Close();
        }


    }

}