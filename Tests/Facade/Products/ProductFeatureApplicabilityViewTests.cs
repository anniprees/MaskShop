using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class ProductFeatureApplicabilityViewTests : SealedClassTests<ProductFeatureApplicabilityView, UniqueEntityView>
    {
        [TestMethod]
        public void ProductIdTest() => IsNullableProperty<string>("Product");
        [TestMethod]
        public void ProductFeatureIdTest() => IsNullableProperty<string>("Product Feature");
        [TestMethod]
        public void FeatureDefinitionTest() => IsNullableProperty<string>("Product Feature");
    }
}
