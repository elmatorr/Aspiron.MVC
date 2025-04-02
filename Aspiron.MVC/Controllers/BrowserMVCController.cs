using Aspiron.MVC.Contracts;
using Aspiron.MVC.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aspiron.MVC.Controllers
{
    public class BrowserMVCController<TData> : BaseMVCController
    {
        protected BaseBrowserPageModel PageModel { get; set; }
        protected string ViewName { get; set; } = "BrowserMVC";

        public BrowserMVCController(IConfigService config, ILogger<BrowserMVCController<TData>> logger, ITranslationService translation, ICacheProvider cacheProvider) :
            base(config, logger, translation, cacheProvider)
        {
            PageModel = new BaseBrowserPageModel();
            SetPageInfo();
        }

        public virtual async Task<IActionResult> IndexAsync()
        {
            var pageConf = await LoadColumnConfigurationAsync();
            return View(ViewName, pageConf);
        }

        public virtual void SetPageInfo()
        {
            var controllerName = GetType().Name.Replace("Controller", ""); // Remove "Controller" suffix
            PageModel.PageTexts.OperationName = $"{controllerName}.Browser";
            PageModel.PageTexts.BrowserTabTitle = $"{controllerName} Browser";
            PageModel.PageTexts.ControllerTitle = controllerName;
            PageModel.PageTexts.ActionTitle = "Index";
        }

        public virtual async Task<BaseBrowserPageModel> LoadColumnConfigurationAsync()
        {
            var pageConf = await config.GetConfigValueAsync(PageModel.PageTexts.OperationName);

            if (pageConf == null)
            {
                pageConf = await SaveDefaultConfiguration();

            }
            return pageConf;
        }

        // Method to fetch data (to be overridden in inherited controllers)
        public virtual async Task<IEnumerable<TData>> FetchData(Dictionary<string, string>? queryParams)
        {
            // Default implementation (can be empty or have some base logic)
            return new List<TData>();
        }

        public async Task<BaseBrowserPageModel> SaveDefaultConfiguration()
        {

            var pageConf = new BaseBrowserPageModel();
            pageConf.PageTexts.OperationName = PageModel.PageTexts.OperationName;
            pageConf.PageTexts.BrowserTabTitle = PageModel.PageTexts.BrowserTabTitle;
            PageModel.PageTexts.ControllerTitle = PageModel.PageTexts.ControllerTitle;
            PageModel.PageTexts.ActionTitle = PageModel.PageTexts.ActionTitle;


            int columnCounter = 0;

            foreach (var prop in typeof(TData).GetProperties())
            {
                var column = new TableColumnModel
                {
                    FieldName = prop.Name,
                    Sequence = columnCounter,
                    Visible = true,
                    Width = 100,
                    DataType = MapToEnumBasicDataTypes(prop.PropertyType)
                };
                pageConf.TableColumns.Columns.Add(column);
                columnCounter++;

                // Add button configurations if needed
                if (prop.Name == "Id") // Example condition to add buttons
                {
                    pageConf.TableColumns.Actions.Add(new ActionModel
                    {
                        CssAction = "edit-btn",
                        DisplayText = "Edit",
                        //UrlTemplate = "@Url.Action(\"Details\", \"Vehicle\", new { area = \"Insurance\", id = \"__id__\" })"
                    });

                }
            }

            try
            {
                await config.SetConfigValueAsync(PageModel.PageTexts.OperationName, pageConf);
            }
            catch (Exception)
            {
                // TODO: Log and handle exception. Maybe it is ok to just to continue so that page is loaded even if configuration saving fails
                throw;
            }

            return pageConf;
        }

        private EnumBasicDataTypes MapToEnumBasicDataTypes(Type type)
        {
            if (type == typeof(bool)) return EnumBasicDataTypes.Boolean;
            if (type == typeof(byte)) return EnumBasicDataTypes.Byte;
            if (type == typeof(char)) return EnumBasicDataTypes.Char;
            if (type == typeof(DateTime)) return EnumBasicDataTypes.DateTime;
            if (type == typeof(DateTimeOffset)) return EnumBasicDataTypes.DateTimeOffset;
            if (type == typeof(decimal)) return EnumBasicDataTypes.Decimal;
            if (type == typeof(double)) return EnumBasicDataTypes.Double;
            if (type == typeof(short)) return EnumBasicDataTypes.Int16;
            if (type == typeof(int)) return EnumBasicDataTypes.Int32;
            if (type == typeof(long)) return EnumBasicDataTypes.Int64;
            if (type == typeof(sbyte)) return EnumBasicDataTypes.SByte;
            if (type == typeof(float)) return EnumBasicDataTypes.Single;
            if (type == typeof(string)) return EnumBasicDataTypes.String;
            if (type == typeof(ushort)) return EnumBasicDataTypes.UInt16;
            if (type == typeof(uint)) return EnumBasicDataTypes.UInt32;
            if (type == typeof(ulong)) return EnumBasicDataTypes.UInt64;
            return EnumBasicDataTypes.String; // Default to string if type is not matched
        }
    }
}
