using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.CoreIdentity.Migrations
{
    public partial class ProductFeaturesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ProductFeatures",
                newName: "Size");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ProductFeatures",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductFeatures");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ProductFeatures",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
