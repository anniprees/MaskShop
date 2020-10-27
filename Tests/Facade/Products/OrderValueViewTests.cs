using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class OrderValueViewTests : SealedClassTests<OrderValueView, UniqueEntityView>
    {
        [TestMethod] 
        public void FromAmountTest() => IsNullableProperty<string>("From amount");
    }
}
