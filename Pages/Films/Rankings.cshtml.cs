using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Data;
using VideotekaApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideotekaApp.Pages.Films
{
    public class RankingsModel : PageModel
    {
        private readonly VideotekaContext _context;

        public RankingsModel(VideotekaContext context)
        {
            _context = context;
        }

        public List<UserRanking> UserRankings { get; set; } = new();
        public List<Film> AvailableFilms { get; set; } = new();

        public Dictionary<int, int> Positions { get; set; } = new();

        public async Task OnGetAsync()
        {
            string userID = "demo"; // Zde použít aktuálního uživatele
            UserRankings = await _context.UserRankings
                .Include(r => r.Film)
                .Where(r => r.UserID == userID)
                .OrderBy(r => r.Position)
                .ToListAsync();

            var rankedFilmIDs = UserRankings.Select(r => r.FilmID).ToList();
            AvailableFilms = await _context.Films
                .Where(f => !rankedFilmIDs.Contains(f.ID))
                .OrderBy(f => f.Title)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            string userID = "demo";
            if (int.TryParse(Request.Form["addFilmID"], out int addFilmID))
            {
                int maxPos = await _context.UserRankings
                    .Where(r => r.UserID == userID)
                    .Select(r => (int?)r.Position)
                    .MaxAsync() ?? 0;

                var newRanking = new UserRanking
                {
                    UserID = userID,
                    FilmID = addFilmID,
                    Position = maxPos + 1
                };
                _context.UserRankings.Add(newRanking);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSaveOrderAsync([FromForm] Dictionary<int, int> positions)
        {
            string userID = "demo";
            var rankings = await _context.UserRankings
                .Where(r => r.UserID == userID)
                .ToListAsync();

            foreach (var ranking in rankings)
            {
                if (positions.TryGetValue(ranking.FilmID, out int newPos))
                {
                    ranking.Position = newPos;
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int filmId)
        {
            string userID = "demo";
            var ranking = await _context.UserRankings
                .FirstOrDefaultAsync(r => r.UserID == userID && r.FilmID == filmId);

            if (ranking != null)
            {
                _context.UserRankings.Remove(ranking);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }

}