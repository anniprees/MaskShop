using Data.Common;
using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class PartyObjectDataTests : SealedClassTests<PartyObjectData, PeriodData>
    {
        [TestMethod]
        public void PartyIdTest()
            => IsNullableProperty(() => obj.PartyId, x => obj.PartyId = x);

        [TestMethod]
        public void ObjectIdTest()
            => IsNullableProperty(() => obj.ObjectId, x => obj.ObjectId = x);
    }
}
