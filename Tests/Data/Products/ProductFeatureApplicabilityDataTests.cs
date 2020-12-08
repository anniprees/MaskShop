﻿using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Data.Products;
using MaskShop.Tests.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureApplicabilityDataTests : SealedClassTests<ProductFeatureApplicabilityData, UniqueEntityData>
    {
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>(() => obj.ProductId, x => obj.ProductId = x);
        [TestMethod] public void ProductFeatureIdTest() => IsNullableProperty<string>(() => obj.ProductFeatureId, x => obj.ProductFeatureId = x);
    }
}
