using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CustomBouquetadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Flowers",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Bouquets",
                type: "bytea",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomBouquets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    RequestTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomBouquets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomBouquets");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Bouquets");
        }
    }
}
