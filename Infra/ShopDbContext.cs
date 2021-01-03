using MaskShop.Data.Orders;
using MaskShop.Data.Parties;
using MaskShop.Data.Products;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }

        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductCategoryData> ProductCategories { get; set; }
        public DbSet<ProductFeatureData> ProductFeatures { get; set; }
        public DbSet<InventoryItemData> InventoryItems { get; set; }
        public DbSet<PriceComponentData> PriceComponents { get; set; }
        public DbSet<ProductFeatureApplicabilityData> ProductFeatureApplicabilities { get; set; }
        public DbSet<BasketData> Baskets { get; set; }
        public DbSet<BasketItemData> BasketItems { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }
        public DbSet<PartyData> Parties { get; set; }
        public DbSet<PartyRoleData> PartyRoles { get; set; }
        public DbSet<ContactMechanismData> ContactMechanisms { get; set; }

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
            builder.Entity<BasketData>().ToTable(nameof(Baskets));
            builder.Entity<BasketItemData>().ToTable(nameof(BasketItems))
                .HasKey(x => new { x.BasketId, x.ProductId });
            builder.Entity<OrderData>().ToTable(nameof(Orders));
            builder.Entity<OrderItemData>().ToTable(nameof(OrderItems))
                .HasKey(x => new { x.OrderId, x.ProductId });
            builder.Entity<PartyData>().ToTable(nameof(Parties));
            builder.Entity<PartyRoleData>().ToTable(nameof(PartyRoles));
            builder.Entity<ContactMechanismData>().ToTable(nameof(ContactMechanisms));
        }
    }
}
