using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class FeatureSizeDataTests: SealedClassTests<FeatureSizeData, ProductFeatureData>
    {
        [TestMethod] public void SizeTest() => IsNullableProperty(() => obj.Size, x => obj.Size = x);
    }
}
