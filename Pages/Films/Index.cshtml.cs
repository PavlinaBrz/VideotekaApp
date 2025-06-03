using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;
using VideotekaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task OnGetAsync(int pageIndex = 1, int pageSize = 10)
        {
            var totalCount = await _context.Films.CountAsync();
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            CurrentPage = pageIndex;

            Films = await _context.Films
                .OrderBy(f => f.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}