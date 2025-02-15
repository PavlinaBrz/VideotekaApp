using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Models;
using VideotekaApp.Data;

/*Soubor obsahuje kontroler pro správu filmù. Kontroler je tøída, která zpracovává poadavky uivatele a reaguje na nì.
 * Kontroler je souèástí architektury MVC (Model-View-Controller) a zpracovává poadavky uivatele, zpracovává data a vrací vısledky.
 * Kontroler je odvozen z tøídy Controller, která je souèástí ASP.NET Core MVC.
 */

namespace VideotekaApp.Controllers.Films;

public class FilmsController : Controller  // Tøída FilmsController odvozená z Controller
{
    private readonly VideotekaContext _context;  // Pole _context je soukromé a obsahuje instanci tøídy VideotekaContext

    public FilmsController(VideotekaContext context)  // Konstruktor tøídy FilmsController
    {
        _context = context;  // Pole _context je inicializováno hodnotou parametru context
    }

    // GET : Films
    public async Task<IActionResult> Index()  /* IActionResults je rozhraní, které je implementováno všemi vısledky akcí v ASP.NET Core MVC
                                               * Metoda Index vrací všechny filmy z databáze a zobrazí je v pohledu Index.cshtml
                                               */
    {
        var films = await _context.Films.ToListAsync();
        return View(films);  // Metoda View vytvoøí pohled a pøedá mu data
    }

    // GET: Films/Create - Metoda Create zobrazí formuláø pro vytvoøení nového filmu
    public IActionResult Create()  // Metoda Create vytvoøí prázdnı formuláø pro vytvoøení nového filmu a uloí záznam do databáze - vrací pohled Create.cshtml
    {
        return View();
    }

    // POST: Films/Create
    [HttpPost]  // Atribut HttpPost zajišuje, e metoda bude reagovat pouze na HTTP POST poadavky
    [ValidateAntiForgeryToken]  // Atribut ValidateAntiForgeryToken zajišuje, e poadavek obsahuje platnı token
    public async Task<IActionResult> Create([Bind("ID,Title,ReleaseYear,Genre,Rating")] Film film)  // Metoda Create pøijímá data z formuláøe a ukládá je do databáze
    {
        if (ModelState.IsValid)
        {
            _context.Add(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(film);
    }

    // GET: Films/Edit/5
    public async Task<IActionResult> Edit(int? id)  // Metoda Edit zobrazí formuláø pro úpravu filmu
    {
        if (id == null)
        {
            return NotFound();
        }
        var film = await _context.Films.FindAsync(id);
        if (film == null)
        {
            return NotFound();
        }
        return View(film);
    }

    // POST: Films/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseYear,Genre,Rating")] Film film)  // Metoda Edit pøijímá data z formuláøe a ukládá je do databáze
    {
        if (id != film.ID)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(film);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // DbUpdateConcurrencyException je vyvolána, kdy je detekována soubìná zmìna
            {
                if (!_context.Films.Any(e => e.ID == film.ID)) // Metoda Any() vrátí hodnotu true, pokud se v kolekci nachází alespoò jeden prvek, kterı splòuje podmínku
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(film);
    }

    // GET: Films/Delete/5
    public async Task<IActionResult> Delete(int? id)  // Metoda Delete zobrazí formuláø pro smazání filmu
    {
        if (id == null)
        {
            return NotFound();
        }
        var film = await _context.Films.FirstOrDefaultAsync(m => m.ID == id); // Metoda FirstOrDefaultAsync() vrátí první prvek v kolekci nebo vıchozí hodnotu
        if (film == null)
        {
            return NotFound();
        }
        return View(film);
    }

    // POST: Films/Delete/5
    [HttpPost, ActionName("Delete")] // Atribut ActionName urèuje název akce, kterı se má pouít
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)  // Metoda DeleteConfirmed smae film z databáze
    {
        var film = await _context.Films.FindAsync(id); // Metoda FindAsync() vyhledá záznam v databázi podle ID
        if (film != null)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
