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
    public class OrderItemsRepositoryTests : ShopDbContextTests<OrderItemsRepository, OrderItem, OrderItemData>
    {
        protected override Type GetBaseClass() => typeof(PaginatedRepository<OrderItem, OrderItemData>);

        protected override OrderItemsRepository GetObject(ShopDbContext c) =>
            new OrderItemsRepository(c);

        protected override DbSet<OrderItemData> GetSet(ShopDbContext c) => c.OrderItems;
        [TestMethod]
        public void AddTest() => Assert.Inconclusive();
    }
}
