using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MaskShop.Aids;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Pages.Common
{

    public abstract class BasePage<TRepository, TDomain, TView, TData> 
        where TRepository : class, ICrudMethods<TDomain>
    {
        protected TRepository db { get; }

        protected internal BasePage(TRepository r) => db = r;
    }
}