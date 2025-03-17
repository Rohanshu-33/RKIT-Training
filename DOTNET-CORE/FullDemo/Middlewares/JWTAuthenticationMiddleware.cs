using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace FullDemo.Middlewares
{
    /// <summary>
    /// Middleware for handling JWT authentication.
    /// </summary>
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private string jwtKey; // Secret key for token validation

        /// <summary>
        /// Initializes the JWTAuthenticationMiddleware with the next middleware in the pipeline.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        public JWTAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            
            jwtKey = configuration["AppSettings:SecretKey"]; // Retrieve the Secret Key from configuration
        }

        /// <summary>
        /// Invokes the middleware to validate the JWT token in the request.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        /// <param name="next">The next middleware in the pipeline.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the endpoint allows anonymous access
            if (context.GetEndpoint()?.Metadata?.GetMetadata<AllowAnonymousAttribute>() != null)
            {
                await _next(context);
                return;
            }

            // Extract the token from the Authorization header
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();  // <Bearer jwt_token>

            if (token == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest; // Missing token
                await context.Response.WriteAsync("Token is required");
                return;
            }

            try
            {
                // Create the security key from the jwtKey
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
                var tokenHandler = new JwtSecurityTokenHandler();

                // Set token validation parameters
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey
                };

                // Validate the token and set the HttpContext user
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                context.User = principal;  // Attach the validated principal to HttpContext.User
                Console.WriteLine("coming out of middleware");
                await _next(context);
            }
            catch
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized; // Invalid token
                await context.Response.WriteAsync("Invalid token");
                return;
            }
        }
    }
}
