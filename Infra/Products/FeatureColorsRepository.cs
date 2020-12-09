using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class FeatureColorsRepository : UniqueEntityRepository<FeatureColor, FeatureColorData>, IFeatureColorsRepository
    {
        public FeatureColorsRepository(ProductDbContext c = null) : base(c, c?.FeatureColors) { }

        protected override FeatureColor ToDomainObject(FeatureColorData d) => new FeatureColor(d);
    }
}