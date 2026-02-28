using ST.Core.Enums;
using ST.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
namespace ST.Core.Models
{
    public abstract class PageResult
    {
        public long? Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public static PageResult<T> BuildWithFullCount<T>(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var count = query.LongCount();
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = query.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        public static PageResult<T> BuildWithFullCount<T>(IQueryable<T> query, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var count = query.LongCount();
            if (orderByDirection == OrderByDirection.Ascending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = query.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        public static PageResult<T> BuildWithPartialCount<T>(IQueryable<T> query, int pageIndex, int pageSize, int additionalPagesToCount)
        {
            var take = (pageIndex + additionalPagesToCount) * pageSize;
            var count = query.Take(take).LongCount();
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = query.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        public static PageResult<T> BuildWithPartialCount<T>(IQueryable<T> query, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection)
        {
            var take = (pageIndex + additionalPagesToCount) * pageSize;
            var count = query.Take(take).LongCount();
            if (orderByDirection == OrderByDirection.Ascending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = query.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public static PageResult<T> BuildScrollingPage<T>(IQueryable<T> query, int pageIndex, int pageSize)
        { 
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            { 
                Items = query.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public static PageResult<T> BuildScrollingPage<T>(IQueryable<T> query, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        { 
            if (orderByDirection == OrderByDirection.Ascending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            { 
                Items = query.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

    }
    public class PageResult<T> : PageResult
    {
        public IEnumerable<T> Items { get; set; }
        public bool HasMore
        {
            get
            {
                if (Count.HasValue)
                {
                    return Count.Value >= PageIndex * PageSize;
                }
                if (!Items.IsNullOrEmpty())
                {
                    return Items.Count() == PageSize;
                }
                return false;
                
            }
        }
    }
}
