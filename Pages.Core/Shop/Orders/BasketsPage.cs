using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaskShop.PagesCore.Shop.Orders
{
    public abstract class BasketsPage<TPage> 
        :ViewPage<TPage, IBasketsRepository, Basket, BasketView, BasketData>
        where TPage : PageModel
    {
        protected BasketsPage(IBasketsRepository r) : base(r, "Baskets") { }

        protected internal override Uri pageUrl() => new Uri("/Shop/Baskets", UriKind.Relative);

        protected internal override Basket toObject(BasketView v) => new BasketViewFactory().Create(v);

        protected internal override BasketView toView(Basket o) => new BasketViewFactory().Create(o);

    }
}
