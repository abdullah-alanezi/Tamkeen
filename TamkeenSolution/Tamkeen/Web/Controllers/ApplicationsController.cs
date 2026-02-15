using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;

namespace Tamkeen.Web.Controllers
{
    public class ApplicationsController : Controller
    {

        private readonly IApplicationRepository _appRepo;
        public ApplicationsController(IApplicationRepository appRepo)
        {
            _appRepo = appRepo;
        }
        public async Task<IActionResult> Index()
        {
            var app = await _appRepo.GetAllAsync();

           
            return View(app);
        }


    }
}
