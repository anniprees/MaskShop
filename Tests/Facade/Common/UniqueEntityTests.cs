﻿using MaskShop.Aids;
using MaskShop.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Common
{

    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, PeriodView>
    {
        private class TestClass : UniqueEntityView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod] public void IdTest() => IsNullableProperty(() => obj.Id, x => obj.Id = x);

        [TestMethod] public void GetIdTest() => Assert.AreEqual(obj.Id, obj.GetId());

    }

}