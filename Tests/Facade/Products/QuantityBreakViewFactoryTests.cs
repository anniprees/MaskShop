using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class QuantityBreakFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(QuantityBreakViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<QuantityBreakView>();
            var data = QuantityBreakViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<QuantityBreakData>();
            var view = QuantityBreakViewFactory.Create(new QuantityBreak(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}