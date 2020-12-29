using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Infra.Common;

namespace BlazorApp.Server.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        }
    }
}
