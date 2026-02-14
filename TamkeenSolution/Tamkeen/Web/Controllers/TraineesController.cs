using Microsoft.AspNetCore.Mvc;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Web.Controllers
{
    public class TraineesController : Controller
    {
        public IActionResult Index()
        {
            
            List<Trainee> t = new List<Trainee>();
            return View(t);
        }
    }
}
