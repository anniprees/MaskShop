using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public abstract class ProductFeature<TData>: NamedEntity<TData> where TData: ProductFeatureData, new()
    {
        protected ProductFeature(TData d) : base(d) { }
    }
}
