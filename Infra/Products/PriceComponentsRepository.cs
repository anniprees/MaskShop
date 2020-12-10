using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class PriceComponentsRepository : UniqueEntityRepository<PriceComponent, PriceComponentData>, IPriceComponentsRepository
    {
        public PriceComponentsRepository(ProductDbContext c = null) : base(c, c?.PriceComponents) { }

        protected internal override PriceComponent ToDomainObject(PriceComponentData d) => new PriceComponent(d);
    }
}