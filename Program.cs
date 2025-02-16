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
            var builder = WebApplication.CreateBuilder(args); // Vytvoøení instance WebApplication

            // Naètení øetìzce pøipojení z appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("VideotekaConnection");

            // Konfigurace SQLite databáze
            builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlite(connectionString));

            //  Pøidání služeb do kontejneru - MVC (Controller, View, Model)
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Vytvoøení databáze pøi startu aplikace
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<VideotekaContext>();
                context.Database.EnsureCreated();
            }

            // Konfigurace HTTP požadavku
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Films/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Nastavení výchozí cesty (routy) - aplikace se spustí v controlleru Films a akci Index
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Films}/{action=Index}/{id?}");

            app.Run();  // Spuštìní aplikace
        }
    }
}
