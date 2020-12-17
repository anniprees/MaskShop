using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MaskShop.Aids;
using MaskShop.Data.Products;

namespace MaskShop.Infra
{
    public class DataInitializer
    {
        internal static string dir = Directory.GetCurrentDirectory() + "\\wwwroot\\images";
        internal static string[] files = Directory.GetFiles(dir);
        internal static int idx = GetRandom.Int32(0, files.Length);

        private static byte[] ConvertToByteArray(string filePath)
        {
            var file = File.OpenRead(filePath);
            var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }

        internal static List<ProductData> Products => new List<ProductData>
        {
            new ProductData{Id = "1", Name = "Reusable cloth mask", Picture = ConvertToByteArray(files[0]), Price = 8, ProductCategoryId = "9", ValidFrom = Convert.ToDateTime("1/04/2020 09:00"), ValidTo = null},
            new ProductData{Id = "2", Name = "Face shield", Picture = ConvertToByteArray(files[1]), Price = 15, ProductCategoryId = "10", ValidFrom = Convert.ToDateTime("15/05/2020 09:00"), ValidTo = null},
            new ProductData{Id = "3", Name = "N95 respirator", Picture = ConvertToByteArray(files[2]), Price = 10, ProductCategoryId = "7", ValidFrom = Convert.ToDateTime("10/04/2020 09:00"), ValidTo = null},
            new ProductData{Id = "4", Name = " 3-layer surgical mask", Picture = ConvertToByteArray(files[3]), Price = 5, ProductCategoryId = "1", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
            new ProductData{Id = "5", Name = "4-layer surgical mask", Picture = ConvertToByteArray(files[4]), Price = 6, ProductCategoryId = "2", ValidFrom = null, ValidTo = null},
            new ProductData{Id = "6", Name = "5-layer surgical mask", Picture = ConvertToByteArray(files[5]), Price = 7, ProductCategoryId = "3", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "7", Name = "", Picture = ConvertToByteArray(files[6]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "8", Name = "", Picture = ConvertToByteArray(files[7]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "9", Name = "", Picture = ConvertToByteArray(files[8]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "10", Name = "", Picture = ConvertToByteArray(files[9]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "11", Name = "", Picture = ConvertToByteArray(files[10]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "12", Name = "", Picture = ConvertToByteArray(files[11]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "13", Name = "", Picture = ConvertToByteArray(files[12]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "14", Name = "", Picture = ConvertToByteArray(files[13]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},
            //new ProductData{Id = "15", Name = "", Picture = ConvertToByteArray(files[14]), Price = , ProductCategoryId = "", ValidFrom = null, ValidTo = null},

        };

        internal static List<ProductCategoryData> ProductCategories => new List<ProductCategoryData>
        {
            new ProductCategoryData{Id = "1", Name = "3PSFM", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "2", Name = "4PSFM", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "3", Name = "5PSFM", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "4", Name = "FFP1", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "5", Name = "FFP2", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "6", Name = "FFP3", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "7", Name = "N95", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "8", Name = "N99", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "9", Name = "REUCM", ValidFrom = null, ValidTo = null},
            new ProductCategoryData{Id = "10", Name = "EN166", ValidFrom = null, ValidTo = null},
        };

        public static void Initialize(ShopDbContext db)
        {
            InitializeProducts(db);
            InitializeProductCategories(db);
        }

        private static void InitializeProductCategories(ShopDbContext db)
        {
            if (db.Products.Count() == 0)
            {
                db.Products.AddRange(Products);
                db.SaveChanges();
            }
        }

        private static void InitializeProducts(ShopDbContext db)
        {
            if (db.ProductCategories.Count() == 0)
            {
                db.ProductCategories.AddRange(ProductCategories);
                db.SaveChanges();
            }
        }


        //public static void Initialize(ShopDbContext productContext)
        //{
        //    Randomizer.Seed = new Random(8675309);

        //    if (productContext.Products.Count() == 0)
        //    {
        //        // Create new organizations only if the collection is empty
        //        var productNames = new[] { "Medical mask", "Reusable cloth mask", "Reusable plastic mask", "Single use cloth mask", "Single use plastic mask" };
        //        var categoryId = new[] {"MED01", "REG01", "REU01"};
        //        var testProducts = new Faker<ProductData>()
        //            .RuleFor(o => o.Id, f => f.IndexFaker.ToString())
        //            .RuleFor(p => p.Name, f => f.PickRandom(productNames))
        //            .RuleFor(o => o.ProductCategoryId, f => f.PickRandom(categoryId))
        //            .RuleFor(p => p.Price, f => f.Random.Decimal(5.1M, 20.9M))
        //            .RuleFor(p => p.ValidFrom, f=> f.Date.Recent(14))
        //            .RuleFor(p => p.ValidTo, f => f.Date.Soon(14));
        //        var products = testProducts.Generate(20);

        //        foreach (var o in products)
        //        {
        //            productContext.Products.Add(o);
        //        }
        //        productContext.SaveChanges();
        //    }

        //    if (productContext.ProductCategories.Count() == 0)
        //    {
        //        // Create new organizations only if the collection is empty
        //        var categoryNames = new[] { "MED01", "REG01", "REU01" };
        //        var testProductCategories = new Faker<ProductCategoryData>()
        //            .RuleFor(o => o.Id, f => f.IndexFaker.ToString())
        //            .RuleFor(p => p.Name, f => f.PickRandom(categoryNames))
        //            .RuleFor(p => p.ValidFrom, f => f.Date.Recent(14))
        //            .RuleFor(p => p.ValidTo, f => f.Date.Soon(14));
        //        var productCategories = testProductCategories.Generate(20);

        //        foreach (var o in productCategories)
        //        {
        //            productContext.ProductCategories.Add(o);
        //        }
        //        productContext.SaveChanges();
        //    }

        //}
    }
}
