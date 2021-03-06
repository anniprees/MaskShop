using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using MaskShop.Infra;
using MaskShop.Infra.Orders;
using MaskShop.Infra.Parties;
using MaskShop.Infra.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Core
{
    public class Startup
    {
        private static string connection => "DefaultConnection";

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration conf) => Configuration = conf;

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterAuthentication(services);
            services.AddRazorPages();
            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection s)
        {
            s.AddScoped<IPriceComponentsRepository, PriceComponentsRepository>();
            s.AddScoped<IProductsRepository, ProductsRepository>();
            s.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            s.AddScoped<IProductFeaturesRepository, ProductFeaturesRepository>();
            s.AddScoped<IBasketsRepository, BasketsRepository>();
            s.AddScoped<IBasketItemsRepository, BasketItemsRepository>();
            s.AddScoped<IOrdersRepository, OrdersRepository>();
            s.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            s.AddScoped<IPartiesRepository, PartiesRepository>();
            s.AddScoped<IPartyNamesRepository, PartyNamesRepository>();
            s.AddScoped<IPartyRolesRepository, PartyRolesRepository>();
            s.AddScoped<IContactMechanismsRepository, ContactMechanismsRepository>();
            s.AddScoped<IInventoryItemsRepository, InventoryItemsRepository>();
            GetRepository.SetServiceProvider(s.BuildServiceProvider());
        }
        private void registerAuthentication(IServiceCollection s)
            => s.AddDefaultIdentity<IdentityUser>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

        private void registerDbContexts(IServiceCollection s)
        {
            registerDbContext<ApplicationDbContext>(s);
            registerDbContext<ShopDbContext>(s);
        }
        protected virtual void registerDbContext<T>(IServiceCollection s) where T : DbContext
        {
            s.AddDbContext<T>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(connection)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
