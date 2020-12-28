using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MaskShop.Aids;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{

    public abstract class BasePage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {

        protected TRepository db { get; }

        protected internal BasePage(TRepository r) => db = r;

        public string SortOrder
        {
            get => db.SortOrder;
            set => db.SortOrder = value;
        }

        public string SearchString
        {
            get => db.SearchString;
            set => db.SearchString = value;
        }

        public string CurrentFilter
        {
            get => db.CurrentFilter;
            set => db.CurrentFilter = value;
        }

        public string FixedValue
        {
            get => db.FixedValue;
            set => db.FixedValue = value;
        }

        public bool HasFixedFilter => !string.IsNullOrWhiteSpace(FixedFilter);

        public string FixedFilter
        {
            get => db.FixedFilter;
            set => db.FixedFilter = value;
        }

        protected internal void SetFixedFilter(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
        }

        protected internal abstract void SetPageValues(string sortOrder, string searchString, in int? pageIndex);

        public Uri GetSortString(Expression<Func<TData, object>> e, Uri page)
        {
            var name = GetMember.Name(e);
            var sortOrder = GetSortOrder(name);

            return new Uri(
                $"{page}?handler=Index&sortOrder={sortOrder}&currentFilter={CurrentFilter}&searchString={SearchString}"
                + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);
        }

        protected internal virtual string GetSortOrder(string name)
        {
            if (string.IsNullOrEmpty(SortOrder)) return name;
            if (!SortOrder.StartsWith(name, StringComparison.InvariantCulture)) return name;
            if (SortOrder.EndsWith("_desc", StringComparison.InvariantCulture)) return name;

            return name + "_desc";
        }

        internal static string GetCurrentFilter(string currentFilter, string searchString, ref int? pageIndex)
        {
            if (searchString != currentFilter)
            {
                pageIndex = 1;
            }

            return searchString;

        }
    }

}