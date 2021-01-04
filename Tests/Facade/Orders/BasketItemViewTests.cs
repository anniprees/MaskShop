using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public class BasketItemViewTests : SealedClassTests<BasketItemView, ItemProductView>
    {
        [TestMethod] public void UnitPriceTest() => IsProperty<decimal>("Unit price");
        
        [TestMethod] public void TotalPriceTest() => IsProperty<decimal>("Total price");

        [TestMethod] public void BasketIdTest() => IsNullableProperty<string>("Basket");

        [TestMethod] public void ProductNameTest() => IsNullableProperty<string>("Product");

        [TestMethod] public void ProductImageTest() => IsNullableProperty<string>("Product image");

        [TestMethod] public void GetIdTest() => Assert.Inconclusive();
    }
}
