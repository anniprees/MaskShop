using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain
{
    [TestClass]
    public class NamedEntityTests : AbstractClassTests<NamedEntity<ProductData>, UniqueEntity<ProductData>>
    {
        private class TestClass : NamedEntity<ProductData>
        {
            public TestClass(ProductData d = null) : base(d) {}
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(Aids.Constants.Word.Unspecified, obj.Name);
            obj = new TestClass(GetRandom.Object<ProductData>());
            isReadOnlyProperty(obj, GetMember.Name<TestClass>(x => x.Name), obj.Data.Name);
        }
    }
}
