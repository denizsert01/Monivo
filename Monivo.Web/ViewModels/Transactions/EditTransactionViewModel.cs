using Microsoft.AspNetCore.Mvc.Rendering;

namespace Monivo.Web.ViewModels.Transactions
{
    public class EditTransactionViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Description { get; set; }

        public List<SelectListItem> Categories { get; set; }
            = new List<SelectListItem>();
    }
}
