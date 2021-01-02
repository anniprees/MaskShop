using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Facade.Common;
using MaskShop.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Facade.Orders
{
    [TestClass]
    public abstract class PartyProductsViewTests : SealedClassTests<PartyProductsView, DefinedView>
    {
        [TestMethod] public void PartyIdTest() => Assert.Inconclusive();
    }
}
