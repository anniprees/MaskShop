using MaskShop.Data.Parties;
using MaskShop.Facade.Common;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class PartyViewTests : SealedClassTests<PartyView, NamedView>
    {
        [TestMethod]
        public void PartyRoleIdTest() => IsNullableProperty<string>("Party Role Id");

        [TestMethod]
        public void ContactMechanismIdTest() => IsNullableProperty<string>("Contact Mechanism Id");

        [TestMethod]
        public void PartyTypeTest() => IsProperty<PartyType>("Party Type");
    }
}

