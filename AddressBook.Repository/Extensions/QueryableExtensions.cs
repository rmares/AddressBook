using AddressBook.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Repository.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationResult<T>> GetPagedResultAsync<T>(
            this IQueryable<T> query,
            int? page,
            int? pageSize)
        {
            var result = new PaginationResult<T>();
            result.CurrentPage = !page.HasValue || page.Value == 0 ? 1 : page.Value;
            result.PageSize = pageSize ?? int.MaxValue;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / result.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (result.CurrentPage - 1) * result.PageSize;
            result.Results = await query.Skip(skip).Take(result.PageSize).ToListAsync();

            return result;
        }
    }
}