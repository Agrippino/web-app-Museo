using Microsoft.EntityFrameworkCore;
using web_app_Museo.Models;

namespace web_app_Museo.Data
{
    public class MuseoContext : DbContext
    {
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Acquisto> Acquisti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Rifornimento> Rifornimenti { get; set; }
        public DbSet<QuantitaAggiunta> QuantitaAggiunte { get; set; }
        public DbSet<QuantitaAcquistata> QuantitaAcquistate { get; set; }
        public DbSet<QuantitaDisponibile> QuantitaDisponibili { get; set; }
        public DbSet<ClassificaProdotto> ClassificaProdotti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DbMuseo; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<QuantitaAggiunta>()
            .ToView(nameof(QuantitaAggiunte))
            .HasKey(t => t.Id);

            modelBuilder
            .Entity<QuantitaAcquistata>()
            .ToView(nameof(QuantitaAcquistate))
            .HasKey(t => t.Id);

            modelBuilder
            .Entity<QuantitaDisponibile>()
            .ToView(nameof(QuantitaDisponibili))
            .HasKey(t => t.Id);

            modelBuilder
           .Entity<ClassificaProdotto>()
           .ToView(nameof(ClassificaProdotti))
           .HasKey(t => t.Id);

            modelBuilder
            .Entity<Prodotto>()
            .Property(b => b.QuantitaDisponibile)
            .HasDefaultValue(0);
        }
    }
}
