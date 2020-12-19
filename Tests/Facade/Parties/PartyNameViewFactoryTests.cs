using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class PartyNameViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(PartyNameViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PartyNameView>();
            var data = PartyNameViewFactory.Create(view).Data;
            TestArePropertiesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PartyNameData>();
            var view = PartyNameViewFactory.Create(new PartyName(data));
            TestArePropertiesEqual(view, data);
        }
    }
}
