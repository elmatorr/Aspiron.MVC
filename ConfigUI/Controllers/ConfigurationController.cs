using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using Aspiron.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Configuration key is required.");
            }
            // Try to parse the version from the config name, for example here Configuration.Browser.v1.json version is 1
            var result = ParseConfigFilename(id);

            //Console.WriteLine(result.OperationName); // Output: Configuration.Browser
            //Console.WriteLine(result.Version);       // Output: 1

            if (result.Version == 0)
            {
                return BadRequest("Invalid configuration file name.");
            }

            var configModel = await config.GetConfigValueAsync(result.OperationName, result.Version);

            if (configModel == null)
            {
                return NotFound($"No configuration found for key: {id}");
            }

            ViewBag.ConfigKey = id; // store key for later save postback

            return View(configModel);
        }

        public (string OperationName, int Version) ParseConfigFilename(string filename)
        {
            var match = Regex.Match(filename, @"^(.*?)\.v(\d+)\.json$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string operationName = match.Groups[1].Value;
                int version = int.Parse(match.Groups[2].Value);
                return (operationName, version);
            }
            return (string.Empty, 0);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(string id, BaseBrowserPageModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ConfigKey = id;
                return View(model); // Return with validation messages
            }

            var result = ParseConfigFilename(id);
            if (result.Version == 0)
            {
                return BadRequest("Invalid configuration file name.");
            }

            var success = await config.SetConfigValueAsync(result.OperationName, model);
            if (!success)
            {
                ModelState.AddModelError("", "Failed to save configuration.");
                ViewBag.ConfigKey = id;
                return View(model);
            }

            TempData["SuccessMessage"] = "Configuration saved successfully!";
            return RedirectToAction(nameof(Index));
        }


    }
}
