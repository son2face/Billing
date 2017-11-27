using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.Entities.Contacts;

namespace Billing.Interfaces.Contacts
{
    interface IUpdateService
    {
        void UpdateInDatabase(int id, ContactEntity contactEntity);
    }
}
