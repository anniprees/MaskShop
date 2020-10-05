using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyAttributeDataTests : AbstractClassTests <PartyAttributeData, UniqueEntityData>
    {
        [TestMethod] public void PartyIdTest() => IsNullableProperty<string>();
    }
}
