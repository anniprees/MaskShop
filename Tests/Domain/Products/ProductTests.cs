using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductTests : SealedClassTests<Product, NamedEntity<ProductData>>
    {
        protected override Product CreateObject() => new Product(GetRandom.Object<ProductData>());

        [TestMethod]
        public void PublicCategoryIdTest() => IsReadOnlyProperty(obj.Data.ProductCategoryId);
    }
}