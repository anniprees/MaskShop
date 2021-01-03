using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public static class OrderViewFactory
    {
        //protected internal override Order ToObject(OrderData d) => new Order(d);

        public static Order Create(OrderView v)
        {
            var d = new OrderData();
            Copy.Members(v, d);
            return new Order(d);
        }

        public static OrderView Create(Order o)
        {
            var v = new OrderView();
            Copy.Members(o?.Data, v);
            //v.PartyNameId = o.PartyName.Name;
            v.ContactMechanismId = o.Party.ContactMechanism.Address;
            v.TotalPrice = o.TotalPrice;
            v.OrderStatus = OrderStatus.Received;
            return v;
        }
    }
}
