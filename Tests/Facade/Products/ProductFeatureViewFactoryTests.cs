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
    public class ProductFeatureViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ProductFeatureViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductFeatureView>();
            var data = ProductFeatureViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductFeatureData>();
            var view = ProductFeatureViewFactory.Create(new ProductFeature(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}