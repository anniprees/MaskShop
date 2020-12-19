using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismDataTests : SealedClassTests <ContactMechanismData, UniqueEntityData>
    {
        [TestMethod] public void StreetTest() => IsNullableProperty(() => obj.Street, x => obj.Street = x);
        [TestMethod] public void CountryTest() => IsNullableProperty(() => obj.Country, x => obj.Country = x);

        [TestMethod] public void StateTest() => IsNullableProperty(() => obj.State, x => obj.State = x);

        [TestMethod] public void CityTest() => IsNullableProperty(() => obj.City, x => obj.City = x);

        [TestMethod] public void ZipCodeTest() => IsNullableProperty(() => obj.ZipCode, x => obj.ZipCode = x);

        [TestMethod] public void ElectronicMailTest() => IsProperty(() => obj.ElectronicMail, x => obj.ElectronicMail = x);
    }
}
