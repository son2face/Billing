using System.Collections.Generic;
using Billing.Models;

namespace Billing.Interfaces.ChargeLevels
{
    interface IReadService
    {
        List<ChargeLevel> ReadAllFromDatabase(string sort);
        ChargeLevel ReadFromDatabase(int level);
    }
}
