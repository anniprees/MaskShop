using System.Linq;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Common;
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
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<Product, ProductData>,
        SortedRepository<Product, ProductData>>
    {

        private class TestClass : FilteredRepository<Product, ProductData>
        {

            public TestClass(DbContext c, DbSet<ProductData> s) : base(c, s) { }

            protected internal override Product ToDomainObject(ProductData d) => new Product(d);

            protected override async Task<ProductData> GetData(string id)
            {
                await Task.CompletedTask;

                return dbSet.Find(id);
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

            //for (var i = 0; i < GetRandom.UInt8(10, 30); i++)
            //{
            //    var d = GetRandom.Object<ProductData>();
            //    obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            //}

        }

        [TestMethod]
        public void SearchStringTest()
            => IsNullableProperty(() => obj.SearchString, x => obj.SearchString = x);

        [TestMethod]
        public void CurrentFilterTest()
            => IsNullableProperty(() => obj.CurrentFilter, x => obj.CurrentFilter = x);

        [TestMethod]
        public void FixedFilterTest()
            => IsNullableProperty(() => obj.FixedFilter, x => obj.FixedFilter = x);

        [TestMethod]
        public void FixedValueTest()
            => IsNullableProperty(() => obj.FixedValue, x => obj.FixedValue = x);

        [TestMethod]
        public void GetListTest()
        {
            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }

        [TestMethod]
        public void GetFilteredListTest()
        {
            var s = GetRandom.String();
            var c = GetRandom.UInt8(10, 30);

            //for (var i = 0; i < c; i++)
            //{
            //    var d = GetRandom.Object<ProductData>();
            //    addFilter(d, s, i);
            //    obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            //}

            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
            obj.SearchString = s;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(c, l.Count);
        }

        //private static void AddFilter(DefinedEntityData d, string s, int i)
        //{
        //    var x = i % 3;
        //    if (x == 0) d.Id += s;
        //    else if (x == 1) d.Name += s;
        //}
        //[TestMethod]
        //public void GetFixedListTest()
        //{
        //    var s1 = GetRandom.String(10, 20);
        //    var s2 = GetRandom.String(10, 20);
        //    var c1 = GetRandom.UInt8(10, 30);
        //    var c2 = GetRandom.UInt8(10, 30);
        //    var c3 = GetRandom.UInt8(10, 30);

        //    for (var i = 0; i < c1; i++)
        //    {
        //        var d = GetRandom.Object<PeriodData>();
        //        AddFilter(d, s1, i);
        //       // obj.Add(MeasureFactory.Create(d)).GetAwaiter();
        //    }

        //    for (var i = 0; i < c2; i++)
        //    {
        //        var d = GetRandom.Object<ProductData>();
        //        AddFilter(d, s1, i);
        //        d.Definition = s2;
        //        obj.Add(MeasureFactory.Create(d)).GetAwaiter();
        //    }

        //    for (var i = 0; i < c3; i++)
        //    {
        //        var d = GetRandom.Object<MeasureData>();
        //        d.Definition = s2;
        //        obj.Add(MeasureFactory.Create(d)).GetAwaiter();
        //    }

        //    var l = obj.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(obj.dbSet.Count(), l.Count);
        //    obj.SearchString = s1;
        //    l = obj.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(c1 + c2, l.Count);
        //    obj.FixedFilter = "Definition";
        //    obj.FixedValue = s2;
        //    l = obj.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(c2, l.Count);
        //    obj.SearchString = null;
        //    l = obj.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(c2 + c3, l.Count);
        //}

    }
}
