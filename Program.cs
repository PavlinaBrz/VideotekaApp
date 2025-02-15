using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using VideotekaApp.Data;

/* 
    Program.cs - soubor, kter� obsahuje vstupn� bod aplikace. 
    Vytvo��me zde instanci WebApplication, kter� obsahuje konfiguraci a slu�by aplikace.
    V metod� Main() se konfiguruje HTTP po�adavek a spou�t� se aplikace.
*/

namespace VideotekaApp
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Vytvo�en� instance WebApplication

            //  P�id�n� slu�eb do kontejneru - MVC (Controller, View, Model)
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VideotekaContext")));

            var app = builder.Build();

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
