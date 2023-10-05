using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineShop.Web.Filters
{
    public class GlobalActionFilter : IActionFilter
    {
        private readonly ILogger<GlobalActionFilter> _logger;

        public GlobalActionFilter(ILogger<GlobalActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"{context.HttpContext.User.Identity.Name} made a request to {context.HttpContext.Request.Path.ToString()}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{context.HttpContext.User.Identity.Name} received response with status code {context.HttpContext.Response.StatusCode}");
        }
    }
}
