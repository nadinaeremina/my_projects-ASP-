using Microsoft.EntityFrameworkCore;

namespace RazorPagesSimpleCRUD.Model
{
    public class ApplicationDbContext : DbContext  
    {
        public required DbSet<Issue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                Data Source=NADI\SQLEXPRESS;
                Initial Catalog=todo_list_db_pv324;
                Integrated Security=SSPI;
                Timeout=10;
                TrustServerCertificate=true;
            ";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
