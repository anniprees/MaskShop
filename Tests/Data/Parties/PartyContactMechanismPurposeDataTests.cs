using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyContactMechanismPurposeDataTests : SealedTests <PartyContactMechanismPurposeData, PeriodData>
    {
        [TestMethod] public void PartyContactMechanismIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ContactMechanismPurposeTypeTest() => IsNullableProperty<string>();
    }
}
