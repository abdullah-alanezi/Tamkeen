using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Domain.Enums;
using Tamkeen.Models.ViewModels;

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
        [Authorize(Roles = "Admin,HR")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var app = await _postRepo.GetAllPostsWithProgramAsync();

            
            return View(app);
        }

        //trainee
        public async Task<IActionResult> UserApply()
        {
            var app = await _postRepo.GetAllPostsWithProgramAsync();


            return View(app);
        }
        //trainee
        [HttpGet]
        public async Task<IActionResult> Apply([FromRoute]int id)
        {
            ViewBag.Program = await _postRepo.GetWithDetailsAsync(id);
            return View();
        }
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Post(int id) {

            try
            {
                await _postRepo.PostAsync(id);

                await _programRepo.MakePosted(id);

                TempData["SuccessMessage"] = "The Program Posted ";

                return RedirectToAction("Index", "Programs");
            }
            catch (Exception ex) { TempData["ErrorMessage"] =" Failed Program Posting "; return RedirectToAction("Index", "Programs"); }
        }
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> Details([FromRoute]int id) {

            var postProgramDetail = await _postRepo.GetWithDetailsAsync(id);
            return View(postProgramDetail);
        }

        [HttpPost]
        //trainee
        public async Task<IActionResult> SubmitApplication(
            int id,
            ApplicationViewModel model,  
            IFormFile cvFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Program = await _postRepo.GetWithDetailsAsync(id);
                return View("Apply", model); 
            }

         
            var post = await _postRepo.GetWithDetailsAsync(id);
            if (post == null)
                return NotFound();

            string uniqueFileName = null;

            
            if (cvFile != null && cvFile.Length > 0)
            {
                
                if (cvFile.ContentType != "application/pdf")
                {
                    ModelState.AddModelError("", "Only PDF files are allowed.");
                    ViewBag.Program = post;
                    return View("Apply", model);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + cvFile.FileName;

                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await cvFile.CopyToAsync(fileStream);
                }
            }

            
            var application = new Tamkeen.Domain.Entities.Application
            {
                FullName = model.FullName,
                Email = model.Email,
                University = model.University,
                Major = model.Major,
                programPostId = id,
                CVPath = uniqueFileName,
                Status = ApplicationStatus.Pending
            };

            await _appRepo.AddAsync(application);

            
            TempData["SuccessMessage"] = "Your application has been submitted successfully!";
            return RedirectToAction("Apply", new { id = id });  
        }

        [HttpGet]
        [Authorize(Roles = "Admin,HR")]
        public async Task<IActionResult> ApplicationDetail([FromRoute] int id)
        {
            var app = await _appRepo.GetByIdAsync(id);
            return View(app);
        }

        [Authorize(Roles = "Admin,HR")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, ApplicationStatus status)
        {
          
            

            await _appRepo.UpdateStatus(id, status);

            TempData["SuccessMessage"] = "Status Updated successfully!";
            return RedirectToAction("ApplicationDetail", new {id=id});
        }
    }
}
