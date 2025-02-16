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
            var builder = WebApplication.CreateBuilder(args); // Vytvo�en� instance WebApplication

            // Na�ten� �et�zce p�ipojen� z appsettings.json
            string connectionString = builder.Configuration.GetConnectionString("VideotekaConnection");

            // Konfigurace SQLite datab�ze
            builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlite(connectionString));

            //  P�id�n� slu�eb do kontejneru - MVC (Controller, View, Model)
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Vytvo�en� datab�ze p�i startu aplikace
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<VideotekaContext>();
                context.Database.EnsureCreated();
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
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Films}/{action=Index}/{id?}");

            app.Run();  // Spu�t�n� aplikace
        }
    }
}
