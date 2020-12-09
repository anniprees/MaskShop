using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class FeatureSizeTests : SealedClassTests<FeatureSize, ProductFeature<FeatureSizeData>>
    {
        protected override FeatureSize CreateObject() => new FeatureSize(GetRandom.Object<FeatureSizeData>());
        [TestMethod] public void SizeTest() => IsReadOnlyProperty(obj.Data.Size);
    }
}
