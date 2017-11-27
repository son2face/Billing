using System;
using System.Linq;
using Billing.Interfaces.ChargeLevels;
using Billing.Models;

namespace Billing.Services.ChargeLevels
{
    public class CreateService : ICreateService
    {

        public void CreateInDatabase(ChargeLevel chargeLevel)
        {
            if (chargeLevel == null) throw new ArgumentNullException(nameof(chargeLevel));

            using (var ipPhoneEntities = new IPPhoneEntities())
            {

                ipPhoneEntities.ChargeLevels.Add(chargeLevel);

                ipPhoneEntities.SaveChanges();
            }
        }
    }


}