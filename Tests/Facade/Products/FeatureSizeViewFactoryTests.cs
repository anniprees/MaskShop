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
    public class FeatureSizeViewFactoryTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(FeatureSizeViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<FeatureSizeView>();
            var data = FeatureSizeViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<FeatureSizeData>();
            var view = FeatureSizeViewFactory.Create(new FeatureSize(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
