using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;

namespace MaskShop.Domain.Orders
{
    public sealed class OrderItem : ItemProduct<OrderItemData>
    {
        public OrderItem(OrderItemData d) : base(d) { }

        public string OrderId => Data?.OrderId ?? Unspecified;
    }
}
