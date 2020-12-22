using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Parties
{
    [TestClass]
    public class PartyNameTests : SealedClassTests<PartyName, PartyAttribute<PartyNameData>>
    {
        protected override PartyName CreateObject() => new PartyName(GetRandom.Object<PartyNameData>());

        [TestMethod] public void NameTest() => IsReadOnlyProperty(obj.Name);
        [TestMethod] public void FirstNameTest() => IsReadOnlyProperty(obj.Data.FirstName);
        [TestMethod] public void MiddleNameTest() => IsReadOnlyProperty(obj.Data.MiddleName);
        [TestMethod] public void LastNameTest() => IsReadOnlyProperty(obj.Data.LastName);
        [TestMethod] public void ToStringTest() => Assert.Inconclusive();

    }
}