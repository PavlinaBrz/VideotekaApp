using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideotekaApp.Data;
using VideotekaApp.Models;

namespace VideotekaApp.Pages.Films
{
    public class DeleteModel : PageModel
    {
        private readonly VideotekaContext _context;

        public DeleteModel(VideotekaContext context)
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
            if (Film == null)
            {
                return NotFound();
            }

            Film? filmToDelete = await _context.Films.FindAsync(Film.ID);

            if (filmToDelete != null)
            {
                _ = _context.Films.Remove(filmToDelete);
                _ = await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}