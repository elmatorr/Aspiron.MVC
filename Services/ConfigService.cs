using Aspiron.MVC.Contracts;
using Aspiron.MVC.Domain;

namespace Aspiron.MVC.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public async Task<List<BaseBrowserPageModel>> GetAllAsync()
        {
            return await _configRepository.GetAllAsync();
        }

        public async Task<BaseBrowserPageModel> GetConfigValueAsync(string operationName)
        {
            return await _configRepository.GetConfigValueAsync(operationName);
        }

        public async Task<bool> SetConfigValueAsync(string operationName, BaseBrowserPageModel pageModel)
        {
            return await _configRepository.SetConfigValueAsync(operationName, pageModel);
        }
    }
}
