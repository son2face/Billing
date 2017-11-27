using Billing.Entities.Contacts;

namespace Billing.Interfaces.Contacts
{
    public interface ICreateService
    {
        void CreateInDatabase(ContactEntity contactEntity);
    }
}