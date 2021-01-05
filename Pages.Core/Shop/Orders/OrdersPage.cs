using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Orders
{
    public abstract class OrdersPage<TPage> : ViewPage<TPage, IOrdersRepository, Order, OrderView, OrderData>
        where TPage : PageModel
    {

        protected OrdersPage(IOrdersRepository r) : base(r, "Orders") { }

        protected internal override Order toObject(OrderView v) => new OrderViewFactory().Create(v);

        protected internal override OrderView toView(Order o) => new OrderViewFactory().Create(o);

        protected internal override Uri pageUrl() => new Uri("/Shop/Orders", UriKind.Relative);

        protected override void createTableColumns()
        {
            createColumn(x => Item.BuyerName);
            createColumn(x => Item.ContactMechanismId);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.OrderStatus);
        }
    }
}
