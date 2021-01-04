using MaskShop.Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{

    [TestClass]
    public class GetEnumTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize() => Type = typeof(GetEnum);

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(4, GetEnum.Count<PartyType>());
            Assert.AreEqual(-1, GetEnum.Count<object>());
        }

        [TestMethod]
        public void CountByTypeTest()
        {
            Assert.AreEqual(4, GetEnum.Count(typeof(PartyType)));
            Assert.AreEqual(-1, GetEnum.Count(typeof(object)));
        }

        [TestMethod]
        public void ValueByTypeTest()
        {
            Assert.AreEqual(PartyType.Unspecified, GetEnum.Value(typeof(PartyType), 0));
            Assert.AreEqual(PartyType.Person, GetEnum.Value(typeof(PartyType), 1));
            Assert.AreEqual(PartyType.Organization, GetEnum.Value(typeof(PartyType), 2));
            Assert.AreEqual(PartyType.AutomatedAgent, GetEnum.Value(typeof(PartyType), 3));
        }

        [TestMethod]
        public void ValueTest()
        {
            Assert.AreEqual(PartyType.Unspecified, GetEnum.Value<PartyType>(0));
            Assert.AreEqual(PartyType.Person, GetEnum.Value<PartyType>(1));
            Assert.AreEqual(PartyType.Organization, GetEnum.Value<PartyType>(2));
            Assert.AreEqual(PartyType.AutomatedAgent, GetEnum.Value<PartyType>(3));
        }
    }
}
