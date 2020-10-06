using MaskShop.Data.Common;
using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class ProductObjectDataTests : SealedClassTests<ProductObjectData, PeriodData>
    {
        [TestMethod]
        public void ProductIdTest()
            => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void ObjectIdTest()
            => IsNullableProperty(() => obj.ObjectId, x => obj.ObjectId = x);
    }
}
