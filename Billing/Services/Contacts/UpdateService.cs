using System;
using System.Linq;
using Billing.Entities.Contacts;
using Billing.Interfaces.Contacts;
using Billing.Models;

namespace Billing.Services.Contacts
{
    public class UpdateService : IUpdateService
    {
        public void UpdateInDatabase(int id, ContactEntity contactEntity)
        {
            if (contactEntity == null) throw new ArgumentNullException(nameof(contactEntity));

            var contact = contactEntity.ToModel();

            using (var ipPhoneEntities = new IPPhoneEntities())
            {

                ipPhoneEntities.SaveChanges();
            }
        }
    }
}