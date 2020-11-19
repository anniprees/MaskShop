using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{

    public abstract class PagedPage<TRepository, TDomain, TView, TData> :
        CrudPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>
        where TView : PeriodView
    {
        protected PagedPage(TRepository r) : base(r)
        {
        }

        public IList<TView> Items { get; private set; }

        protected internal async Task GetList()
        {
            Items = await GetListForView().ConfigureAwait(true);
        }

        internal async Task<List<TView>> GetListForView()
        {
            var l = await db.Get().ConfigureAwait(true);

            return l.Select(ToView).ToList();
        }
    }
}