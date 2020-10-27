using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class OrderValueViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(OrderValueViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<OrderValueView>();
            var data = OrderValueViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<OrderValueData>();
            var view = OrderValueViewFactory.Create(new OrderValue(data));

            TestArePropertyValuesEqual(view, data);

        }
    }
}