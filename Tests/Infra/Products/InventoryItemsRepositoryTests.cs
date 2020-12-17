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
    public class InventoryItemsRepositoryTests : ProductDbContextTests<InventoryItemsRepository, InventoryItem, InventoryItemData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<InventoryItem, InventoryItemData>);

        protected override InventoryItemsRepository GetObject(ShopDbContext c) =>
            new InventoryItemsRepository(c);

        protected override DbSet<InventoryItemData> GetSet(ShopDbContext c) => c.InventoryItems;
    }
}