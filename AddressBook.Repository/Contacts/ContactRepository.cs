using AddressBook.Core.Contacts;
using AddressBook.Infrastructure.Domain;
using AddressBook.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Repository.Contacts
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookContext _ctx;

        public ContactRepository(AddressBookContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<PaginationResult<Contact>> SearchAsync(int pageNumber, int pageSize)
        {
            var query = _ctx.Contacts
                .Include(c => c.Phones)
                .OrderBy(c => c.Name)
                .AsQueryable();

            var paginationResult = await query.GetPagedResultAsync(pageNumber, pageSize);

            return paginationResult;
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _ctx.Contacts
                .Include(c => c.Phones)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact> GetByNameAndAddressAsync(string name, string address)
        {
            return await _ctx.Contacts.FirstOrDefaultAsync(c => c.Name == name && c.Address == address);
        }

        public async Task InsertAsync(Contact contact)
        {
            await _ctx.AddAsync(contact);
        }

        public async Task UpdateAsync(Contact contact)
        {
            if (_ctx.Entry(contact).State != EntityState.Modified)
            {
                _ctx.Entry(contact).State = EntityState.Modified;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Contact contact)
        {
            _ctx.Remove(contact);

            await Task.CompletedTask;
        }
    }
}