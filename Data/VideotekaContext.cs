using Microsoft.EntityFrameworkCore;
using VideotekaApp.Models;

/// <summary>
/// Soubor definuje kontext databáze, který propojuje modely s databází.
/// Kontext databáze je odvozen z třídy DbContext, která je součástí Entity Framework Core - posyktuje DbSet pro entitu Film a konfiguraci modelu.
/// </summary>

namespace VideotekaApp.Data
{
    public class VideotekaContext : DbContext // Třída VideotekaContext odvozená z DbContext
    {
        public VideotekaContext(DbContextOptions<VideotekaContext> options) : base(options) // Konstruktor třídy
        {
            // Zajistíme, že databáze bude vytvořena při prvním použití
            Database.EnsureCreated();
        }

        // Vlastnosti, které reprezentují tabulku v databázi
        public DbSet<Film> Films { get; set; } = null!; // Vlastnost Films reprezentuje tabulku v databázi

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Metoda OnModelCreating, která konfiguruje modely
        {
            base.OnModelCreating(modelBuilder);

            // Nastavení výchozích hodnot a omezení pro tabulku Films
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.ID); // Nastavení primárního klíče pro tabulku Films
                entity.Property(e => e.Title).IsRequired().HasMaxLength(60); // Nastavení výchozích hodnot a omezení pro sloupec Title
                entity.Property(e => e.ReleaseYear).IsRequired(); // Nastavení výchozích hodnot a omezení pro sloupec ReleaseYear
                entity.Property(e => e.Genre).IsRequired().HasMaxLength(30); // Nastavení výchozích hodnot a omezení pro sloupec Genre
                entity.Property(e => e.Rating).IsRequired(); // Nastavení výchozích hodnot a omezení pro sloupec Rating

            });
        }
    }
}
