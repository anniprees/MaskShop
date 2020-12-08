using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class FeatureColorTests : SealedClassTests<FeatureColor, ProductFeature<FeatureColorData>>
    {
        protected override FeatureColor CreateObject() => new FeatureColor(GetRandom.Object<FeatureColorData>());
        [TestMethod] public void ColorCodeTest() => IsReadOnlyProperty(obj.Data.ColorCode);
    }
}
