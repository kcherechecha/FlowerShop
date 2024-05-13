using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ItemOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "ItemOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ItemOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders");

            migrationBuilder.DropIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders",
                columns: new[] { "OrderId", "ItemId" });
        }
    }
}
