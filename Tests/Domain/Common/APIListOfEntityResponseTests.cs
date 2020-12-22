using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class APIListOfEntityResponseTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(APIListOfEntityResponse<>);
        }

        [TestMethod] public void SuccessTest() => Assert.Inconclusive();

        [TestMethod] public void ErrorMessagesTest() => Assert.Inconclusive();

        [TestMethod] public void DataTest() => Assert.Inconclusive();
    }
}