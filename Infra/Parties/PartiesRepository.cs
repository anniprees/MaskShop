using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Parties
{
    public sealed class PartiesRepository : UniqueEntityRepository<Party, PartyData>, IPartiesRepository
    {
        public PartiesRepository(PartyDbContext c = null) : base(c, c?.Parties) { }

        protected internal override Party ToDomainObject(PartyData d) => new Party(d);
    }
}
