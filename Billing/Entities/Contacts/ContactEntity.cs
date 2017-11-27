using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Billing.Models;

namespace Billing.Entities.Contacts
{
    public class ContactEntity
    {
        public Guid Id { get; set; }

        public string DirectoryNumber { get; set; }
        public string Owner { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public int? Level { get; set; }

        public static ContactEntity GetInstance(Contact contact)
        {
            return new ContactEntity
            {
                Id = contact.Id,
                DirectoryNumber = contact.DirectoryNumber,
                Owner = contact.Owner,
                Department = contact.Department,
                Company = contact.Company,
                Level = contact.Level
            };
        }

        public Contact ToModel()
        {

            var contact = new Contact();

            contact.Id = Id;
            contact.DirectoryNumber = DirectoryNumber;
            contact.Owner = Owner;
            contact.Department = Department;
            contact.Company = Company;
            contact.Level = Level;

            return contact;
        }
    }
}