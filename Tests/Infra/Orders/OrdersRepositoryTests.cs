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
    public class OrdersRepositoryTests : ShopDbContextTests<OrdersRepository, Order, OrderData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<Order, OrderData>);

        protected override OrdersRepository GetObject(ShopDbContext c) =>
            new OrdersRepository(c);

        protected override DbSet<OrderData> GetSet(ShopDbContext c) => c.Orders;
    }
}