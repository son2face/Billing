using Billing.Interfaces.Authentication;
using Billing.Models;
using Billing.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Billing.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private IUserService userService;

        public AuthenticationService()
        {
            userService = new UserService();
        }

        public string GetCookie(HttpRequestMessage httpRequestMessage)
        {
            CookieHeaderValue cookieHeaderValue = httpRequestMessage.Headers.GetCookies().FirstOrDefault();
            string cookie = cookieHeaderValue == null ? null : cookieHeaderValue[".AspNet.Cookies"].Value;
            return cookie;
        }

        public bool IsAuthenticated(string token)
        {
            if (token == null)
            {
                return false;
            }

            IPPhoneEntities ipphoneEntities = new IPPhoneEntities();
            UserToken userToken = ipphoneEntities.UserTokens.Where(c => c.Token.Equals(token) && DateTime.Today < c.ExpiredTime).FirstOrDefault();

            if (userToken == null)
            {
                return false;
            }


            return true;
        }

        public bool IsAuthenticated(string token, ClaimsIdentity userLogin)
        {
            if (IsAuthenticated(token))
            {
                return true;
            }

            if (userLogin.IsAuthenticated)
            {
                Validate(token, userLogin);
                return true;
            }

            return false;
        }

        public void Validate(string token, ClaimsIdentity userLogin)
        {

            IPPhoneEntities ipphoneEntities = new IPPhoneEntities();

            User user = ipphoneEntities.Users.Where(c => c.Name.Equals(userLogin.Name)).SingleOrDefault();

            if (user == null)
            {
                userService.CreateUser(userLogin);

            }

            InsertUserToken(user, token);
        }

        public void InsertUserToken(User user, string token)
        {
            using (IPPhoneEntities ipphoneEntities = new IPPhoneEntities())
            {
                DateTime today = DateTime.Now.Date;

                List<UserToken> userExpired = ipphoneEntities.UserTokens.Where(t => t.ExpiredTime < today).ToList();

                if (userExpired.Count != 0)
                {
                    ipphoneEntities.UserTokens.RemoveRange(userExpired);
                }

                ipphoneEntities.UserTokens.Add(new UserToken { UserName = user.Name, Token = token, ExpiredTime = today.AddDays(10) });

                ipphoneEntities.SaveChanges();
            }
        }
    }
}