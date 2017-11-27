using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Billing.Models;
namespace Billing.Entity.CallRecord
{
    public class CallRecordEntity
    {
        public int Id;
        public int Month;
        public int Year;
        public int Duration;
        public int CallingPartyNumber;
        public String AuthCodeDescription;
        public String FinalCalledPartyNumber;
        public DateTime DateTimeConnect;
        public DateTime DataTimeDisconnect;
        public String FinalCalledPartyNumberPartition;
        public int Charge;
        public int DirectoryNumber;
        public String Owner;
        public String Department;
        public String Company;
        public CallRecordEntity(Billing.Models.CallRecord CallRecord)
        {
            this.Id = CallRecord.Id;
            this.Month = (int)CallRecord.Month;
            this.Year = (int)CallRecord.Year;
            this.Duration = (int)CallRecord.Duration;
            this.CallingPartyNumber = (int)CallRecord.CallingPartyNumber;
            this.Charge = (int)CallRecord.Charge;
            this.DirectoryNumber = (int)CallRecord.DirectoryNumber;
            this.AuthCodeDescription = CallRecord.AuthCodeDescription;
            this.FinalCalledPartyNumber = CallRecord.FinalCalledPartyNumber;
            this.DateTimeConnect = ConvertFromUnixTimestamp((int)CallRecord.DateTimeConnect);
            this.DataTimeDisconnect = ConvertFromUnixTimestamp((int)CallRecord.DataTimeDisconnect);
            this.Owner = CallRecord.Owner;
            this.Department = CallRecord.Department;
            this.Company = CallRecord.Company;
        }

        public CallRecordEntity()
        {

        }

        public Billing.Models.CallRecord ToModel(int Id)
        {
            Billing.Models.CallRecord CallRecord = new Billing.Models.CallRecord();
            this.Id = Id;
            CallRecord.Id = Id;
            CallRecord.Month = this.Month;
            CallRecord.Year = this.Year;
            CallRecord.Duration = this.Duration;
            CallRecord.CallingPartyNumber = this.CallingPartyNumber;
            CallRecord.Charge = this.Charge;
            CallRecord.DirectoryNumber = this.DirectoryNumber;
            CallRecord.AuthCodeDescription = this.AuthCodeDescription;
            CallRecord.FinalCalledPartyNumber = this.FinalCalledPartyNumber;
            CallRecord.DateTimeConnect = (int)ConvertToUnixTimestamp(this.DateTimeConnect);
            CallRecord.DataTimeDisconnect = (int)ConvertToUnixTimestamp(this.DataTimeDisconnect);
            CallRecord.Owner = this.Owner;
            CallRecord.Department = this.Department;
            CallRecord.Company = this.Company;
            return CallRecord;
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}