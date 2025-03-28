using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/users")]
public class UserController :ControllerBase
{
    // api/users
    [HttpGet]
    public IActionResult Get() {
        return Ok();
    }

    // api/users/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        
        // Busca o usuário.  Não encontrou...
        //return NotFound();

        //Encontrou...
        return Ok();
    }

    // api/users/
    [HttpPost()]
    public IActionResult Post([FromBody] CreateUserModel createUserModel) {
        
        //return BadRequest() Caso alguma validaçao inesperada.
        //Cadastrou ...
        return CreatedAtAction(nameof(GetById), new{id = 1}, createUserModel);
    }

     // api/users/1/login 
    [HttpPut("{id}/login")]
    public IActionResult Login([FromBody] LoginModel loginModel) {
        
        //return BadRequest() Caso alguma validaçao inesperada.
        //Cadastrou ...
        return NoContent();
    }
}
