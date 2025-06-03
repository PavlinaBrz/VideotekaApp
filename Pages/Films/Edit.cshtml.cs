using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;
using VideotekaApp.Models;
using System.Threading.Tasks;

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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Film = await _context.Films.FindAsync(id);

            if (Film == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var filmToUpdate = await _context.Films.FindAsync(Film.ID);
            if (filmToUpdate == null)
            {
                return NotFound();
            }

            // aktualizace hodnot
            filmToUpdate.Title = Film.Title;
            filmToUpdate.ReleaseYear = Film.ReleaseYear;
            filmToUpdate.Genre = Film.Genre;
            filmToUpdate.Rating = Film.Rating;

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}