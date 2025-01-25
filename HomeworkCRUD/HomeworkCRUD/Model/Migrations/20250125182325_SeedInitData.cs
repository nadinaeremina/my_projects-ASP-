using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkCRUD.Model.Migrations
{
    public partial class SeedInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: ["Id", "Nickname", "Gender", "Breed", "Birthday", "Behaviour", "Price"],
                values: new object[,]
                {
                { 1, "Richard", "M", "Scotland", new DateTime(2020, 2, 14), "Calm", 35000.00 },
                { 2, "Miya", "F", "Siamese", new DateTime(2022, 12, 1), "Wild", 20000.00 },
                { 3, "Rocky", "M", "Sphinx", new DateTime(2023, 5, 4), "Quiet", 55000.00 },
                { 4, "Lola", "F", "British", new DateTime(2019, 4, 5), "Loud", 25000.00 },
                { 5, "Saimon", "M", "Maine Coon", new DateTime(2024, 10, 10), "Jolly", 65000.00 },
                { 6, "Koka", "F", "Bengali", new DateTime(2022, 12, 22), "Calm", 45000.00 },
                { 7, "Maxi", "M", "Oriental", new DateTime(2021, 12, 14), "Wild", 20000.00 },
                { 8, "Spicy", "M", "Scotland", new DateTime(2022, 9, 1), "Loud", 40000.00 },
                { 9, "Mimi", "F", "British", new DateTime(2024, 12, 1), "Quiet", 35000.00 },
                { 10, "Pupa", "M", "Sphinx", new DateTime(2020, 2, 14), "Jolly", 30000.00 },
                }
            );
        }

        /// <inheritdoc />
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
