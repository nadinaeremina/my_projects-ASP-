using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkCRUD.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitData : Migration
    {
        // применение миграции
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: ["Id", "Nickname", "Gender", "Breed", "Birthday", "Rating", "Price"],
                values: new object[,]
                {
                { 1, "Richard", "M", "Scotland", new DateTime(2020, 2, 14), 5, 35000.00 },
                { 2, "Miya", "F", "Siamese", new DateTime(2022, 12, 1), 3, 20000.00 },
                { 3, "Rocky", "M", "Sphinx", new DateTime(2023, 5, 4), 4, 55000.00 },
                { 4, "Lola", "F", "British", new DateTime(2019, 4, 5), 3, 25000.00 },
                { 5, "Saimon", "M", "Maine Coon", new DateTime(2024, 10, 10), 4, 65000.00 },
                { 6, "Koka", "F", "Bengali", new DateTime(2022, 12, 22), 5, 45000.00 },
                { 7, "Maxi", "M", "Oriental", new DateTime(2021, 12, 14), 3, 20000.00 },
                { 8, "Spicy", "M", "Scotland", new DateTime(2022, 9, 1), 3, 40000.00 },
                { 9, "Mimi", "F", "British", new DateTime(2024, 12, 1), 4, 35000.00 },
                { 10, "Pupa", "M", "Sphinx", new DateTime(2020, 2, 14), 4, 30000.00 },
                }
            );
        }

        // отмена миграции
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 10; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Cats",
                    keyColumn: "Id",
                    keyValue: i
                );
            }
        }
    }
}
