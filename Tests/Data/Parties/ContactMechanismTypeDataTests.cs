using System;
using System.Collections.Generic;
using System.Text;
using Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismTypeDataTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ContactMechanismTypeData);

        [TestMethod] public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<ContactMechanismTypeData>());

        [TestMethod] public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)ContactMechanismTypeData.Unspecified);
        [TestMethod] public void PostalAddressTest() =>
            Assert.AreEqual(1, (int)ContactMechanismTypeData.PostalAddress);
        [TestMethod] public void TelecomNumberTest() =>
            Assert.AreEqual(2, (int)ContactMechanismTypeData.TelecomNumber);
        [TestMethod] public void ElectronicAddressTest() =>
            Assert.AreEqual(3, (int)ContactMechanismTypeData.ElectronicAddress);
    }
}
