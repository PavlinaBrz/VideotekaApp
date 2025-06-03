using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;
using Microsoft.Extensions.Logging;

/// <summary> Program.cs - soubor, kter� obsahuje vstupn� bod aplikace. Vytvo��me zde instanci WebApplication, kter� obsahuje konfiguraci a slu�by aplikace.
/// V metod� Main() se konfiguruje HTTP po�adavek a spou�t� se aplikace.
/// </summary>

namespace VideotekaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Vytvo�en� instance WebApplication

            // Na�ten� �et�zce p�ipojen� z appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("VideotekaConnection");

            // Konfigurace SQLite datab�ze
            builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlite(connectionString));

            //  P�id�n� slu�eb do kontejneru
            builder.Services.AddRazorPages(); // P�id�n� Razor Pages

            var app = builder.Build();

            // Inicializace datab�ze s migracemi a logov�n�m chyb
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<VideotekaContext>();
                    context.Database.Migrate(); // Pou�ijte migrace m�sto EnsureCreated
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Chyba p�i migraci datab�ze.");
                }
            }

            // Konfigurace HTTP po�adavku
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Films/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Nastaven� v�choz� cesty (routy) - aplikace se spust� v controlleru Films a akci Index
            // app.MapControllerRoute(
               // name: "default",
               // pattern: "{controller=Films}/{action=Index}/{id?}");

            app.MapRazorPages(); // Mapov�n� Razor Pages

            app.Run();  // Spu�t�n� aplikace
        }
    }
}
