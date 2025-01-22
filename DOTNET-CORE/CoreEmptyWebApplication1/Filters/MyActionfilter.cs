using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Filters
{
    public class MyActionfilter : Attribute, IActionFilter  // real life eg: check state of model before performing the action (method)
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action executing.");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action executed.");
        }

    }
}
