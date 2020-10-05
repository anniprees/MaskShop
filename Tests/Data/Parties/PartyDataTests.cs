using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyDataTests : SealedTests <PartyData, UniqueEntityData>
    {
        [TestMethod] public void DescriptionTest() => isNullableProperty<string>();
        [TestMethod] public void PartyNameIdTest() => isNullableProperty<string>();
        // [TestMethod] public void OrganizationTypeIdTest() => isNullableProperty<string>();
        [TestMethod] public void PartyTypeTest() => isNullableProperty<PartyTypeData>();

    }
}
