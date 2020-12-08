using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class FeatureColorViewFactoryTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(FeatureColorViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<FeatureColorView>();
            var data = FeatureColorViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<FeatureColorData>();
            var view = FeatureColorViewFactory.Create(new FeatureColor(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}