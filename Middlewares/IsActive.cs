using basic_api.Data;
using basic_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace basic_api.Middlewares
{
    [AttributeUsage(AttributeTargets.All)]
    public class IsActive : Attribute, IAsyncActionFilter
    {
        private readonly string? _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY");

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_secretKey == null)
                return;

            var authorizationHeader = context.HttpContext.Request.Headers.Authorization.ToString();
            var principal = Jwt.ValidateToken(authorizationHeader, _secretKey);

            if (principal == null)
            {
                context.Result = new JsonResult(ErrorMessages.TokenIsInvalid)
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }

            var isActiveClaim = principal.Claims.FirstOrDefault(c => c.Type == "is_active")?.Value;
            if (isActiveClaim == "false")
            {
                context.Result = new JsonResult(ErrorMessages.AccountIsInactive)
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
                return;
            }

            await next();
        }
    }
}