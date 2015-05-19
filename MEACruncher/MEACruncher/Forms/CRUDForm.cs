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

        // CONSTRUCTORS
        public CRUDForm() {
            InitializeComponent();
        }

        // EVENT HANDLERS
        private void CRUDForm_Load(object sender, EventArgs e) {
            // Initialize members
            initialize();

            // Initialize form controls
            buildForm();
        }

        // FUNCTIONS
        private void initialize() {
            // Open an NHibernate session with the database
            _db = Program.MeaDataDb.Session;
        }
        protected virtual void buildForm() { }
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

            // Check that the numbers for month, day, and year are valid and are not after the current date
            bool isValidDate = false;
            try {
                int[] parts = dateStr.Split('/')
                                     .Select(p => Convert.ToInt32(p))
                                     .ToArray();
                DateTime dt = new DateTime(parts[2], parts[0], parts[1]);
                if (dt <= DateTime.Today)
                    isValidDate = true;
            }
            catch (ArgumentOutOfRangeException) { }

            // If any above condition fails, show an error dialog and return false, otherwise return true
            if (isValidDate)
                return true;
            string message = String.Format(ValidateRes.DateValue, DateTime.Today.ToShortDateString());
            MessageBox.Show(
                message,
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            return false;
        }
        protected bool isUnique(E entity) {
            // If this Entity is not unique, show an error message
            bool unique = EntityManager.IsUnique(entity);
            if (!unique) {
                string message = EntityManager.DuplicateError(entity);
                MessageBox.Show(
                    message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
            }
            return unique;
        }
        protected virtual void closeStuff() {
            this.Close();
        }

    }

}