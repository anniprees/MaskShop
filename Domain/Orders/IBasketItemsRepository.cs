using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;

namespace MaskShop.Domain.Orders
{
    public interface IBasketItemsRepository : IRepository<BasketItem>
    {
        Task<BasketItem> Add(Basket b, Product p);

    }
}
