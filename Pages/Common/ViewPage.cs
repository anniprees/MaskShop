using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.Pages.Common
{

    public abstract class ViewPage<TRepository, TDomain, TView, TData> :
        TitledPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
        where TView : PeriodView
    {
        protected ViewPage(TRepository r, string title) : base(r, title) { }

        public virtual async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        public List<LambdaExpression> Columns { get; }
            = new List<LambdaExpression>();

        public void SetItem(int i)
        {
            Item = null;
            if (IsCorrectIndex(i, Items)) Item = Items[i];
        }
        private static bool IsCorrectIndex<TList>(int i, IList<TList> l) => i >= 0 && i < l?.Count;

        public int ColumnsCount => Columns?.Count ?? -1;

        public int RowsCount => Items?.Count ?? -1;

        public string Undefined => "Undefined";
    }
}