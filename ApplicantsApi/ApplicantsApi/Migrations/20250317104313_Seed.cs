﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicantsApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applicants",
                columns: ["Id", "Name", "BirtDate", "IsInternational"],
                values: new object[,] {
                { 1, "Иванов Иван", DateOnly.Parse("2000.01.01"), false },
                { 2, "John Doe", DateOnly.Parse("2002.02.02"), true },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // откат бд
            migrationBuilder.DeleteData(
                table: "Applicants",
                keyColumn: "Id",
                keyValues: [1,2]
            );
        }
    }
}

// после добавления еще одной миграции - снова 'Update-Database'
