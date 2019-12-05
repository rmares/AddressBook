using AddressBook.Infrastructure.Domain;
using System.Threading.Tasks;

namespace AddressBook.Core.Contacts
{
    public interface IContactRepository
    {
        Task<PaginationResult<Contact>> SearchAsync(int pageNumber, int pageSize);

        Task<Contact> GetByIdAsync(int id);

        Task<Contact> GetByNameAndAddressAsync(string name, string address);

        Task InsertAsync(Contact contact);

        Task UpdateAsync(Contact contact);

        Task DeleteAsync(Contact contact);
    }
}