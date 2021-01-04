using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class CopyTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Copy);
        }

        [TestMethod]
        public void MembersTest()
        {
            var x = GetRandom.Object<ProductCategoryData>();
            var y = GetRandom.Object<ProductCategoryView>();
            TestArePropertyValuesNotEqual(x, y);
            Copy.Members(x, y);
            TestArePropertiesEqual(x, y);
        }

    }

}