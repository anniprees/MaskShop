using System;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain
{
    [TestClass]
    public class BaseEntityTests : AbstractClassTests<BaseEntity, object>
    {
        private class TestClass : BaseEntity { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void UnspecifiedTest() => Assert.AreEqual(BaseEntity.Unspecified, Aids.Constants.Word.Unspecified);
        [TestMethod]
        public void UnspecifiedValidFromTest() => Assert.AreEqual(BaseEntity.UnspecifiedValidFrom, DateTime.MinValue);
        [TestMethod]
        public void UnspecifiedValidToTest() => Assert.AreEqual(BaseEntity.UnspecifiedValidTo, DateTime.MaxValue);
        [TestMethod]
        public void UnspecifiedDoubleTest() => Assert.AreEqual(BaseEntity.UnspecifiedDouble, double.NaN);
        [TestMethod]
        public void UnspecifiedDecimalTest() => Assert.AreEqual(BaseEntity.UnspecifiedDecimal, Decimal.MaxValue);
        [TestMethod]
        public void UnspecifiedIntegerTest() => Assert.AreEqual(BaseEntity.UnspecifiedInteger, 0);

    }
}
