using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MeaData;
using Util;
using MEACruncher.Events;

namespace MEACruncher.Forms {

    internal partial class AddTissueTypeForm : BaseForm {

        public event EntitySelectedEventHandler TissueTypeSelected;

        // CONSTRUCTORS
        public AddTissueTypeForm() {
            InitializeComponent();

            loadEntities();
            
        }

        // HELPER FUNCTIONS
        private void loadEntities() {
            // Select Entities from the database
            IList<TissueType> entities = _db.QueryOver<TissueType>().List();

            // Bind the result set to the DataGridView
            DbBoundList<TissueType> list = new DbBoundList<TissueType>(_db, entities) {
                Sortable = true,
                AllowEdit = true,
                AllowNew = true,
                AllowRemove = true,
                HandleCreates = true,
                HandleUpdates = false,
                HandleDeletes = true
            };
            BindingSource bs = new BindingSource(list, null) { AllowNew = true };
        }
    }

}
