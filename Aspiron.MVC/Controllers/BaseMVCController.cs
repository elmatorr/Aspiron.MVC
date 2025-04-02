using Aspiron.MVC.Contracts;
using Aspiron.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspiron.MVC.Controllers
{
    // generic controller for table type pages

    public class BaseMVCController : Controller
    {
        protected IConfigService config { get; }
        protected ITranslationService translation { get; }
        protected ICacheProvider cacheProvider { get; }
        protected ILogger logger { get; }

        public BaseMVCController(IConfigService config, ILogger<BaseMVCController> logger, ITranslationService translation, ICacheProvider cacheProvider)
        {
            this.config = config;
            this.translation = translation;
            this.cacheProvider = cacheProvider;
            this.logger = logger;
        }
    }
}
