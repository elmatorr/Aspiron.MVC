using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using ConfigUI.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigUI.Controllers
{
    public class VehicleController : BrowserMVCController<Vehicle>
    {
        public VehicleController(IConfigService config, ITranslationService translation, ICacheProvider cacheProvider)
            : base(config, translation, cacheProvider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
