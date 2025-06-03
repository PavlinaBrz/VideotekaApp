using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;
using VideotekaApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideotekaApp.Pages.Films
{
    public class StatisticsModel : PageModel
    {
        private readonly VideotekaContext _context;

        public StatisticsModel(VideotekaContext context)
        {
            _context = context;
        }

        public int TotalCount { get; set; }
        public double AverageRating { get; set; }
        public Film? LatestFilm { get; set; }
        public List<GenreCount> FilmsByGenre { get; set; } = new();

        public class GenreCount
        {
            public string Genre { get; set; } = string.Empty;
            public int Count { get; set; }
        }

        public async Task OnGetAsync()
        {
            var films = await _context.Films.AsNoTracking().ToListAsync();

            TotalCount = films.Count;
            AverageRating = films.Count > 0 ? films.Average(f => f.Rating) : 0;
            LatestFilm = films.OrderByDescending(f => f.ReleaseYear).FirstOrDefault();

            FilmsByGenre = films
                .GroupBy(f => f.Genre)
                .Select(g => new GenreCount
                {
                    Genre = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ToList();
        }
    }
}