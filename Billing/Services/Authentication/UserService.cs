using Billing.Interfaces.Authentication;
using System.Collections.Generic;
using System.Linq;
using Billing.Models;
using System.Security.Claims;

namespace Billing.Services.Authentication
{
    class UserService : IUserService
    {

        private IPPhoneEntities ipphoneEntities;

        public UserService()
        {
            ipphoneEntities = new IPPhoneEntities();
        }

        public void CreateUser(ClaimsIdentity userLogin)
        {
            ipphoneEntities.Users.Add(new User { Name = userLogin.Name });
            ipphoneEntities.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = ipphoneEntities.Users.ToList();
            return users;
        }

        public User GetUser(int id)
        {
            User user = ipphoneEntities.Users.Where(c => c.Id.Equals(id)).SingleOrDefault();
            if (user == null)
            {
                return null;
            } 
            else
            {
                return user;
            }

        }
    }
}
