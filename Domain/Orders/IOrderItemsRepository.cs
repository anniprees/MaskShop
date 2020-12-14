using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Orders
{
    public interface IOrderItemsRepository : IRepository<OrderItem>
    {
    }
}
