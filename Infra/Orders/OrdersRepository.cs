using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Orders
{
    public sealed class OrdersRepository : UniqueEntityRepository<Order, OrderData>, IOrdersRepository
    {
        public OrdersRepository(ShopDbContext c = null) : base(c, c?.Orders) { }

        public async Task<Order> Add(Basket b)
        {
            OrderData d = new OrderData
            {
                PartyId = b.PartyId,
                Name = b.Name,
                ContactMechanismId = b.Party.ContactMechanismId,
                OrderStatus = OrderStatus.Received,
                ValidFrom = b.ValidFrom
            };
            var obj = ToDomainObject(d);
            await Add(obj);
            return obj;
        }

        protected internal override Order ToDomainObject(OrderData d)
            => new Order(d);
    }
}
