using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain
{
    [TestClass]
    public class BaseEntityTests : AbstractClassTests<BaseEntity, object>
    {
        private class TestClass : BaseEntityTests { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void UnspecifiedTest() => Assert.AreEqual(BaseEntity.Unspecified);
        [TestMethod]
        public void UnspecifiedValidFromTest() => Assert.AreEqual(BaseEntity.UnspecifiedValidFrom);
        [TestMethod]
        public void UnspecifiedValidToTest() => Assert.AreEqual(BaseEntity.UnspecifiedValidTo);
        [TestMethod]
        public void UnspecifiedDoubleTest() => Assert.AreEqual(BaseEntity.UnspecifiedDouble);
        [TestMethod]
        public void UnspecifiedDecimalTest() => Assert.AreEqual(BaseEntity.UnspecifiedDecimal);
        [TestMethod]
        public void UnspecifiedIntegerTest() => Assert.AreEqual(BaseEntity.UnspecifiedInteger);

    }
}
