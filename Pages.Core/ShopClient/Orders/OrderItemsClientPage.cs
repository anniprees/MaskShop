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
    public class OrderItemsClientPage : OrderItemsPage<OrderItemsClientPage>
    {
        public OrderItemsClientPage(IOrderItemsRepository r, IOrdersRepository o, IProductsRepository p) 
            : base(r, o, p) { }

        protected internal override Uri pageUrl() => new Uri("/Client/OrderItems", UriKind.Relative);

        protected override void createTableColumns()
        {
            createColumn(x => Item.ProductName);
            //createColumn(x => Item.ProductImage);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.TotalPrice);
        }
        public override IHtmlContent GetValue(IHtmlHelper<OrderItemsClientPage> h, int i) => i switch
        {
            //1 => h.DisplayImageFor(Item.ProductImage),
            _ => base.GetValue(h, i)
        };
    }
}
