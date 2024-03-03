using Microsoft.AspNetCore.Mvc.Filters;

namespace ngLifeCounter.MVC.Filters
{
	public class LoggedUserDataFilter : ActionFilterAttribute, IActionFilter, IAsyncActionFilter
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{

			var tokenHeader = context.HttpContext.Request.Headers["Authorization"];
			var bearerToken = tokenHeader.FirstOrDefault();

			var token = bearerToken?.Split("Bearer ")[1];
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			var ts = DateTime.Parse(context.ActionDescriptor.RouteValues["timestamp"]).AddHours(1).ToString();
			context.HttpContext.Response.Headers["X-EXPIRY-TIMESTAMP"] = ts;
		}

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			this.OnActionExecuting(context);
			var resultContext = await next();
			this.OnActionExecuted(resultContext);
		}
	}
}

