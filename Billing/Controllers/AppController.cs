using System.Web.Mvc;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.WsFederation;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using Billing.Interfaces.Authentication;
using Billing.Services.Authentication;

namespace Billing.Controllers
{
    public class AppController : Controller
    {

        private IAuthenticationService authenticationService;

        public AppController()
        {
            authenticationService = new AuthenticationService();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            string token = Request.Cookies[".AspNet.Cookies"] == null ? null : Request.Cookies[".AspNet.Cookies"].Value;

            ClaimsIdentity userLogin = User.Identity as ClaimsIdentity;
            

            if (!authenticationService.IsAuthenticated(token, userLogin))
            {
                Login();
                return new EmptyResult();
            }
            else
            {
                return View();
            }
        }

        public void Login()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, WsFederationAuthenticationDefaults.AuthenticationType);
            }


        }
        public void Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(WsFederationAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}