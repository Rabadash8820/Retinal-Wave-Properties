using System.Collections.Generic;
using System.ComponentModel;

using NHibernate;

using MeaData;

namespace Util {

    public class DbBoundList<E> : SortableBindingList<E> where E : Entity {
        // ENCAPSULATE FIELDS
        private ISession _db;

        // CONSTRUCTORS
        public DbBoundList(ISession session, IList<E> list) : base(list) {
            _db = session;

            // Handle all CRUD changes by default
            HandleCreates = true;
            HandleUpdates = true;
            HandleDeletes = true;

            // Subscribe to the necessary change events
            this.ListChanged += SortableBindingList_ListChanged;
            this.BeforeRemove += SortableBindingList_BeforeRemove;
        }

        // INTERFACE
        public bool HandleCreates { get; set; }
        public bool HandleUpdates { get; set; }
        public bool HandleDeletes { get; set; }

        // EVENT HANDLERS
        private void SortableBindingList_ListChanged(object sender, ListChangedEventArgs e) {
            // Interact with the database depending on how the bound list was changed
            using (ITransaction trans = _db.BeginTransaction()) {
                switch (e.ListChangedType) {

                    // Add newly created Entity to the database
                    case ListChangedType.ItemAdded:
                        if (HandleCreates) {
                            E created = this.Items[e.NewIndex];
                            _db.Save(created);
                        }
                        break;

                    // Update changed Entity in the database
                    case ListChangedType.ItemChanged:
                        if (HandleUpdates) {
                            E updated = this.Items[e.NewIndex];
                            _db.Update(updated);
                        }
                        break;
                }

                trans.Commit();
            }
        }
        private void SortableBindingList_BeforeRemove(object sender, ListChangedEventArgs e) {
            if (!HandleDeletes)
                return;

            // Delete the removed Entity from the database
            E deleted = this.Items[e.NewIndex];
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Delete(deleted);
                trans.Commit();
            }
        }

    }

}
