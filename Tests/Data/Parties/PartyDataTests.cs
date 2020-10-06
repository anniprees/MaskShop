using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyDataTests : SealedClassTests <PartyData, UniqueEntityData>
    {
        [TestMethod] public void DescriptionTest() => IsNullableProperty(() => obj.Description, x => obj.Description = x);
        [TestMethod] public void PartyNameIdTest() => IsNullableProperty(() => obj.PartyNameId, x => obj.PartyNameId = x);
        [TestMethod] public void PartyTypeTest() => IsProperty(() => obj.PartyType, x => obj.PartyType = x);

    }
}
