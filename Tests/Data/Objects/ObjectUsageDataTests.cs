using Data.Common;
using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class ObjectUsageDataTests : SealedClassTests<ObjectUsageData, UniqueEntityData>
    {
        [TestMethod]
        public void ObjectIdTest()
            => IsNullableProperty(() => obj.ObjectId, x => obj.ObjectId = x);
    }
}
