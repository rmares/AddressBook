using AddressBook.Application.Contacts.DTOs;
using AddressBook.Infrastructure.Application;
using System.Threading.Tasks;

namespace AddressBook.Application.Contacts
{
    public interface IContactService
    {
        Task<PaginationResultDto<ContactDto>> SearchAsync(PaginationDto pagination);

        Task<ContactDto> GetAsync(int id);

        Task CreateAsync(ContactDto contact);

        Task UpdateAsync(ContactDto contact);

        Task DeleteAsync(int id);
    }
}