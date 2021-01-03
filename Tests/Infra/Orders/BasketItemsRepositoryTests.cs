using System;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Infra;
using MaskShop.Infra.Common;
using MaskShop.Infra.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Orders
{
    [TestClass]
    public class BasketItemsRepositoryTests : ShopDbContextTests<BasketItemsRepository, BasketItem, BasketItemData>
    {
        protected override Type GetBaseClass() => typeof(PaginatedRepository<BasketItem, BasketItemData>);

        protected override BasketItemsRepository GetObject(ShopDbContext c) => new BasketItemsRepository(c);

        protected override DbSet<BasketItemData> GetSet(ShopDbContext c) => c.BasketItems;

    }
}
