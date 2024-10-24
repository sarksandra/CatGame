using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Data.Migrations
{
    /// <inheritdoc />
    public partial class init34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatDMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatFoodXP = table.Column<int>(type: "int", nullable: false),
                    CatFoodXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    CatLevel = table.Column<int>(type: "int", nullable: false),
                    CatType = table.Column<int>(type: "int", nullable: false),
                    CatFoodType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CatID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatDMs");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");
        }
    }
}
