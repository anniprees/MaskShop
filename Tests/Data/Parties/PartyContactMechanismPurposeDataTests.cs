using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyContactMechanismPurposeDataClassTests : SealedClassTests <PartyContactMechanismPurposeData, PeriodData>
    {
        [TestMethod] public void PartyContactMechanismIdTest() => IsNullableProperty<string>(() => obj.PartyContactMechanismId, x => obj.PartyContactMechanismId = x);
        [TestMethod] public void ContactMechanismPurposeTypeIdTest() => IsNullableProperty<string>(() => obj.ContactMechanismPurposeTypeId, x => obj.ContactMechanismPurposeTypeId = x);
    }
}
