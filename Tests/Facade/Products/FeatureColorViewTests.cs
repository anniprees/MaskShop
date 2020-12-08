using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class FeatureColorViewTests : SealedClassTests<FeatureColorView, ProductFeatureView>
    {
        [TestMethod]
        public void ColorCodeTest() => IsProperty<int>("Color Code");
    }
}