using Billing.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Billing.Interfaces.Authentication
{
    interface IUserService
    {
        void CreateUser(ClaimsIdentity user);

        User GetUser(int id);

        List<User> GetAllUsers();

    }
}
