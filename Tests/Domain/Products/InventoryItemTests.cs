using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class InventoryItemTests : SealedClassTests<InventoryItem, UniqueEntity<InventoryItemData>>
    {
        protected override InventoryItem CreateObject() => new InventoryItem(GetRandom.Object<InventoryItemData>());

        [TestMethod]
        public void QuantityOnHandTest() => IsReadOnlyProperty(obj.Data.QuantityOnHand);
        [TestMethod]
        public void ProductIdTest() => IsReadOnlyProperty(obj.Data.ProductId);
        [TestMethod]
        public void ProductFeatureApplicabilityIdTest() => IsReadOnlyProperty(obj.Data.ProductFeatureApplicabilityId);

        [TestMethod]
        public void ProductTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ProductId), obj.Data.ProductId);
        [TestMethod]
        public void ProductFeatureApplicabilityTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ProductFeatureApplicabilityId), obj.Data.ProductFeatureApplicabilityId);

    }
}