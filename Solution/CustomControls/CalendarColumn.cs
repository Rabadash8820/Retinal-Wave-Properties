using System;
using System.Windows.Forms;

namespace Danware.Controls {

    public class CalendarColumn : DataGridViewColumn {
        // CONSTRUCTORS
        public CalendarColumn() : base(new DataGridViewCalendarCell()) { }

        // PROPERTIES
        public override DataGridViewCell CellTemplate {
            get { return base.CellTemplate; }
            set {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCalendarCell)))
                    throw new InvalidCastException("Must be a CalendarCell");
                base.CellTemplate = value;
            }
        }
    }

}