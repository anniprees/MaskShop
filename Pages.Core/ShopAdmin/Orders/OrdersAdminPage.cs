using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
using MaskShop.PagesCore.Common;
using MaskShop.PagesCore.Shop.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopAdmin.Orders
{
    public class OrdersAdminPage : OrdersPage<OrdersAdminPage>
    {
        public IEnumerable<SelectListItem> OrderStatus
        {
            get
            {
                return Enum.GetNames(typeof(OrderStatus)).Select(o => new SelectListItem() { Text = o, Value = o });
            }
        }

        public OrdersAdminPage(IOrdersRepository r) : base(r) { }

        protected internal override Uri pageUrl() => new Uri("/Shop/Orders", UriKind.Relative);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.PartyId);
            createColumn(x => Item.BuyerName);
            createColumn(x => Item.ContactMechanismId);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.OrderStatus);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
    }
}