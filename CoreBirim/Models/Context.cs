using Microsoft.EntityFrameworkCore;

namespace CoreBirim.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MIKDAT; database=corebirim; integrated security=true; TrustServerCertificate=True;");
        }
        public DbSet<Birim> Birims  { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
