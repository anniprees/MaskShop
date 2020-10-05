using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class QuantityBreakDataClassTests : SealedClassTests<QuantityBreakData, UniqueEntityData>
    {
        [TestMethod] public void FromQuantityTest() => IsProperty<int>(() => obj.FromQuantity, x => obj.FromQuantity = x);
    }
}

