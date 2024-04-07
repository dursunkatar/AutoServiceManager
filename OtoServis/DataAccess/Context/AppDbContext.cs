using Microsoft.EntityFrameworkCore;
using OtoServis.DataAccess.Entities;

namespace OtoServis.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Model> Modeller { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Parca> Parcalar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Tamir> Tamirler { get; set; }
        public DbSet<TamirDurum> TamirDurum { get; set; }
    }
}
