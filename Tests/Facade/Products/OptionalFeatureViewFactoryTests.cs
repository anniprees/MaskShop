using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class OptionalFeatureViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => type = typeof(OptionalFeatureViewFactory);

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<OptionalFeatureView>();
            var data = OptionalFeatureViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<OptionalFeatureData>();
            var view = OptionalFeatureViewFactory.Create(new OptionalFeature(data));

            TestArePropertyValuesEqual(view, data);

        }
    }
}