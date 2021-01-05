using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public sealed class BasketViewFactory : AbstractViewFactory<BasketData, Basket, BasketView>
    {
        protected internal override Basket ToObject(BasketData d ) => new Basket(d);

        public override BasketView Create(Basket o)
        {
            var v = base.Create(o);
            v.PartyName = o?.Party?.Name;
            v.PartyAddress = o?.Party?.ContactMechanism.Address;
            v.TotalPrice = o?.TotalPrice ?? decimal.Zero;
            return v;
        }
    }
}
