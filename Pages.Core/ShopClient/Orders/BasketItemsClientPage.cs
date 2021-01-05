using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Orders;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopClient.Orders
{
    public class BasketItemsClientPage : BasketItemsPage<BasketItemsClientPage>
    {
        protected override string ordersPage => "/Client/Orders";
        public BasketItemsClientPage(IBasketItemsRepository r, IBasketsRepository b, 
            IOrdersRepository o, IOrderItemsRepository oi, IProductsRepository p) 
            : base(r, b, o, oi, p) { }

        protected internal override Uri pageUrl() => new Uri("/Client/BasketItems", UriKind.Relative);
        
        public override IHtmlContent GetValue(IHtmlHelper<BasketItemsClientPage> h, int i) => i switch
        {
            1 => h.DisplayImageFor(Item.ProductImage),
            _ => base.GetValue(h, i)
        };
    }
}
