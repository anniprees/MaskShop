using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Orders
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        public DbSet<BasketData> Baskets { get; set; }
        public DbSet<BasketItemData> BasketItems { get; set; }
        //public DbSet<OrderData> Orders { get; set; }
        //public DbSet<OrderItemData> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<BasketData>().ToTable(nameof(Baskets));
            builder.Entity<BasketItemData>().ToTable(nameof(BasketItems))
                .HasKey(x => new {x.BasketId, x.ProductId});
            //builder.Entity<OrderData>().ToTable(nameof(Orders));
            //builder.Entity<OrderItemData>().ToTable(nameof(OrderItems));
        }
    }
}
