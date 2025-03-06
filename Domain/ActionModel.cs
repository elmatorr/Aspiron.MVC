using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class ActionModel
    {
        public string CssVisual { get; set; } // e.g., "btn-primary", "btn-secondary"
        public string CssAction { get; set; } // e.g., "edit-btn", "delete-btn"
        public string DisplayText { get; set; } // e.g., "Details", "Delete"

        public string? OnClick { get; set; } // e.g., "addToWatchlist"

        private string _idField = "Id"; // Default to "Id"
        // Field name to get the ID value from the row data 
        public string IdField
        {
            get => _idField;
            set => _idField = string.IsNullOrEmpty(value) ? "Id" : value;
        }
        public string Area { get; set; } // 
        public string Controller { get; set; } // 
        public string Action { get; set; } // 

        // Read-only property to construct the URL template

        public string UrlTemplate
        {
            get
            {
                return $"/{Area}/{Controller}/{Action}/__id__";
            }
        }

        public ActionModel()
        {
            CssVisual = "btn-primary";
            CssAction = "edit-btn";
            DisplayText = "Details";
            Area = "Asset";
            Controller = "Controller";
            Action = "Details";
        }
    }
}
