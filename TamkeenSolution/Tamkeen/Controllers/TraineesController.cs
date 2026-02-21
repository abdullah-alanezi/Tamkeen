using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Infrastructure.Repository;

namespace Tamkeen.Controllers
{
    [Authorize(Roles = "Admin,HR")]
    public class TraineesController : Controller
    {
        private readonly ITraineeRepository _traineeRepo;

        public TraineesController(ITraineeRepository traineeRepo)
        {
            _traineeRepo = traineeRepo;
        }
        public async Task<IActionResult> Index()
        {

            var trainees = await _traineeRepo.GetAllAsync();
            return View(trainees);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int id)
        {
            var trainee = await _traineeRepo.GetWithDetailsAsync(id);
            return View(trainee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) {

            var trainee = await _traineeRepo.GetWithDetailsAsync(id);
            return View(trainee);
        }

        [HttpPost]
        public  IActionResult Edit(Trainee trainee)
        {

             _traineeRepo.Update(trainee);
            return RedirectToAction("Edit", trainee.Id);
        }
    }
}
