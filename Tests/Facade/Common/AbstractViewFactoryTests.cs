using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using MaskShop.Data.Products;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using MaskShop.Facade.Common;
using MaskShop.Facade.Parties;
using MaskShop.Facade.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Common
{
    [TestClass]
    public class AbstractViewFactoryTests : AbstractClassTests<AbstractViewFactory<ProductCategoryData, ProductCategory, ProductCategoryView>, object>
    {
        private class TestClass : AbstractViewFactory<ProductCategoryData, ProductCategory, ProductCategoryView>
        {
            protected override ProductCategory ToObject(ProductCategoryData d) => new ProductCategory(d);
        }

        [TestInitialize] public override void TestInitialize() => type = typeof(AbstractViewFactory<ProductCategoryData, ProductCategory, ProductCategoryView>);

        [TestMethod]
        public void CreateTest() => Assert.Inconclusive();


        [TestMethod]
        public void CreateViewTest() => Assert.Inconclusive();

    }
}
