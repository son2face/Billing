using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.Models;
namespace Billing.Interfaces.CallRecord
{
    interface ICallRecordService
    {
        void ExtractDataToDB(int FileId, int Month, int Year);
        void DeleteDataFromDB(int Month, int Year);
        void GetDataFromDB(int Month, int Year);
        void ModifyDataDB(int Month, int Year);
    }
}
