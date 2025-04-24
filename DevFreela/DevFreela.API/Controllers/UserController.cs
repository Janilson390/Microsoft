using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/users")]
public class UserController : ControllerBase
{
    #region Context
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion Context

    #region Views
    // api/users
    [HttpGet]
    public IActionResult GetAll(string query)
    {

        var users = _userService.GetAll(query);

        return Ok(users);
    }

    // api/users/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var user = _userService.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
    #endregion Views

    #region Inputs
    // api/users/
    [HttpPost()]
    public IActionResult Post([FromBody] NewUserInputModel inputModel)
    {
        if (string.IsNullOrEmpty(inputModel.FullName))
        {
            return BadRequest("Nome do usuário está vazio!");
        }

        var id = _userService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
    }

    // api/users/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
    {
        var user = _userService.GetUser(id);

        if (user == null)
        {
            return NoContent();
        }

        if (string.IsNullOrEmpty(inputModel.FullName))
        {
            return BadRequest("Nome do usuário está vazio!");
        }

        _userService.Update(inputModel);

        return NoContent();
    }

    // api/users/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _userService.GetUser(id);

        if (user == null)
        {
            return NoContent();
        }

        _userService.Delete(id);

        return NoContent();
    }

    // api/users/1/login 
    [HttpPut("{id}/login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        //return BadRequest() Caso alguma validaçao inesperada.
        //Cadastrou ...
        return NoContent();
    }
    #endregion Inputs
}
