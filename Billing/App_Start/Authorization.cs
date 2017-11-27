using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Billing
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
 
        public AuthorizationAttribute()
        {
   
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //string Cookie = AuthenticationService.GetCookie(actionContext.Request);
            //if (!AuthorizationService.IsAuthorized(Cookie, actionContext.Request.Method, actionContext.Request.RequestUri))
            //{
            //    throw new UnauthorizedAccessException();
            //}
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}