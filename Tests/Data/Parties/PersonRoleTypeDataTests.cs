using System;
using System.Collections.Generic;
using System.Text;
using Aids;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class PersonRoleTypeDataTests : AbstractClassTests <PersonRoleTypeData, PartyRoleTypeData>
    {
        private class TestClass : PersonRoleTypeData { }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }
    }
}
