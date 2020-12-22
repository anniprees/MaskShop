using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    public class PartyProductsTests : AbstractClassTests<PartyProducts<OrderData>, DefinedEntity<OrderData>>
    {
        private class TestClass : PartyProducts<OrderData>
        {
            public TestClass(OrderData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
    }
}
