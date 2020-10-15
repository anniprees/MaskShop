using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Products
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductFeatureData> ProductFeatures { get; set; }
        public DbSet<ProductCategoryData> ProductCategories { get; set; }
        public DbSet<ProductFeatureCategoryData> ProductFeatureCategories { get; set; }
        public DbSet<BasePriceData> BasePrices { get; set; }
        public DbSet<DiscountComponentData> DiscountComponents { get; set; }
        public DbSet<SurchargeComponentData> SurchargeComponents { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<OrderValueData> OrderValues { get; set; }
        public DbSet<QuantityBreakData> QuantityBreaks { get; set; }
        public DbSet<RequiredFeatureData> RequiredFeatures { get; set; }
        public DbSet<OptionalFeatureData> OptionalFeatures { get; set; }
        public DbSet<SelectableFeatureData> SelectableFeatures { get; set; }
        public DbSet<StandardFeatureData> StandardFeatures { get; set; }


        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    InitializeTables(builder);
        //}

        //public static void InitializeTables(ModelBuilder builder)
        //{
        //    if (builder is null) return;
        //    builder.Entity<ProductData>().ToTable(nameof(Products));
        //    builder.Entity<ProductFeatureData>().ToTable(nameof(ProductFeatures));
        //    builder.Entity<ProductCategoryData>().ToTable(nameof(ProductCategories));
        //    builder.Entity<ProductFeatureCategoryData>().ToTable(nameof(ProductFeatureCategories));
        //    builder.Entity<BasePriceData>().ToTable(nameof(BasePrices));
        //    builder.Entity<DiscountComponentData>().ToTable(nameof(DiscountComponents)).OwnsOne(
        //        x => x.Percent);
        //    builder.Entity<SurchargeComponentData>().ToTable(nameof(SurchargeComponents)).OwnsOne(
        //        x => x.Percent);
        //    builder.Entity<InventoryItem>().ToTable(nameof(InventoryItems));
        //    builder.Entity<OrderValueData>().ToTable(nameof(OrderValues));
        //    builder.Entity<QuantityBreakData>().ToTable(nameof(QuantityBreaks));
        //    builder.Entity<RequiredFeatureData>().ToTable(nameof(RequiredFeatures))
        //        .HasKey(x => new {x.ProductFeatureId, x.ProductId});
        //    builder.Entity<OptionalFeatureData>().ToTable(nameof(OptionalFeatures))
        //        .HasKey(x => new {x.ProductFeatureId, x.ProductId});
        //    builder.Entity<SelectableFeatureData>().ToTable(nameof(SelectableFeatures))
        //        .HasKey(x => new {x.ProductFeatureId, x.ProductId});
        //    builder.Entity<StandardFeatureData>().ToTable(nameof(StandardFeatures))
        //        .HasKey(x => new {x.ProductFeatureId, x.ProductId});
        //}
    }
}