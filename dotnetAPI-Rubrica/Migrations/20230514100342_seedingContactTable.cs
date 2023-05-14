using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnetAPI_Rubrica.Migrations
{
    /// <inheritdoc />
    public partial class seedingContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Email", "Lastname", "Name", "TelephoneNumber", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, null, "marocorssi@gmail.com", "Rossi", "Mario", "3333333333", null, "63accc2d-c69b-4ce5-9f76-3415fc98ce1e" },
                    { 2, null, "luigiverdi@gmail.com", "Verdi", "Luigi", "123123123", null, "2b5b0646-712c-4e6a-a6c2-8e887ca5ffb9" },
                    { 3, null, "giovabianchi@gmail.com", "Bianchi", "Giovanni", "456456456", null, "2b5b0646-712c-4e6a-a6c2-8e887ca5ffb9" },
                    { 4, null, "paroloneri@gmail.com", "Neri", "Paolo", "789789789", null, "63accc2d-c69b-4ce5-9f76-3415fc98ce1e" },
                    { 5, null, "marcogialli@gmail.com", "Gialli", "Marco", "159159159", null, "63accc2d-c69b-4ce5-9f76-3415fc98ce1e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
