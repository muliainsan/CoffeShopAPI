using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeShop.Migrations
{
    public partial class CoffeShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    _CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    _DeletedDate = table.Column<DateTime>(nullable: false),
                    _DeletedFlag = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    _LastModifier = table.Column<bool>(nullable: false),
                    LastModifierBy = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    _CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    _DeletedDate = table.Column<DateTime>(nullable: false),
                    _DeletedFlag = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    _LastModifier = table.Column<bool>(nullable: false),
                    LastModifierBy = table.Column<string>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    _CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    _DeletedDate = table.Column<DateTime>(nullable: false),
                    _DeletedFlag = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    _LastModifier = table.Column<bool>(nullable: false),
                    LastModifierBy = table.Column<string>(nullable: true),
                    OrderName = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    _CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    _DeletedDate = table.Column<DateTime>(nullable: false),
                    _DeletedFlag = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    _LastModifier = table.Column<bool>(nullable: false),
                    LastModifierBy = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderEntry");
        }
    }
}
