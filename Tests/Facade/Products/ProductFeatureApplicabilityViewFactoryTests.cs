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
    public class ProductFeatureApplicabilityViewFactoryTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(ProductFeatureApplicabilityViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductFeatureApplicabilityView>();
            var data = ProductFeatureApplicabilityViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductFeatureApplicabilityData>();
            var view = ProductFeatureApplicabilityViewFactory.Create(new ProductFeatureApplicability(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
