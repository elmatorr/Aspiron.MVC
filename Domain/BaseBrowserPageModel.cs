using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class BaseBrowserPageModel : BasePageModel
    {
        public TableColumnsModel TableColumns { get; set; } // New property for table columns

        public ActionModel Action { get; set; } // New property for buttons

        public BaseBrowserPageModel() {
            TableColumns = new TableColumnsModel();
            Action = new ActionModel();
        }
    }
}
