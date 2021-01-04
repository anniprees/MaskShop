using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public class BasketItemViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(BasketItemViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<BasketItemView>();
            var data = new BasketItemViewFactory().Create(view).Data;
            TestArePropertiesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<BasketItemData>();
            var view = new BasketItemViewFactory().Create(new BasketItem(data));
            TestArePropertiesEqual(view, data);
        }
    }
}
