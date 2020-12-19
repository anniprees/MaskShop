using MaskShop.Facade.Common;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Parties
{
    [TestClass]
    public class ContactMechanismViewTests : SealedClassTests<ContactMechanismView, UniqueEntityView>
    {
        [TestMethod]
        public void CountryTest() => IsNullableProperty<string>("Country");
        [TestMethod]
        public void StateTest() => IsNullableProperty<string>("State");
        [TestMethod]
        public void CityTest() => IsNullableProperty<string>("City");
        [TestMethod]
        public void StreetTest() => IsNullableProperty<string>("Street");
        [TestMethod]
        public void ZipCodeTest() => IsNullableProperty<string>("Zipcode");
        [TestMethod]
        public void ElectronicMailTest() => IsNullableProperty<string>("E-mail");
        
    }
}

