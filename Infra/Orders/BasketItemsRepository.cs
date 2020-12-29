using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Orders
{
    public class BasketItemsRepository : PaginatedRepository<BasketItem, BasketItemData>, IBasketItemsRepository
    {
        public BasketItemsRepository(ShopDbContext c) : base(c, c.BasketItems) { }

        public async Task<BasketItem> Add(Basket b, Product p)
        {
            BasketItemData d = new BasketItemData
            {
                BasketId = b.Id,
                ProductId = p.Id,
                Quantity = 1
            };
            var o = ToDomainObject(d);
            await Add(o);
            return o;
        }

        protected override async Task<BasketItemData> GetData(string id)
        {
            var basketId = id?.GetHead();
            var productId = id?.GetTail();
            return await dbSet.FirstOrDefaultAsync(
                m => m.BasketId == basketId && m.ProductId == productId);
        }

        protected override BasketItemData GetDataById(BasketItemData d)
            => dbSet.Find(d?.BasketId, d?.ProductId);

        protected internal override BasketItem ToDomainObject(BasketItemData d)
            => new BasketItem(d);
    }
}
