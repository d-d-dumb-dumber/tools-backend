using System.Net.Mime;
using Domain.Resources;
using Newtonsoft.Json;

namespace WebApi.Modules.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;

            switch (error)
            {
                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    await response.WriteAsync(JsonConvert.SerializeObject(new { message = Messages.InternalServerError }));
                    return;
            }
        }
    }
}
