using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class BasePageModel
    {
        public int Version { get; set; }

        public PageTextModel PageTexts { get; set; }

        // page default layout
        public string Layout { get; set; } = string.Empty;

        public BasePageModel()
        {
            Version = 1;
            PageTexts = new PageTextModel();
            // for now using Skote admin template approach
            Layout = "~/Views/Shared/_Layout.cshtml";
        }
    }
}
