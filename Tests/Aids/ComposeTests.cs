using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class ComposeTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => Type = typeof(Compose);

        [TestMethod]
        public void IdTest()
        {
            var h = GetRandom.String();
            var t = GetRandom.String();
            var actual = Compose.Id(h, t);
            var expected = $"{h}.{t}";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(".", Compose.Id(null, null));
        }

    }

}
