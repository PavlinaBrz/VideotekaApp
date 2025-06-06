using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;

/// <summary> Program.cs - soubor, kter� obsahuje vstupn� bod aplikace. Vytvo��me zde instanci WebApplication, kter� obsahuje konfiguraci a slu�by aplikace.
/// V metod� Main() se konfiguruje HTTP po�adavek a spou�t� se aplikace.
/// </summary>

namespace VideotekaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args); // Vytvo�en� instance WebApplication

            // Na�ten� �et�zce p�ipojen� z appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("VideotekaConnection");

            // Konfigurace SQLite datab�ze
            _ = builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlite(connectionString));

            //  P�id�n� slu�eb do kontejneru
            _ = builder.Services.AddRazorPages(); // P�id�n� Razor Pages

            WebApplication app = builder.Build();

            // Inicializace datab�ze s migracemi a logov�n�m chyb
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    VideotekaContext context = services.GetRequiredService<VideotekaContext>();
                    context.Database.Migrate(); // Pou�ijte migrace m�sto EnsureCreated
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Chyba p�i migraci datab�ze.");
                }
            }

            // Konfigurace HTTP po�adavku
            if (!app.Environment.IsDevelopment())
            {
                _ = app.UseExceptionHandler("/Films/Error");
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            // Nastaven� v�choz� cesty (routy) - aplikace se spust� v controlleru Films a akci Index
            // app.MapControllerRoute(
            // name: "default",
            // pattern: "{controller=Films}/{action=Index}/{id?}");

            _ = app.MapRazorPages(); // Mapov�n� Razor Pages

            app.Run();  // Spu�t�n� aplikace
        }
    }
}
