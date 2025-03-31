using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly OpeningTimeOption _option;
    public ProjectsController(IOptions<OpeningTimeOption> options, ExampleClass exampleClass)
    {
        exampleClass.Name = "Updated at projects ...";
        _option = options.Value;
    }
    // api/projects?query=net core
    [HttpGet]
    public IActionResult Get(string query) => Ok();
    
    // api/projects/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        // return NotFound();
        
        return Ok();
    }

    // api/projects/
    [HttpPost]
    public IActionResult Post([FromBody]CreateProjectModel createProject) {
        if(createProject.Title.Length > 50){
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new {id = createProject.Id}, createProject);
    }

    // api/projects/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]UpdateProjectModel updateProject){
        //Buscar o projeto
        //return BadRequest();
        
        if (updateProject.Description.Length > 200){
            return BadRequest();
        }

        //Atualiza o projeto

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        //Buscar o projeto
        
        //return BadRequest();  

        // Remover;
         return NoContent();
    }

     // api/projects/1/comments
    [HttpPost("{id}/comments")]
    public IActionResult PostComment([FromBody]CreateCommentModel createCommentModel) {
    
        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    public IActionResult Start(int id) {
    
        return NoContent();
    }

    // api/projects/1/finish
    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id) {
    
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody]UpdateProjectModel updateProjectModel)
    {   
        //Buscar o projeto
        //return BadRequest();
        
        if (updateProjectModel.Description.Length > 200){
            return BadRequest();
        }

        //Atualiza o projeto
        return NoContent();
    }

}
