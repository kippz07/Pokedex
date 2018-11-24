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
            var pokemon = GetPokemonList().SingleOrDefault(p => p.Id == id);

            if (pokemon == null)
                return HttpNotFound();

            return View(pokemon);
        }

        [HttpPost]
        public ActionResult Add(Pokemon pokemon)
        {
            PokedexEntry entry = new PokedexEntry() { PokemonId = pokemon.Id, Name = pokemon.Name };

            _context.PokedexEntry.Add(entry);
            _context.SaveChanges();

            return RedirectToAction("Index", "Pokemon");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PokedexEntry entry = _context.PokedexEntry.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var entry = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 1);
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
                    Id = 1,
                    Name = "Bulbsaur",
                    IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 1) != null ? true : false
                },
                new Pokemon()
                {
                    Id = 2,
                    Name = "Charmander",
                    IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 2) != null ? true : false
                },
                new Pokemon()
                {
                    Id = 3,
                    Name = "Squirtle",
                    IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == 3) != null ? true : false
                }
            };
            
        }
    }
}