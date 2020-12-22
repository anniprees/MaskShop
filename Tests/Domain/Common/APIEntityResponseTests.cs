using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class APIEntityResponseTests : BaseTests
    {
        [TestInitialize] public void TestInitialize()
        {
            type = typeof(APIEntityResponse<>);
        }

        [TestMethod] public void SuccessTest() => Assert.Inconclusive();

        [TestMethod] public void ErrorMessagesTest() => Assert.Inconclusive();

        [TestMethod] public void DataTest() => Assert.Inconclusive();
    }
}
