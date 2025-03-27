using Aspiron.MVC.Domain;

namespace Aspiron.MVC.Contracts
{
    public interface IConfigRepository<TKey>
    {
        public Task<BaseBrowserPageModel> GetConfigValueAsync(string operationName);
        public Task<Boolean> SetConfigValueAsync(string operationName, BaseBrowserPageModel pageModel);
        public Task<List<ConfigListItem<TKey>>> GetAllAsync();
    }
}
