using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Orders
{
    public interface IOrderItemsRepository : IRepository<OrderItem>
    {
        Task Add(Order o, Basket b);
    }
}
