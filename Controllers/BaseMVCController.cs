using Aspiron.MVC.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Controllers
{
    public class BaseMVCController<TData> : Controller
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
