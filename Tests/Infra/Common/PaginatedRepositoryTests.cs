﻿using System;
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
    public class PaginatedRepositoryTests : AbstractClassTests<PaginatedRepository<Product, ProductData>,
         FilteredRepository<Product, ProductData>>
    {

        private class TestClass : PaginatedRepository<Product, ProductData>
        {

            public TestClass(DbContext c, DbSet<ProductData> s) : base(c, s) { }
            protected internal override Product ToDomainObject(ProductData d) => new Product(d);
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

            //for (var i = 0; i < GetRandom.UInt8(10, 30); i++)
            //{
            //    var d = GetRandom.Object<ProductData>();
            //    obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            //}

        }

        [TestMethod] public void PageIndexTest() => IsProperty(() => obj.PageIndex, x => obj.PageIndex = x);

        [TestMethod]
        public void TotalPagesTest()
            => IsReadOnlyProperty(obj, nameof(obj.TotalPages),
                (int)Math.Ceiling((double)obj.dbSet.Count() / obj.PageSize));

        [TestMethod]
        public void HasNextPageTest() =>
            IsReadOnlyProperty(obj, nameof(obj.HasNextPage), obj.PageIndex < obj.TotalPages);

        [TestMethod]
        public void HasPreviousPageTest()
            => IsReadOnlyProperty(obj, nameof(obj.HasPreviousPage), obj.PageIndex > 1);

        [TestMethod]
        public void PageSizeTest()
        {
            Assert.AreEqual(obj.PageSize, Constants.DefaultPageSize);
            IsProperty(() => obj.PageSize, x => obj.PageSize = x);
        }

        [TestMethod]
        public void GetListTest()
        {
            //for (var i = 0; i < GetRandom.UInt8(10, 30); i++)
            //{
            //    var d = GetRandom.Object<ProductData>();
            //    obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            //}

            obj.PageIndex = 1;
            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.PageSize, l.Count);
            obj.PageIndex = -1;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }
    }

}
