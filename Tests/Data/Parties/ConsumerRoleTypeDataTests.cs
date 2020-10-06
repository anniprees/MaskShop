using MaskShop.Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ConsumerRoleTypeDataTests : AbstractClassTests <ConsumerRoleTypeData, PartyRoleTypeData>
    {
        private class TestClass : ConsumerRoleTypeData { }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }
    }
}
