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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DbMuseo; Integrated Security=True");
        }
    }
}
