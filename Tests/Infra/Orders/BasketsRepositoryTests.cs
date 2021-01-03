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
    public class BasketsRepositoryTests : ShopDbContextTests<BasketsRepository, Basket, BasketData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<Basket, BasketData>);

        protected override BasketsRepository GetObject(ShopDbContext c) => new BasketsRepository(c);

        protected override DbSet<BasketData> GetSet(ShopDbContext c) => c.Baskets;
    }
}
