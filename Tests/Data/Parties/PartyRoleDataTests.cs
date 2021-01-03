using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyRoleDataTests : SealedClassTests <PartyRoleData, UniqueEntityData>
    {
        [TestMethod] public void RoleTest() => IsNullableProperty(() => obj.Role, x => obj.Role = x);
    }
}
