using BlazorApp.Server.Models;
using IdentityServer4.EntityFramework.Options;
using MaskShop.Infra;
using MaskShop.Infra.Orders;
using MaskShop.Infra.Products;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        internal void InitializeTables(ModelBuilder builder)
        {
            ShopDbContext.InitializeTables(builder);
        }
    }
}
