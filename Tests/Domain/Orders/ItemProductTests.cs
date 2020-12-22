using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    public class ItemProductTests : AbstractClassTests<ItemProduct<OrderItemData>, Entity<OrderItemData>>
    {
        private class TestClass : ItemProduct<OrderItemData>
        {
            public TestClass(OrderItemData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
    }
}
