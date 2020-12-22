using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    public class OrderItemTests : SealedClassTests<OrderItem, ItemProduct<OrderItemData>>
    {
        [TestMethod]
        public void OrderIdTest() => IsReadOnlyProperty(obj.Data.OrderId);
    }
}
