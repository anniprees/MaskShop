using System.Threading.Tasks;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{

    public abstract class ViewPage<TRepository, TDomain, TView, TData> :
        TitledPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>
        where TDomain : IEntity<TData>
        where TData : PeriodData, new()
        where TView : PeriodView
    {
        protected ViewPage(TRepository r, string title) : base(r, title)
        {
        }

        public async Task OnGetIndexAsync()
        {
            await GetListForView().ConfigureAwait(true);
        }
    }
}