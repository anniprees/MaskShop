using Data.Common;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentItemDataTests : SealedTests<ShipmentItemData, UniqueEntityData> {
        [TestMethod] public void QuantityTest() => IsNullableProperty<int>();
        [TestMethod] public void ShipmentIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>();
    }
}


