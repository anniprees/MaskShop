using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class FeatureColorDataTests: SealedClassTests<FeatureColorData, ProductFeatureData>
    {
        [TestMethod] public void ColorCodeTest() => IsProperty<int>(() => obj.ColorCode, x => obj.ColorCode = x);
    }
}
