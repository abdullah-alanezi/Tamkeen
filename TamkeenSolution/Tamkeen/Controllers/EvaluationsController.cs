using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var evaluation = await _evaluationRepo.GetAllAsync();
            return View(evaluation);
        }
    }
}
