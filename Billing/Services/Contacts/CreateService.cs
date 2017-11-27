using System;
using Billing.Entities.Contacts;
using Billing.Interfaces.Contacts;
using Billing.Models;

namespace Billing.Services.Contacts
{
    public class CreateService : ICreateService
    {
        public void CreateInDatabase(ContactEntity contactEntity)
        {

            if (contactEntity == null) throw new ArgumentNullException(nameof(contactEntity));

            var contact = contactEntity.ToModel();

            contact.Id = Guid.NewGuid();


            using (var ipPhoneEntities = new IPPhoneEntities())
            {
               
                ipPhoneEntities.Contacts.Add(contact);
                ipPhoneEntities.SaveChanges();
            }
         }
    }
}