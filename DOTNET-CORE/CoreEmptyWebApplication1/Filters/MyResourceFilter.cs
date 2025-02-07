using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter  // real life eg: cache the response and check cache key presence in request. 
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Debug.WriteLine("Resource filter - Before Request is processed.");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Debug.WriteLine("Resource filter - After Request is processed.");
        }

    }
}
