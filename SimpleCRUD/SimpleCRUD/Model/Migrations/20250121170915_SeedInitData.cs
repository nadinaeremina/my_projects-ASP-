using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesSimpleCRUD.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DateTime now = DateTime.Today;
            migrationBuilder.InsertData(
                table: "Issues",
                columns: ["Id", "Title", "Description", "CreatedAt", "Deadline", "Priority", "Done"],
                values: new object[,]
                {
                    { 1, "Сделать домашку", "Необходимо сделать все домашние работы до конца месяца", now.AddDays(-5), now.AddDays(10), 3, false },
                    { 2, "Починить велосипед", "Нужно заменить цепь и почистить велосипед", now.AddDays(-3), now.AddDays(-1), 2, true },
                    { 3, "Купить продукты", "Необходимо купить продукты для ужина", now.AddDays(-2), now.AddDays(5), 1, false },
                    { 4, "Помыть машину", "Нужно помыть машину перед поездкой", now.AddDays(-1), now.AddDays(-2), 2, false },
                    { 5, "Записаться к врачу", "Необходимо записаться на прием к врачу", now, now.AddDays(15), 3, false },
                    { 6, "Оплатить счета", "Нужно оплатить коммунальные услуги до конца месяца", now.AddDays(-4), now.AddDays(-3), 2, true },
                    { 7, "Подготовить презентацию", "Необходимо подготовить презентацию для работы", now.AddDays(-6), now.AddDays(8), 3, false },
                    { 8, "Почистить компьютер", "Нужно удалить ненужные файлы и оптимизировать систему", now.AddDays(-7), now.AddDays(-5), 1, true },
                    { 9, "Позвонить другу", "Нужно позвонить другу и обсудить планы на выходные", now.AddDays(-8), now.AddDays(-6), 2, false },
                    { 10, "Записаться на курсы", "Необходимо записаться на онлайн-курсы по программированию", now.AddDays(-9), now.AddDays(-7), 3, true },
                    { 11, "Починить кран", "Нужно починить текущий кран на кухне", now.AddDays(-10), now.AddDays(-8), 2, false }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 11; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Issues",
                    keyColumn: "Id",
                    keyValue: i
                );
            }
        }
    }
}
