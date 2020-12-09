using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductTests : SealedClassTests<Product, NamedEntity<ProductData>>
    {
        protected override Product CreateObject() => new Product(GetRandom.Object<ProductData>());

        [TestMethod]
        public void ProductCategoryIdTest() => IsReadOnlyProperty(obj.Data.ProductCategoryId);
        
        [TestMethod]
        public void PriceComponentIdTest() => IsReadOnlyProperty(obj.Data.PriceComponentId);

        [TestMethod]
        public void ProductFeatureApplicabilityIdTest() => IsReadOnlyProperty(obj.Data.ProductFeatureApplicabilityId);

        [TestMethod]
        public void PriceTest() => IsReadOnlyProperty(obj.Data.Price);

        [TestMethod]
        public void PictureUriTest() => IsReadOnlyProperty(obj.Data.PictureUri);

        [TestMethod]
        public void PictureTest() => IsReadOnlyProperty(obj.Data.Picture);

        [TestMethod]
        public void ProductCategoryTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ProductCategoryId), obj.Data.ProductCategoryId);

        [TestMethod]
        public void PriceComponentTest() =>
            IsReadOnlyProperty(obj, nameof(obj.PriceComponentId), obj.Data.PriceComponentId);

        [TestMethod]
        public void ProductFeatureApplicabilityTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ProductFeatureApplicabilityId), obj.Data.ProductFeatureApplicabilityId);

    }
}