using System.ComponentModel.DataAnnotations;

namespace Aspiron.MVC.Domain
{
    public class TableColumnModel
    {
        [Required]
        public required string FieldName { get; set; }

        private string _headerText = string.Empty;
        private string _shortText = string.Empty;

        // property for custom header text, use field name if not set
        public string HeaderText
        {
            get => string.IsNullOrEmpty(_headerText) ? FieldName : _headerText;
            set => _headerText = value;
        }

        // property for custom short text, use field name if not set
        public string ShortText
        {
            get => string.IsNullOrEmpty(_shortText) ? FieldName : _shortText;
            set => _shortText = value;
        }

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
        public string? MediaFormat { get; set; } = string.Empty;

        public TableColumnModel()
        {
            Visible = true;
            Width = 100;
            ResponsivePriority = 1;
            DataType = EnumBasicDataTypes.String;
        }
    }
}
