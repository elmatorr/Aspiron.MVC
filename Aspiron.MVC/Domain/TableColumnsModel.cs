using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class TableColumnsModel
    {
        private List<TableColumnModel> _columns;

        // As most UI table components create the columns in the order they are defined, we need to sort them by sequence
        // and if same sequence then by field name, hidden columns are always at the end
        // Sorted getter
        public List<TableColumnModel> Columns
        {
            get
            {
                return _columns
                    .OrderByDescending(c => c.Visible)
                    .ThenBy(c => c.Sequence)
                    .ThenBy(c => c.FieldName, StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }
            set
            {
                _columns = value ?? new List<TableColumnModel>();
            }
        }

        public List<ActionModel> Actions { get; set; } // New property for buttons

        public TableColumnsModel()
        {
            _columns = [];
            Actions = [];
        }
    }
}
