using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class GetRepositoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => Type = typeof(GetRepository);

        [TestMethod] public void SetServiceProviderTest() => Assert.Inconclusive();
        [TestMethod] public void InstanceTest() => Assert.Inconclusive();

    }
}