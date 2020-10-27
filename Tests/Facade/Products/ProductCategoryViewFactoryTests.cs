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
    public class ProductCategoryViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ProductCategoryViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductCategoryView>();
            var data = ProductCategoryViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductCategoryData>();
            var view = ProductCategoryViewFactory.Create(new ProductCategory(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}