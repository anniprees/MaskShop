using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class ProductFeatureTypeViewTests : SealedClassTests<ProductFeatureCategoryView, DefinedView>
    {
        [TestMethod]
        public void IsMandatoryTest() => IsProperty<bool>("Is Mandatory Feature");

        [TestMethod]
        public void NumericCodeTest() => IsProperty<int>("Numeric Code");
    }
}
