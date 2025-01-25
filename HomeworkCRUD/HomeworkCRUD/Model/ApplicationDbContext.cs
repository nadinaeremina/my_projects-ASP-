using Microsoft.EntityFrameworkCore;

namespace HomeworkCRUD.Model
{
    public class ApplicationDbContext: DbContext
    {
        public required DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                Data Source=NADI\SQLEXPRESS;
                Initial Catalog=cats_list_db_pv324;
                Integrated Security=SSPI;
                Timeout=10;
                TrustServerCertificate=true;
            ";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
