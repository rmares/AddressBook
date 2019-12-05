using System;
using System.Collections.Generic;

namespace AddressBook.Application.Contacts.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public IEnumerable<ContactPhoneDto> Phones { get; set; }
    }
}