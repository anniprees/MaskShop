using System;
using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class ValueObjectTests : AbstractClassTests<ValueObject<ValueData>, BaseEntity>
    {

        private class TestClass : ValueObject<ValueData>
        {

            public TestClass(ValueData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<ValueData>());
        }

        [TestMethod] public void DataTest() => IsReadOnlyProperty();

        [TestMethod]
        public void IsUnspecifiedTest()
        {
            Assert.IsTrue(new TestClass().IsUnspecified);
            Assert.IsFalse(new TestClass(GetRandom.Object<ValueData>()).IsUnspecified);
        }

        [TestMethod]
        public void CanSetDataTest()
        {
            var d = GetRandom.Object<ValueData>();
            obj = new TestClass(d);
            Assert.AreNotSame(d, obj.Data);
            TestArePropertyValuesEqual(d, obj.Data);
        }

        [TestMethod]
        public void CanSetNullDataTest()
        {
            obj = new TestClass();
            Assert.IsNotNull(obj.Data);
            Assert.IsTrue(obj.IsUnspecified);
        }

        [TestMethod]
        public void CantChangeDataElementsTest()
        {
            obj = new TestClass(GetRandom.Object<ValueData>());
            var d = obj.Data;
            obj.Data.UnitOrCurrencyId = GetRandom.String();
            //obj.Data.ValueType = GetRandom.Enum<ValueType>();
            obj.Data.Value = GetRandom.String();
            TestArePropertyValuesEqual(d, obj.Data);
        }

    }
}
