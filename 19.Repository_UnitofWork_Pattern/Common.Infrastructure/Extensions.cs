using System.Linq;
using System.Linq.Dynamic.Core;

namespace Common.Infrastructure
{
    public static class Extensions
    {
        public static IQueryable<T> OrderByWithDirection<T>(this IQueryable<T> query, string sortDirection, string sortField)
        {
            return query.OrderBy($"{sortField} {sortDirection}");
        }

        public static IQueryable<T> GetPaggedList<T>(this IQueryable<T> query, int offset, int limit)
        {
            return query.Skip(--offset * limit)
                        .Take(limit);
        }
    }

}
