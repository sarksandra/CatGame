using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Data.Migrations
{
    /// <inheritdoc />
    public partial class error35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CatDMs",
                table: "CatDMs");

            migrationBuilder.RenameTable(
                name: "CatDMs",
                newName: "Kittys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kittys",
                table: "Kittys",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kittys",
                table: "Kittys");

            migrationBuilder.RenameTable(
                name: "Kittys",
                newName: "CatDMs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatDMs",
                table: "CatDMs",
                column: "Id");
        }
    }
}
