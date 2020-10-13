using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    //initializeTables(builder);
        //}

        //internal void initializeTables(ModelBuilder builder)
        //{
        //    MoneyDbContext.InitializeTables(builder);
        //    QuantityDbContext.InitializeTables(builder);
        //    PartyDbContext.InitializeTables(builder);
        //    RulesDbContext.InitializeTables(builder);
        //    ProductDbContext.InitializeTables(builder);
        //}

    }
}
