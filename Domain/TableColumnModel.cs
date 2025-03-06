using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Domain
{
    public class TableColumnModel
    {
        [Required]
        public required string FieldName { get; set; }
        public string HeaderText { get; set; } // New property for custom header text

        // sequence of columns in table
        public int Sequence { get; set; }

        // whether column is visible or not
        public bool Visible { get; set; }

        // width of column  
        public int Width { get; set; }

        // priority of column in responsive mode
        public int ResponsivePriority { get; set; }

        // data type of column
        public EnumBasicDataTypes DataType { get; set; }



        public TableColumnModel()
        {
            Visible = true;
            Width = 100;
            ResponsivePriority = 1;
            DataType = EnumBasicDataTypes.String;
        }
    }
}
