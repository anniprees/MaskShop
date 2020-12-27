using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{
    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : PeriodView
    {
        protected internal TitledPage(TRepository r, string title) : base(r) { }

        public string PageTitle { get; }

        public string PageSubTitle => FixedValue is null
        ? string.Empty
        : $"{PageSubtitle()}";

        protected internal virtual string PageSubtitle() => string.Empty;
        public virtual bool IsMasterDetail() => PageSubTitle != string.Empty;
    }
}