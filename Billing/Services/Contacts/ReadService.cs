using System.Collections.Generic;
using System.Linq;
using Billing.Entities.Contacts;
using Billing.Interfaces.Contacts;
using Billing.Models;
using Microsoft.Practices.ObjectBuilder2;

namespace Billing.Services.Contacts
{
    public class ReadService : IReadService
    {
        public List<ContactEntity> ReadAllFromDatabase()
        {
            using (var ipPhoneEntities = new IPPhoneEntities())
            {
                var contactEntities = new List<ContactEntity>();

                ipPhoneEntities.Contacts.ForEach(c => contactEntities.Add(ContactEntity.GetInstance(c)));

                return contactEntities;
            }
        }
    }
}