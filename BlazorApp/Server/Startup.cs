using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using BlazorApp.Server.Data;
using BlazorApp.Server.Hubs;
using BlazorApp.Server.Models;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Parties;
using MaskShop.Domain.Products;
using MaskShop.Infra;
using MaskShop.Infra.Orders;
using MaskShop.Infra.Parties;
using MaskShop.Infra.Products;

namespace BlazorApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterAuthentication(services);
            services.AddRazorPages();
            services.AddControllersWithViews();
            RegisterConnections(services);
            RegisterRepositories(services);
        }

        private void RegisterDbContexts(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        private void RegisterAuthentication(IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
        }

        private void RegisterConnections(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination"));
            });

            services.AddSignalR();

            services.AddResponseCompression(option => option.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" }));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IPriceComponentsRepository, PriceComponentsRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddScoped<IProductFeaturesRepository, ProductFeaturesRepository>();
            services.AddScoped<IBasketsRepository, BasketsRepository>();
            services.AddScoped<IBasketItemsRepository, BasketItemsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IPartiesRepository, PartiesRepository>();
            services.AddScoped<IPartyNamesRepository, PartyNamesRepository>();
            services.AddScoped<IPartyRolesRepository, PartyRolesRepository>();
            services.AddScoped<IContactMechanismsRepository, ContactMechanismsRepository>();
            services.AddScoped<IInventoryItemsRepository, InventoryItemsRepository>();
            GetRepository.SetServiceProvider(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<ProductHub>("/ProductHub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
