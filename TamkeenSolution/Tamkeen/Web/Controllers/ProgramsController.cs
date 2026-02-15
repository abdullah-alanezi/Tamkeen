using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;

namespace Tamkeen.Web.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly ITrainingProgramRepository _rainingProgramRepo;

        public ProgramsController(ITrainingProgramRepository trainingProgramRepo)
        {
            _rainingProgramRepo = trainingProgramRepo;
        }
        public async Task<IActionResult> Index()
        {
            var program = await _rainingProgramRepo.GetAllAsync();
            return View(program);
        }
    }
}
