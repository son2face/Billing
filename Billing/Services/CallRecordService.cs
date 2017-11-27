using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Billing.Models;
using Billing.Interfaces.CallRecord;
namespace Billing.Services.CallRecord
{
    public class CallRecordService : ICallRecordService
    {
        public void DeleteDataFromDB(int Month, int Year)
        {
            throw new NotImplementedException();
        }

        public void ExtractDataToDB(int FileId, int Month, int Year)
        {
            throw new NotImplementedException();
        }

        public void GetDataFromDB(int Month, int Year)
        {
            throw new NotImplementedException();
        }

        public void ModifyDataDB(int Month, int Year)
        {
            throw new NotImplementedException();
        }
    }
}