using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public class OrderViewFactory
    {
        protected internal Order ToObject(OrderData d) => new Order(d);

        public Order Create(OrderView v)
        {
            var d = new OrderData();
            Copy.Members(v, d);
            return new Order(d);
        }

        public OrderView Create(Order o)
        {
            var v = new OrderView();
            Copy.Members(o?.Data, v);
            //v.BuyerName = o.Party.Name;
            //v.ContactMechanismId = o.Party.ContactMechanism.Address;
            v.TotalPrice = o?.TotalPrice ?? decimal.Zero;
            v.OrderStatus = o.OrderStatus;
            return v;
        }
    }
}
