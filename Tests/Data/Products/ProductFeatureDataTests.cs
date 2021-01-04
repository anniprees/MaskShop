using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureDataTests : SealedClassTests<ProductFeatureData, DefinedEntityData> 
    {
        [TestMethod]
        public void NumericCodeTest() => IsProperty<int>(() => obj.NumericCode, x => obj.NumericCode = x);

        [TestMethod]
        public void ColorTest() => IsProperty<string>(() => obj.Color, x => obj.Color = x);

       [TestMethod]
       public void SizeTest() => IsProperty<string>(() => obj.Size, x => obj.Size = x);
    }
}