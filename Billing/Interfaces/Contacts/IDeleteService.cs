using System;

namespace Billing.Interfaces.Contacts
{
    public interface IDeleteService
    {
        void DeleteInDatabase(Guid id);
    }
}