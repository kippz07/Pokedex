using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using Pokedex.Models;
using Pokedex.ViewModels;
using System.Web.UI;

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
        [OutputCache(CacheProfile = "Cache1Hour")]
        public async Task<ActionResult> Index(int gen = 1, int page = 0)
        {
            var pageSize = 10;
            var pokemon = await PokeApiGetPokemon.GetGenerationListAsync(gen, page, pageSize);

            var viewModel = new PokemonIndexViewModel()
            {
                Pokemon = pokemon,
                Gen = gen,
                Page = page,
                PageSize = pageSize
            };

            return View(viewModel);
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public async Task<ActionResult> Details(int id)
        {
            var pokemon = await PokeApiGetPokemon.GetPokemonAsync(id);

            if (pokemon == null)
                return HttpNotFound();

            return View(pokemon);
        }

        [HttpPost]
        public ActionResult Add(Pokemon pokemon)
        {
            PokedexEntry entry = new PokedexEntry() { PokemonId = pokemon.PokemonId, Name = pokemon.Name };

            if (!String.IsNullOrWhiteSpace(entry.Type1))
                entry.Type1 = entry.Type1;

            if (!String.IsNullOrWhiteSpace(entry.Type2))
                entry.Type2 = entry.Type2;

            _context.PokedexEntry.Add(entry);
            _context.SaveChanges();

            HttpResponse.RemoveOutputCacheItem("/");
            HttpResponse.RemoveOutputCacheItem(Url.Action("Details", "Pokemon", new { id = pokemon.PokemonId }));

            return RedirectToAction("Edit", "PokedexEntry", new { id = pokemon.PokemonId });
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

            HttpResponse.RemoveOutputCacheItem("/");
            HttpResponse.RemoveOutputCacheItem(Url.Action("Details", "Pokemon", new { id = pokemon.PokemonId }));

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