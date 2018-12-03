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

        private static Dictionary<int, int> genList = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 151 },
            { 3, 251 },
            { 4, 386 },
            { 5, 493 },
            { 6, 649 },
            { 7, 721 }
        };

        public static async Task<IEnumerable<Pokemon>> GetGenerationListAsync(int gen, int page, int pageSize)
        {
            var result = await PokeAPI.DataFetcher.GetApiObject<PokeAPI.Generation>(gen);
            var speciesList = new List<Pokemon>();

            foreach (var species in result.Species)
            {
                // "http://pokeapi.co/api/v2/pokemon-species/2/"
                var id = Int32.Parse(species.Url.ToString().Split('/')[6]);
                var name = char.ToUpper(species.Name[0]) + species.Name.Substring(1);
                speciesList.Add(new Pokemon() { PokemonId = id, Name = name });
            }

            return speciesList.Where(p => ((p.PokemonId - genList[gen] > page * pageSize) && (p.PokemonId - genList[gen] <= page * pageSize + pageSize))).OrderBy(p => p.PokemonId);
        }

        public static async Task<Pokemon> GetPokemonAsync(int pokemonId)
        {
            _context = new ApplicationDbContext();

            var result = await PokeAPI.DataFetcher.GetApiObject<PokeAPI.Pokemon>(pokemonId);
            var moves = result.Moves;

            var pokemon = new Pokemon()
            {
                PokemonId = result.ID,
                Name = char.ToUpper(result.Name[0]) + result.Name.Substring(1),
                IsInPokedex = _context.PokedexEntry.SingleOrDefault(p => p.PokemonId == result.ID) != null ? true : false,
                Types = GetPokemonStats(result.Types),
                Moves = GetPokemonStats(result.Moves)
            };


            return pokemon;
        }

        public static List<Stat> GetPokemonStats(PokeAPI.PokemonTypeMap[] types)
        {
            var list = new List<Stat>();
            foreach (var type in types)
            {
                list.Add(new Stat { Name = char.ToUpper(type.Type.Name[0]) + type.Type.Name.Substring(1)});
            }
            return list;
        }

        public static List<Stat> GetPokemonStats(PokeAPI.PokemonMove[] moves)
        {
            var list = new List<Stat>();
            foreach (var move in moves)
            {
                var id = Int32.Parse(move.Move.Url.ToString().Split('/')[6]);
                var name = char.ToUpper(move.Move.Name[0]) + move.Move.Name.Substring(1);
                list.Add(new Stat { Id = id, Name = name });
            }
            return list;
        }
    }
}