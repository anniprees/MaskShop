using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;

namespace MaskShop.Domain.Orders
{
    public sealed class Order : PartyProducts<OrderData>
    {
        private readonly string _orderId = GetMember.Name<OrderItemData>(x => x.OrderId);

        public Order(OrderData d) : base(d) { }

        public string ContactMechanismId => Data?.ContactMechanismId ?? Unspecified;

        public OrderStatus OrderStatus => Data?.OrderStatus?? OrderStatus.Unspecified;

        public IReadOnlyList<OrderItem> Items =>
        new GetFrom<IOrderItemsRepository, OrderItem>().ListBy(_orderId, Id);
        
        public ContactMechanism ContactMechanism => new GetFrom<IContactMechanismsRepository, ContactMechanism>().ById(ContactMechanismId);

        public decimal TotalPrice
        {
            get
            {
                var sum = decimal.Zero;
                foreach (var i in Items) sum += i.TotalPrice;
                return sum;
            }
        }
    }
}
