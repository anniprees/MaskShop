using MaskShop.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra
{
    [TestClass]
    public class ConstantsTests : BaseTests
    {
        [TestMethod] 
        public void DefaultPageSizeTest() => Assert.AreEqual(5, Constants.DefaultPageSize);
    }
}
