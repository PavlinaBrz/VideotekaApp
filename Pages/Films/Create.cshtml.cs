using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideotekaApp.Data;
using VideotekaApp.Models;
using System.Threading.Tasks;

namespace VideotekaApp.Pages.Films
{
    public class CreateModel : PageModel
    {
        private readonly VideotekaContext _context;

        public CreateModel(VideotekaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; } = default!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Pokud jsou ve formuláři chyby, stránka se znovu zobrazí s chybovými 
                return Page();
            }

            // Zde následuje logika pro uložení dat do databáze
            _context.Films.Add(Film);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}