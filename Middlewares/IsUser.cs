using System.Security.Claims;
using basic_api.Constants;
using basic_api.Data;
using basic_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace basic_api.Middlewares
{
    [AttributeUsage(AttributeTargets.All)]
    public class IsUserAttribute : Attribute, IAsyncActionFilter
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

            var roleClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (roleClaim != Roles.User)
            {
                context.Result = new JsonResult(ErrorMessages.NotAuthorizedToAccess)
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
                return;
            }

            context.HttpContext.Items["ID"] = principal.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            await next();
        }
    }
}