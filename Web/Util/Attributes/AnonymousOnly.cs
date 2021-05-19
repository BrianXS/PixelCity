using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Util.Attributes
{
    public class AnonymousOnly : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity is {IsAuthenticated: true})
            {
                context.HttpContext.Response.Redirect("/");
            }
        }
    }
}