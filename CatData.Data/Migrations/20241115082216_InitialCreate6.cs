using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatFood",
                table: "Kittys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatFood",
                table: "Kittys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
