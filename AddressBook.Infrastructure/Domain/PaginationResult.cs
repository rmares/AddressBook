using System;
using System.Collections.Generic;

namespace AddressBook.Infrastructure.Domain
{
    public class PaginationResult<T>
    {
        public PaginationResult()
        {
            Results = new List<T>();
        }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }

        public IList<T> Results { get; set; }
    }
}