using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class FeatureSizesRepository : UniqueEntityRepository<FeatureSize, FeatureSizeData>, IFeatureSizesRepository
    {
        public FeatureSizesRepository(ProductDbContext c = null) : base(c, c?.FeatureSizes) { }

        protected override FeatureSize ToDomainObject(FeatureSizeData d) => new FeatureSize(d);
    }
}