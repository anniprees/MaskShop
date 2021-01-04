using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Orders
{
    public class OrderItemsRepository : PaginatedRepository<OrderItem, OrderItemData>, IOrderItemsRepository
    {
        public OrderItemsRepository(ShopDbContext c) : base(c, c.OrderItems) { }

        public async Task Add(Order o, Basket b)
        {
            foreach (var e in b.Items)
            {
                OrderItemData d = new OrderItemData
                {
                    OrderId = o.Id,
                    ProductId = e.ProductId,
                    Quantity = e.Quantity
                };
                var obj = ToDomainObject(d);
                await Add(obj);
            }
        }

        protected override async Task<OrderItemData> GetData(string id)
        {
            var orderId = id?.GetHead();
            var productId = id?.GetTail();
            return await dbSet.FirstOrDefaultAsync(
                m => m.OrderId == orderId && m.ProductId == productId);
        }

        protected override OrderItemData GetDataById(OrderItemData d)
            => dbSet.Find(d?.OrderId, d?.ProductId);

        protected internal override OrderItem ToDomainObject(OrderItemData d)
            => new OrderItem(d);
    }
}
