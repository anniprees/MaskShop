using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class InventoryItemViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(InventoryItemViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<InventoryItemView>();
            var data = InventoryItemViewFactory.Create(view).Data;
            TestArePropertiesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<InventoryItemData>();
            var view = InventoryItemViewFactory.Create(new InventoryItem(data));
            TestArePropertiesEqual(view, data);
        }
    }
}