using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Orders;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Orders;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopClient.Orders
{
    public class OrdersClientPage : OrdersPage<OrdersClientPage>
    {
        public OrdersClientPage(IOrdersRepository r) : base(r) { }
        protected internal override Uri pageUrl() => new Uri("/Client/Orders", UriKind.Relative);

        public override IHtmlContent GetValue(IHtmlHelper<OrdersClientPage> h, int i) => i switch
        {
            //1 => h.DisplayImageFor(Item.ProductImage),
            _ => base.GetValue(h, i)
        };

    }
}
