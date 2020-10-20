using MaskShop.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Common
{

    [TestClass]
    public class EntityTypeViewTests : AbstractClassTests<EntityTypeView, DefinedView>
    {

        private class TestClass : EntityTypeView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void BaseTypeIdTest()
            => IsNullableProperty(() => obj.BaseTypeId, x => obj.BaseTypeId = x);

    }

}