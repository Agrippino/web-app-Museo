using Microsoft.EntityFrameworkCore;

namespace web_app_Museo.Data
{
    public class MuseoContext : DbContext
    {
        DbSet<Prodotto> Prodotti { get; set; }
        DbSet<Acquisto> Acquisti { get; set; }
        DbSet<Categoria> Categorie { get; set; }
        DbSet<Rifornimento> Rifornimenti { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DbMuseo; Integrated Security=True");
        }
    }
}
