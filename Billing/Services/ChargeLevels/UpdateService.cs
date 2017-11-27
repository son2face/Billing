using System;
using System.Linq;
using Billing.Interfaces.ChargeLevels;
using Billing.Models;

namespace Billing.Services.ChargeLevels
{
    public class UpdateService : IUpdateService
    { 
        public void UpdateInDatabase(int level, ChargeLevel chargeLevel)
        {
            if (chargeLevel == null) throw new ArgumentNullException(nameof(chargeLevel));

            using (var ipPhoneEntities = new IPPhoneEntities())
            {
                var focusChargeLevel = ipPhoneEntities.ChargeLevels.FirstOrDefault(c => c.Level == chargeLevel.Level);

                if (focusChargeLevel != null)
                {
                    focusChargeLevel.Level = chargeLevel.Level;
                    focusChargeLevel.Charge = chargeLevel.Charge;
                }

                ipPhoneEntities.SaveChanges();
            }
        }
    }
}