using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public sealed class OrderViewFactory : AbstractViewFactory<OrderData, Order, OrderView>
    {
        protected internal override Order ToObject(OrderData d) => new Order(d);

        public override OrderView Create(Order o)
        {
            var v = base.Create(o);
            v.PartyNameId = o.Party.PartyName.Name;
            v.ContactMechanismId = o.Party.ContactMechanism.Address;
            v.TotalPrice = o.TotalPrice;
            return v;
        }
    }
}
