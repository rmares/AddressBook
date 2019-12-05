using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}