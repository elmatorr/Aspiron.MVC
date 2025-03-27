
namespace Aspiron.MVC.Domain
{
    public class ConfigListItem<TKey>
    {
        // Depending on repository type TKey property can be of different types
        // For example, if repository is using Entity Framework, TKey can be int
        // If repository is using file system, TKey can be string
        public TKey Key { get; set; }

        // Name of the configuration used for display purposes
        public string Name { get; set; }

    }
}
