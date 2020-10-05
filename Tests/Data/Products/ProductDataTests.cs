using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductDataTests : SealedTests<ProductData, NamedEntityData>{
        [TestMethod] public void ProductCategoryIdTest() => isNullableProperty<string>();
    }
}


