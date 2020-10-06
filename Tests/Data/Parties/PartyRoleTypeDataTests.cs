using Aids;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyRoleTypeDataTests : AbstractClassTests <PartyRoleTypeData, UniqueEntityData>
    {
        private class TestClass : PartyRoleTypeData { }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }
        [TestMethod] public void PartyRoleIdTest() => IsNullableProperty(() => obj.PartyRoleId, x => obj.PartyRoleId = x);
    }
}
