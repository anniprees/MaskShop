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
    [TestClass]
    public class PriceComponentViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => type = typeof(PriceComponentViewFactory);

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PriceComponentView>();
            var data = PriceComponentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PriceComponentData>();
            var view = PriceComponentViewFactory.Create(new PriceComponent(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
