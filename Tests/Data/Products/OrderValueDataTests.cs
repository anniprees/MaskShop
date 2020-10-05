using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class OrderValueDataClassTests : SealedClassTests<OrderValueData, UniqueEntityData> 
    {
        [TestMethod] public void FromAmountTest() => IsProperty<double>(() => obj.FromAmount, x => obj.FromAmount = x);
    }
}
