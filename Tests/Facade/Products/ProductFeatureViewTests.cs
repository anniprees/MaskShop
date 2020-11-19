using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class ProductFeatureViewTests : SealedClassTests<ProductFeatureView, DefinedView>
    {
        [TestMethod]
        public void ProductIdTest() => IsNullableProperty<string>("Product Id");

        [TestMethod]
        public void ProductFeatureTypeIdTest() => IsNullableProperty<string>("Product Feature Type Id");
    }
}
