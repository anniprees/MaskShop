using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    [TestClass]
    public class ItemProductTests : AbstractClassTests<ItemProduct<OrderItemData>, Entity<OrderItemData>>
    {

        private class TestClass : ItemProduct<OrderItemData>
        {
            public TestClass(OrderItemData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<OrderItemData>());
        }

        [TestMethod] public void ProductIdTest() => IsReadOnlyProperty(obj, nameof(obj.ProductId), obj.Data.ProductId);

        [TestMethod]
        public async Task ProductTest()
        {
            var p = GetRandom.Object<ProductData>();
            p.Id = obj.ProductId;
            var repo = GetRepository.Instance<IProductsRepository>();
                await repo.Add(new Product(p));
            TestArePropertiesEqual(p, obj.Product.Data);
        }

        [TestMethod]
        public void QuantityTest() => IsReadOnlyProperty(obj.Data.Quantity);

        [TestMethod]
        public void TotalPriceTest() => Assert.Inconclusive();
    }
}
