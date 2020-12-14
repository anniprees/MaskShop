using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Parties
{
    public sealed class PartyRolesRepository : UniqueEntityRepository<PartyRole, PartyRoleData>, IPartyRolesRepository
    {
        public PartyRolesRepository(PartyDbContext c = null) : base(c, c?.PartyRoles) { }

        protected internal override PartyRole ToDomainObject(PartyRoleData d) => new PartyRole(d);
    }
}
