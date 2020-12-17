using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Orders
{
    public sealed class OrdersRepository : UniqueEntityRepository<Order, OrderData>, IOrdersRepository
    {
        public OrdersRepository(ShopDbContext c = null) : base(c, c?.Orders) { }

        protected internal override Order ToDomainObject(OrderData d)
            => new Order(d);
    }
}
