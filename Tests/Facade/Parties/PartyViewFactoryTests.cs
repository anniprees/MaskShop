using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class PartyViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(PartyViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PartyView>();
            var data = PartyViewFactory.Create(view).Data;
            TestArePropertiesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PartyData>();
            var view = PartyViewFactory.Create(new Party(data));
            TestArePropertiesEqual(view, data);
        }
    }
}
