namespace Aspiron.MVC.Domain
{
    public class BaseBrowserPageModel : BasePageModel
    {
        public TableColumnsModel TableColumns { get; set; } // New property for table columns

        public List<CondColorModel> CondColors { get; set; }
        public BaseBrowserPageModel()
        {
            TableColumns = new TableColumnsModel();
            //Action = new ActionModel();
            CondColors = [];
        }
    }
}
