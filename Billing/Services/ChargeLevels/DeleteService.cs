using System.Linq;
using Billing.Interfaces.ChargeLevels;
using Billing.Models;

namespace Billing.Services.ChargeLevels
{
    public class DeleteService : IDeleteService
    {
        public void DeleteFromDatabase(int level)
        {
            using (var ipPhoneEntities = new IPPhoneEntities())
            {
                var chargeLevel = ipPhoneEntities.ChargeLevels.SingleOrDefault(c => c.Level == level);

                if (chargeLevel != null)
                {
                    ipPhoneEntities.ChargeLevels.Remove(chargeLevel);
                } 

                ipPhoneEntities.SaveChanges();
            }

        }
    }
}