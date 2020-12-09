using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class PriceComponentDataTests : SealedClassTests<PriceComponentData, UniqueEntityData>
    {
        [TestMethod] public void DiscountPercentageTest() => IsProperty<double>(() => obj.DiscountPercentage, x => obj.DiscountPercentage = x);
        [TestMethod] public void CommentTest() => IsNullableProperty<string>(() => obj.Comment, x => obj.Comment = x);
        [TestMethod] public void PartyRoleIdTest() => IsNullableProperty<string>(() => obj.PartyRoleId, x => obj.PartyRoleId = x);
    }
}


