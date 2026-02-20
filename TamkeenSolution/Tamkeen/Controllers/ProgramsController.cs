using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly ITrainingProgramRepository _programRepo;

        public ProgramsController(ITrainingProgramRepository trainingProgramRepo)
        {
            _programRepo = trainingProgramRepo;
        }
        public async Task<IActionResult> Index()
        {
            var program = await _programRepo.GetAllAsync();
            return View(program);
        }

        [HttpGet]
        public IActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainingProgram program)
        {
            await _programRepo.AddAsync(program);
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Details([FromRoute]int id) {
        
            var program = await _programRepo.GetByIdAsync(id);

            return View(program);
            
        }

        public async Task<IActionResult> Edit([FromRoute]int id)
        {
            var program = await _programRepo.GetByIdAsync(id);
            return View(program);
        }
    }
}
