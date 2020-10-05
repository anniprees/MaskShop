using System;
using System.Collections.Generic;
using System.Text;
using Aids;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PartyRoleTypeDataTests : AbstractClassTests <PartyAttributeData, UniqueEntityData>
    {
        private class TestClass : PartyAttributeData { }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }
        //[TestMethod] public void PartyRoleIdTest() => IsNullableProperty<string>();
    }
}
