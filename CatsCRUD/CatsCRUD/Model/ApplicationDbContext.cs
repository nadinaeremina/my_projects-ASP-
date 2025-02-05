using Microsoft.EntityFrameworkCore;

namespace CatsCRUD.Model
{
    public class ApplicationDbContext: DbContext
    {
        public required DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                Data Source=NADI\SQLEXPRESS;
                Initial Catalog=cats_sber;
                Integrated Security=SSPI;
                Timeout=10;
                TrustServerCertificate=true;
            ";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
