using Microsoft.EntityFrameworkCore;
using PharmacyAPI_Test.Domains;

namespace PharmacyAPI_Test.Context
{
    public class ProductContext : DbContext
    {
    public DbSet<ProductsDomain> ProductsDomain { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source= NOTE15-S21; Initial Catalog= PharmacyAPITest; User Id= sa; pwd = Senai@134; TrustServerCertificate = true;");
            optionsBuilder.UseSqlServer("Data Source= JC-SP-ADM-GABRIEL; Initial Catalog= PharmacyAPITest; Integrated Security=True; TrustServerCertificate = true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
