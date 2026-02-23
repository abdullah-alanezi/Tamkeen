using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Models.ViewModels;

namespace Tamkeen.Controllers
{
    [Authorize(Roles = "Admin,HR")]
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingProgramViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                
                var entity = new TrainingProgram
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Capacity = model.Capacity,
                    
                };

                await _programRepo.AddAsync(entity);

            
                TempData["SuccessMessage"] = "Program saved successfully!";

                return RedirectToAction(nameof(Create)); 
            }
            catch (Exception ex)
            {
    
                TempData["ErrorMessage"] = "An error occurred while saving. Please check your data and try again.";

                return View(model); 
            }
        }
        public async Task<IActionResult> Details([FromRoute]int id) {
        
            var program = await _programRepo.GetByIdAsync(id);

            return View(program);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var program = await _programRepo.GetByIdAsync(id);
            if (program == null) return NotFound();

            // Map Entity to ViewModel
            var model = new TrainingProgramViewModel
            {
                Id = program.Id,
                Name = program.Name,
                Description = program.Description,
                StartDate = program.StartDate,
                EndDate = program.EndDate,
                Capacity = program.Capacity
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(TrainingProgramViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var entity = new TrainingProgram
                {
                    Id = model.Id, 
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Capacity = model.Capacity
                };

                
                await _programRepo.Update(entity);

                TempData["SuccessMessage"] = "Program Updated successfully!";
                return View(model);

            }
            catch (Exception ex) {
                TempData["ErrorMessage"] = $"An error occurred while saving. Please check your data and try again.\n{ex.Message}";

                return View(model);
            }
        }
    }
}
