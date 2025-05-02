using DevFreela.Application.InputModels;
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

        if (skills == null)
        {
            return NotFound();
        }

        return Ok(skills);   
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var skill = _skillService.GetById(id);

        if (skill == null)
        {
            return NotFound();
        }

        return Ok(skill);
    }
    #endregion Views

    #region Inputs
    [HttpPost]
    public IActionResult Post([FromBody] NewSkillInputModel inputModel)
    {
        if (inputModel.Description.Length > 50)
        {
            return BadRequest();
        }

        var id = _skillService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

    }
    #endregion Inputs
}
