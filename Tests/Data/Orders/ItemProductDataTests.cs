using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class ItemProductDataTests : AbstractClassTests<ItemProductData, PeriodData>
    {
        private class TestClass : ItemProductData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void ProductIdTest()
            => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void QuantityTest()
            => IsProperty(() => obj.Quantity, x => obj.Quantity = x);
    }
}
