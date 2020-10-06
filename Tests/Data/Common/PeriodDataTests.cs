using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MaskShop.Data.Common;

namespace MaskShop.Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTests<PeriodData, object>
    {
        private class TestClass : PeriodData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void FromTest() => IsNullableProperty<DateTime?>();

        [TestMethod]
        public void ToTest() => IsNullableProperty<DateTime?>();
    }
}
