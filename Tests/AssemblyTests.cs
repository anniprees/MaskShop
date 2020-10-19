﻿using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public class AssemblyTests : BaseAssemblyTests
    {
        [TestMethod] public void IsCommonTested() => IsAllTested(Assembly, NameSpace("Common"));
        [TestMethod] public void IsObjectsTested() => IsAllTested(Assembly, NameSpace("Objects"));
        [TestMethod] public void IsOrdersTested() => IsAllTested(Assembly, NameSpace("Orders"));
        [TestMethod] public void IsPartiesTested() => IsAllTested(Assembly, NameSpace("Parties"));
        [TestMethod] public void IsProductsTested() => IsAllTested(Assembly, NameSpace("Products"));
        [TestMethod] public void IsShipmentsTested() => IsAllTested(Assembly, NameSpace("Shipments"));
    }
}
