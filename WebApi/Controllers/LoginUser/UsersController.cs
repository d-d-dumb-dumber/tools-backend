using Application.UseCases.CreateUser;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.LoginUser;

/// <summary>
/// UsersController
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsersController(ICreateUser createUser) : BaseController
{
    /// <summary>
    /// Cria um usuário.
    /// </summary>
    /// <response code="204">Successfull request.</response>
    /// <response code="400">Invalid Request.</response>
    /// <param name="request"></param>
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginUser([FromBody] CreateUserRequest request)
    {
        ValidateRequest(request);
        await createUser.Execute(request);
        
        return Created();
    }
}
