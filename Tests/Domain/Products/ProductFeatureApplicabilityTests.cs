using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductFeatureApplicabilityTests : SealedClassTests<ProductFeatureApplicability, UniqueEntity<ProductFeatureApplicabilityData>>
    {
        protected override ProductFeatureApplicability CreateObject() => new ProductFeatureApplicability(GetRandom.Object<ProductFeatureApplicabilityData>());

        [TestMethod]
        public void ProductIdTest() => IsReadOnlyProperty(obj.Data.ProductId);

        [TestMethod]
        public void ProductFeatureIdTest() => IsReadOnlyProperty(obj.Data.ProductFeatureId);

        [TestMethod]
        public void ProductTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ProductId), obj.Data.ProductId);

        [TestMethod]
        public void ProductFeatureTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ProductFeatureId), obj.Data.ProductFeatureId);
    }
}