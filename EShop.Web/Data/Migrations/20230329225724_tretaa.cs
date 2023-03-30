using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Web.Data.Migrations
{
    public partial class tretaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCards_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInShoppingCards",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    ShoppingCardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInShoppingCards", x => new { x.ProductId, x.ShoppingCardId });
                    table.ForeignKey(
                        name: "FK_ProductInShoppingCards_ShoppingCards_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ShoppingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInShoppingCards_Products_ShoppingCardId",
                        column: x => x.ShoppingCardId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShoppingCards_ShoppingCardId",
                table: "ProductInShoppingCards",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_OwnerId",
                table: "ShoppingCards",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInShoppingCards");

            migrationBuilder.DropTable(
                name: "ShoppingCards");
        }
    }
}
