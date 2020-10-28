using System;
using System.Collections.Generic;
using System.Text;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Shared.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
