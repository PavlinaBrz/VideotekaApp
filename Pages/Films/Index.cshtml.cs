using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;
using VideotekaApp.Models;

namespace VideotekaApp.Pages.Films
{
    public class IndexModel : PageModel
    {
        private readonly VideotekaContext _context;

        public IndexModel(VideotekaContext context)
        {
            _context = context;
        }

        public IList<Film> Films { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<string> AllGenres { get; set; } = new();
        public string? SelectedGenre { get; set; }

        public async Task OnGetAsync(int pageIndex = 1, int pageSize = 10, string? genre = null)
        {
            AllGenres = await _context.Films.Select(f => f.Genre).Distinct().OrderBy(g => g).ToListAsync();
            SelectedGenre = genre;

            int totalCount = await _context.Films.CountAsync();
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            CurrentPage = pageIndex;

            IQueryable<Film> query = _context.Films.AsQueryable();
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(f => f.Genre == genre);
            }

            Films = await query
                .OrderBy(f => f.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}