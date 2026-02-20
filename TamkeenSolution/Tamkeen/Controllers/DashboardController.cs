using Microsoft.AspNetCore.Mvc;

namespace Tamkeen.Controllers
{
    
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
