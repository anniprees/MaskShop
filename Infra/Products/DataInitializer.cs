using System;
using System.Linq;
using Bogus;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Infra.Products
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
                var testProducts = new Faker<ProductData>()
                    .RuleFor(o => o.Id, f => f.IndexFaker.ToString())
                    .RuleFor(p => p.Name, f => f.PickRandom(productNames))
                    .RuleFor(o => o.ProductCategoryId, f => f.PickRandom(categoryId))
                    .RuleFor(p => p.Price, f => f.Random.Double())
                    .RuleFor(p => p.ValidFrom, f=> f.Date.Recent(14))
                    .RuleFor(p => p.ValidTo, f => f.Date.Soon(14));
                var products = testProducts.Generate(20);

                foreach (var o in products)
                {
                    productContext.Products.Add(o);
                }
                productContext.SaveChanges();
            }

            if (productContext.ProductCategories.Count() == 0)
            {
                // Create new organizations only if the collection is empty
                var categoryNames = new[] { "MED01", "REG01", "REU01" };
                var testProductCategories = new Faker<ProductCategoryData>()
                    .RuleFor(o => o.Id, f => f.IndexFaker.ToString())
                    .RuleFor(p => p.Name, f => f.PickRandom(categoryNames))
                    .RuleFor(p => p.ValidFrom, f => f.Date.Recent(14))
                    .RuleFor(p => p.ValidTo, f => f.Date.Soon(14));
                var productCategories = testProductCategories.Generate(20);

                foreach (var o in productCategories)
                {
                    productContext.ProductCategories.Add(o);
                }
                productContext.SaveChanges();
            }

        }
    }
}
