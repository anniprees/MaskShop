using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class PriceComponentDataTests : SealedClassTests<PriceComponentData, UniqueEntityData>
    {
        [TestMethod] public void PriceTest() => IsProperty(() => obj.Price, x => obj.Price = x);
        [TestMethod] public void PercentTest() => IsProperty<double>(() => obj.DiscountComponent, x => obj.DiscountComponent = x);
        [TestMethod] public void CommentTest() => IsNullableProperty<string>(() => obj.Comment, x => obj.Comment = x);
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>(() => obj.ProductId, x => obj.ProductId = x);
        [TestMethod] public void ConsumerRoleTypeIdTest() => IsNullableProperty<string>(() => obj.ConsumerRoleTypeId, x => obj.ConsumerRoleTypeId = x);
    }
}


