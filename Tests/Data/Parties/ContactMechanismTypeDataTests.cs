using MaskShop.Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismTypeDataTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ContactMechanismType);

        [TestMethod] public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<ContactMechanismType>());

        [TestMethod] public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)ContactMechanismType.Unspecified);
        [TestMethod] public void PostalAddressTest() =>
            Assert.AreEqual(1, (int)ContactMechanismType.PostalAddress);
        [TestMethod] public void TelecomNumberTest() =>
            Assert.AreEqual(2, (int)ContactMechanismType.TelecomNumber);
        [TestMethod] public void ElectronicAddressTest() =>
            Assert.AreEqual(3, (int)ContactMechanismType.ElectronicAddress);
    }
}
