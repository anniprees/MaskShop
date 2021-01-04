
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class ProductViewFactoryTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => Type = typeof(ProductViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductView>();
            var data =  new ProductViewFactory().Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductData>();
            var view = new ProductViewFactory().Create(new Product(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}