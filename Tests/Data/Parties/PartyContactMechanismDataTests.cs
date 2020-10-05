using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyContactMechanismDataTests : SealedClassTests<PartyContactMechanismData, PeriodData>
    {
        [TestMethod] public void PartyIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ContactMechanismIdTest() => IsNullableProperty<string>();
    }
}
