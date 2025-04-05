using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using Aspiron.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace ConfigUI.Controllers
{
    public class ConfigurationController : BrowserMVCController<ConfigListItem>
    {
        public ConfigurationController(IConfigService config, ILogger<ConfigurationController> logger, ITranslationService translation, ICacheProvider cacheProvider)
            : base(config, logger, translation, cacheProvider)
        {

        }

        public override async Task<IEnumerable<ConfigListItem>> FetchData(Dictionary<string, string>? queryParams)
        {
            var configs = await config.GetAllAsync();
            return configs.AsEnumerable();
        }
    }
}
