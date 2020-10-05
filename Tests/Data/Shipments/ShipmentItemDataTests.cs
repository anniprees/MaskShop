using Data.Common;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentItemDataTests : SealedTests<ShipmentItemData, UniqueEntityData> {
        [TestMethod] public void QuantityTest() => isNullableProperty<int>();
        [TestMethod] public void ShipmentIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductIdTest() => isNullableProperty<string>();
    }
}


