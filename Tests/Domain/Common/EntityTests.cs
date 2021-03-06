﻿using System;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
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
        public void DataTest() => IsReadOnlyProperty();

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
            obj.Data.ValidFrom = GetRandom.DateTime();
            obj.Data.ValidTo = GetRandom.DateTime();
            obj.Data.ProductCategoryId = GetRandom.String();
            TestArePropertyValuesEqual(d, obj.Data);
        }


        [TestMethod]
        public void ValidFromTest()
        {
            Assert.AreEqual(DateTime.MinValue, obj.ValidFrom);
            obj = new TestClass(GetRandom.Object<ProductData>());
            IsReadOnlyProperty(obj, GetMember.Name<Product>(x => x.ValidFrom), obj.Data.ValidFrom);
        }

        [TestMethod]
        public void ValidToTest()
        {
            Assert.AreEqual(DateTime.MaxValue, obj.ValidTo);
            obj = new TestClass(GetRandom.Object<ProductData>());
            IsReadOnlyProperty(obj, GetMember.Name<Product>(x => x.ValidTo), obj.Data.ValidTo);
        }
    }
}
