using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class DiscountComponentsRepository : UniqueEntityRepository<DiscountComponent, DiscountComponentData>,
        IDiscountComponentsRepository
    {
        public DiscountComponentsRepository(ProductDbContext c = null) : base(c, c?.DiscountComponents)
        {
        }

        protected internal override DiscountComponent toDomainObject(DiscountComponentData d) =>
            new DiscountComponent(d);
    }
}