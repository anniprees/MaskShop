using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class SurchargeComponentsRepository :
        UniqueEntityRepository<SurchargeComponent, SurchargeComponentData>, ISurchargeComponentsRepository
    {
        public SurchargeComponentsRepository(ProductDbContext c = null) : base(c, c?.SurchargeComponents)
        {
        }

        protected internal override SurchargeComponent ToDomainObject(SurchargeComponentData d) =>
            new SurchargeComponent(d);
    }
}