using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;

/// <summary> Program.cs - soubor, který obsahuje vstupní bod aplikace. Vytvoøíme zde instanci WebApplication, která obsahuje konfiguraci a služby aplikace.
/// V metodì Main() se konfiguruje HTTP požadavek a spouští se aplikace.
/// </summary>

namespace VideotekaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args); // Vytvoøení instance WebApplication

            // Naètení øetìzce pøipojení z appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("VideotekaConnection");

            // Konfigurace SQLite databáze
            _ = builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlite(connectionString));

            //  Pøidání služeb do kontejneru
            _ = builder.Services.AddRazorPages(); // Pøidání Razor Pages

            WebApplication app = builder.Build();

            // Inicializace databáze s migracemi a logováním chyb
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    VideotekaContext context = services.GetRequiredService<VideotekaContext>();
                    context.Database.Migrate(); // Použijte migrace místo EnsureCreated
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Chyba pøi migraci databáze.");
                }
            }

            // Konfigurace HTTP požadavku
            if (!app.Environment.IsDevelopment())
            {
                _ = app.UseExceptionHandler("/Films/Error");
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            // Nastavení výchozí cesty (routy) - aplikace se spustí v controlleru Films a akci Index
            // app.MapControllerRoute(
            // name: "default",
            // pattern: "{controller=Films}/{action=Index}/{id?}");

            _ = app.MapRazorPages(); // Mapování Razor Pages

            app.Run();  // Spuštìní aplikace
        }
    }
}
