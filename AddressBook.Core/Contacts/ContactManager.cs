using AddressBook.Infrastructure.Exceptions;
using System;
using System.Threading.Tasks;

namespace AddressBook.Core.Contacts
{
    public class ContactManager : IContactManager
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> CreateAsync(string name, DateTime dateOfBirth, string address)
        {
            var existingContact = await _contactRepository.GetByNameAndAddressAsync(name, address);
            if (existingContact != null)
            {
                throw new ValidationException("Contact with same name and address already exists!");
            }

            var contact = new Contact(name, dateOfBirth, address);

            await _contactRepository.InsertAsync(contact);

            return contact;
        }
    }
}