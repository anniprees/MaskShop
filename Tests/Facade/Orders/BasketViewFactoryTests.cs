using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public class BasketViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(BasketViewFactory);
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateObjectTest() => Assert.Inconclusive();
        [TestMethod] public void CreateViewTest() => Assert.Inconclusive();

    }
}
