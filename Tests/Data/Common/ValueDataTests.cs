using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Common
{
    [TestClass]
    public class ValueDataTests : SealedClassTests<ValueData, object>
    {
        [TestMethod]
        public void UnitOrCurrencyIdTest()
            => IsNullableProperty(() => obj.UnitOrCurrencyId, x => obj.UnitOrCurrencyId = x);
        
        [TestMethod]
        public void ValueTest()
            => IsNullableProperty(() => obj.Value, x => obj.Value = x);
    }
}
