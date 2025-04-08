using Aspiron.MVC.Contracts;
using Aspiron.MVC.Domain;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Aspiron.MVC.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;
        private readonly ITranslationService _translationService;

        public ConfigService(IConfigRepository configRepository, ITranslationService translationService)
        {
            _configRepository = configRepository;
            _translationService = translationService;
        }

        public async Task<List<ConfigListItem>> GetAllAsync()
        {
            return await _configRepository.GetAllAsync();
        }

        public async Task<BaseBrowserPageModel?> GetConfigValueAsync(string operationName, int? version = null)
        {
            var result =  await _configRepository.GetConfigValueAsync(operationName, version);
            if (result == null) return result;

            result.PageTexts.BrowserTabTitle = await _translationService.GetTranslationAsync(result.PageTexts.BrowserTabTitle, result.PageTexts.BrowserTabTitle);
            result.PageTexts.ActionDescription = await _translationService.GetTranslationAsync(result.PageTexts.ActionDescription, result.PageTexts.ActionDescription);
            result.PageTexts.ActionTitle = await _translationService.GetTranslationAsync(result.PageTexts.ActionTitle, result.PageTexts.ActionTitle);
            result.PageTexts.ControllerTitle = await _translationService.GetTranslationAsync(result.PageTexts.ControllerTitle, result.PageTexts.ControllerTitle);

            foreach (var column in result.TableColumns.Columns)
            {
                column.HeaderText = await _translationService.GetTranslationAsync(column.HeaderText, column.HeaderText);
                column.ShortText= await _translationService.GetTranslationAsync(column.ShortText, column.ShortText);
            }

            foreach (var action in result.TableColumns.Actions)
            {
                action.DisplayText = await _translationService.GetTranslationAsync(action.DisplayText, action.DisplayText);
            }

            return result;
        }

        public async Task<bool> SetConfigValueAsync(string operationName, BaseBrowserPageModel pageModel)
        {
            return await _configRepository.SetConfigValueAsync(operationName, pageModel);
        }
    }
}
