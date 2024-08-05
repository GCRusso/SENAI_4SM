using Microsoft.EntityFrameworkCore;
using PharmacyAPI_Test.Domains;

namespace PharmacyAPI_Test.Context
{
    public class ProductContext : DbContext
    {
    public DbSet<ProductsDomain> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= NOTE15-S21; Initial Catalog= PharmacyAPITest; User Id= sa; pwd = Senai@134; TrustServerCertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
