using Microsoft.AspNetCore.Mvc.Rendering;

namespace Monivo.Web.ViewModels.Categories
{
    public class CreateCategoryViewModel
    {
        public string CategoryName { get; set; }

        public int TypeParameterId { get; set; }

        public List<SelectListItem> TransactionTypes { get; set; }
            = new List<SelectListItem>();
    }
}
