using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Parties
{
    [TestClass]
    public class PartyRoleTests : SealedClassTests<PartyRole, UniqueEntity<PartyRoleData>>
    {
        protected override PartyRole CreateObject() => new PartyRole(GetRandom.Object<PartyRoleData>());

        [TestMethod] public void RoleTest() => IsReadOnlyProperty(obj.Data.Role);

    }
}
