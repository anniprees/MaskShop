using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class OrderValueDataTests : SealedTests<OrderValueData, UniqueEntityData> {
        [TestMethod] public void FromAmountTest() => isNullableProperty<double>();
    }
}
