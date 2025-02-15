using Microsoft.EntityFrameworkCore;
using VideotekaApp.Models;

/*Soubor definuje kontext databáze, který popojují modely s databází.
 * Kontext databáze je odvozen z třídy DbContext, která je součástí Entity Framework Core.
 */

namespace VideotekaApp.Data
{
    public class VideotekaContext : DbContext // Třída VideotekaContext odvozená z DbContext
    {
        public VideotekaContext(DbContextOptions<VideotekaContext> options) : base(options) // Konstruktor třídy
        {
        }
        // Vlastnosti, které reprezentují tabulku v databázi
        public DbSet<Film> Films { get; set; }
    }
}
