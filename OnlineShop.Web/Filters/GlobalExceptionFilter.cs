using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace OnlineShop.Web.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;

                var result = new ObjectResult(new
                {
                    exception.Message,
                    exception.Source,
                    exception.StackTrace,
                    exception.InnerException,
                    ExceptionType = exception.GetType().FullName
                })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);

                context.Result = result;
            }
        }
    }
}
