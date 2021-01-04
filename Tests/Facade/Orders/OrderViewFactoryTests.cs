using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public class OrderViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(OrderViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateObjectTest() => Assert.Inconclusive();

        [TestMethod] public void CreateViewTest() => Assert.Inconclusive();
    }
}
