using MaskShop.Aids;
using MaskShop.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Common
{

    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, PeriodView>
    {

        private class TestClass : UniqueEntityView {
            public override string GetId()
            {
                throw new System.NotImplementedException();
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }

        [TestMethod] public void IdTest() => IsNullableProperty(() => obj.Id, x => obj.Id = x);

        [TestMethod] public void GetIdTest() => Assert.AreEqual(obj.Id, obj.GetId());

    }

}