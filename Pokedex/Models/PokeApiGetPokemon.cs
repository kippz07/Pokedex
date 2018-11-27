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

        public static async Task<IEnumerable<Pokemon>> GetGenerationListAsync(int gen)
        {
            var result = await PokeAPI.DataFetcher.GetApiObject<PokeAPI.Generation>(1);
            var speciesList = new List<Pokemon>();
            foreach (var species in result.Species)
            {
                // "http://pokeapi.co/api/v2/pokemon-species/2/"
                var id = Int32.Parse(species.Url.ToString().Split('/')[6]);
                var name = char.ToUpper(species.Name[0]) + species.Name.Substring(1);
                speciesList.Add(new Pokemon() { PokemonId = 1, Name = species.Name });
            }
            return speciesList;
        }

        public static async Task<Pokemon> GetAsyncPokemon(int pokemonId)
        {
            _context = new ApplicationDbContext();

            var result = await PokeAPI.DataFetcher.GetApiObject<PokeAPI.Pokemon>(pokemonId);
            
            var pokemon = new Pokemon()
            {
                PokemonId = result.ID,
                Name = char.ToUpper(result.Name[0]) + result.Name.Substring(1),
                IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == result.ID) != null ? true : false,
                Types = GetPokemonTypes(result.Types)
            };


            return pokemon;
        }

        public static List<Stat> GetPokemonTypes(PokeAPI.PokemonTypeMap[] types)
        {
            var list = new List<Stat>();
            foreach (var type in types)
            {
                list.Add(new Stat { Name = char.ToUpper(type.Type.Name[0]) + type.Type.Name.Substring(1)});
            }
            return list;
        }
    }
}