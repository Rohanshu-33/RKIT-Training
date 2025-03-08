using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CoreEmptyWebApplication1.Filters
{
    public class ApiAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _apiKey;

        // Constructor to inject IConfiguration
        public ApiAuthorizationFilter(IConfiguration configuration)
        {
            // Access the JwtSecretKey from configuration
            _apiKey = configuration["JwtSecretKey"];
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Debug.WriteLine("Authorization filter started.");

            // Check if API key is provided in the request headers
            if (!context.HttpContext.Request.Headers.TryGetValue("API-KEY", out var userKey))
            {
                context.Result = new ObjectResult("API key missing")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                Debug.WriteLine("Authorization filter ended.");
                return;
            }

            string apiKey = userKey.ToString();

            // Validate the API key
            if (!string.Equals(apiKey, _apiKey))
            {
                context.Result = new ObjectResult("Invalid API key")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            Debug.WriteLine("Authorization filter ended.");
            return;
        }
    }
}
