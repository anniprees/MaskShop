using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Products
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<Product>().ToTable(nameof(Products));
            builder.Entity<ProductCategory>().ToTable(nameof(ProductCategories));
        }

        //public DbSet<ProductData> Products { get; set; }
        //public DbSet<ProductFeatureData> ProductFeatures { get; set; }
        //public DbSet<ProductCategoryData> ProductCategories { get; set; }
        //public DbSet<ProductFeatureCategoryData> ProductFeatureCategories { get; set; }
        //public DbSet<BasePriceData> BasePrices { get; set; }
        //public DbSet<DiscountComponentData> DiscountComponents { get; set; }
        //public DbSet<SurchargeComponentData> SurchargeComponents { get; set; }
        //public DbSet<InventoryItemData> InventoryItems { get; set; }
        //public DbSet<OrderValueData> OrderValues { get; set; }
        //public DbSet<QuantityBreakData> QuantityBreaks { get; set; }
        //public DbSet<RequiredFeatureData> RequiredFeatures { get; set; }
        //public DbSet<OptionalFeatureData> OptionalFeatures { get; set; }
        //public DbSet<SelectableFeatureData> SelectableFeatures { get; set; }
        //public DbSet<StandardFeatureData> StandardFeatures { get; set; }


        //public ProductDbContext(DbContextOptions<ProductDbContext> options)
        //    : base(options)
        //{
        //}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    InitializeTables(builder);
        //}

        //public static void InitializeTables(ModelBuilder builder)
        //{
        //    if (builder is null) return;


        //    builder.Entity<ProductData>().HasKey(table => new { table.Id, });

        //    //builder.Entity<ProductData>()
        //    //    .HasOne(i => i.Id).WithMany(i => i.Products)
        //    //    .HasForeignKey(i => i.ProductCategoryId)
        //    //    ;


        //    builder.Entity<ProductFeatureData>().HasKey(nameof(ProductFeatures));
        //    builder.Entity<ProductCategoryData>().HasKey(nameof(ProductCategories));
        //    builder.Entity<ProductFeatureCategoryData>().HasKey(nameof(ProductFeatureCategories));
        //    builder.Entity<BasePriceData>().HasKey(nameof(BasePrices));
        //    builder.Entity<DiscountComponentData>().HasKey(nameof(DiscountComponents));
        //    builder.Entity<SurchargeComponentData>().HasKey(nameof(SurchargeComponents));
        //    builder.Entity<InventoryItemData>().HasKey(nameof(InventoryItems));
        //    builder.Entity<OrderValueData>().HasKey(nameof(OrderValues));
        //    builder.Entity<QuantityBreakData>().HasKey(nameof(QuantityBreaks));
        //    builder.Entity<RequiredFeatureData>().HasKey(table => new { table.ProductFeatureId, table.ProductId });
        //    builder.Entity<OptionalFeatureData>().HasKey(table => new { table.ProductFeatureId, table.ProductId });
        //    builder.Entity<SelectableFeatureData>().HasKey(table => new { table.ProductFeatureId, table.ProductId });
        //    builder.Entity<StandardFeatureData>().HasKey(table => new { table.ProductFeatureId, table.ProductId });
        }
        }
