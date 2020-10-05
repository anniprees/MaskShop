using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyContactMechanismDataTests : SealedTests<PartyContactMechanismData, PeriodData>
    {
        [TestMethod] public void PartyIdTest() => isNullableProperty<string>();
        [TestMethod] public void ContactMechanismIdTest() => isNullableProperty<string>();
    }
}
