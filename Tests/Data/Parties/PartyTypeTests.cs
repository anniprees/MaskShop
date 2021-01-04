using MaskShop.Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyTypeTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(PartyType);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<PartyType>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)PartyType.Unspecified);
        [TestMethod]
        public void PersonTest() =>
            Assert.AreEqual(1, (int)PartyType.Person);
        [TestMethod]
        public void OrganizationTest() =>
            Assert.AreEqual(2, (int)PartyType.Organization);
        [TestMethod]
        public void AutomatedAgentTest() =>
            Assert.AreEqual(3, (int)PartyType.AutomatedAgent);
    }
}
