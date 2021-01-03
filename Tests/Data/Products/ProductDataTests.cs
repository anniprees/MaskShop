using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductDataTests : SealedClassTests<ProductData, NamedEntityData>
    {
        [TestMethod] public void ProductCategoryIdTest() => IsNullableProperty<string>(() 
            => obj.ProductCategoryId, x => obj.ProductCategoryId = x);

        [TestMethod] public void PriceComponentIdTest() => IsNullableProperty<string>(() 
            => obj.PriceComponentId, x => obj.PriceComponentId = x);

        [TestMethod] public void PriceTest() => IsProperty<decimal>(() 
            => obj.Price, x => obj.Price = x);

        [TestMethod] public void PictureUriTest() => IsNullableProperty<string>(() 
            => obj.PictureUri, x => obj.PictureUri = x);

        [TestMethod] public void PictureTest() => IsNullableProperty<string>(() 
            => obj.ProductCategoryId, x => obj.ProductCategoryId = x);

    }
}


