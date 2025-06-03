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
        public List<Film> TopRatedFilms { get; set; } = new();

        // Nové vlastnosti pro graf:
        public List<string> Genres { get; set; } = new();
        public List<int> Years { get; set; } = new();
        public List<GenreYearRating> RatingsByGenreYear { get; set; } = new();
        public List<GenreYearFilm> FilmsByGenreYear { get; set; } = new();

        public class GenreCount
        {
            public string Genre { get; set; } = string.Empty;
            public int Count { get; set; }
        }

        // Nová tøída pro graf:
        public class GenreYearRating
        {
            public string Genre { get; set; } = string.Empty;
            public int Year { get; set; }
            public double AverageRating { get; set; }
        }

        // Nová tøída pro mapování žánr + rok na film
        public class GenreYearFilm
        {
            public string Genre { get; set; } = string.Empty;
            public int Year { get; set; }
            public string Title { get; set; } = string.Empty;
            public double AverageRating { get; set; }
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

            TopRatedFilms = films.OrderByDescending(f => f.Rating).ThenByDescending(f => f.ReleaseYear).Take(3).ToList();

            // Pøidej toto pro graf:
            Genres = films.Select(f => f.Genre).Distinct().OrderBy(g => g).ToList();
            Years = films.Select(f => f.ReleaseYear).Distinct().OrderBy(y => y).ToList();
            RatingsByGenreYear = films
                .GroupBy(f => new { f.Genre, f.ReleaseYear })
                .Select(g => new GenreYearRating
                {
                    Genre = g.Key.Genre,
                    Year = g.Key.ReleaseYear,
                    AverageRating = g.Average(f => f.Rating)
                })
                .ToList();

            //Mapování žánr + rok na film
            FilmsByGenreYear = films
                .GroupBy(f => new { f.Genre, f.ReleaseYear })
                .Select(g => new GenreYearFilm
                {
                    Genre = g.Key.Genre,
                    Year = g.Key.ReleaseYear,
                    Title = g.OrderByDescending(f => f.Rating).First().Title, // vezme název filmu s nejvyšším hodnocením v daném žánru a roce
                    AverageRating = g.Average(f => f.Rating)
                })
                .ToList();
        }
    }
}