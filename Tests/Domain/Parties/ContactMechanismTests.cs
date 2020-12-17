using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Parties
{
    [TestClass]
    public class ContactMechanismTests: SealedClassTests<ContactMechanism, UniqueEntity<ContactMechanismData>>
    {
        protected override ContactMechanism CreateObject() => new ContactMechanism(GetRandom.Object<ContactMechanismData>());

        [TestMethod] public void CountryTest() => IsReadOnlyProperty(obj.Data.Country);
        [TestMethod] public void StateTest() => IsReadOnlyProperty(obj.Data.State);
        [TestMethod] public void CityTest() => IsReadOnlyProperty(obj.Data.City);
        [TestMethod] public void AddressTest() => IsReadOnlyProperty(obj.Data.Address);
        [TestMethod] public void ZipOrPostCodeTest() => IsReadOnlyProperty(obj.Data.ZipCode);
        [TestMethod] public void ElectronicMailTest() => IsReadOnlyProperty(obj.Data.ElectronicMail);
    }
}

