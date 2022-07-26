using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Persistence.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            User? user = context.HttpContext.Items["User"] as User;

            if(user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized!" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
