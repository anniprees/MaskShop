using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Orders
{
    public interface  IOrdersRepository : IRepository<Order>
    {
        Task<Order> Add(Basket b);
    }
}
