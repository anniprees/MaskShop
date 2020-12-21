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
    public class PartyNamesRepositoryTests : ShopDbContextTests<PartyNamesRepository, PartyName, PartyNameData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<PartyName, PartyNameData>);

        protected override PartyNamesRepository GetObject(ShopDbContext c) =>
            new PartyNamesRepository(c);

        protected override DbSet<PartyNameData> GetSet(ShopDbContext c) => c.PartyNames;
    }
}
