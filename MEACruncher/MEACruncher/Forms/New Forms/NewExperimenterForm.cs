using System;
using System.Linq;
using System.Collections.Generic;
using MeaData;
using MEACruncher.Events;
using MEACruncher.Resources;
using NHibernate;
using System.Windows.Forms;

namespace MEACruncher.Forms {
    internal partial class NewExperimenterForm : INewExperimenterForm {
        // CONSTRUCTORS
        public NewExperimenterForm() : base() { }

        // EVENT HANDLERS
        private void CreateButton_Click(object sender, EventArgs e) {
            this.createEntity();
        }
        private void CancelCreateButton_Click(object sender, EventArgs e) {
            this.closeStuff();
        }

        // OVERRIDE FUNCTIONS
        protected override void construct() {
            InitializeComponent();
            base.construct();
        }
        protected override Experimenter defaultEntity() {
            // Create/return a new Project with that title and the current date as the start date
            Experimenter entity = new Experimenter() {
                FullName  = DefaultRes.ExperimenterName,
                WorkEmail = DefaultRes.ExperimenterEmail,
                WorkPhone = DefaultRes.ExperimenterPhone,
                Comments  = DefaultRes.ExperimenterComments
            };
            return entity;
        }
        protected override void buildForm() {
            TitleTextbox.DataBindings.Add("Text", _entity, "FullName");
            CommentsTextbox.DataBindings.Add("Text", _entity, "Comments");
        }
        protected override bool isUnique() {
            int numEntities = _db.QueryOver<Experimenter>()
                                 .Where(e =>
                                     e.FullName  == _entity.FullName &&
                                     e.WorkEmail == _entity.WorkEmail &&
                                     e.WorkPhone == _entity.WorkPhone)
                                 .RowCount();
            return (numEntities == 0);
        }

    }

}