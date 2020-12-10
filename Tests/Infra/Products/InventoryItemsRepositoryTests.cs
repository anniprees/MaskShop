using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;
using MaskShop.Infra.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Products
{
    [TestClass]
    public class InventoryItemsDbContextTests : ProductDbContextTests<InventoryItemsRepository, InventoryItem, InventoryItemData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<InventoryItem, InventoryItemData>);

        protected override InventoryItemsRepository GetObject(ProductDbContext c) =>
            new InventoryItemsRepository(c);

        protected override DbSet<InventoryItemData> GetSet(ProductDbContext c) => c.InventoryItems;
    }
}