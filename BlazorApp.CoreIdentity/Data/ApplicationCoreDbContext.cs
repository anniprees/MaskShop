﻿using MaskShop.Infra;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.CoreIdentity.Data
{
    public class ApplicationCoreDbContext : IdentityDbContext
    {
        public ApplicationCoreDbContext(DbContextOptions<ApplicationCoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitializeTables(b);
        }

        internal static void InitializeTables(ModelBuilder b)
        {
            ShopDbContext.InitializeTables(b);
        }
    }
}
