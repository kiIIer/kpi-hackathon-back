using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Idk.Application.Exceptions.Common;

namespace Idk.Web.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;
        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException);
                break;
            case EntityNotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        if ((int)code > 499)
        {
            return context.Response.WriteAsync(JsonSerializer.Serialize(new {error = "An error occured while processing your request"}));
        }
        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new {error = exception.Message});
        }
        
        return context.Response.WriteAsync(result);
    }
}