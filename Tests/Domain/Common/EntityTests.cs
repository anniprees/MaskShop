using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<ProductData>, ValueObject<ProductData>>
    {
        private class TestClass : Entity<ProductData>
        {
            public TestClass(ProductData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void DataTest() => isReadOnlyProperty();

        [TestMethod]
        public void IsUnspecifiedTest()
        {
            Assert.IsTrue(new TestClass().IsUnspecified);
            Assert.IsFalse(new TestClass(GetRandom.Object<ProductData>()).IsUnspecified);
        }

        [TestMethod]
        public void CanSetDataTest()
        {
            var d = GetRandom.Object<ProductData>();
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
            obj = new TestClass(GetRandom.Object<ProductData>());
            var d = obj.Data;
            obj.Data.Id = GetRandom.String();
            obj.Data.Name = GetRandom.String();
            obj.Data.From = GetRandom.DateTime();
            obj.Data.To = GetRandom.DateTime();
            obj.Data.ProductCategoryId = GetRandom.String();
            TestArePropertyValuesEqual(d, obj.Data);
        }
        
        //TODO: Domain.Products puudu
        //[TestMethod]
        //public void ValidFromTest()
        //{
        //    Assert.AreEqual(DateTime.MinValue, obj.ValidFrom);
        //    obj = new TestClass(GetRandom.Object<ProductData>());
        //    isReadOnlyProperty(obj, GetMember.Name<Product>(x => x.ValidFrom), obj.Data.From);
        //}

        //[TestMethod]
        //public void ValidToTest()
        //{
        //    Assert.AreEqual(DateTime.MaxValue, obj.ValidTo);
        //    obj = new TestClass(GetRandom.Object<ProductData>());
        //    isReadOnlyProperty(obj, GetMember.Name<Product>(x => x.ValidTo), obj.Data.To);
        //}
    }
}
