﻿using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyNameDataTests : SealedClassTests <PartyNameData, PartyAttributeData>
    {
        [TestMethod] public void NameTest() => IsNullableProperty(() => obj.Name, x => obj.Name = x);
        [TestMethod] public void GivenNameTest() => IsNullableProperty(() => obj.GivenName, x => obj.GivenName = x);
        [TestMethod] public void MiddleNameTest() => IsNullableProperty(() => obj.MiddleName, x => obj.MiddleName = x);
        [TestMethod] public void PreferredNameTest() => IsNullableProperty(() => obj.PreferredName, x => obj.PreferredName = x);
        [TestMethod] public void PartyTypeTest() => IsProperty(() => obj.PartyType, x => obj.PartyType = x);
    }
}