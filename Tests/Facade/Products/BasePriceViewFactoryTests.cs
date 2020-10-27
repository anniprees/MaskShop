using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
   [TestClass] public class BasePriceViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(BasePriceViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<BasePriceView>();
            var data = BasePriceViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<BasePriceData>();
            var view = BasePriceViewFactory.Create(new BasePrice(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}