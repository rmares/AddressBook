using System.Collections.Generic;

namespace AddressBook.Infrastructure.Application
{
    public class PaginationResultDto<T>
    {
        public IList<T> Data { get; set; }
        public int TotalCount { get; set; }

        public PaginationResultDto()
        {
            Data = new List<T>();
        }
    }
}