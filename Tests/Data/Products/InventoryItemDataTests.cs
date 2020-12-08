using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class InventoryItemDataTests : SealedClassTests<InventoryItemData, UniqueEntityData> 
    {
        [TestMethod] public void QuantityOnHandTest() => IsProperty(() => obj.QuantityOnHand, x => obj.QuantityOnHand = x);

        [TestMethod] public void ProductIdTest() => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);
    }
}

