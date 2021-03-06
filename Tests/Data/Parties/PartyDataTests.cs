﻿using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyDataTests : SealedClassTests <PartyData, NamedEntityData>
    {
        [TestMethod] public void PartyRoleIdTest() => IsNullableProperty(() => obj.PartyRoleId, x => obj.PartyRoleId = x);
        [TestMethod] public void ContactMechanismIdTest() => IsNullableProperty(() => obj.ContactMechanismId, x => obj.ContactMechanismId = x);
        [TestMethod] public void PartyTypeTest() => IsProperty(() => obj.PartyType, x => obj.PartyType = x);

    }
}
