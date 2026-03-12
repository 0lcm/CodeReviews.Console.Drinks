using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drinksInfo._0lcm.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoritedDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDrink = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    StrDrink = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SavedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViewedDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDrink = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    StrDrink = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    ViewCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewedDrinks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritedDrinks");

            migrationBuilder.DropTable(
                name: "ViewedDrinks");
        }
    }
}
