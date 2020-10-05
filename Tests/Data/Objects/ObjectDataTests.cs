using Aids;
using Data.Common;
using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class ObjectDataTests : AbstractClassTests<ObjectData, DefinedEntityData>
    {
        private class TestClass : ObjectData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }

        [TestMethod]
        public void FileLocationTest()
            => IsNullableProperty(() => obj.FileLocation, x => obj.FileLocation = x);

        [TestMethod]
        public void ObjectTypeIdTest()
            => IsNullableProperty(() => obj.ObjectTypeId, x => obj.ObjectTypeId = x);
    }
}
