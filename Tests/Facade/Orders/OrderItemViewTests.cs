using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public sealed class OrderItemViewTests : SealedClassTests<OrderItemView, ItemProductView>
    {
        [TestMethod] public void ProductNameTest() => IsNullableProperty<string>("Product name");

        [TestMethod] public void PictureUriTest() => IsNullableProperty<string>("Product image");

        [TestMethod] public void UnitPriceTest() => IsProperty<decimal>("Unit price");

        [TestMethod] public void TotalPriceTest() => IsProperty<decimal>("Total price");

        [TestMethod] public void OrderIdTest() => IsNullableProperty<string>("Order");

        [TestMethod] public void GetIdTest() => Assert.Inconclusive();
    }
}
