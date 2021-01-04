using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaskShop.PagesCore.Shop.Orders
{
    public abstract class BasketsPage<TPage> 
        :ViewPage<TPage, IBasketsRepository, Basket, BasketView, BasketData>
        where TPage : PageModel
    {
        public IBasketsRepository BasketsRepo { get; }
        public IOrdersRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }

        protected BasketsPage(IBasketsRepository r, IOrdersRepository o, IOrderItemsRepository oi)
            : base(r, "Baskets")
        {
            BasketsRepo = r;
            Orders = o;
            OrderItems = oi;
        }

        protected internal override Uri pageUrl() => new Uri("/Shop/Baskets", UriKind.Relative);

        protected internal override Basket toObject(BasketView v) => new BasketViewFactory().Create(v);

        protected internal override BasketView toView(Basket o) => new BasketViewFactory().Create(o);

        public Uri OrdersUrl => ordersUrl();
        protected internal Uri ordersUrl()
            => new Uri($"?handler=Orders" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);

        public async Task<IActionResult> OnGetSelectAsync(string id, string sortOrder, string searchString,
            int pageIndex, string fixedFilter, string fixedValue)
        {
            Basket b = await db.Get(id);
            await db.Close(b, id);
            Order o = await Orders.Add(b);
            await OrderItems.Add(o, b);

            var url = new Uri($"{OrdersPage}/Details?handler=Details" +
                              $"&id={o.Id}", UriKind.Relative);

            return Redirect(url.ToString());
        }

        protected abstract string OrdersPage { get; }

    }
}
