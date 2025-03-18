using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: ["Id", "Name", "Email", "RegistrationDate"],
                values: new object[,] {
                { 1, "Соболев Никита", "sob12@mail.ru", DateOnly.FromDateTime(DateTime.Now)},
                { 2, "Капустина Ольга", "kap33@mail.ru", DateOnly.FromDateTime(DateTime.Now)},
                { 3, "Старцев Геннадий", "sta48r@mail.ru", DateOnly.FromDateTime(DateTime.Now)},
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // откат бд
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValues: [1, 2, 3]
            );
        }
    }
}
