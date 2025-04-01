using System.ComponentModel.DataAnnotations;

namespace Aspiron.MVC.Domain
{
    public class TableColumnModel
    {
        [Required]
        public required string FieldName { get; set; }

        // property for custom header text
        public string HeaderText { get; set; }

        // property for custom short text
        public string ShortText { get; set; }

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

        // media format of column, depends on UI table component
        // e.g. hideAtMedia:'(min-width: 500px)'
        public string MediaFormat { get; set; }

        public TableColumnModel()
        {
            Visible = true;
            Width = 100;
            ResponsivePriority = 1;
            DataType = EnumBasicDataTypes.String;
        }
    }
}
