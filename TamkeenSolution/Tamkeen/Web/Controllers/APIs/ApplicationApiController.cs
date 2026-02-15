using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Web.Controllers.APIs
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationApiController : ControllerBase
    {
        private readonly IApplicationRepository _appRepo;
        public ApplicationApiController(IApplicationRepository appRepo)
        {
            _appRepo = appRepo;
        }
  
        // ✅ POST: api/applications
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tamkeen.Domain.Entities.Application model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.Status = ApplicationStatus.Pending;

            await _appRepo.AddAsync(model);
            

            return Ok(new
            {
                message = "Application submitted successfully"
            });
        }
    }
}
