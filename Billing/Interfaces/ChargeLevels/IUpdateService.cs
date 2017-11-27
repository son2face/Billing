using Billing.Models;

namespace Billing.Interfaces.ChargeLevels
{
    internal interface IUpdateService
    {
        void UpdateInDatabase(int level, ChargeLevel chargeLevel);
    }
}