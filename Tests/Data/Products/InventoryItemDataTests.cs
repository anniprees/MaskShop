using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class InventoryItemDataTests : SealedTests<InventoryItemData, UniqueEntityData> {

        [TestMethod] public void QuantityOnHandTest() => IsNullableProperty<int>();

        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>();
    }
}

