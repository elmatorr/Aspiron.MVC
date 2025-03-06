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
        public TableColumnsModel()
        {
            Columns = new List<TableColumnModel>();
            Actions = new List<ActionModel>();
        }
    }
}
