using Domain.Models.Requests;
using Infrastructure.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers.PostUser;

/// <summary>
/// UsersController
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsersController(ToolsContext toolsContext) : BaseController
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
        await toolsContext.Database.MigrateAsync();
        ValidateRequest(request);
        //await _useCase.Execute(request);

        return NoContent();
    }
}
