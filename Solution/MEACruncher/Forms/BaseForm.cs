using System;
using System.Windows.Forms;

using NHibernate;

namespace MEACruncher.Forms {

    internal partial class BaseForm : Form {

        // ENCAPSULATED FIELDS
        protected ISession _db;
        protected EntityManager _entityMgr;
        protected MementoManager _mementoMgr;

        public BaseForm() {
            InitializeComponent();

            _db = Program.MeaDataDb.SessionFactory.OpenSession();
            _entityMgr = new EntityManager(_db);
            _mementoMgr = new MementoManager();
        }
    }

}
