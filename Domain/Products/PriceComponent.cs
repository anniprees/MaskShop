using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class PriceComponent: UniqueEntity<PriceComponentData>
    {
        public PriceComponent(PriceComponentData d) : base(d) { }
        public double Price => Data?.Price ?? UnspecifiedDouble;
        public double Percent => Data?.DiscountComponent ?? UnspecifiedDouble;
        public string Comment => Data?.Comment ?? Unspecified;
        public string ProductId => Data?.ProductId ?? Unspecified;
        //public string ProductFeatureId => Data?.ProductFeatureId ?? Unspecified;
        //public string ProductCategoryId => Data?.ProductCategoryId ?? Unspecified;
        public string ConsumerRoleTypeId => Data?.ConsumerRoleTypeId ?? Unspecified;
        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);

        //public ProductFeature ProductFeature => new GetFrom<IProductFeaturesRepository, ProductFeature>().ById(ProductFeatureId);
        //public ProductCategory ProductCategory => new GetFrom<IProductCategoriesRepository, ProductCategory>().ById(ProductCategoryId);

        //public ConsumerRoleType ConsumerRoleType => new GetFrom<IConsumerRoleTypesRepository, ConsumerRoleType>().ById(ConsumerRoleTypeId);

    }
}
