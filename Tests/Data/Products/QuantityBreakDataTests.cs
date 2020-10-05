using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class QuantityBreakDataTests : SealedTests<QuantityBreakData, UniqueEntityData>{
        [TestMethod] public void FromQuantityTest() => IsNullableProperty<int>();
    }
}

