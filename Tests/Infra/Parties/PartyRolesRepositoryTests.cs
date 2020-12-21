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
    public class PartyRolesRepositoryTests : ShopDbContextTests<PartyRolesRepository, PartyRole, PartyRoleData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<PartyRole, PartyRoleData>);

        protected override PartyRolesRepository GetObject(ShopDbContext c) =>
            new PartyRolesRepository(c);

        protected override DbSet<PartyRoleData> GetSet(ShopDbContext c) => c.PartyRoles;
    }
}
