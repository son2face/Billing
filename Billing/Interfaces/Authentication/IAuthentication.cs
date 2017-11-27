using System.Net.Http;
using System.Security.Claims;

namespace Billing.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        string GetCookie(HttpRequestMessage httpRequestMessage);
        bool IsAuthenticated(string token);
        bool IsAuthenticated(string token, ClaimsIdentity userLogin);
        void Validate(string token, ClaimsIdentity userLogin);
    }

}