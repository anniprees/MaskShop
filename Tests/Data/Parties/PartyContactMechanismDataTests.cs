using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyContactMechanismDataClassTests : SealedClassTests<PartyContactMechanismData, PeriodData>
    {
        [TestMethod] public void PartyIdTest() => IsNullableProperty<string>(() => obj.PartyId, x => obj.PartyId = x);
        [TestMethod] public void ContactMechanismIdTest() => IsNullableProperty<string>(() => obj.ContactMechanismId, x => obj.ContactMechanismId = x);
    }
}
