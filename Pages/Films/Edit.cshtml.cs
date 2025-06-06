using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideotekaApp.Data;
using VideotekaApp.Models;

namespace VideotekaApp.Pages.Films
{
    public class EditModel : PageModel
    {
        private readonly VideotekaContext _context;

        public EditModel(VideotekaContext context)
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
            // ... další žánry
        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Film = new Film(); // Nový film (vytváření)
            }
            else
            {
                Film = await _context.Films.FindAsync(id);
                if (Film == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Film? filmToUpdate = await _context.Films.FindAsync(Film.ID);
            if (filmToUpdate == null)
            {
                return NotFound();
            }

            // aktualizace hodnot
            filmToUpdate.Title = Film.Title;
            filmToUpdate.ReleaseYear = Film.ReleaseYear;
            filmToUpdate.Genre = Film.Genre;
            filmToUpdate.Rating = Film.Rating;

            _ = await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}