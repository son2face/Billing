using Billing.Interfaces.Authentication;
using Billing.Services.Authentication;
using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Billing
{
    public class AuthenticationAttribute : Attribute, IAuthenticationFilter

    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationAttribute()
        {
            authenticationService = new AuthenticationService();
        }

        public bool AllowMultiple => true;

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var cookie = authenticationService.GetCookie(context.Request);


//            if (!authenticationService.IsAuthenticated(cookie))
//            {
//                throw new InvalidCredentialException();
//            }

            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}