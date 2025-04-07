using Aspiron.MVC.Domain;

namespace Aspiron.MVC.Contracts
{
    public interface IConfigRepository
    {
        public Task<BaseBrowserPageModel?> GetConfigValueAsync(string operationName, int? version = null);
        public Task<Boolean> SetConfigValueAsync(string operationName, BaseBrowserPageModel pageModel);
        public Task<List<ConfigListItem>> GetAllAsync();
    }
}
