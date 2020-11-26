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

        //[TestMethod]
        //public void ProductCategoryTest() =>
        //    GetFromRepository<ProductCategoryData, ProductCategory, IProductCategoriesRepository>(obj.ProductCategoryId, () =>
        //        obj.ProductCategory.Data, d => new ProductCategory(d));


    }
}