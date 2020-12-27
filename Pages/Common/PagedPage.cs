﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{

    public abstract class PagedPage<TRepository, TDomain, TView, TData> :
        CrudPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : PeriodView
    {
        protected PagedPage(TRepository r) : base(r) { }

        public IList<TView> Items { get; private set; }

        public string SelectedId { get; set; }

        public int PageIndex
        {
            get => db.PageIndex;
            set => db.PageIndex = value;
        }

        public bool HasPreviousPage => db.HasPreviousPage;
        public bool HasNextPage => db.HasNextPage;
        public int TotalPages => db.TotalPages;

        protected internal override void SetPageValues(string sortOrder, string searchString, in int? pageIndex)
        {
            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex ?? 0;
        }

        protected internal async Task GetList(string sortOrder, string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = searchString;
            CurrentFilter = GetCurrentFilter(currentFilter, searchString, ref pageIndex);
            PageIndex = pageIndex ?? 1;

            Items = await GetListForView().ConfigureAwait(true);
        }

        internal async Task<List<TView>> GetListForView()
        {
            var l = await db.Get().ConfigureAwait(true);

            return l.Select(ToView).ToList();
        }
    }
}