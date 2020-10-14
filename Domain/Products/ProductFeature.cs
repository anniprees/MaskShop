using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public abstract class ProductFeature<TData>: DefinedEntity<TData> where TData: ProductFeatureData, new()
    {
        public ProductFeature(TData d = null) : base(d) { }
    }
}
