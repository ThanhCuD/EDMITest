using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EDMITest.Global
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;
        public ErrorLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var message = "";
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                    _logger.LogError("InnerException: " + message + Environment.NewLine);
                }
                else
                {
                    _logger.LogError("Exception: " + message + Environment.NewLine);
                }
                _logger.LogError(ex.ToString() + Environment.NewLine);
                throw ex;
            }
        }
    }
}
