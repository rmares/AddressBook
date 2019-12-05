using AddressBook.Application.Contacts.DTOs;
using AddressBook.Core.Contacts;
using AddressBook.Infrastructure.Application;
using AddressBook.Infrastructure.Domain;
using System.Collections.Generic;

namespace AddressBook.Application.Contacts
{
    public static class ContactMapper
    {
        public static PaginationResultDto<ContactDto> MapToPaginationResultDto(this PaginationResult<Contact> paginationResult)
        {
            var paginationDto = new PaginationResultDto<ContactDto>
            {
                TotalCount = paginationResult.RowCount
            };

            foreach (var contact in paginationResult.Results)
            {
                paginationDto.Data.Add(MapContactToContactDto(contact));
            }

            return paginationDto;
        }

        public static ContactDto MapToContactDto(this Contact contact)
        {
            return MapContactToContactDto(contact);
        }

        private static ContactDto MapContactToContactDto(Contact contact)
        {
            var contactPhoneDtos = new List<ContactPhoneDto>();
            foreach (var contactPhone in contact.Phones)
            {
                contactPhoneDtos.Add(new ContactPhoneDto
                {
                    Id = contactPhone.Id,
                    PhoneNumber = contactPhone.PhoneNumber
                });
            }

            var contactDto = new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Address = contact.Address,
                DateOfBirth = contact.DateOfBirth,
                Phones = contactPhoneDtos
            };

            return contactDto;
        }
    }
}