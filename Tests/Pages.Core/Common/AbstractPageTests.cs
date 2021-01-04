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
        internal abstract class testClass : ViewsPage<ProductsPage, IProductsRepository, Product, ProductView, ProductData>
        {

        //    internal string subTitle { get; set; } = string.Empty;

        //    protected internal testClass(IProductsRepository r) : base(r, QuantityPagesNames.SystemsOfUnits) { }

            protected override Uri pageUrl() => new Uri(QuantityPagesUrls.SystemsOfUnits, UriKind.Relative);

            protected override Product toObject(ProductView view) => ProductViewFactory.Create(view);

            protected override ProductView toView(Product obj) => ProductViewFactory.Create(obj);

            protected override string pageSubtitle() => subTitle;

        //}

        internal class testRepository : UniqueRepository<Product, ProductData>, IProductsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new testRepository();
        }

    }

}