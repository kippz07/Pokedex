using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Pokedex.Models;
using System.Web.Mvc;

namespace Pokedex.Models
{
    public class PokeApiGetPokemon
    {
        private static ApplicationDbContext _context;

        public static async Task<List<Pokemon>> GetAsyncPokemonList(int page)
        {
            page *= 5;
            return new List<Pokemon>
            {
                await GetAsyncPokemon(page + 1),
                await GetAsyncPokemon(page + 2),
                await GetAsyncPokemon(page + 3),
                await GetAsyncPokemon(page + 4),
                await GetAsyncPokemon(page + 5)
            };
        }

        public static async Task<Pokemon> GetAsyncPokemon(int pokemonId)
        {
            _context = new ApplicationDbContext();

            var result = await PokeAPI.DataFetcher.GetApiObject<PokeAPI.Pokemon>(pokemonId);

            var pokemon = new Pokemon()
            {
                PokemonId = result.ID,
                Name = char.ToUpper(result.Name[0]) + result.Name.Substring(1),
                IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == result.ID) != null ? true : false
            };

            return pokemon;
        }
    }
}