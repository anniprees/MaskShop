using System;
using System.Linq.Expressions;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{

    [TestClass]
    public class GetMemberTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize() => Type = typeof(GetMember);

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual("Data", GetMember.Name<Product>(o => o.Data));
            Assert.AreEqual("Name", GetMember.Name<ProductData>(o => o.Name));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o => o.NameTest()));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Func<ProductData, object>>) null));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Action<ProductData>>) null));
        }

        [TestMethod]
        public void DisplayNameTest()
        {
            Assert.AreEqual("Data", GetMember.DisplayName<Product>(o => o.Data));
            Assert.AreEqual("Valid From",
                GetMember.DisplayName<PartyView>(o => o.ValidFrom));
            Assert.AreEqual("Name", GetMember.DisplayName<PartyView>(o => o.Name));
            Assert.AreEqual("Valid To", GetMember.DisplayName<PartyView>(o => o.ValidTo));
            Assert.AreEqual(string.Empty, GetMember.DisplayName((Expression<Func<PartyView, object>>) null));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<PartyView>((string) null));
            //Impossible to use for methods
            //Assert.AreEqual(string.Empty, GetMember.DisplayName<GetMemberTests>(o => o.NameTest()));
        }

    }

}
