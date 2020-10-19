using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
            protected override string Assembly => "MaskShop.Domain";

            protected override string NameSpace(string name) { return $"{Assembly}.{name}"; }
    } 
}
