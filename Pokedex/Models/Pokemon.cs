using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int PokemonId { get; set; }
        public string Name { get; set; }
        public bool IsInPokedex { get; set; }
        public List<Stat> Types { get; set; }
        public List<Stat> Moves { get; set; }
    }
}