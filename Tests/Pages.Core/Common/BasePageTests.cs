//using System;
//using MaskShop.Aids;
//using MaskShop.Data.Products;
//using MaskShop.Domain.Products;
//using MaskShop.Facade.Products;
//using MaskShop.PagesCore.Common;
//using MaskShop.PagesCore.Shop.Products;
//using MaskShop.Tests.Data.Common;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using static MaskShop.Tests.Pages.Core.Common.AbstractPageTests<TClass, TBaseClass>;

//namespace MaskShop.Tests.Pages.Core.Common
//{
//    [TestClass]

//    public class BasePageTests : AbstractClassTests<BasePage<IProductsRepository,
//            Product, ProductView, ProductData>,
//        PageModel>
//    {
//        [TestInitialize]
//        public override void TestInitialize()
//        {
//            base.TestInitialize();
//            obj = new testClass(db);
//        }

//        [TestMethod]
//        public void SortOrderTest()
//        {
//            var s = GetRandom.String();
//            obj.SortOrder = s;
//            Assert.AreEqual(s, db.SortOrder);
//            Assert.AreEqual(s, obj.SortOrder);
//        }

//        [TestMethod]
//        public void SearchStringTest()
//        {
//            var s = GetRandom.String();
//            obj.SearchString = s;
//            Assert.AreEqual(s, db.SearchString);
//            Assert.AreEqual(s, obj.SearchString);
//        }

//        [TestMethod]
//        public void currentFilterTest()
//        {
//            var s = GetRandom.String();
//            obj.CurrentFilter = s;
//            Assert.AreEqual(s, db.CurrentFilter);
//            Assert.AreEqual(s, obj.CurrentFilter);
//        }
//        [TestMethod]
//        public void fixedValueTest()
//        {
//            var s = GetRandom.String();
//            obj.FixedValue = s;
//            Assert.AreEqual(s, db.FixedValue);
//            Assert.AreEqual(s, obj.FixedValue);
//        }

//        [TestMethod]
//        public void HasFixedFilterTest() => Assert.Inconclusive();

//        [TestMethod]
//        public void fixedFilterTest()
//        {
//            var s = GetRandom.String();
//            obj.FixedFilter = s;
//            Assert.AreEqual(s, db.FixedFilter);
//            Assert.AreEqual(s, obj.FixedFilter);
//        }

//        [TestMethod]
//        public void setFixedFilterTest()
//        {
//            var filter = GetRandom.String();
//            var value = GetRandom.String();
//            obj.setFixedFilter(filter, value);
//            Assert.AreEqual(filter, obj.FixedFilter);
//            Assert.AreEqual(value, obj.FixedValue);
//        }

//        [TestMethod]
//        public void setPageValuesTest() => Assert.Inconclusive();

//        [TestMethod]
//        public void getSortStringTest()
//        {
//            var page = new Uri("xxx/yyy", UriKind.Relative);
//            obj.SortOrder = "Code";
//            obj.SearchString = "AAA";
//            obj.FixedFilter = "BBB";
//            obj.FixedValue = "CCC";
//            obj.CurrentFilter = "DDD";
//            var sortString = obj.GetSortString(x => x.Code, page);
//            var s = "xxx/yyy?handler=Index&sortOrder=Code_desc&currentFilter=DDD&searchString=AAA&fixedFilter=BBB&fixedValue=CCC";
//            Assert.AreEqual(s, sortString.ToString());
//        }
//        [TestMethod]
//        public void getSortOrderTest()
//        {
//            void test(string sortOrder, string name, bool isDesc)
//            {
//                obj.SortOrder = sortOrder;
//                var actual = obj.getSortOrder(name);
//                var expected = isDesc ? name + "_desc" : name;
//                Assert.AreEqual(expected, actual);
//            }
//            test(null, GetRandom.String(), false);
//            test(GetRandom.String(), GetRandom.String(), false);
//            var s = GetRandom.String();
//            test(s, s, true);
//            test(s + "_desc", s, false);
//        }

//        [TestMethod]
//        public void getCurrentFilterTest() => Assert.Inconclusive();

//        [TestMethod]
//        public void loadDetailsTest() => Assert.Inconclusive();

//        [TestMethod]
//        public void loadDetails2Test() => Assert.Inconclusive();
//    }
//}

