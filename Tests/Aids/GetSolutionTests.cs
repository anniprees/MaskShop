using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{

    [TestClass]
    public class GetSolutionTests : BaseTests
    {

        private static readonly string _assemblyName = "MaskShop.Aids";
        private const string DummyName = "bla-bla";

        [TestInitialize]
        public void TestInitialize() => Type = typeof(GetSolution);

        [TestMethod]
        public void DomainTest()
        {
            var expected = AppDomain.CurrentDomain;
            var actual = GetSolution.Domain;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssembliesTest()
        {
            var expected = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var actual = GetSolution.Assemblies;
            foreach (var e in expected) Assert.IsTrue(actual.Contains(e));
            Assert.AreEqual(expected.Count, actual.Count);
        }

        [TestMethod]
        public void AssemblyByNameTest()
        {
            Assert.IsNull(GetSolution.AssemblyByName(DummyName));
            var assembly = GetSolution.AssemblyByName(_assemblyName);
            Assert.IsTrue(assembly.FullName.StartsWith(_assemblyName));
        }

        [TestMethod]
        public void TypesForAssemblyTest()
        {
            var expected = GetSolution.AssemblyByName(_assemblyName).GetTypes();
            var actual = GetSolution.TypesForAssembly(DummyName);
            Assert.AreEqual(0, actual.Count);
            Assert.IsInstanceOfType(actual, typeof(List<Type>));
            actual = GetSolution.TypesForAssembly(_assemblyName);
            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var e in expected) Assert.IsTrue(actual.Contains(e));
        }

        [TestMethod]
        public void TypeNamesForAssemblyTest()
        {
            var expected = GetSolution.AssemblyByName(_assemblyName).GetTypes();
            var actual = GetSolution.TypeNamesForAssembly(DummyName);
            Assert.AreEqual(0, actual.Count);
            Assert.IsInstanceOfType(actual, typeof(List<string>));
            actual = GetSolution.TypeNamesForAssembly(_assemblyName);
            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var e in expected)
                Assert.IsTrue(actual.Contains(e.FullName));
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual(nameof(MaskShop), GetSolution.Name);
        }

    }

}