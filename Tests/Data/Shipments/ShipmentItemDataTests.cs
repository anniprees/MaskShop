using Data.Common;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentItemDataClassTests : SealedClassTests<ShipmentItemData, UniqueEntityData> {
        [TestMethod] public void QuantityTest() => IsProperty<int>(() => obj.Quantity, x => obj.Quantity = x);
        [TestMethod] public void ShipmentIdTest() => IsNullableProperty<string>(() => obj.ShipmentId, x => obj.ShipmentId = x);
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>(() => obj.ProductId, x => obj.ProductId = x);
    }
}


