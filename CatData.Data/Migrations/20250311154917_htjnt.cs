using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Data.Migrations
{
    /// <inheritdoc />
    public partial class htjnt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FoodID",
                table: "FilesToDatabase",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "FilesToDatabase");
        }
    }
}
