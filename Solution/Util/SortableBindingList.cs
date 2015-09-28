using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Util {

    public interface IRemovable : IBindingList {
        event EventHandler<ListChangedEventArgs> BeforeRemove;
    }

    /// <summary>
    /// Provides a generic collection that supports data binding and additionally supports sorting.
    /// See http://msdn.microsoft.com/en-us/library/ms993236.aspx
    /// If the elements are IComparable it uses that; otherwise compares the ToString()
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class SortableBindingList<T> : BindingList<T>, IRemovable where T : class {
        // ENCAPSULATED FIELDS
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;
        private Dictionary<Type, IComparer> _typeComparers;
        private Dictionary<string, IComparer> _propertyComparers;

        // CONSTRUCTORS
        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public SortableBindingList() : base() {
            _typeComparers = new Dictionary<Type, IComparer>();
            _propertyComparers = new Dictionary<string, IComparer>(StringComparer.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="list">An <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
        public SortableBindingList(IList<T> list) : base(list) {
            _typeComparers = new Dictionary<Type, IComparer>();
            _propertyComparers = new Dictionary<string, IComparer>(StringComparer.OrdinalIgnoreCase);
        }

        // INTERFACE
        public event EventHandler<ListChangedEventArgs> BeforeRemove;

        /// <summary>
        /// Specifies if the list allows sorting or not.
        /// </summary>
        public bool Sortable { get; set; }
        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore {
            get { return this.Sortable; }
        }
        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        protected override bool IsSortedCore {
            get { return _isSorted; }
        }
        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore {
            get { return _sortDirection; }
        }
        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore {
            get { return _sortProperty; }
        }

        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented
        /// </summary>
        protected override void RemoveSortCore() {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
            _isSorted = false; //thanks Luca
        }
        /// <summary>
        /// Sorts the items if overridden in a derived class
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction) {
            _sortProperty = prop;
            _sortDirection = direction;

            List<T> list = Items as List<T>;
            if (list == null) return;

            list.Sort(Compare);

            _isSorted = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        /// <summary>
        /// Fire the BeforeRemove event on the item to about to be removed.
        /// </summary>
        /// <param name="index"></param>
        protected override void RemoveItem(int index) {
            if (this.BeforeRemove != null) {
                BeforeRemove(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
            }

            base.RemoveItem(index);
        }
        public void AddComparer<C>(IComparer comparer) {
            _typeComparers[typeof(C)] = comparer;
        }
        public void AddComparer(string property, IComparer comparer) {
            _propertyComparers[property] = comparer;
        }

        // HELPER FUNCTIONS
        private int Compare(T lhs, T rhs) {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }
        private int OnComparison(T lhs, T rhs) {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            IComparer comparer = null;

            if (lhsValue == null) {
                //nulls are equal
                return (rhsValue == null) ? 0 : -1;
            } else if (rhsValue == null) {
                //first has value, second doesn't
                return 1;
            } else if (lhsValue is IComparable) {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }

            // Look for a property specific comparer first.
            if (_propertyComparers.TryGetValue(_sortProperty.Name, out comparer)) {
                return comparer.Compare(lhsValue, rhsValue);
            }

            Type t = lhsValue.GetType();

            do {
                if (_typeComparers.TryGetValue(t, out comparer)) {
                    return comparer.Compare(lhsValue, rhsValue);
                }

                t = t.BaseType;
            } while (t != null);

            if (lhsValue.Equals(rhsValue)) {
                return 0; //both are the same
            }
            //not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }
    }
}
