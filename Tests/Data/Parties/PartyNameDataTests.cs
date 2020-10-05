using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyNameDataTests : SealedTests <PartyNameData, PartyAttributeData>
    {
        [TestMethod] public void NameTest() => isNullableProperty<string>();
        [TestMethod] public void GivenNameTest() => isNullableProperty<string>();
        [TestMethod] public void MiddleNameTest() => isNullableProperty<string>();
        [TestMethod] public void PreferredNameTest() => isNullableProperty<string>();
        [TestMethod] public void PartyTypeTest() => isNullableProperty<PartyTypeData>();
    }
}
