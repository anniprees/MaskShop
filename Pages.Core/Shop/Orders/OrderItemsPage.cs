using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Data.Products;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Facade.Orders;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Orders
{
    public class OrderItemsPage : ViewPage<OrderItemsPage, IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData>
    {
        public IEnumerable<SelectListItem> Products { get; }

        public IEnumerable<SelectListItem> Orders { get; }

        public OrderItemsPage(IOrderItemsRepository r, IOrdersRepository o, IProductsRepository p)
            : base(r, "Order items")
        {
            Products = newItemsList<Product, ProductData>(p);
            Orders = newItemsList<Order, OrderData>(o);
        }

        protected internal override string pageSubtitle() => OrderName(FixedValue);

        public string OrderName(string id) => itemName(Orders, id);

        public string ProductName(string id) => itemName(Products, id);

        protected internal override OrderItem toObject(OrderItemView v) => new OrderItemViewFactory().Create(v);

        protected internal override OrderItemView toView(OrderItem o) => new OrderItemViewFactory().Create(o);

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

        public override string GetName(IHtmlHelper<OrderItemsPage> h, int i) => i switch
        {
            0 => "Id",
            _ => base.GetName(h, i)
        };
        public override IHtmlContent GetValue(IHtmlHelper<OrderItemsPage> h, int i) => i switch
        {
            0 => getRaw(h, Item.GetId()),
            _ => base.GetValue(h, i)
        };
    }
}
