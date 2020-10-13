using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
            protected override string assembly => "MaskShop.Domain";

            protected override string nameSpace(string name) { return $"{assembly}.{name}"; }
    } 
}
