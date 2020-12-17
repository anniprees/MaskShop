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
    public class BasketItemsRepository : PaginatedRepository<BasketItem, BasketItemData>, IBasketItemsRepository
    {
        public BasketItemsRepository(ShopDbContext c) : base(c, c.BasketItems) { }

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
