using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class ProductViewTests : SealedClassTests<ProductView, NamedView>
    {
        [TestMethod]
        public void ProductCategoryIdTest() => IsNullableProperty<string>("Product category Id");
    }
}
