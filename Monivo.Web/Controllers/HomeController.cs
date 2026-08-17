using Microsoft.AspNetCore.Mvc;

namespace Monivo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Monivo is running successfully! 🚀");
        }
    }
}
