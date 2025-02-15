using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using VideotekaApp.Data;

/* 
    Program.cs - soubor, který obsahuje vstupní bod aplikace. 
    Vytvoøíme zde instanci WebApplication, která obsahuje konfiguraci a služby aplikace.
    V metodì Main() se konfiguruje HTTP požadavek a spouští se aplikace.
*/

namespace VideotekaApp
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Vytvoøení instance WebApplication

            //  Pøidání služeb do kontejneru - MVC (Controller, View, Model)
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<VideotekaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VideotekaContext")));

            var app = builder.Build();

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
