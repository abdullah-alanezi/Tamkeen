using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tamkeen.Controllers
{
    
    public class DashboardController : Controller
    {
        [Authorize(Roles ="Admin,HR")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
