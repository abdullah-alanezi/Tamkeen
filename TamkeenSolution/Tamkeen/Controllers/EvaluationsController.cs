using Microsoft.AspNetCore.Mvc;
using Tamkeen.Application.Interfaces;

namespace Tamkeen.Controllers
{
    
    public class EvaluationsController : Controller
    {
        private protected IEvaluationRepository _evaluationRepo;

        public EvaluationsController(IEvaluationRepository evaluationRepo)
        {
            _evaluationRepo = evaluationRepo;
        }
        public IActionResult Index()
        {
            var _evaluationRepo.GetAllAsync();
            return View();
        }
    }
}
