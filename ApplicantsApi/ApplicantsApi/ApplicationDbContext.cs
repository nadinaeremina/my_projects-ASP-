using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApplicantsApi
{
    public class ApplicationDbContext: DbContext
    {
        public required DbSet<Applicant> Applicants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // берем из 'Session pooler' (из проекта)
            string connectionstring = @"
                Host=aws-0-eu-central-1.pooler.supabase.com;
                Port=5432;
                Database=postgres;
                Username=postgres.yzwmmrquecjffzeziias;
                Password=postgres;
            ";
            // 'UseNpgsql' - характерно для 'Postgres'
            optionsBuilder.UseNpgsql(connectionstring);
        }
    }
}
// Add - Migration init
// Update - Database
// Add-Migration Seed - создание пустой миграции