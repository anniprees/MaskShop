using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using BlazorApp.Server.Data;
using BlazorApp.Server.Grid;
using BlazorApp.Server.Hubs;
using BlazorApp.Server.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BlazorApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: lisada Identity tagasi - hetkel rakendus toimib
            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddResponseCompression(option =>
            {
                option.ExcludedMimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/octet-stream"});
            });


            // Tehtud EFCore Code First Add-Migration - abstraktne ApplicationDBContext esialgu pole kasutusel
            services.AddDbContext<ProductDbContext>(option =>
                option.UseSqlServer(
                    Configuration.GetConnectionString("ProductDBContext")));

            // TODO: concurrency rakendamisel DBContextFactory kasutamine
            //services.AddDbContextFactory<ProductDbContext>(opt =>
            //    opt.UseSqlServer(Configuration.GetConnectionString($"{nameof(ProductDbContext.ProductsDb)}.db")));
            
            services.AddScoped<IPageHelper, PageHelper>();
            services.AddScoped<IFilters, GridControls>();
            services.AddScoped<GridQueryAdapter>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseIdentityServer();
            //app.UseAuthentication();
            //app.UseAuthorization();

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
