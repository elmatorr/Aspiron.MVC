using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class PageTextModel
    {
        // Business Operation what this model corresponds to, can be used for billing or rights
        public string OperationName { get; set; } = string.Empty;

        // text to show on web browser tab
        public string BrowserTabTitle { get; set; } = string.Empty;

        // text to show for controller, ex: User
        public string ControllerTitle { get; set; } = string.Empty;

        // action accessed, ex: Edit
        public string ActionTitle { get; set; } = string.Empty;

        // action description text
        public string ActionDescription { get; set; } = string.Empty;
    }
}
