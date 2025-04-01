namespace Aspiron.MVC.Domain
{
    public class SearchModel
    {
        // Field name by which search will be performed
        public string FieldName { get; set; } = string.Empty;

        // Search value  
        public string Value { get; set; } = string.Empty;

        // Operator to be used in search
        public string Operator { get; set; } = string.Empty;

        // Data type of the field
        public string DataType { get; set; } = string.Empty;

    }
}
