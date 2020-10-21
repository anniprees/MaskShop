using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasePrices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ProductFeatureId = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<string>(nullable: true),
                    ConsumerRoleTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountComponents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ProductFeatureId = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<string>(nullable: true),
                    ConsumerRoleTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    QuantityOnHand = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionalFeatures",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductFeatureId = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalFeatures", x => new { x.ProductId, x.ProductFeatureId });
                });

            migrationBuilder.CreateTable(
                name: "OrderValues",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    FromAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Definition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatureCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Definition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatureCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Definition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuantityBreaks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    FromQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityBreaks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequiredFeatures",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductFeatureId = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredFeatures", x => new { x.ProductId, x.ProductFeatureId });
                });

            migrationBuilder.CreateTable(
                name: "SelectableFeatures",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductFeatureId = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectableFeatures", x => new { x.ProductId, x.ProductFeatureId });
                });

            migrationBuilder.CreateTable(
                name: "StandardFeatures",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    ProductFeatureId = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardFeatures", x => new { x.ProductId, x.ProductFeatureId });
                });

            migrationBuilder.CreateTable(
                name: "SurchargeComponents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Percent = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ProductFeatureId = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<string>(nullable: true),
                    ConsumerRoleTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurchargeComponents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasePrices");

            migrationBuilder.DropTable(
                name: "DiscountComponents");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "OptionalFeatures");

            migrationBuilder.DropTable(
                name: "OrderValues");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductFeatureCategories");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "QuantityBreaks");

            migrationBuilder.DropTable(
                name: "RequiredFeatures");

            migrationBuilder.DropTable(
                name: "SelectableFeatures");

            migrationBuilder.DropTable(
                name: "StandardFeatures");

            migrationBuilder.DropTable(
                name: "SurchargeComponents");
        }
    }
}
