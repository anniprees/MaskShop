using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    [TestClass]
    public class PartyProductsTests : AbstractClassTests<PartyProducts<OrderData>, DefinedEntity<OrderData>>
    {
        private class TestClass : PartyProducts<OrderData>
        {
            public TestClass(OrderData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<OrderData>());
        }

        [TestMethod] public void PartyIdTest() => IsReadOnlyProperty(obj, nameof(obj.PartyId), obj.Data.PartyId);

        [TestMethod]
        public async Task PartyTest()
        {
            var p = GetRandom.Object<PartyData>();
            p.Id = obj.PartyId;
            await GetRepository.Instance<IPartiesRepository>().Add(new Party(p));
            TestArePropertiesEqual(p, obj.Party.Data);
        }

    }
}
