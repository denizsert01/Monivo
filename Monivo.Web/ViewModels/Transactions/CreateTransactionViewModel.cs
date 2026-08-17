using Microsoft.AspNetCore.Mvc.Rendering;

namespace Monivo.Web.ViewModels.Transactions
{
    public class CreateTransactionViewModel
    {
        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Today;

        public string? Description { get; set; }

        public List<SelectListItem> Categories { get; set; }
            = new List<SelectListItem>();
    }
}
