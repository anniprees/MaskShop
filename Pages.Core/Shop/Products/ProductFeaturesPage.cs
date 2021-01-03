using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;

namespace MaskShop.PagesCore.Shop.Products
{
    public class ProductFeaturesPage : ViewPage<ProductFeaturesPage, IProductFeaturesRepository, ProductFeature, ProductFeatureView, ProductFeatureData>
    {

        public ProductFeaturesPage(IProductFeaturesRepository r) : base(r, "Product Features") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/ProductFeatures", UriKind.Relative);
        protected internal override ProductFeature toObject(ProductFeatureView v) => ProductFeatureViewFactory.Create(v);
        protected internal override ProductFeatureView toView(ProductFeature o) => ProductFeatureViewFactory.Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.Definition);
            createColumn(x => Item.NumericCode);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
    }
}
