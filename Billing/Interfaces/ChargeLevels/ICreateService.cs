using Billing.Models;

namespace Billing.Interfaces.ChargeLevels
{
    internal interface ICreateService
    {
        void CreateInDatabase(ChargeLevel chargeLevel);
    }
}