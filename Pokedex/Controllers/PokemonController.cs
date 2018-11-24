using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private ApplicationDbContext _context;

        public PokemonController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Pokemon
        public ActionResult Index()
        {
            var pokemon = GetPokemonList();

            return View(pokemon);
        }

        public ActionResult Details(int id)
        {
            var pokemon = GetPokemonList().SingleOrDefault(p => p.PokemonId == id);

            if (pokemon == null)
                return HttpNotFound();

            return View(pokemon);
        }

        [HttpPost]
        public ActionResult Add(Pokemon pokemon)
        {
            PokedexEntry entry = new PokedexEntry() { PokemonId = pokemon.PokemonId, Name = pokemon.Name };

            _context.PokedexEntry.Add(entry);
            _context.SaveChanges();

            return RedirectToAction("Index", "Pokemon");
        }

        public ActionResult Delete(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PokedexEntry entry = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == pokemon.PokemonId);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Pokemon pokemon)
        {
            var entry = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == pokemon.PokemonId);
            _context.PokedexEntry.Remove(entry);
            _context.SaveChanges();

            return RedirectToAction("Index", "Pokemon");
        }

        public IEnumerable<Pokemon> GetPokemonList()
        {
            return new List<Pokemon>
            {
                new Pokemon()
                {
                    PokemonId = 1,
                    Name = "Bulbsaur",
                    IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 1) != null ? true : false
                },
                new Pokemon()
                {
                    PokemonId = 2,
                    Name = "Charmander",
                    IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 2) != null ? true : false
                },
                new Pokemon()
                {
                    PokemonId = 3,
                    Name = "Squirtle",
                    IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 3) != null ? true : false
                }
            };
            
        }
    }
}