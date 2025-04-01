
namespace Aspiron.MVC.Domain
{
    public class ConfigListItem
    {
        // Key of the configuration used for identification purposes
        // For example, controller name or model name depending on implementation
        public string Key { get; set; } = string.Empty;

        // Name of the configuration used for display purposes
        public string Name { get; set; } = string.Empty;

    }
}
