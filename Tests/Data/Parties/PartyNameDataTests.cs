using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyNameDataClassTests : SealedClassTests <PartyNameData, PartyAttributeData>
    {
        [TestMethod] public void NameTest() => IsNullableProperty<string>(() => obj.Name, x => obj.Name = x);
        [TestMethod] public void GivenNameTest() => IsNullableProperty<string>(() => obj.GivenName, x => obj.GivenName = x);
        [TestMethod] public void MiddleNameTest() => IsNullableProperty<string>(() => obj.MiddleName, x => obj.MiddleName = x);
        [TestMethod] public void PreferredNameTest() => IsNullableProperty<string>(() => obj.PreferredName, x => obj.PreferredName = x);
        //[TestMethod] public void PartyTypeTest() => IsNullableProperty<PartyTypeData>();
    }
}
