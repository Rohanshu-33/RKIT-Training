using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Debug.WriteLine($"Exception: {context.Exception}, isHandled? {context.ExceptionHandled}");
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;  // to stop propagation of exception towards c# default exception handler.
        }
    }
}
