using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AvcolFacilityManager.Models
{
    // PaginatedList is a custom collection class that extends List<T> to provide support for pagination, such as page index and total page count.
    public class PaginatedList<T> : List<T>
    {
        //Current page index
        public int PageIndex { get; private set; }

        //Total number of pages based on the count and page size
        public int TotalPages { get; private set; }

        //Constructor to initialize a PaginatedList with a set of items, total count of items, current page index, and page size.
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;

            // Calculate the total pages by dividing total count by page size.
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            //Add the paginated items to the base List<T>
            this.AddRange(items);
        }

        //Property to determine if there's a previous page (true if PageIndex > 1)
        public bool HasPreviousPage => PageIndex > 1;

        //Property to determine if there's a next page (true if PageIndex < TotalPages)
        public bool HasNextPage => PageIndex < TotalPages;

        //Static method to create a PaginatedList asynchronously from a queryable source (e.g., database). It fetches a specific page of data based on pageIndex and pageSize
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            //Get the total number of items in the source.
            var count = await source.CountAsync();

            // Get the items for the current page by skipping previous pages' items and taking the number of items defined by pageSize
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            //Return a new PaginatedList instance with the fetched items, total count, page index, and page size
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}