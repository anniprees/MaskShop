using System;
using System.Linq;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using Microsoft.EntityFrameworkCore;
using MaskShop.Aids;

namespace MaskShop.Infra.Common
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
    {

        public int PageIndex { get; set; }
        public int TotalPages => GetTotalPages(PageSize);
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public int PageSize { get; set; } = Constants.DefaultPageSize;

        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        internal int GetTotalPages(in int pageSize)
        {
            var count = GetItemsCount();
            var pages = CountTotalPages(count, pageSize);

            return pages;
        }

        internal int CountTotalPages(int count, in int pageSize) => (int)Math.Ceiling(count / (double)pageSize);

        internal int GetItemsCount() => base.createSqlQuery().CountAsync().Result;

        protected internal override IQueryable<TData> createSqlQuery() => AddSkipAndTake(base.createSqlQuery());

        private IQueryable<TData> AddSkipAndTake(IQueryable<TData> query)
        {
            if (PageIndex < 1) return query;

            return query
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize);
        }

    }

}