using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public class AssemblyTests : BaseAssemblyTests
    {
        [TestMethod] public void IsCommonTested() => isAllTested(assembly, nameSpace("Common"));
        [TestMethod] public void IsObjectsTested() => isAllTested(assembly, nameSpace("Objects"));
        [TestMethod] public void IsOrdersTested() => isAllTested(assembly, nameSpace("Orders"));
        [TestMethod] public void IsPartiesTested() => isAllTested(assembly, nameSpace("Parties"));
        [TestMethod] public void IsProductsTested() => isAllTested(assembly, nameSpace("Products"));
        [TestMethod] public void IsShipmentsTested() => isAllTested(assembly, nameSpace("Shipments"));
    }
}
