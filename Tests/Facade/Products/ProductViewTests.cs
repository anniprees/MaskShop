using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class ProductViewTests : SealedClassTests<ProductView, NamedView>
    {
        [TestMethod]
        public void PriceTest() => IsProperty<decimal>("Product Price");

        [TestMethod]
        public void ProductCategoryIdTest() => IsNullableProperty<string>("Product Category Id");

        [TestMethod]
        public void ProductFeatureApplicabilityIdTest() => IsNullableProperty<string>("Product feature applicability");

        [TestMethod]
        public void PriceComponentIdTest() => IsNullableProperty<string>("Price Component Id");

        [TestMethod]
        public void PictureUriTest() => IsNullableProperty<string>("Picture Uri");

        [TestMethod]
        public void PictureFileTest() => IsProperty<IFormFile>("Picture");

    }
}