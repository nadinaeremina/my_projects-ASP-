using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkingsCRUD.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                // название таблицы
                table: "Drinks",
                // зададим колонки
                columns: ["Id", "Title", "Volume", "Price", "IsHot"],
                values: new object[,]
                {
                    { 1, "Кофе", 400, 200, true },
                    { 2, "Минеральная вода", 500, 120, false },
                    { 3, "Энергетик", 500, 250, false },
                    { 4, "Чай", 200, 100, true },
                    { 5, "Холодный чай", 400, 150, false },
                    { 6, "Сок", 500, 130, false },
                    { 7, "Швепс", 450, 140, false },

                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 7; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Drinks",
                    // удалять будем по 'id'
                    keyColumn: "Id",
                    keyValue: i
                );
            }
        }
    }
}

