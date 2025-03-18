using Microsoft.EntityFrameworkCore;

namespace CustomerApi
{
    public class ApplicationDbContext:DbContext
    {
        public required DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // берем из 'Session pooler' (из проекта)
            string connectionstring = @"
                Host=aws-0-eu-central-1.pooler.supabase.com;
                Port=5432;
                Database=postgres;
                Username=postgres.avkwdfmbcknqwvqyyaxj;
                Password=postgres;
            ";
            // 'UseNpgsql' - характерно для 'Postgres'
            optionsBuilder.UseNpgsql(connectionstring);
        }
    }
}
