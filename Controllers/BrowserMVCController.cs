using Aspiron.MVC.Contracts;
using Aspiron.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aspiron.MVC.Controllers
{
    public class BrowserMVCController<TData> : BaseMVCController<TData>
    {
        protected BaseBrowserPageModel PageModel { get; set; }

        public BrowserMVCController(IConfigService config, ITranslationService translation, ICacheProvider cacheProvider) :
            base(config, translation, cacheProvider)
        {
            PageModel = new BaseBrowserPageModel();
            SetPageInfo();
        }

        public virtual async Task<IActionResult> IndexAsync()
        {
            await LoadColumnConfigurationAsync();
            return View(PageModel);
        }

        public virtual void SetPageInfo()
        {
            PageModel.PageTexts.OperationName = "BaseBrowser";
            PageModel.PageTexts.BrowserTabTitle = "Base Browser";
            PageModel.PageTexts.ControllerTitle = "Base Browser";
            PageModel.PageTexts.ActionTitle = "Index";
        }

        public virtual async Task<bool> LoadColumnConfigurationAsync()
        {
            PageModel = await config.GetConfigValueAsync("BaseBrowser:ColumnConfiguration");
            return PageModel != null;
        }

        // Method to fetch data (to be overridden in inherited controllers)
        public virtual async Task<IEnumerable<TData>> FetchData(Dictionary<string, string>? queryParams)
        {
            // Default implementation (can be empty or have some base logic)
            return new List<TData>();
        }
    }
}
