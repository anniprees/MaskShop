using MaskShop.Data.Common;
using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class FeatureObjectDataTests : SealedClassTests<FeatureObjectData, PeriodData>
    {
        [TestMethod]
        public void ObjectIdTest()
            => IsNullableProperty(() => obj.ObjectId, x => obj.ObjectId = x);

        [TestMethod]
        public void ProductFeatureIdTest()
            => IsNullableProperty(() => obj.ProductFeatureId, x => obj.ProductFeatureId = x);
    }
}
