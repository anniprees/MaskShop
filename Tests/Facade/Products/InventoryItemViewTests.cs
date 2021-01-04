using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] 
    public class InventoryItemViewTests : SealedClassTests<InventoryItemView, UniqueEntityView>
    {
        [TestMethod]
        public void QuantityOnHandTest() => IsProperty<int>("Quantity on hand");

        [TestMethod]
        public void ProductIdTest() => IsNullableProperty<string>("Product");

        [TestMethod]
        public void ProductFeatureApplicabilityIdTest() => IsNullableProperty<string>("Product Feature");
    }
}
