using System;
using System.Threading.Tasks;

namespace AddressBook.Core.Contacts
{
    public interface IContactManager
    {
        Task<Contact> CreateAsync(string name, DateTime dateOfBirth, string address);
    }
}