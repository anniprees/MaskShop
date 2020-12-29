using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Data.Products;

namespace MaskShop.Infra
{
    public class DataInitializer
    {
        internal static string dir = Directory.GetCurrentDirectory() + "\\wwwroot\\images";
        internal static string[] files = Directory.GetFiles(dir);
        internal static int idx = GetRandom.Int32(0, files.Length);

        public static void Initialize(ShopDbContext db)
        {
            InitializeProducts(db);
            InitializeProductCategories(db);
            InitializeBasketItems(db);
        }

        private static void InitializeBasketItems(ShopDbContext db)
        {
            if (db.BasketItems.Count() != 0) return;
            var basketItems = new[]
            {
                new BasketItemData{BasketId = "1",ProductId = "1", Quantity = 1},
                new BasketItemData{BasketId = "1",ProductId = "2", Quantity = 2},
            };

            db.BasketItems.AddRange(basketItems);
            db.SaveChanges();
        }

        private static void InitializeProductCategories(ShopDbContext db)
        {
            if (db.ProductCategories.Count() != 0) return;

            var categories = new[]
            {
                new ProductCategoryData {Id = "1", Name = "3PSFM", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "2", Name = "4PSFM", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "3", Name = "5PSFM", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "4", Name = "FFP1", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "5", Name = "FFP2", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "6", Name = "FFP3", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "7", Name = "N95", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "8", Name = "N99", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "9", Name = "REUCM", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "10", Name = "EN166", ValidFrom = null, ValidTo = null},
            };
                
            db.ProductCategories.AddRange(categories); 
            db.SaveChanges();
            
        }

        private static void InitializeProducts(ShopDbContext db)
        {
            if (db.Products.Count() != 0) return;

            var products = new[]
            {
                new ProductData{Id = "1", Name = "Reusable cloth mask", Price = 8, ProductCategoryId = "9",PictureUri = "", ValidFrom = Convert.ToDateTime("1/04/2020 09:00"), ValidTo = null},
                new ProductData{Id = "2", Name = "Face shield", Price = 15, ProductCategoryId = "10", ValidFrom = Convert.ToDateTime("15/05/2020 09:00"), ValidTo = null},
                new ProductData{Id = "3", Name = "N95 respirator", Price = 10, ProductCategoryId = "7", ValidFrom = Convert.ToDateTime("10/04/2020 09:00"), ValidTo = null},
                new ProductData{Id = "4", Name = " 3-layer surgical mask", Price = 5, ProductCategoryId = "1", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "5", Name = "4-layer surgical mask", Price = 6, ProductCategoryId = "2", ValidFrom = null, ValidTo = null},
                new ProductData{Id = "6", Name = "5-layer surgical mask", Price = 7, ProductCategoryId = "3", ValidFrom = null, ValidTo = null},
            };

            db.Products.AddRange(products);
            db.SaveChanges();
        }

        private static byte[] ConvertToByteArray(string filePath)
        {
            var file = File.OpenRead(filePath);
            var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }

        //internal static List<ProductData> Products => new List<ProductData>
        //{
        //    new ProductData{Id = "1", Name = "Reusable cloth mask", Picture = ConvertToByteArray(files[0]), Price = 8, ProductCategoryId = "9", ValidFrom = Convert.ToDateTime("1/04/2020 09:00"), ValidTo = null},
        //    new ProductData{Id = "2", Name = "Face shield", Picture = ConvertToByteArray(files[1]), Price = 15, ProductCategoryId = "10", ValidFrom = Convert.ToDateTime("15/05/2020 09:00"), ValidTo = null},
        //    new ProductData{Id = "3", Name = "N95 respirator", Picture = ConvertToByteArray(files[2]), Price = 10, ProductCategoryId = "7", ValidFrom = Convert.ToDateTime("10/04/2020 09:00"), ValidTo = null},
        //    new ProductData{Id = "4", Name = " 3-layer surgical mask", Picture = ConvertToByteArray(files[3]), Price = 5, ProductCategoryId = "1", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
        //    new ProductData{Id = "5", Name = "4-layer surgical mask", Picture = ConvertToByteArray(files[4]), Price = 6, ProductCategoryId = "2", ValidFrom = null, ValidTo = null},
        //    new ProductData{Id = "6", Name = "5-layer surgical mask", Picture = ConvertToByteArray(files[5]), Price = 7, ProductCategoryId = "3", ValidFrom = null, ValidTo = null},
        //};

    }
}
