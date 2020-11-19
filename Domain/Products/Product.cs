using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class Product: NamedEntity<ProductData>
    {
        public Product() : this(null) { }

        public Product(ProductData d) : base(d) { }

        public string ProductCategoryId
        {
            get => Data?.ProductCategoryId ?? Unspecified;
            set => throw new System.NotImplementedException();
        }

        //public ProductCategory ProductCategory => new GetFrom<IProductCategoriesRepository, ProductCategory>().ById(ProductCategoryId);
    }
}
