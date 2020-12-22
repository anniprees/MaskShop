using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Parties
{
    [TestClass]
    public class PartyAttributeTests : AbstractClassTests<PartyAttributeData, UniqueEntityData>
    {
        private class TestClass : PartyAttributeData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod] public void PartyIdTest() => Assert.Inconclusive();
    }
}