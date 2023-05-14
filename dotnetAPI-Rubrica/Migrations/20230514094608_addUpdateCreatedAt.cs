using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetAPI_Rubrica.Migrations
{
    /// <inheritdoc />
    public partial class addUpdateCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Contacts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Contacts");
        }
    }
}
