using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismDataTests : SealedClassTests <ContactMechanismData, UniqueEntityData>
    {
        [TestMethod] public void CountryIdTest() => IsNullableProperty(() => obj.CountryId, x => obj.CountryId = x);

        [TestMethod] public void NationalDirectDialingPrefixTest() => IsNullableProperty(() => obj.NationalDirectDialingPrefix, x => obj.NationalDirectDialingPrefix = x);

        [TestMethod] public void AddressTest() => IsNullableProperty(() => obj.Address, x => obj.Address = x);

        [TestMethod] public void CityOrAreaCodeTest() => IsNullableProperty(() => obj.CityOrAreaCode, x => obj.CityOrAreaCode = x);

        [TestMethod] public void RegionOrStateOrCountryCodeTest() => IsNullableProperty(() => obj.RegionOrStateOrCountryCode, x => obj.RegionOrStateOrCountryCode = x);

        [TestMethod] public void ZipOrPostCodeOrExtensionTest() => IsNullableProperty(() => obj.ZipOrPostCodeOrExtension, x => obj.ZipOrPostCodeOrExtension = x);

        [TestMethod] public void ContactMechanismTypeTest() => IsProperty(() => obj.ContactMechanismType, x => obj.ContactMechanismType = x);
    }
}
