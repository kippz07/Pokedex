using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex.Models
{
    public class PokeApiGetPokemon
    {
        private static ApplicationDbContext _context;

        public static async Task<List<Pokemon>> GetAsyncPokemonList()
        {
            return new List<Pokemon>
            {
                await GetAsyncPokemon(1),
                await GetAsyncPokemon(2),
                await GetAsyncPokemon(3),
                await GetAsyncPokemon(4),
                await GetAsyncPokemon(5)
            };
        }

        public static async Task<Pokemon> GetAsyncPokemon(int pokemonId)
        {
            _context = new ApplicationDbContext();

            var result = await PokeAPI.DataFetcher.GetApiObject<PokeAPI.Pokemon>(pokemonId);

            var pokemon = new Pokemon()
            {
                PokemonId = result.ID,
                Name = result.Name,
                IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == result.ID) != null ? true : false
            };

            return pokemon;
        }
    }
}