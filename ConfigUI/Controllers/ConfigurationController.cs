using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using Aspiron.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace ConfigUI.Controllers
{
    public class ConfigurationController : BrowserMVCController<BaseBrowserPageModel>
    {
        public ConfigurationController(IConfigService config, ITranslationService translation, ICacheProvider cacheProvider) : 
            base(config, translation, cacheProvider)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
