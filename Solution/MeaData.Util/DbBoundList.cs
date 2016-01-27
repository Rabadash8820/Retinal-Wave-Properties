using System.Collections.Generic;
using System.ComponentModel;

using NHibernate;

using MeaData;

namespace MeaData.Util {

    public class DbBoundList<T> : SortableBindingList<T> where T : class {
        // HIDDEN FIELDS
        private ISession _sess;

        // CONSTRUCTORS
        public DbBoundList(ISession session, IList<T> list) : base(list) {
            _sess = session;

            // Subscribe to the necessary change events
            this.ListChanged += SortableBindingList_ListChanged;
            this.BeforeRemove += SortableBindingList_BeforeRemove;
        }

        // PROPERTIES
        public bool DbCreates { get; set; } = true;
        public bool DbUpdates { get; set; } = true;
        public bool DbDeletes { get; set; } = true;

        // EVENT HANDLERS
        private void SortableBindingList_ListChanged(object sender, ListChangedEventArgs e) {
            T item = (e.ListChangedType == ListChangedType.ItemDeleted) ? default(T) : this.Items[e.NewIndex];

            switch (e.ListChangedType) {

                // Add a newly created item to the database
                case ListChangedType.ItemAdded:
                    if (DbCreates)
                        create(item);
                    break;

                // Update a changed item in the database
                case ListChangedType.ItemChanged:
                    if (DbUpdates)
                        update(item);
                    break;
            }
        }
        private void SortableBindingList_BeforeRemove(object sender, ListChangedEventArgs e) {
            // Delete the removed Entity from the database
            T item = this.Items[e.NewIndex];
            if (DbDeletes)
                delete(item);
        }

        // HELPER FUNCTIONS
        private void create(T item) {
            using (ITransaction trans = _sess.BeginTransaction()) {
                _sess.Save(item);
                trans.Commit();
            }
        }
        private void update(T item) {
            using (ITransaction trans = _sess.BeginTransaction()) {
                _sess.Update(item);
                trans.Commit();
            }
        }
        private void delete(T item) {
            using (ITransaction trans = _sess.BeginTransaction()) {
                _sess.Delete(item);
                trans.Commit();
            }
        }

    }

}
