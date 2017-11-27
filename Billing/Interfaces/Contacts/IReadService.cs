using System.Collections.Generic;
using Billing.Entities.Contacts;

namespace Billing.Interfaces.Contacts
{
    public interface IReadService
    {
        List<ContactEntity> ReadAllFromDatabase();

    }
}