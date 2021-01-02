using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MaskShop.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.CoreIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var db = services.GetRequiredService<ShopDbContext>();
                DataInitializer.Initialize(db);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
