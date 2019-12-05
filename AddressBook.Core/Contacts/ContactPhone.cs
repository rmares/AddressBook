using AddressBook.Infrastructure.Domain;

namespace AddressBook.Core.Contacts
{
    public class ContactPhone : EntityBase<int>
    {
        public Contact Contact { get; private set; }
        public string PhoneNumber { get; private set; }

        private ContactPhone()
        {
        }

        public ContactPhone(Contact contact, string phoneNumber)
        {
            Contact = contact;
            PhoneNumber = phoneNumber;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}