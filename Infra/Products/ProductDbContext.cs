using MaskShop.Data.Products;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Products
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductCategoryData> ProductCategories { get; set; }
        public DbSet<ProductFeatureData> ProductFeatures { get; set; }
        public DbSet<InventoryItemData> InventoryItems { get; set; }
        public DbSet<PriceComponentData> PriceComponents { get; set; }
        public DbSet<ProductFeatureApplicabilityData> ProductFeatureApplicabilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<ProductData>().ToTable(nameof(Products))
                .Property(x => x.Price)
                .HasColumnType("decimal(16, 2)");
            builder.Entity<ProductCategoryData>().ToTable(nameof(ProductCategories));
            builder.Entity<ProductFeatureData>().ToTable(nameof(ProductFeatures));
            builder.Entity<InventoryItemData>().ToTable(nameof(InventoryItems));
            builder.Entity<PriceComponentData>().ToTable(nameof(PriceComponents));
            builder.Entity<ProductFeatureApplicabilityData>().ToTable(nameof(ProductFeatureApplicabilities));
        }
    }
}
