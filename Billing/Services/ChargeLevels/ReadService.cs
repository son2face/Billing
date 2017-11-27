using System.Collections.Generic;
using System.Linq;
using Billing.Interfaces.ChargeLevels;
using Billing.Models;

namespace Billing.Services.ChargeLevels
{
    public class ReadService : IReadService
    {
        public List<ChargeLevel> ReadAllFromDatabase(string sort)
        {

            using (var ipPhoneEntities = new IPPhoneEntities())
            {

                if (sort == "-level")
                    return ipPhoneEntities.ChargeLevels.OrderByDescending(c => c.Level).ToList();

                if (sort == " level")
                    return ipPhoneEntities.ChargeLevels.OrderBy(c => c.Level).ToList();
            }

            return null;

        }

        public ChargeLevel ReadFromDatabase(int level)
        {
            using (var ipPhoneEntities = new IPPhoneEntities())
            {
                return ipPhoneEntities.ChargeLevels.SingleOrDefault(c => c.Level == level);
            }
         }
    }
}