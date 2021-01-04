using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Common
{
    [TestClass]
    public class AbstractViewFactoryTests : AbstractClassTests<AbstractViewFactory<ProductCategoryData, ProductCategory, ProductCategoryView>, object>
    {
        private class TestClass : AbstractViewFactory<ProductCategoryData, ProductCategory, ProductCategoryView>
        {
            protected internal override ProductCategory ToObject(ProductCategoryData d) => new ProductCategory(d);
        }

        [TestInitialize] public override void TestInitialize() => type = typeof(AbstractViewFactory<ProductCategoryData, ProductCategory, ProductCategoryView>);

        [TestMethod]
        public void CreateTest() => Assert.Inconclusive();


        [TestMethod]
        public void CreateViewTest() => Assert.Inconclusive();

    }
}