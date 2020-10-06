using MaskShop.Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyTypeDataTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(PartyTypeData);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<PartyTypeData>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)PartyTypeData.Unspecified);
        [TestMethod]
        public void PersonTest() =>
            Assert.AreEqual(1, (int)PartyTypeData.Person);
        [TestMethod]
        public void OrganizationTest() =>
            Assert.AreEqual(2, (int)PartyTypeData.Organization);
        [TestMethod]
        public void AutomatedAgentTest() =>
            Assert.AreEqual(3, (int)PartyTypeData.AutomatedAgent);
    }
}
