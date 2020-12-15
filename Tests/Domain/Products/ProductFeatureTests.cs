using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductFeatureTests : SealedClassTests<ProductFeature, DefinedEntity<ProductFeatureData>>
    {
        protected override ProductFeature CreateObject() => new ProductFeature(GetRandom.Object<ProductFeatureData>());

        [TestMethod]
        public void NumericCodeTest() => IsReadOnlyProperty(obj.Data.NumericCode);
    }
}
