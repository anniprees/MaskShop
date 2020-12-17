using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<Product, ProductData>,
        BaseRepository<Product, ProductData>>
    {

        private string TestingClass => nameof(ProductData);

        private class TestClass : SortedRepository<Product, ProductData>
        {

            public TestClass(DbContext c, DbSet<ProductData> s) : base(c, s) { }

            protected override Product ToDomainObject(ProductData d) => new Product(d);

            protected override async Task<ProductData> GetData(string id)
            {
                await Task.CompletedTask;
                return new ProductData();
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
        public void SortOrderTest()
        {
            IsNullableProperty(() => obj.SortOrder, x => obj.SortOrder = x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {

            var propertyName = GetMember.Name<TestClass>(x => x.DescendingString);
            IsReadOnlyProperty(obj, propertyName, "_desc");
        }

        [TestMethod]
        public void SetSortingTest()
        {
            void test(IQueryable<ProductData> d, string sortOrder)
            {
                obj.SortOrder = sortOrder + obj.DescendingString;
                var set = obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"{TestingClass}]).OrderByDescending(x => Convert(x.{sortOrder}, Object))"));
                obj.SortOrder = sortOrder;
                set = obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.Contains($"{TestingClass}]).OrderBy(x => Convert(x.{sortOrder}, Object))"));
            }

            Assert.IsNull(obj.AddSorting(null));
            IQueryable<ProductData> data = obj.dbSet;
            obj.SortOrder = null;
            Assert.AreEqual(data, obj.AddSorting(data));
            test(data, GetMember.Name<ProductData>(x => x.Id));
            test(data, GetMember.Name<ProductData>(x => x.Name));
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            TestCreateExpression(GetMember.Name<ProductData>(x => x.ValidFrom));
            TestCreateExpression(GetMember.Name<ProductData>(x => x.ValidTo));
            TestCreateExpression(GetMember.Name<ProductData>(x => x.Id));
            TestCreateExpression(GetMember.Name<ProductData>(x => x.Name));
            TestCreateExpression(s = GetMember.Name<ProductData>(x => x.ValidFrom), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<ProductData>(x => x.ValidTo), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<ProductData>(x => x.Id), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<ProductData>(x => x.Name), s + obj.DescendingString);
            TestNullExpression(string.Empty);
            TestNullExpression(null);
        }

        private void TestNullExpression(string name)
        {
            obj.SortOrder = name;
            var lambda = obj.CreateExpression();
            Assert.IsNull(lambda);
        }

        private void TestCreateExpression(string expected, string name = null)
        {
            name ??= expected;
            obj.SortOrder = name;
            var lambda = obj.CreateExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<ProductData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<ProductData>(x => x.ValidFrom);
            var property = typeof(ProductData).GetProperty(name);
            var lambda = obj.LambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<ProductData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;

            void test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.FindProperty());
            }

            test(null, GetRandom.String());
            test(null, null);
            test(null, string.Empty);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.Name)), s);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.ValidFrom)), s);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.ValidTo)), s);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.Id)), s);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.Name)), s + obj.DescendingString);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.ValidFrom)), s + obj.DescendingString);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.ValidTo)), s + obj.DescendingString);
            test(typeof(ProductData).GetProperty(s = GetMember.Name<ProductData>(x => x.Id)), s + obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;

            void test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.GetName());
            }

            test(s = GetRandom.String(), s);
            test(s = GetRandom.String(), s + obj.DescendingString);
            test(string.Empty, string.Empty);
            test(string.Empty, null);
        }

        [TestMethod]
        public void SetOrderByTest()
        {
            void test(IQueryable<ProductData> d, Expression<Func<ProductData, object>> e, string expected)
            {
                obj.SortOrder = GetRandom.String() + obj.DescendingString;
                var set = obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"{TestingClass}]).OrderByDescending({expected})"));
                obj.SortOrder = GetRandom.String();
                set = obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                Assert.IsTrue(set.Expression.ToString().Contains($"{TestingClass}]).OrderBy({expected})"));
            }

            Assert.IsNull(obj.AddOrderBy(null, null));
            IQueryable<ProductData> data = obj.dbSet;
            Assert.AreEqual(data, obj.AddOrderBy(data, null));
            test(data, x => x.Id, "x => x.Id");
            test(data, x => x.Name, "x => x.Name");
            test(data, x => x.ValidFrom, "x => Convert(x.From, Object)");
            test(data, x => x.ValidTo, "x => Convert(x.To, Object)");
        }

        [TestMethod]
        public void IsDescendingTest()
        {
            void test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.IsDescending());
            }

            test(GetRandom.String(), false);
            test(GetRandom.String() + obj.DescendingString, true);
            test(string.Empty, false);
            test(null, false);
        }

    }

}