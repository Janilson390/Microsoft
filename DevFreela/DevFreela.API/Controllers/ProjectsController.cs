using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    #region Context
    private readonly IProjectService _projectService;
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    #endregion Context

    #region Views
    // api/projects?query=net core
    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _projectService.GetAll(query);

        return Ok(projects);
    }

    // api/projects/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }
    #endregion Views

    #region Inputs
    // api/projects/
    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel inputModel)
    {
        if (inputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = _projectService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
    }

    // api/projects/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
    {
        //Buscar o projeto
        var project = _projectService.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        if (inputModel.Description.Length > 200)
        {
            return BadRequest();
        }

        //Atualiza o projeto
        _projectService.Update(inputModel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        //Buscar o projeto
        var project = _projectService.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        // Remover
        _projectService.Delete(id);

        return NoContent();
    }

    // api/projects/1/comments
    [HttpPost("{id}/comments")]
    public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
    {
        _projectService.CreateComment(inputModel);

        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _projectService.Start(id);

        return NoContent();
    }

    // api/projects/1/finish
    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _projectService.Finish(id);
        
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody] UpdateProjectModel updateProjectModel)
    {
        //Buscar o projeto
        //return BadRequest();

        if (updateProjectModel.Description.Length > 200)
        {
            return BadRequest();
        }

        //Atualiza o projeto
        return NoContent();
    }
    #endregion Inputs

}
