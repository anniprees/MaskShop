using System.Net.Http;
using MaskShop.Domain.Products;

namespace BlazorApp.Client.Services
{
    public class ProductManager : APIRepository<Product>
    {
        HttpClient HttpClient;

        public ProductManager(HttpClient http)
            : base(http, "products", "Id")
        {
            HttpClient = http;
        }
    }
}