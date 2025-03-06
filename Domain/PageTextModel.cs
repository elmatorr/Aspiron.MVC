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

        // for now using Skote admin template approach
        // ViewBag.Title = "Data Tables";
        // text to show on web browser tab
        public string BrowserTabTitle { get; set; } = string.Empty;

        // ViewBag.pTitle = "Data Tables";
        // text to show for controller, ex: User
        public string ControllerTitle { get; set; } = string.Empty;

        // ViewBag.pageTitle = "Tables";
        // action accessed, ex: Edit
        public string ActionTitle { get; set; } = string.Empty;

        // action description text
        public string ActionDescription { get; set; } = string.Empty;

        // page default layout
        public string Layout { get; set; } = string.Empty;

        public PageTextModel() {
            // for now using Skote admin template approach
            Layout = "~/Views/Shared/_Layout.cshtml";
        }
    }
}
