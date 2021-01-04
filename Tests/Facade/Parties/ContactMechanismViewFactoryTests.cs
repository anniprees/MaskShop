using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class ContactMechanismViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(ContactMechanismViewFactory);
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ContactMechanismView>();
            var data = ContactMechanismViewFactory.Create(view).Data;
            TestArePropertiesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ContactMechanismData>();
            var view = ContactMechanismViewFactory.Create(new ContactMechanism(data));
            TestArePropertiesEqual(view, data);
        }
    }
}
