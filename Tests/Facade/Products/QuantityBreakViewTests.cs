using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class QuantityBreakViewTests : SealedClassTests<QuantityBreakView, UniqueEntityView>
    {
        [TestMethod]
        public void FromQuantityTest() => IsNullableProperty<string>("From quantity");
    }
}
