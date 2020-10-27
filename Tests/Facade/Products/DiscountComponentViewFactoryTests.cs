using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass]
    public class DiscountComponentViewFactoryTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(DiscountComponentViewFactory);

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<DiscountComponentView>();
            var data = DiscountComponentViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<DiscountComponentData>();
            var view = DiscountComponentViewFactory.Create(new DiscountComponent(data));

            TestArePropertyValuesEqual(view, data);

        }

    }

}