//using MaskShop.Aids;
//using MaskShop.Data.Products;
//using MaskShop.Domain.Products;
//using MaskShop.Facade.Products;
//using MaskShop.PagesCore.Common;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace MaskShop.Tests.Pages.Core.Common
//{
//    [TestClass]
//    public class CrudPageTests : AbstractPageTests<CrudPage<IProductsRepository, Product, ProductView, ProductData>,
//        BasePage<IProductsRepository, Product, ProductView, ProductData>>
//    {

//        private string fixedFilter;
//        private string fixedValue;

//        [TestInitialize]
//        public override void TestInitialize()
//        {
//            base.TestInitialize();
//            obj = new testClass(db);
//            fixedFilter = GetRandom.String();
//            fixedValue = GetRandom.String();
//            Assert.AreEqual(null, obj.FixedValue);
//            Assert.AreEqual(null, obj.FixedFilter);
//        }

//        [TestMethod]
//        public void itemTest()
//        {
//            IsProperty(() => obj.Item, x => obj.Item = x);
//        }
//        [TestMethod]
//        public void itemIdTest()
//        {
//            obj.Item = GetRandom.Object<ProductView>();
//            Assert.AreEqual(obj.Item.GetId(), obj.ItemId);
//        }
//        [TestMethod]
//        public void addObjectTest()
//        {
//            var idx = db.list.Count;
//            obj.Item = GetRandom.Object<ProductView>();
//            obj.addObject(fixedFilter, fixedValue).GetAwaiter();
//            Assert.AreEqual(fixedFilter, obj.FixedFilter);
//            Assert.AreEqual(fixedValue, obj.FixedValue);
//            TestArePropertiesEqual(obj.Item, db.list[idx].Data);
//        }
//        [TestMethod] public void addObject2Test() => Assert.Inconclusive();
//        [TestMethod]
//        public void UpdateObjectTest()
//        {
//            getObjectTest();
//            var idx = GetRandom.Int32(0, db.list.Count);
//            var itemId = db.list[idx].Data.Id;
//            obj.Item = GetRandom.Object<ProductView>();
//            obj.Item.Id = itemId;
//            obj.updateObject(fixedFilter, fixedValue).GetAwaiter();
//            TestArePropertiesEqual(db.list[^1].Data, obj.Item);
//        }
//        [TestMethod] public void updateObject2Test() => Assert.Inconclusive();
//        [TestMethod]
//        public void getObjectTest()
//        {
//            var count = GetRandom.UInt8(5, 10);
//            var idx = GetRandom.UInt8(0, count);
//            for (var i = 0; i < count; i++) addObjectTest();
//            var item = db.list[idx];
//            obj.getObject(item.Data.Id, fixedFilter, fixedValue).GetAwaiter();
//            Assert.AreEqual(count, db.list.Count);
//            TestArePropertiesEqual(item.Data, obj.Item);
//        }
//        [TestMethod] public void getObject2Test() => Assert.Inconclusive();
//        [TestMethod]
//        public void deleteObjectTest()
//        {
//            addObjectTest();
//            obj.deleteObject(obj.Item.Id, fixedFilter, fixedValue).GetAwaiter();
//            Assert.AreEqual(fixedFilter, obj.FixedFilter);
//            Assert.AreEqual(fixedValue, obj.FixedValue);
//            Assert.AreEqual(0, db.list.Count);
//        }
//        [TestMethod] public void deleteObject2Test() => Assert.Inconclusive();
//        [TestMethod] public void toObjectTest() => Assert.Inconclusive();
//        [TestMethod] public void toViewTest() => Assert.Inconclusive();
//    }

//}