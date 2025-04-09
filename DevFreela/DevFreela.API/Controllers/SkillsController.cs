using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/skills")]
public class SkillsController : ControllerBase
{
    #region Context
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }
    #endregion Context
    
    #region Views
    [HttpGet]
    public IActionResult GetAll()
    {
        var skills = _skillService.GetAll();

        return Ok(skills);   
    }
    #endregion Views
}
