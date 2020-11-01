using System;
using System.Linq;
using BlazorApp.Shared.Models;
using Bogus;
using Bogus.DataSets;

namespace BlazorApp.Shared.Data
{
    public class DataInitializer
    {
        public static void Initialize(ProductDbContext productContext)
        {
            Randomizer.Seed = new Random(8675309);

            if (productContext.Products.Count() == 0)
            {
                // Create new organizations only if the collection is empty
                var productNames = new[] { "Medical mask", "Reusable cloth mask", "Reusable plastic mask", "Single use cloth mask", "Single use plastic mask" };
                var categoryId = new[] {"MED01", "REG01", "REU01"};
                var testProducts = new Faker<Product>()
                    .RuleFor(o => o.Id, f => f.IndexFaker.ToString())
                    .RuleFor(p => p.Name, f => f.PickRandom(productNames))
                    .RuleFor(o => o.ProductCategoryId, f => f.PickRandom(categoryId))
                    .RuleFor(p => p.From, f=> f.Date.Recent(14))
                    .RuleFor(p => p.To, f => f.Date.Soon(14));
                var products = testProducts.Generate(20);

                foreach (Product o in products)
                {
                    productContext.Products.Add(o);
                }
                productContext.SaveChanges();
            }
        }
    }
}
