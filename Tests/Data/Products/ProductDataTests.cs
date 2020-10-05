using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductDataClassTests : SealedClassTests<ProductData, NamedEntityData>{
        [TestMethod] public void ProductCategoryIdTest() => IsNullableProperty<string>(() => obj.ProductCategoryId, x => obj.ProductCategoryId = x);
    }
}


