using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Pokedex.ViewModels;

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

        //[OutputCache(Duration = 3600, VaryByParam = "id")]
        public async Task<ActionResult> Edit(int id)
        {
            var entry = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == id);
            var pokemon = await PokeApiGetPokemon.GetPokemonAsync(id);

            if (pokemon == null)
                return HttpNotFound();

            if (entry == null)
                return HttpNotFound();

            var viewModel = new EntryEditViewModel()
            {
                Pokemon = pokemon,
                Entry = entry
            };

            return View(viewModel);
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