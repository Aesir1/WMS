using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiRest.Extensions;

public static class StatusCodeResponseExtensions
{
    private const int DefaultCodeForNotModified = StatusCodes.Status304NotModified;
    
    public static ObjectResult NotModified(this ControllerBase controllerBase, [ActionResultObjectValue] object? value)
    {
        //controllerBase.Response.StatusCode = DefaultCodeForNotModified;
        return new ObjectResult(value)
        {
            StatusCode = DefaultCodeForNotModified
        };
    }
}