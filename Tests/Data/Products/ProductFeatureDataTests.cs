using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureDataTests : SealedClassTests<ProductFeatureData, NamedEntityData> 
    {
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>(() => obj.ProductId, x => obj.ProductId = x);
        [TestMethod] public void ProductFeatureTypeIdTest() => IsNullableProperty<string>(() => obj.ProductFeatureTypeId, x => obj.ProductFeatureTypeId = x);
    }
}