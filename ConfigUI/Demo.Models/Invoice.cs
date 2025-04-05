namespace ConfigUI.Demo.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount => Amount + TaxAmount;

    }
}
