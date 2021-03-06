﻿using System;
using System.IO;
using System.Linq;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Data.Parties;
using MaskShop.Data.Products;

namespace MaskShop.Infra
{
    public class DataInitializer
    {
        internal static string dir = Directory.GetCurrentDirectory() + "\\wwwroot\\images";
        internal static string[] files = Directory.GetFiles(dir);

        public static void Initialize(ShopDbContext db)
        {
            InitializeProducts(db);
            InitializeProductCategories(db);
            InitializeBasketItems(db);
            InitializeProductFeatures(db);
            InitializeInventoryItems(db);
            InitializeContactMechanisms(db);
            InitializeOrders(db);
            InitializeOrderItems(db);
            InitializeBaskets(db);
            InitializeParties(db);
            InitializePartyRoles(db);
            InitializePriceComponents(db);
        }

        private static void InitializeContactMechanisms(ShopDbContext db)
        {
            if (db.ContactMechanisms.Count() != 0) return;

            var contactMechanisms = new[]
            {
                new ContactMechanismData {Id = "1", Street = "Viru", City= "Tallinn", State= "Harjumaa", Country= "Eesti", ZipCode= "10114" ,ElectronicMail="silvi.orav@mail.com" ,ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new ContactMechanismData {Id = "2", Street = "Noole", City= "Tallinn", State= "Harjumaa", Country= "Eesti", ZipCode= "10116" ,ElectronicMail="mari.karu@mail.com" ,ValidFrom = Convert.ToDateTime("1/06/2019 09:00"), ValidTo = Convert.ToDateTime("14/04/2021 09:00")},
                new ContactMechanismData {Id = "3", Street = "Kadaka tee", City= "Tallinn", State= "Harjumaa", Country= "Eesti", ZipCode= "10119" ,ElectronicMail="kati.lumi@mail.com" ,ValidFrom = Convert.ToDateTime("25/06/2019 09:00"), ValidTo = Convert.ToDateTime("1/12/2021 09:00")},
                new ContactMechanismData {Id = "4", Street = "Kalda", City= "Tartu", State= "Tartumaa", Country= "Eesti", ZipCode= "10114" ,ElectronicMail="silver.aun@mail.com" ,ValidFrom = Convert.ToDateTime("1/09/2019 09:00"), ValidTo = Convert.ToDateTime("10/04/2028 09:00")},
                new ContactMechanismData {Id = "5", Street = "Pae", City= "Narva", State= "Ida-Virumaa", Country= "Eesti", ZipCode= "10214" ,ElectronicMail="olga.onegin@mail.com" ,ValidFrom = Convert.ToDateTime("11/09/2000 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new ContactMechanismData {Id = "6", Street = "Valli", City= "Valga", State= "Valgamaa", Country= "Eesti", ZipCode= "10314" ,ElectronicMail="mati.maasikasv@mail.com" ,ValidFrom = Convert.ToDateTime("1/06/2010 09:00"), ValidTo = Convert.ToDateTime("1/12/2026 09:00")},

            };

            db.ContactMechanisms.AddRange(contactMechanisms);
            db.SaveChanges();

        }

        private static void InitializeProductFeatures(ShopDbContext db)
        {
            if (db.ProductFeatures.Count() != 0) return;

            var productFeatures = new[]
            {
                new ProductFeatureData {Id = "1", Name = "Feature combo 1", Color = "Black", Size = "L", ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new ProductFeatureData {Id = "2", Name = "Feature combo 2", Color = "Blue", Size = "M", ValidFrom = Convert.ToDateTime("17/06/2018 09:00"), ValidTo = Convert.ToDateTime("21/04/2022 09:00")},
                new ProductFeatureData {Id ="3", Name = "Feature combo 3", Color="Black", Size = "M", ValidFrom = Convert.ToDateTime("17/06/2018 09:00"), ValidTo = Convert.ToDateTime("21/04/2022 09:00")},
                new ProductFeatureData {Id ="4", Name = "Feature combo 4", Color="Blue", Size = "L", ValidFrom = Convert.ToDateTime("17/06/2018 09:00"), ValidTo = Convert.ToDateTime("21/04/2022 09:00")}

            };

            db.ProductFeatures.AddRange(productFeatures);
            db.SaveChanges();

        }

        private static void InitializeOrders(ShopDbContext db)
        {
            if (db.Orders.Count() != 0) return;

            var orders = new[]
            {
                new OrderData {Id = "1", Name = "Order1", PartyId = "1",ContactMechanismId   = "1", OrderStatus = OrderStatus.Received, ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new OrderData {Id = "2", Name = "Order2", PartyId = "4",ContactMechanismId   = "3", OrderStatus = OrderStatus.Received, ValidFrom = Convert.ToDateTime("17/06/2018 09:00"), ValidTo = Convert.ToDateTime("21/04/2022 09:00")},

            };

            db.Orders.AddRange(orders);
            db.SaveChanges();

        }

        private static void InitializeOrderItems(ShopDbContext db)
        {
            if (db.OrderItems.Count() != 0) return;

            var orderItems = new[]
            {
                new OrderItemData {OrderId = "1", ProductId = "1", Quantity = 5, ValidFrom = DateTime.Now, ValidTo = null},
                new OrderItemData {OrderId = "1", ProductId = "2", Quantity = 2, ValidFrom = DateTime.Now, ValidTo = null},
                new OrderItemData {OrderId = "1", ProductId = "3", Quantity = 2, ValidFrom = DateTime.Now, ValidTo = null},
                new OrderItemData {OrderId = "2", ProductId = "4", Quantity = 5, ValidFrom = DateTime.Now, ValidTo = null},
                new OrderItemData {OrderId = "2", ProductId = "5", Quantity = 5, ValidFrom = DateTime.Now, ValidTo = null},

            };

            db.OrderItems.AddRange(orderItems);
            db.SaveChanges();
        }

        private static void InitializeBaskets(ShopDbContext db)
        {
            if (db.Baskets.Count() != 0) return;

            var baskets = new[]
            {
                new BasketData {Id = "1", Name = "Basket1", ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},

            };

            db.Baskets.AddRange(baskets);
            db.SaveChanges();

        }

        private static void InitializeBasketItems(ShopDbContext db)
        {
            if (db.BasketItems.Count() != 0) return;
            var basketItems = new[]
            {
                new BasketItemData{BasketId = "1",ProductId = "1", Quantity = 1},
                new BasketItemData{BasketId = "1",ProductId = "2", Quantity = 2},
                new BasketItemData{BasketId = "1", ProductId = "9", Quantity = 5}, 
            };

            db.BasketItems.AddRange(basketItems);
            db.SaveChanges();
        }

        private static void InitializeParties(ShopDbContext db)
        {
            if (db.Parties.Count() != 0) return;

            var parties = new[]
            {
                new PartyData {Id = "1", Name = "Silvi Orav", PartyRoleId = "4", ContactMechanismId = "1", PartyType = PartyType.Person , ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new PartyData {Id = "2", Name = "Mari Karu", PartyRoleId = "1", ContactMechanismId = "2" , PartyType =PartyType.Unspecified , ValidFrom = Convert.ToDateTime("17/06/2016 09:00"), ValidTo = Convert.ToDateTime("29/04/2026 09:00")},
                new PartyData {Id = "3", Name = "Kati Lumi", PartyRoleId = "3", ContactMechanismId = "3" , PartyType = PartyType.Person, ValidFrom = null, ValidTo = null},
                new PartyData {Id = "4", Name = "Silver Aun", PartyRoleId = "2", ContactMechanismId = "4" , PartyType = PartyType.Organization, ValidFrom = null, ValidTo = null},
                new PartyData {Id = "5", Name = "Olga Onegin", PartyRoleId = "6", ContactMechanismId = "5" , PartyType =PartyType.Person , ValidFrom = null, ValidTo = null},
                new PartyData {Id = "6", Name = "Mati Maasikas", PartyRoleId = "5", ContactMechanismId = "6" , PartyType = PartyType.Person, ValidFrom = null, ValidTo = null},

            };

            db.Parties.AddRange(parties);
            db.SaveChanges();

        }

        private static void InitializePartyRoles(ShopDbContext db)
        {
            if (db.PartyRoles.Count() != 0) return;

            var roles = new[]
            {
                new PartyRoleData {Id = "1", Role = "Webmaster", ValidFrom = Convert.ToDateTime("1/08/2019 09:00"), ValidTo = Convert.ToDateTime("10/04/2025 09:00")},
                new PartyRoleData {Id = "2", Role = "Employee", ValidFrom = Convert.ToDateTime("1/06/2012 09:00"), ValidTo = Convert.ToDateTime("1/04/2021 09:00")},
                new PartyRoleData {Id = "3", Role = "Customer", ValidFrom = null, ValidTo = null},
                new PartyRoleData {Id = "4", Role = "Visitor", ValidFrom = null, ValidTo = null},

            };

            db.PartyRoles.AddRange(roles);
            db.SaveChanges();

        }

        private static void InitializeProductCategories(ShopDbContext db)
        {
            if (db.ProductCategories.Count() != 0) return;

            var categories = new[]
            {
                new ProductCategoryData {Id = "1", Name = "Medical", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "2", Name = "Reusable", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "3", Name = "Organic", ValidFrom = null, ValidTo = null},
                new ProductCategoryData {Id = "4", Name = "Plastic", ValidFrom = null, ValidTo = null},
            };

            db.ProductCategories.AddRange(categories);
            db.SaveChanges();

        }

        private static void InitializeProducts(ShopDbContext db)
        {
            if (db.Products.Count() != 0) return;

            var products = new[]
            {
                new ProductData{Id = "1", Name = "Reusable cloth mask", Picture = ConvertToByteArray(files[0]), Price = 8, ProductCategoryId = "3", ValidFrom = Convert.ToDateTime("1/04/2020 09:00"), ValidTo = null},
                new ProductData{Id = "2", Name = "Face shield", Picture = ConvertToByteArray(files[1]), Price = 15, ProductCategoryId = "4", ValidFrom = Convert.ToDateTime("15/05/2020 09:00"), ValidTo = null},
                new ProductData{Id = "3", Name = "N95 respirator", Picture = ConvertToByteArray(files[5]), Price = 10, ProductCategoryId = "4", ValidFrom = Convert.ToDateTime("10/04/2020 09:00"), ValidTo = null},
                new ProductData{Id = "4", Name = " 3-layer surgical mask", Picture = ConvertToByteArray(files[7]), Price = 5, ProductCategoryId = "1", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "5", Name = "4-layer surgical mask", Picture = ConvertToByteArray(files[8]), Price = 6, ProductCategoryId = "1", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "6", Name = "5-layer surgical mask", Picture = ConvertToByteArray(files[9]), Price = 7, ProductCategoryId = "1", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "7", Name = "FFP1 mask", Picture = ConvertToByteArray(files[2]), Price = 8, ProductCategoryId = "4", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "8", Name = "FFP2 mask", Picture = ConvertToByteArray(files[3]), Price = 9, ProductCategoryId = "4", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "9", Name = "FFP3 mask", Picture = ConvertToByteArray(files[4]), Price = 10, ProductCategoryId = "4", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null},
                new ProductData{Id = "10", Name = "N99 respirator", Picture = ConvertToByteArray(files[6]), Price = 12, ProductCategoryId = "4", ValidFrom = Convert.ToDateTime("13/03/2020 09:00"), ValidTo = null}
            };

            db.Products.AddRange(products);
            db.SaveChanges();
        }

        private static void InitializeInventoryItems(ShopDbContext db)
        {
            if (db.InventoryItems.Count() != 0) return;

            var inventoryItems = new[]
            {
                new InventoryItemData {Id = "1", ProductId = "1", QuantityOnHand = 750, ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new InventoryItemData {Id = "2", ProductId = "2", QuantityOnHand = 553, ValidFrom = Convert.ToDateTime("1/06/2019 09:00"), ValidTo = Convert.ToDateTime("14/04/2021 09:00")},
                new InventoryItemData {Id = "3", ProductId = "3", QuantityOnHand = 98, ValidFrom = Convert.ToDateTime("25/06/2019 09:00"), ValidTo = Convert.ToDateTime("1/12/2021 09:00")},
                new InventoryItemData {Id = "4", ProductId = "4", QuantityOnHand = 405, ValidFrom = Convert.ToDateTime("1/09/2019 09:00"), ValidTo = Convert.ToDateTime("10/04/2028 09:00")},
                new InventoryItemData {Id = "5", ProductId = "5", QuantityOnHand = 315, ValidFrom = Convert.ToDateTime("11/09/2000 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new InventoryItemData {Id = "6", ProductId = "6", QuantityOnHand = 99, ValidFrom = Convert.ToDateTime("1/06/2010 09:00"), ValidTo = Convert.ToDateTime("1/12/2026 09:00")},
                new InventoryItemData {Id = "7", ProductId = "7", QuantityOnHand = 102, ValidFrom = Convert.ToDateTime("1/06/2010 09:00"), ValidTo = Convert.ToDateTime("1/12/2026 09:00")},
                new InventoryItemData {Id = "8", ProductId = "8", QuantityOnHand = 189, ValidFrom = Convert.ToDateTime("1/06/2010 09:00"), ValidTo = Convert.ToDateTime("1/12/2026 09:00")},
                new InventoryItemData {Id = "9", ProductId = "9", QuantityOnHand = 299, ValidFrom = Convert.ToDateTime("1/06/2010 09:00"), ValidTo = Convert.ToDateTime("1/12/2026 09:00")},
                new InventoryItemData {Id = "10", ProductId = "10", QuantityOnHand = 330, ValidFrom = Convert.ToDateTime("1/06/2010 09:00"), ValidTo = Convert.ToDateTime("1/12/2026 09:00")},
            };

            db.InventoryItems.AddRange(inventoryItems);
            db.SaveChanges();

        }

        private static void InitializePriceComponents(ShopDbContext db)
        {
            if (db.PriceComponents.Count() != 0) return;

            var priceComponents = new[]
            {
                new PriceComponentData {Id = "1", DiscountPercentage = 5, Comment = "New user", PartyRoleId = "1", ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new PriceComponentData {Id = "2", DiscountPercentage = 10, Comment = "Fifth purchase", PartyRoleId = "2", ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")},
                new PriceComponentData {Id = "3", DiscountPercentage = 20, Comment = "Sell old stock", PartyRoleId = "3", ValidFrom = Convert.ToDateTime("10/06/2019 09:00"), ValidTo = Convert.ToDateTime("21/04/2021 09:00")}
            };

            db.PriceComponents.AddRange(priceComponents);
            db.SaveChanges();

        }

        private static byte[] ConvertToByteArray(string filePath)
        {
            var file = File.OpenRead(filePath);
            var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }
    }
}
