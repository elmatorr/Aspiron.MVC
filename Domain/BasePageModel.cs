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

        public BasePageModel()
        {
            Version = 1;
            PageTexts = new PageTextModel();
        }
    }
}
