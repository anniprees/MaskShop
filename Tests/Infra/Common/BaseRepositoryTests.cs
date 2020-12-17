using System.Linq;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra;
using MaskShop.Infra.Common;
using MaskShop.Infra.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Common
{
    [TestClass]
    public class BaseRepositoryTests : AbstractClassTests<BaseRepository<Product, ProductData>, object>
    {
        private class TestClass : BaseRepository<Product, ProductData>
        {

            public TestClass(DbContext c, DbSet<ProductData> s) : base(c, s) { }
            protected override Product ToDomainObject(ProductData d) => new Product(d);
            protected override async Task<ProductData> GetData(string id)
            {
                await Task.CompletedTask;

                return await dbSet.FindAsync(id);
            }
            protected override ProductData GetDataById(ProductData d) => dbSet.Find(d.Id);

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<ShopDbContext>().Options;
            var c = new ShopDbContext(options);
            obj = new TestClass(c, c.Products);
        }

        [TestMethod]
        public void GetTest()
        {
            var d = GetRandom.Object<ProductData>();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsTrue(o.IsUnspecified);
            obj.dbSet.Add(d);
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, typeof(Product));
            TestArePropertyValuesEqual(d, o.Data);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var d = GetRandom.Object<ProductData>();
            obj.dbSet.Add(d);
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            obj.Delete(d.Id).GetAwaiter();
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsTrue(o.IsUnspecified);
        }
        [TestMethod]
        public void AddTest()
        {
            var d = GetRandom.Object<ProductData>();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsTrue(o.IsUnspecified);
            obj.Add(new Product(d)).GetAwaiter();
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(d, o.Data);
        }
        [TestMethod]
        public void UpdateTest()
        {
            var d = GetRandom.Object<ProductData>();
            var d1 = GetRandom.Object<ProductData>();
            obj.Add(new Product(d)).GetAwaiter();
            d1.Id = d.Id;
            obj.Update(new Product(d1)).GetAwaiter();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(d1, o.Data);
        }
        [TestMethod]
        public void GetListTest()
        {
            for (var i = 0; i < GetRandom.UInt8(10, 30); i++)
            {
                var d = GetRandom.Object<ProductData>();
                obj.Add(new Product(d)).GetAwaiter();
            }

            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            ProductData data = new ProductData();
            var count = GetRandom.UInt8(10, 30);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.Object<ProductData>();
                if (i == idx) data = d;
                obj.Add(new Product(d)).GetAwaiter();
            }

            var m = obj.GetById(data.Id) as Product;
            Assert.IsNotNull(m);
            TestArePropertyValuesEqual(data, m.Data);
        }

    }

}
