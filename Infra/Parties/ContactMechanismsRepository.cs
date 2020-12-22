using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Parties
{
    public sealed class ContactMechanismsRepository : UniqueEntityRepository<ContactMechanism, ContactMechanismData>, IContactMechanismsRepository
    {
        public ContactMechanismsRepository(ShopDbContext c = null) : base(c, c?.ContactMechanisms) { }

        protected internal override ContactMechanism ToDomainObject(ContactMechanismData d) => new ContactMechanism(d);
    }
}

