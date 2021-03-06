﻿using System;
using System.Reflection;
using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{

    [TestClass]
    public class PublicFlagsForTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(PublicFlagsFor);
            testType = typeof(TestClass);
        }

        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        private Type testType;

        internal class TestClass
        {

            public void Aaa() => bbb();

            private void bbb()
            {
            }

            public static void Ccc() => ddd();

            private static void ddd()
            {
            }

        }

        [TestMethod]
        public void AllTest()
            => testMembers(i | s | p, PublicFlagsFor.All, 7);

        [TestMethod]
        public void InstanceTest()
            => testMembers(i | p, PublicFlagsFor.Instance, 6);

        [TestMethod]
        public void StaticTest()
            => testMembers(s | p, PublicFlagsFor.Static, 1);

        [TestMethod]
        public void DeclaredTest()
            => testMembers(d | i | s | p, PublicFlagsFor.Declared, 3);

        private void testMembers(BindingFlags expected, BindingFlags actual,
            int membersCount)
        {
            var a = testType.GetMembers(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(membersCount, a.Length);
        }

    }

}