using System.Collections.Generic;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class Product: NamedEntity<ProductData>
    {
        public Product() : this(null) { }

        public Product(ProductData d) : base(d) { }

        //public string ProductCategoryId { get; set; }

        public string ProductCategoryId => Data?.ProductCategoryId ?? Unspecified;

        public ProductCategory ProductCategory => new GetFrom<IProductCategoriesRepository, ProductCategory>().ById(ProductCategoryId);

        public string PriceComponentId => Data?.PriceComponentId ?? Unspecified;

        public string ProductFeatureApplicabilityId => Data?.ProductFeatureApplicabilityId ?? Unspecified;

        public decimal Price => Data?.Price ?? UnspecifiedDecimal;

        public string PictureUri => Data?.PictureUri ?? Unspecified;

        public byte[] Picture => Data?.Picture ?? new List<byte>().ToArray();

    }
}
