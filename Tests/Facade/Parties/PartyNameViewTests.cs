using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class PartyNameViewTests : SealedClassTests<PartyNameView, PartyAttributeView>
    {
        [TestMethod]
        public void FirstNameTest() => IsNullableProperty<string>("First Name");

        [TestMethod]
        public void MiddleNameTest() => IsNullableProperty<string>("Middle Name");

        [TestMethod]
        public void LastNameTest() => IsNullableProperty<string>("Last Name");
    }
}
