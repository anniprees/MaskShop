using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Parties
{
    public class PartyDbContext: DbContext
    {
        public PartyDbContext(DbContextOptions<PartyDbContext> options)
            : base(options) { }

        public DbSet<PartyData> Parties{ get; set; }
        public DbSet<PartyNameData> PartyNames { get; set; }
        public DbSet<PartyRoleData> PartyRoles { get; set; }
        public DbSet<ContactMechanismData> ContactMechanisms { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<PartyData>().ToTable(nameof(Parties));
            builder.Entity<PartyNameData>().ToTable(nameof(PartyNames));
            builder.Entity<PartyRole>().ToTable(nameof(PartyRoles));
            builder.Entity<ContactMechanismData>().ToTable(nameof(ContactMechanisms));
        }
    }
}
