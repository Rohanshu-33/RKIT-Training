using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using FullDemo.Models;

namespace FullDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        private Response _objresponse;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
            _objresponse = new Response();
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            _objresponse.Success = false;
            _objresponse.Message = "CEF Something went wrong.";
            Console.WriteLine("CEF Exception Filter");
            int statusCode;

            // Handle Specific Exception Types and write them in their corresponding log files.
            switch (exception)
            {
                case ArgumentNullException:
                case ArgumentException:
                    _logger.LogWarning(exception, "CEF Bad Request: {Message}", exception.Message);
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case UnauthorizedAccessException:
                    _logger.LogWarning(exception, "CEF Unauthorized Access: {Message}", exception.Message);
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case KeyNotFoundException:
                    _logger.LogError(exception, "CEF Not Found: {Message}", exception.Message);
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case InvalidOperationException:
                    _logger.LogError(exception, "CEF Invalid Operation: {Message}", exception.Message);
                    statusCode = (int)HttpStatusCode.Conflict;
                    break;

                case Exception:
                    _logger.LogCritical(exception, "CEF Fatal Error: {Message}", exception.Message);
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;

                default:
                    _logger.LogCritical(exception, "CEF Unhandled Exception: {Message}", exception.Message);
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Result = new ObjectResult(_objresponse)
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
