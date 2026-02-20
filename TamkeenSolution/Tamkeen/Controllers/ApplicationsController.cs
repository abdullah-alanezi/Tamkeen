using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Controllers
{
    public class ApplicationsController : Controller
    {

        private readonly IApplicationRepository _appRepo;
        private readonly IProgramPostRepository _postRepo;
        private readonly ITrainingProgramRepository _programRepo;
        public ApplicationsController(IApplicationRepository appRepo,IProgramPostRepository postRepo,ITrainingProgramRepository programRepo)
        {
            _appRepo = appRepo;
            _postRepo = postRepo;
            _programRepo = programRepo;
        }
        public async Task<IActionResult> Index()
        {
            var app = await _postRepo.GetAllPostsWithProgramAsync();

            
            return View(app);
        }

        public async Task<IActionResult> UserApply()
        {
            var app = await _postRepo.GetAllPostsWithProgramAsync();


            return View(app);
        }

        public async Task<IActionResult> Apply([FromRoute]int id)
        {
            ViewBag.Program = await _postRepo.GetWithDetailsAsync(id);
            return View();
        }

        public async Task<IActionResult> Post(int id) {
        

           _postRepo.Post(id);

           await _programRepo.MakePosted(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details([FromRoute]int id) {

            var postProgramDetail = await _postRepo.GetWithDetailsAsync(id);
            return View(postProgramDetail);
        }

        public async Task<IActionResult> SubmitApplication([FromRoute]int id,Tamkeen.Domain.Entities.Application application)
        {
            var post = await _postRepo.GetWithDetailsAsync(id);
            application.programPost = post;
            await _appRepo.AddAsync(application);

            
            return RedirectToAction("UserApply");
        }



    }
}
