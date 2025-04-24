using Microsoft.EntityFrameworkCore;

namespace ETicaret.Models
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EMRE\\SQLEXPRESS01; Database=EticaretDemoDb;Integrated Security=true; TrustServerCertificate=True;");
        }

        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Sepet> Sepetim { get; set; }

    }
}
