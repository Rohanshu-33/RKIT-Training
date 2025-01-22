using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("Result Filter executing"); ;
            context.HttpContext.Response.Headers.Add("MyName", "RohanshuBanodha");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("Result Filter executed"); ;
        }
    }
}
