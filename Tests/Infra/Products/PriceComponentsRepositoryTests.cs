using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra;
using MaskShop.Infra.Common;
using MaskShop.Infra.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Products
{
    [TestClass]
    public class PriceComponentsRepositoryTests : ShopDbContextTests<PriceComponentsRepository, PriceComponent, PriceComponentData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<PriceComponent, PriceComponentData>);

        protected override PriceComponentsRepository GetObject(ShopDbContext c) =>
            new PriceComponentsRepository(c);

        protected override DbSet<PriceComponentData> GetSet(ShopDbContext c) => c.PriceComponents;
    }
}