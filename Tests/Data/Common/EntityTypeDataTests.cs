using Aids;
using Data.Common;
using MaskShop.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Common
{
    [TestClass] 
    public class EntityTypeDataTests : AbstractClassTests<EntityTypeData, DefinedEntityData>
    {
        private class TestClass : EntityTypeData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }

        [TestMethod]
        public void BaseTypeIdTest()
            => IsNullableProperty(() => obj.BaseTypeId, x => obj.BaseTypeId = x);
    }
}
