using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class PartyRoleViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(PartyRoleViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PartyRoleView>();
            var data = PartyRoleViewFactory.Create(view).Data;
            TestArePropertiesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PartyRoleData>();
            var view = PartyRoleViewFactory.Create(new PartyRole(data));
            TestArePropertiesEqual(view, data);
        }
    }
}
