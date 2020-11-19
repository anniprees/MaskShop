using System.Threading.Tasks;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{

    public abstract class CrudPage<TRepository, TDomain, TView, TData> :
        BasePage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>
        where TView : PeriodView
    {

        protected CrudPage(TRepository r) : base(r)
        {
        }

        public TView Item { get; set; }

        public string ItemId => Item?.GetId() ?? string.Empty;

        protected internal async Task<bool> AddObject()
        {
            await db.Add(ToObject(Item)).ConfigureAwait(true);
            return true;
        }

        protected internal async Task<bool> UpdateObject()
        {
            await db.Update(ToObject(Item)).ConfigureAwait(true);

            return true;
        }

        protected internal async Task GetObject(string id)
        {
            var o = await db.Get(id).ConfigureAwait(true);
            Item = ToView(o);
        }
        
        protected internal async Task DeleteObject(string id)
        {
            await db.Delete(id).ConfigureAwait(true);
        }

        protected internal abstract TDomain ToObject(TView v);

        protected internal abstract TView ToView(TDomain o);

    }

}
