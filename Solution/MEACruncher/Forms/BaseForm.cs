using System.Windows.Forms;

using NHibernate;

using MeaData.Util;

namespace MEACruncher.Forms {

    internal partial class BaseForm : Form {

        // ENCAPSULATED FIELDS
        protected ISession _db;
        protected EntityManager _entityMgr;
        protected MementoManager _mementoMgr;

        // CONSTRUCTORS
        public BaseForm() {
            InitializeComponent();

            _db = Program.MeaDataDb.OpenSession();
            _entityMgr = new EntityManager(_db);
            _mementoMgr = new MementoManager();
        }
    }

}
