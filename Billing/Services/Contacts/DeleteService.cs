using System;
using System.Linq;
using Billing.Interfaces.Contacts;
using Billing.Models;

namespace Billing.Services.Contacts
{
    public class DeleteService : IDeleteService
    {
        public void DeleteInDatabase(Guid id)
        {
            using (var ipPhoneEntities = new IPPhoneEntities())
            {
                var contact = ipPhoneEntities.Contacts.SingleOrDefault(c => c.Id.Equals(id));
                if (contact != null) ipPhoneEntities.Contacts.Remove(contact);
                ipPhoneEntities.SaveChanges();
            }
        }
    }
}