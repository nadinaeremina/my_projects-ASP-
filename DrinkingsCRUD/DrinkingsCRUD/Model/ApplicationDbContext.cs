using Microsoft.EntityFrameworkCore;

namespace DrinkingsCRUD.Model
{
    public class ApplicationDbContext: DbContext
    {
        public required DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                Data Source=NADI\SQLEXPRESS;
                Initial Catalog=drinks_db_pv324;
                Integrated Security=SSPI;
                Timeout=10;
                TrustServerCertificate=true;
            ";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
