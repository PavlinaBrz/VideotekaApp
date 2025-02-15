using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotekaApp.Models;
using VideotekaApp.Data;

/*Soubor obsahuje kontroler pro spr�vu film�. Kontroler je t��da, kter� zpracov�v� po�adavky u�ivatele a reaguje na n�.
 * Kontroler je sou��st� architektury MVC (Model-View-Controller) a zpracov�v� po�adavky u�ivatele, zpracov�v� data a vrac� v�sledky.
 * Kontroler je odvozen z t��dy Controller, kter� je sou��st� ASP.NET Core MVC.
 */

namespace VideotekaApp.Controllers.Films;

public class FilmsController : Controller  // T��da FilmsController odvozen� z Controller
{
    private readonly VideotekaContext _context;  // Pole _context je soukrom� a obsahuje instanci t��dy VideotekaContext

    public FilmsController(VideotekaContext context)  // Konstruktor t��dy FilmsController
    {
        _context = context;  // Pole _context je inicializov�no hodnotou parametru context
    }

    // GET : Films
    public async Task<IActionResult> Index()  /* IActionResults je rozhran�, kter� je implementov�no v�emi v�sledky akc� v ASP.NET Core MVC
                                               * Metoda Index vrac� v�echny filmy z datab�ze a zobraz� je v pohledu Index.cshtml
                                               */
    {
        var films = await _context.Films.ToListAsync();
        return View(films);  // Metoda View vytvo�� pohled a p�ed� mu data
    }

    // GET: Films/Create - Metoda Create zobraz� formul�� pro vytvo�en� nov�ho filmu
    public IActionResult Create()  // Metoda Create vytvo�� pr�zdn� formul�� pro vytvo�en� nov�ho filmu a ulo�� z�znam do datab�ze - vrac� pohled Create.cshtml
    {
        return View();
    }

    // POST: Films/Create
    [HttpPost]  // Atribut HttpPost zaji��uje, �e metoda bude reagovat pouze na HTTP POST po�adavky
    [ValidateAntiForgeryToken]  // Atribut ValidateAntiForgeryToken zaji��uje, �e po�adavek obsahuje platn� token
    public async Task<IActionResult> Create([Bind("ID,Title,ReleaseYear,Genre,Rating")] Film film)  // Metoda Create p�ij�m� data z formul��e a ukl�d� je do datab�ze
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
    public async Task<IActionResult> Edit(int? id)  // Metoda Edit zobraz� formul�� pro �pravu filmu
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
    public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseYear,Genre,Rating")] Film film)  // Metoda Edit p�ij�m� data z formul��e a ukl�d� je do datab�ze
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
            catch (DbUpdateConcurrencyException) // DbUpdateConcurrencyException je vyvol�na, kdy� je detekov�na soub�n� zm�na
            {
                if (!_context.Films.Any(e => e.ID == film.ID)) // Metoda Any() vr�t� hodnotu true, pokud se v kolekci nach�z� alespo� jeden prvek, kter� spl�uje podm�nku
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
    public async Task<IActionResult> Delete(int? id)  // Metoda Delete zobraz� formul�� pro smaz�n� filmu
    {
        if (id == null)
        {
            return NotFound();
        }
        var film = await _context.Films.FirstOrDefaultAsync(m => m.ID == id); // Metoda FirstOrDefaultAsync() vr�t� prvn� prvek v kolekci nebo v�choz� hodnotu
        if (film == null)
        {
            return NotFound();
        }
        return View(film);
    }

    // POST: Films/Delete/5
    [HttpPost, ActionName("Delete")] // Atribut ActionName ur�uje n�zev akce, kter� se m� pou��t
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)  // Metoda DeleteConfirmed sma�e film z datab�ze
    {
        var film = await _context.Films.FindAsync(id); // Metoda FindAsync() vyhled� z�znam v datab�zi podle ID
        if (film != null)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
