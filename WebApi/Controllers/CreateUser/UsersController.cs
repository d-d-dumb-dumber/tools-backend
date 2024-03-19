using Application.UseCases.CreateUser;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.CreateUser;

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
    /// <response code="201">Ressource Created.</response>
    /// <response code="400">Invalid Request.</response>
    /// <response code="409">Already Existing Login.</response>
    /// <param name="request"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
    {
        ValidateRequest(request);
        await createUser.Execute(request);
        
        return Created();
    }
}
