using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class PartyProductsDataTests : AbstractClassTests<PartyProductsData, DefinedEntityData>
    {
        private class TestClass : PartyProductsData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void PartyIdTest()
            => IsNullableProperty(() => obj.PartyId, x => obj.PartyId = x);

    }
}
