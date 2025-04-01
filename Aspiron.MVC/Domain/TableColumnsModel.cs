using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class TableColumnsModel
    {
        public List<TableColumnModel> Columns { get; set; }
        public List<ActionModel> Actions { get; set; } // New property for buttons
        public List<CondColorModel> CondColors { get; set; }

        public TableColumnsModel()
        {
            Columns = [];
            Actions = [];
            CondColors = [];
        }
    }
}
