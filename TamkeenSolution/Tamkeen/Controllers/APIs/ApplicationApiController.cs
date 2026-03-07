using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tamkeen.Application.DTOs;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Controllers.APIs
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
  
        
[HttpGet]
public async Task<ActionResult<List<ApplicationDto>>> GetAll()
{
    var entities = await _appRepo.GetAllAsync();

    var dtos = entities.Select(a => new ApplicationDto
    {
        Id = a.Id,
        FullName = a.FullName,
        Email = a.Email,
        University = a.University,
        Major = a.Major,
        CVPath = a.CVPath,
        ProgramPostId = a.programPostId,
        ProgramPostName = a.programPost.trainingProgram.Name,
        Status = a.Status.ToString()
    }).ToList();

    return dtos;
}
    }
}
