using AddressBook.Infrastructure.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AddressBookContext _ctx;

        public UnitOfWork(AddressBookContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}