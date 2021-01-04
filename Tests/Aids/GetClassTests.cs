using System;
using System.Collections.Generic;
using System.Reflection;
using MaskShop.Aids;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class GetClassTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => Type = typeof(GetClass);

        [TestMethod]
        public void NamespaceTest()
        {
            var t = typeof(object);
            Assert.AreEqual(t.Namespace, GetClass.Namespace(t));
            Assert.AreEqual(string.Empty, GetClass.Namespace(null));
        }

        [TestMethod]
        public void MembersTest()
        {
            testMember(typeof(TestClass));
            testNull(null);
        }

        private static void testNull(Type t)
        {
            var a = GetClass.Members(t);
            Assert.IsInstanceOfType(a, typeof(List<MemberInfo>));
            Assert.AreEqual(0, a.Count);
        }

        private static void testMember(Type t)
        {
            var a = GetClass.Members(t, PublicFlagsFor.All, false);
            var e = t.GetMembers(PublicFlagsFor.All);
            Assert.AreEqual(e.Length, a.Count);
            Assert.AreEqual(10, a.Count);
            foreach (var v in e) Assert.IsTrue(a.Contains(v));
            Assert.AreEqual(7, GetClass.Members(t).Count);
        }

        [TestMethod]
        public void PropertiesTest()
        {
            var a = GetClass.Properties(typeof(TestClass));
            Assert.IsNotNull(a);
            Assert.IsInstanceOfType(a, typeof(List<PropertyInfo>));
            Assert.AreEqual(1, a.Count);
            Assert.AreEqual("F", a[0].Name);
        }

        [TestMethod]
        public void ReadWritePropertyValuesTest()
        {
            var o = GetRandom.Object<TestClass>();
            var l = GetClass.ReadWritePropertyValues(o);
            Assert.AreEqual(1, l.Count);
            Assert.AreEqual(l[0], o.F);
        }

        [TestMethod]
        public void PropertyTest()
        {
            static void test(string name)
                => Assert.AreEqual(name, GetClass.Property<ProductCategoryView>(name).Name);

            Assert.IsNull(GetClass.Property<ProductCategoryView>((string) null));
            Assert.IsNull(GetClass.Property<ProductCategoryView>(string.Empty));
            Assert.IsNull(GetClass.Property<ProductCategoryView>("bla bla"));
            test(GetMember.Name<ProductCategoryView>(m => m.Id));
            test(GetMember.Name<ProductCategoryView>(m => m.Name));
            test(GetMember.Name<ProductCategoryView>(m => m.ValidFrom));
            test(GetMember.Name<ProductCategoryView>(m => m.ValidTo));
        }

        internal class TestBaseClass
        {
            public void Aaa() => bbb();
            private void bbb() { }
            public static void Ccc() => ddd();
            private static void ddd() { }
        }

        internal class TestClass : TestBaseClass
        {
            public int E = 0;
            public string F { get; set; }
        }
    }
}