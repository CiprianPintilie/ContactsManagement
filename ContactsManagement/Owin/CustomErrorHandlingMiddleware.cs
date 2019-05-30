using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ContactsManagement.Owin
{
    public class CustomErrorHandlingMiddleware
    {
        private readonly ILogger<CustomErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CustomErrorHandlingMiddleware(
            ILogger<CustomErrorHandlingMiddleware> logger, 
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An unhandled error occured. Inner exception: '{e.InnerException?.Message}'");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "An unhandled error occured. Please contact your administrator");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string exceptionMessage)
        {
            var errorBody = JsonConvert.SerializeObject(new { error = exceptionMessage });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(errorBody);
        }
    }
}
