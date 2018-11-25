using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokedex.Controllers
{
    public class PokedexEntryController : Controller
    {
        private ApplicationDbContext _context;

        public PokedexEntryController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: PokedexEntry
        public ActionResult Index()
        {
            var entries = _context.PokedexEntry.OrderBy(p => p.PokemonId).ToList();

            return View(entries);
        }

        public ActionResult Details(int id)
        {
            var entry = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == id);

            return View(entry);
        }

        public ActionResult Edit(int id)
        {
            var entry = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == id);

            if (entry == null)
                return HttpNotFound();

            return View(entry);
        }

        [HttpPost]
        public ActionResult Save(PokedexEntry entry)
        {
            if (entry.Id == 0)
                return HttpNotFound();

            var dbEntry = _context.PokedexEntry.Single(p => p.PokemonId == entry.Id);

            if (!String.IsNullOrWhiteSpace(entry.Nickname))
                dbEntry.Nickname = entry.Nickname;

            _context.SaveChanges();

            return RedirectToAction("Index", "PokedexEntry");
        }
    }
}