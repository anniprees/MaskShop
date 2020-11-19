﻿using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class ProductFeatureTypeViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ProductFeatureCategoryViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductFeatureCategoryView>();
            var data = ProductFeatureCategoryViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductFeatureTypeData>();
            var view = ProductFeatureCategoryViewFactory.Create(new ProductFeatureCategory(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}