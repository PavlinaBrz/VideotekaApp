using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideotekaApp.Data;
using VideotekaApp.Models;

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

        public List<SelectListItem> GenreList { get; set; } = new()
        {
            new SelectListItem { Value = "Akční", Text = "Akční" },
            new SelectListItem { Value = "Komedie", Text = "Komedie" },
            new SelectListItem { Value = "Drama", Text = "Drama" },
            new SelectListItem { Value = "Horor", Text = "Horor" },
            new SelectListItem { Value = "Animovaný", Text = "Animovaný" },
            new SelectListItem { Value = "Dokument", Text = "Dokument"},
            new SelectListItem { Value = "Sci-fi", Text = "Sci-fi"},
            // ... další žánry
        };

        public void OnGet()
        {
            Film = new Film();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Pokud jsou ve formuláři chyby, stránka se znovu zobrazí s chybovými 
                return Page();
            }

            // Zde následuje logika pro uložení dat do databáze
            Film.ReleaseYear = Film.ReleaseYear;
            _ = _context.Films.Add(Film);
            _ = await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}