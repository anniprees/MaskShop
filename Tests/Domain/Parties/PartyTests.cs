using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Parties
{
    [TestClass]
    public class PartyTests : SealedClassTests<Party, NamedEntity<PartyData>>
    {
        protected override Party CreateObject() => new Party(GetRandom.Object<PartyData>());

        [TestMethod] public void PartyRoleIdTest() => IsReadOnlyProperty(obj.Data.PartyRoleId);
        [TestMethod] public void ContactMechanismIdTest() => IsReadOnlyProperty(obj.Data.ContactMechanismId);
        [TestMethod] public void PartyTypeTest() => IsReadOnlyProperty(obj.Data.PartyType);

        [TestMethod]
        public void PartyRoleTest() =>
            IsReadOnlyProperty(obj, nameof(obj.PartyRoleId), obj.Data.PartyRoleId);
        [TestMethod]
        public void ContactMechanismTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ContactMechanismId), obj.Data.ContactMechanismId);

    }
}