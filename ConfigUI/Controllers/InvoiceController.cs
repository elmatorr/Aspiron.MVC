using Aspiron.MVC.Contracts;
using Aspiron.MVC.Controllers;
using ConfigUI.Demo.Models;

namespace ConfigUI.Controllers
{
    public class InvoiceController : BrowserMVCController<Invoice>
    {
        public InvoiceController(IConfigService config, ILogger<InvoiceController> logger, ITranslationService translation, ICacheProvider cacheProvider)
            : base(config, logger, translation, cacheProvider)
        {
        }
        public override Task<IEnumerable<Invoice>> FetchData(Dictionary<string, string>? queryParams)
        {
            // AI (ChatGPT) generated example data to simulate fetching data from a database
            var invoices = new Dictionary<int, (string InvoiceNumber, string CustomerName, DateTime CreatedAt, DateTime DueDate, decimal Amount, decimal TaxAmount, string Status)>
            {
                { 1, ("INV-10001", "John Doe", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(10), 200.00m, 20.00m, "Paid") },
                { 2, ("INV-10002", "Jane Smith", DateTime.Now.AddDays(-25), DateTime.Now.AddDays(15), 350.00m, 35.00m, "Pending") },
                { 3, ("INV-10003", "Acme Corp", DateTime.Now.AddDays(-40), DateTime.Now.AddDays(5), 500.00m, 50.00m, "Overdue") },
                { 4, ("INV-10004", "XYZ Ltd.", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(20), 150.00m, 15.00m, "Paid") },
                { 5, ("INV-10005", "MegaMart", DateTime.Now.AddDays(-35), DateTime.Now.AddDays(7), 425.00m, 42.50m, "Pending") },
                { 6, ("INV-10006", "Tech Innovations", DateTime.Now.AddDays(-50), DateTime.Now.AddDays(-5), 600.00m, 60.00m, "Overdue") },
                { 7, ("INV-10007", "Home Supplies", DateTime.Now.AddDays(-15), DateTime.Now.AddDays(25), 180.00m, 18.00m, "Paid") },
                { 8, ("INV-10008", "Alpha Traders", DateTime.Now.AddDays(-28), DateTime.Now.AddDays(12), 275.00m, 27.50m, "Cancelled") },
                { 9, ("INV-10009", "Beta Solutions", DateTime.Now.AddDays(-22), DateTime.Now.AddDays(18), 325.00m, 32.50m, "Pending") },
                { 10, ("INV-10010", "Gamma Inc.", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(30), 480.00m, 48.00m, "Paid") },
                { 11, ("INV-10011", "Delta Enterprises", DateTime.Now.AddDays(-45), DateTime.Now.AddDays(3), 550.00m, 55.00m, "Overdue") },
                { 12, ("INV-10012", "Omega Systems", DateTime.Now.AddDays(-18), DateTime.Now.AddDays(22), 225.00m, 22.50m, "Pending") },
                { 13, ("INV-10013", "Sunrise Builders", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(10), 375.00m, 37.50m, "Paid") },
                { 14, ("INV-10014", "Eco Green", DateTime.Now.AddDays(-12), DateTime.Now.AddDays(28), 195.00m, 19.50m, "Cancelled") },
                { 15, ("INV-10015", "Fast Logistics", DateTime.Now.AddDays(-25), DateTime.Now.AddDays(15), 410.00m, 41.00m, "Pending") },
                { 16, ("INV-10016", "Global Networks", DateTime.Now.AddDays(-38), DateTime.Now.AddDays(6), 600.00m, 60.00m, "Overdue") },
                { 17, ("INV-10017", "Horizon Marketing", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(20), 300.00m, 30.00m, "Paid") },
                { 18, ("INV-10018", "Innovate Labs", DateTime.Now.AddDays(-27), DateTime.Now.AddDays(13), 455.00m, 45.50m, "Pending") },
                { 19, ("INV-10019", "Skyline Ventures", DateTime.Now.AddDays(-14), DateTime.Now.AddDays(26), 250.00m, 25.00m, "Paid") },
                { 20, ("INV-10020", "Vertex Solutions", DateTime.Now.AddDays(-48), DateTime.Now.AddDays(2), 580.00m, 58.00m, "Overdue") }
            };

            var demoInvoices = invoices.Select(kv => new Invoice
            {
                Id = kv.Key,
                InvoiceNumber = kv.Value.InvoiceNumber,
                CustomerName = kv.Value.CustomerName,
                CreatedAt = kv.Value.CreatedAt,
                DueDate = kv.Value.DueDate,
                Amount = kv.Value.Amount,
                TaxAmount = kv.Value.TaxAmount,
                Status = kv.Value.Status
            }).ToList();

            return Task.FromResult(demoInvoices.AsEnumerable());
        }

    }
}
