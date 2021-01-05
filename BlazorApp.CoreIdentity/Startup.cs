using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp.CoreIdentity.Data;
using BlazorApp.CoreIdentity.Services;
using BlazorStrap;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using MaskShop.Infra;
using MaskShop.Infra.Orders;
using MaskShop.Infra.Parties;
using MaskShop.Infra.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BlazorApp.CoreIdentity
{
    public class Startup
    {
        private static string connection => "DefaultConnection";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddServerSideBlazor();
            services.AddBootstrapCss();
            RegisterDbContexts(services);
            RegisterAuthentication(services);
            RegisterRepositories(services);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<ShoppingService>();
        }

        private static void RegisterRepositories(IServiceCollection s)
        {
            s.AddScoped<IPriceComponentsRepository, PriceComponentsRepository>();
            s.AddScoped<IProductsRepository, ProductsRepository>();
            s.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            s.AddScoped<IProductFeaturesRepository, ProductFeaturesRepository>();
            s.AddScoped<IProductFeatureApplicabilitiesRepository, ProductFeatureApplicabilitiesRepository>();
            s.AddScoped<IBasketsRepository, BasketsRepository>();
            s.AddScoped<IBasketItemsRepository, BasketItemsRepository>();
            s.AddScoped<IOrdersRepository, OrdersRepository>();
            s.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            s.AddScoped<IPartiesRepository, PartiesRepository>();
            s.AddScoped<IPartyRolesRepository, PartyRolesRepository>();
            s.AddScoped<IContactMechanismsRepository, ContactMechanismsRepository>();
            s.AddScoped<IInventoryItemsRepository, InventoryItemsRepository>();
            GetRepository.SetServiceProvider(s.BuildServiceProvider());
        }

        private static void RegisterAuthentication(IServiceCollection s)
            => s.AddDefaultIdentity<IdentityUser>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationCoreDbContext>();

        private void RegisterDbContexts(IServiceCollection s)
        {
            s.AddDbContext<ApplicationCoreDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(connection)));

            s.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(connection)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapBlazorHub();
            });
        }
    }
}
