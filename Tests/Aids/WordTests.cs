using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class WordTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => Type = typeof(Word);

        [TestMethod]
        public void UnspecifiedTest()
            => Assert.AreEqual("Unspecified", Word.Unspecified);

        [TestMethod]
        public void ListTest()
            => Assert.AreEqual("List", Word.List);

        [TestMethod]
        public void NoneTest()
            => Assert.AreEqual("None", Word.None);

        [TestMethod]
        public void NullTest()
            => Assert.AreEqual("Null", Word.Null);
    }
}