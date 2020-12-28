using System.Threading.Tasks;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MaskShop.Pages.Common
{

    public abstract class CrudPage<TRepository, TDomain, TView, TData> :
        BasePage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : PeriodView
    {

        protected CrudPage(TRepository r) : base(r) { }

        public TView Item { get; set; }

        public string ItemId => Item?.GetId() ?? string.Empty;

        protected internal async Task<bool> AddObject(string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);
            await db.Add(ToObject(Item)).ConfigureAwait(true);
            return true;
        }

        protected internal async Task<bool> AddObject(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            return await AddObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }


        protected internal async Task<bool> UpdateObject(string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);
            await db.Update(ToObject(Item)).ConfigureAwait(true);

            return true;
        }

        protected internal async Task<bool> UpdateObject(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            return await UpdateObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }


        protected internal async Task GetObject(string id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);
            var o = await db.Get(id).ConfigureAwait(true);
            Item = ToView(o);
        }

        protected internal async Task GetObject(string id, string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            await GetObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }


        protected internal async Task DeleteObject(string id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);
            await db.Delete(id).ConfigureAwait(true);
        }

        protected internal async Task DeleteObject(string id, string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            await DeleteObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal abstract TDomain ToObject(TView v);

        protected internal abstract TView ToView(TDomain o);

    }

}
