using Aspiron.MVC.Contracts;
using Aspiron.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aspiron.MVC.Controllers
{
    // generic controller for table type pages

    public class BaseMVCController : Controller
    {
        protected IConfigService config { get; }
        protected ITranslationService translation { get; }

        protected ICacheProvider cacheProvider { get; }

        public BaseMVCController(IConfigService config, ITranslationService translation, ICacheProvider cacheProvider)
        {
            this.config = config;
            this.translation = translation;
            this.cacheProvider = cacheProvider;
        }
    }
}
