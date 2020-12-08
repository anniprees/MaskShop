using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class FeatureSizeViewTests : SealedClassTests<FeatureSizeView, ProductFeatureView>
    {
        [TestMethod]
        public void SizeTest() => IsNullableProperty<string>("Size");
    }
}