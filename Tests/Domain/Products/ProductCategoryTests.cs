using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductCategoryTests : SealedClassTests<ProductCategory, NamedEntity<ProductCategoryData>>
    {
    }
}