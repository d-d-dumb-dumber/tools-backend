using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.PostUser;

/// <summary>
/// UsersController
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsersController : BaseController
{
    /// <summary>
    /// Cria um usuário.
    /// </summary>
    /// <response code="204">Successfull Request.</response>
    /// <response code="400">Invalid Request.</response>
    /// <response code="409">Already Existing Login.</response>
    /// <param name="request"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
    {
        ValidateRequest(request);
        //await _useCase.Execute(request);

        return NoContent();
    }
}
