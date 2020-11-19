using System;
using MaskShop.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Common
{

    [TestClass]
    public class PeriodViewTests : AbstractClassTests<PeriodView, object>
    {

        private class TestClass : PeriodView
        {
            public override string GetId() => string.Empty;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod] public void ValidFromTest() => IsNullableProperty<DateTime?>();

        [TestMethod] public void ValidToTest() => IsNullableProperty<DateTime?>();

        [TestMethod] public void GetIdTest() => IsAbstractMethod(nameof(obj.GetId));

    }

}