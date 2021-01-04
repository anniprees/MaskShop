using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Shop.Orders;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopAdmin.Orders
{
    public class OrderItemsAdminPage : OrderItemsPage<OrderItemsAdminPage>
    {
        public OrderItemsAdminPage(IOrderItemsRepository r, IOrdersRepository o, IProductsRepository p) 
            : base(r, o, p) { }

        protected internal override Uri pageUrl() => new Uri("/Shop/OrderItems", UriKind.Relative);

        protected override void createTableColumns()
        {
            createColumn(x => Item.GetId());
            createColumn(x => Item.OrderId);
            createColumn(x => Item.ProductId);
            createColumn(x => Item.ProductName);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

        public override string GetName(IHtmlHelper<OrderItemsAdminPage> h, int i) => i switch
        {
            0 => "Id",
            _ => base.GetName(h, i)
        };
        public override IHtmlContent GetValue(IHtmlHelper<OrderItemsAdminPage> h, int i) => i switch
        {
            0 => getRaw(h, Item.GetId()),
            _ => base.GetValue(h, i)
        };

    }
}
