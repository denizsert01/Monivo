namespace Monivo.Web.ViewModels.Transactions
{
    public class DeleteTransactionViewModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Description { get; set; }

        public string CategoryName { get; set; }
    }
}
