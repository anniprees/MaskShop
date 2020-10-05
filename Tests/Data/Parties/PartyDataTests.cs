using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyDataClassTests : SealedClassTests <PartyData, UniqueEntityData>
    {
        [TestMethod] public void DescriptionTest() => IsNullableProperty<string>(() => obj.Description, x => obj.Description = x);
        [TestMethod] public void PartyNameIdTest() => IsNullableProperty<string>(() => obj.PartyNameId, x => obj.PartyNameId = x);

        //[TestMethod] public void PartyTypeTest() => IsNullableProperty<PartyTypeData>();

    }
}
