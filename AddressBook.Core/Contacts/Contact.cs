using AddressBook.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace AddressBook.Core.Contacts
{
    public class Contact : EntityBase<int>
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public ICollection<ContactPhone> Phones { get; private set; }

        private Contact()
        {
        }

        internal Contact(string name, DateTime dateOfBirth, string address)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;

            Phones = new List<ContactPhone>();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void AddPhone(string phoneNumber)
        {
            Phones.Add(new ContactPhone(this, phoneNumber));
        }

        public void RemovePhone(ContactPhone contactPhone)
        {
            Phones.Remove(contactPhone);
        }
    }
}