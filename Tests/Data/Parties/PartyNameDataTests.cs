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
        [TestMethod] public void NameTest() => IsNullableProperty<string>();
        [TestMethod] public void GivenNameTest() => IsNullableProperty<string>();
        [TestMethod] public void MiddleNameTest() => IsNullableProperty<string>();
        [TestMethod] public void PreferredNameTest() => IsNullableProperty<string>();
        [TestMethod] public void PartyTypeTest() => IsNullableProperty<PartyTypeData>();
    }
}
