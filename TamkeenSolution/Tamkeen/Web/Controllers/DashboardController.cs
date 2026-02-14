using Microsoft.AspNetCore.Mvc;

namespace Tamkeen.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
