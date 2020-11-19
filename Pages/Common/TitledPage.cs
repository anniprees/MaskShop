using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Aids.Constants;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;
using Microsoft.Data.SqlClient;

namespace MaskShop.Pages.Common
{
    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>
        where TView : PeriodView
    {
        protected internal TitledPage(TRepository r, string title) : base(r) { }
    }
}