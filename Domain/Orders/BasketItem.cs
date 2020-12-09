using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;

namespace MaskShop.Domain.Orders
{
    public sealed class BasketItem : ItemProduct<BasketItemData>
    {
        public BasketItem(BasketItemData d) :  base(d) { }

        public string BasketId => Data?.BasketId ?? Unspecified;
    }
}
