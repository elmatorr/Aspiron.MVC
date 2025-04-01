using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class CondColorModel
    {

        // Smallest sequence is applied first
        public int Sequence { get; set; }

        // Condition to apply the color
        public string Condition { get; set; }

        // Background color
        public string BackColor { get; set; }

        // Font color
        public string FontColor { get; set; }

        public CondColorModel()
        {
            Sequence = 0;
            Condition = string.Empty;
            BackColor = string.Empty;
            FontColor = string.Empty;
        }
    }
}
