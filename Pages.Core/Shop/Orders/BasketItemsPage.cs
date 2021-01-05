using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Data.Orders;
using MaskShop.Data.Products;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Facade.Orders;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Orders
{
    public abstract class BasketItemsPage<TPage> 
        : ViewPage<TPage, IBasketItemsRepository, BasketItem, BasketItemView, BasketItemData>
        where TPage : PageModel
    {
        public IEnumerable<SelectListItem> Products { get; }
        public IEnumerable<SelectListItem> Baskets { get; }
        public IBasketsRepository BasketsRepo { get; }
        public IOrdersRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }

        protected BasketItemsPage(IBasketItemsRepository r, IBasketsRepository b, 
            IOrdersRepository o, IOrderItemsRepository oi, IProductsRepository p) : base(r, "Basket items")
        {
            Baskets = newItemsList<Basket, BasketData>(b);
            BasketsRepo = b;
            Orders = o;
            OrderItems = oi;
            Products = newItemsList<Product, ProductData>(p);
        }

        protected internal override string pageSubtitle() => BasketsName(FixedValue);
        public string BasketsName(string id) => itemName(Baskets, id);
        public string ProductName(string id) => itemName(Products, id);
        protected internal override BasketItem toObject(BasketItemView v) => new BasketItemViewFactory().Create(v);
        protected internal override BasketItemView toView(BasketItem o) => new BasketItemViewFactory().Create(o);
        public Uri OrdersUrl => ordersUrl();
        protected internal Uri ordersUrl()
            => new Uri($"{PageUrl}/Orders" +
                       "?handler=Orders" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            return Redirect("/Client/Products/Index?handler=Index");
        }

        public async Task<IActionResult> OnGetOrdersAsync(string id, string sortOrder, string searchString,
            int pageIndex, string fixedFilter, string fixedValue)
        {

            Basket b = await BasketsRepo.Get(fixedValue);
            //await BasketsRepo.Close(b);
            Order o = await Orders.Add(b);
            await OrderItems.Add(o, b);

            var url = new Uri($"{ordersPage}/Details?handler=Details" +
                              $"&id={o.Id}", UriKind.Relative);

            return Redirect(url.ToString());
        }
        protected override void createTableColumns()
        {
            createColumn(x => Item.ProductName);
            createColumn(x=> Item.ProductImage);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.TotalPrice);
        }

        protected abstract string ordersPage { get; }

    }
}
