using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Filters
{
    public class ApiAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _apiKey = "RohanshuBanodha";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Debug.WriteLine("Authorization filter started.");
            
            if(!context.HttpContext.Request.Headers.TryGetValue("API-KEY", out var userKey))
            {
                context.Result = new ObjectResult("Api key missing")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                Debug.WriteLine("Authorization filter ended.");
                return;
            }

            string apiKey = userKey.ToString();
            if (!string.Equals(apiKey, _apiKey))
            {
                context.Result = new ObjectResult("Invalid api key")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            Debug.WriteLine("Authorization filter ended.");
            return;
        }

    }
}
