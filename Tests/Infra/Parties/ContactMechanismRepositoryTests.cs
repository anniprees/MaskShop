using System;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using MaskShop.Infra;
using MaskShop.Infra.Common;
using MaskShop.Infra.Parties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Parties
{
    [TestClass]
    public class ContactMechanismsRepositoryTests : ShopDbContextTests<ContactMechanismsRepository, ContactMechanism, ContactMechanismData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<ContactMechanism, ContactMechanismData>);

        protected override ContactMechanismsRepository GetObject(ShopDbContext c) =>
            new ContactMechanismsRepository(c);

        protected override DbSet<ContactMechanismData> GetSet(ShopDbContext c) => c.ContactMechanisms;
    }
}
