using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyRoleDataTests : SealedClassTests <PartyRoleData, PartyAttributeData>
    {
        [TestMethod] public void RoleTest() => IsNullableProperty(() => obj.Role, x => obj.Role = x);
    }
}
