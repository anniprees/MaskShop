using MaskShop.Facade.Common;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class PartyRoleViewTests : SealedClassTests<PartyRoleView, UniqueEntityView>
    {
        [TestMethod]
        public void RoleTest() => IsNullableProperty<string>("Role");
    }
}
