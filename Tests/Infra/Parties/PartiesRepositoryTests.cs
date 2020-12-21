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
    public class PartiesRepositoryTests : ShopDbContextTests<PartiesRepository, Party, PartyData>
    {
        protected override Type GetBaseClass() =>
            typeof(UniqueEntityRepository<Party, PartyData>);

        protected override PartiesRepository GetObject(ShopDbContext c) =>
            new PartiesRepository(c);

        protected override DbSet<PartyData> GetSet(ShopDbContext c) => c.Parties;
    }
}
