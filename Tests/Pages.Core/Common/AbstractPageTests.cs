using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using MaskShop.PagesCore.Common.Consts;
using MaskShop.PagesCore.Shop.Products;
using MaskShop.PagesCore.ShopAdmin.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Pages.Core.Common
{

    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IProductsRepository, Product, ProductView, ProductData>
    {

        internal testRepository db;
        internal abstract class testClass : ViewsPage<ProductsAdminPage, IProductsRepository, Product, ProductView, ProductData>
        {

            internal string subTitle { get; set; } = string.Empty;

            protected internal testClass(IProductsRepository r) : base(r, QuantityPagesNames.SystemsOfUnits) { }

            protected internal override Uri pageUrl() => new Uri(QuantityPagesUrls.SystemsOfUnits, UriKind.Relative);

            protected internal override Product toObject(ProductView view) => new ProductViewFactory().Create(view);

            protected internal override ProductView toView(Product obj) => new ProductViewFactory().Create(obj);

            protected internal override string pageSubtitle() => subTitle;

        }

        internal class testRepository : UniqueRepository<Product, ProductData>, IProductsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new testRepository();
        }

    }

}