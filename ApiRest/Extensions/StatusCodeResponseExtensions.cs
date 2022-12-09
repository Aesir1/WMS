using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiRest.Extensions;

public static class StatusCodeResponseExtensions
{
    private const int DefaultCodeForNotModified = StatusCodes.Status304NotModified;
    /// <summary>
    /// NotModified method of type ObjectResult
    /// StatusCode int 304
    /// </summary>
    /// <param name="controllerBase"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ObjectResult NotModified(this ControllerBase controllerBase, [ActionResultObjectValue] object? value)
    {
        //controllerBase.Response.StatusCode = DefaultCodeForNotModified;
        return new ObjectResult(value)
        {
            StatusCode = DefaultCodeForNotModified
        };
    }
}